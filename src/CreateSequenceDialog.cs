using Cyotek.Demo;
using Cyotek.Demo.Windows.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Cyotek.SkylineGenerator
{
  internal partial class CreateSequenceDialog : BaseForm
  {
    #region Private Fields

    private readonly Bitmap _source;

    private SequenceBuilder _sequence;

    #endregion Private Fields

    #region Public Constructors

    public CreateSequenceDialog()
    {
      this.InitializeComponent();
    }

    public CreateSequenceDialog(Bitmap source)
      : this()
    {
      _source = source;

      stepSizeNumericUpDown.Maximum = source.Width;
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      nameTextBox.Text = DateTime.Now.ToString("yyyyMMdd");
      pathTextBox.Text = Environment.CurrentDirectory;

      this.RequestRefresh();
    }

    #endregion Protected Methods

    #region Private Methods

    private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      Tuple<Bitmap, int> options;
      SequenceBuilder builder;

      options = (Tuple<Bitmap, int>)e.Argument;

      builder = new SequenceBuilder(options.Item1, options.Item2);

      try
      {
        builder.Build();
        e.Result = builder;
      }
      catch
      {
        builder.Dispose();

        throw;
      }
    }

    private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      preview1ImageBox.Image = null;
      preview2ImageBox.Image = null;
      preview3ImageBox.Image = null;

      _sequence?.Dispose();

      hScrollBar.Enabled = false;

      if (e.Error != null)
      {
        MessageBox.Show(e.Error.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        _sequence = (SequenceBuilder)e.Result;

        hScrollBar.Maximum = _sequence.ImageCount + (hScrollBar.LargeChange - (hScrollBar.SmallChange + 1));
        hScrollBar.Value = 0;
        hScrollBar.Enabled = true;

        imageCountLabel.Text = string.Format("{0} images", _sequence.ImageCount);

        this.UpdatePreview();
      }

      this.SetControls(true);
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void HScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
      this.UpdatePreview();
    }

    private void HScrollBar_ValueChanged(object sender, EventArgs e)
    {
      this.UpdatePreview();
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      string name;
      string path;

      this.DialogResult = DialogResult.None;

      name = nameTextBox.Text;
      path = pathTextBox.Text;

      if (string.IsNullOrEmpty(name))
      {
        MessageBox.Show("Please enter the base name for the sequence.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (string.IsNullOrEmpty(path))
      {
        MessageBox.Show("Please enter or selected the output location where images will be saved.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (!Directory.Exists(path))
      {
        MessageBox.Show("The specified output path does not exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (_sequence == null || _sequence.ImageCount == 0)
      {
        MessageBox.Show("There are no images to export.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        try
        {
          string format;

          format = "D" + _sequence.ImageCount.ToString().Length;

          for (int i = 0; i < _sequence.ImageCount; i++)
          {
            string fileName;

            fileName = Path.Combine(path, name + (i + 1).ToString(format) + ".png");

            _sequence.GetImage(i).Save(fileName, ImageFormat.Png);
          }
          this.DialogResult = DialogResult.OK;
          this.Close();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void PathBrowseButton_Click(object sender, EventArgs e)
    {
      string folderName;

      folderName = FileDialogHelper.GetFolderName("Select &output folder:", pathTextBox.Text);

      if (!string.IsNullOrEmpty(folderName))
      {
        pathTextBox.Text = folderName;
      }
    }

    private void RequestRefresh()
    {
      if (!backgroundWorker.IsBusy)
      {
        this.SetControls(false);

        backgroundWorker.RunWorkerAsync(Tuple.Create(_source, (int)stepSizeNumericUpDown.Value));
      }
    }

    private void SetControls(bool enabled)
    {
      this.UseWaitCursor = !enabled;
      Cursor.Current = enabled ? Cursors.Default : Cursors.WaitCursor;

      settingsGroupBox.Enabled = enabled;
      previewGroupBox.Enabled = enabled;
      okButton.Enabled = enabled;
    }

    private void stepSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      this.RequestRefresh();
    }

    private void UpdatePreview()
    {
      if (_sequence?.ImageCount > 0)
      {
        int index;

        index = hScrollBar.Value;

        preview1ImageBox.Image = index > 0 ? _sequence.GetImage(index - 1) : null;
        preview2ImageBox.Image = _sequence.GetImage(index);
        preview3ImageBox.Image = index < _sequence.ImageCount - 1 ? _sequence.GetImage(index + 1) : null;
      }
    }

    #endregion Private Methods
  }
}
