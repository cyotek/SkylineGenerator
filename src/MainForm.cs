using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Cyotek.SkylineGenerator
{
  public partial class MainForm : Form
  {
    #region Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Shown"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      this.LoadPresets();

      _simpleSkylineGenerator = new SimpleSkylineGenerator();
      _simpleSkylineGenerator.Generated += this.SimpleSkylineGeneratorGeneratedHandler;
      _simpleSkylineGenerator.SettingsChanged += this.SimpleSkylineGeneratorSettingsChangedHandler;

      propertyGrid.SelectedObject = _simpleSkylineGenerator.Settings;

      _simpleSkylineGenerator.Generate();

      previewImageBox.ZoomToFit();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.FormClosing"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.FormClosingEventArgs"/> that contains the event data. </param>
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      base.OnFormClosing(e);

      if (!e.Cancel)
      {
        _simpleSkylineGenerator.Generated -= this.SimpleSkylineGeneratorGeneratedHandler;
        _simpleSkylineGenerator.SettingsChanged -= this.SimpleSkylineGeneratorSettingsChangedHandler;
      }
    }

    private void SimpleSkylineGeneratorSettingsChangedHandler(object sender, EventArgs e)
    {
      propertyGrid.SelectedObject = _simpleSkylineGenerator.Settings;
    }

    private string PresetFolder
    {
      get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "presets"); }
    }

    private void LoadPresets()
    {
      presetToolStripComboBox.Items.Clear();

      foreach (string fileName in Directory.GetFiles(this.PresetFolder, "*.json"))
      {
        // ReSharper disable once AssignNullToNotNullAttribute
        presetToolStripComboBox.Items.Add(Path.GetFileNameWithoutExtension(fileName));
      }
    }

    private void actualSizeToolStripButton_Click(object sender, EventArgs e)
    {
      previewImageBox.ActualSize();
    }

    private Bitmap CloneBitmap(Image image, Color transparentColor)
    {
      Bitmap copy;

      copy = new Bitmap(image.Size.Width, image.Size.Height, PixelFormat.Format32bppArgb);

      using (Graphics g = Graphics.FromImage(copy))
      {
        g.Clear(transparentColor);
        g.PageUnit = GraphicsUnit.Pixel;
        g.DrawImage(image, new Rectangle(Point.Empty, image.Size));
      }

      return copy;
    }

    private void CopyImageToClipboard(Bitmap image)
    {
      IDataObject data;
      Bitmap opaqueBitmap;
      Bitmap transparentBitmap;
      MemoryStream transparentBitmapStream;

      // http://csharphelper.com/blog/2014/09/copy-an-irregular-area-from-one-picture-to-another-in-c/

      data = new DataObject();
      opaqueBitmap = null;
      transparentBitmap = null;
      transparentBitmapStream = null;

      try
      {
        opaqueBitmap = this.CloneBitmap(image, Color.White);
        transparentBitmap = this.CloneBitmap(image, Color.Transparent);

        transparentBitmapStream = new MemoryStream();
        transparentBitmap.Save(transparentBitmapStream, ImageFormat.Png);

        data.SetData(DataFormats.Bitmap, opaqueBitmap);
        data.SetData("PNG", false, transparentBitmapStream);

        Clipboard.Clear();
        Clipboard.SetDataObject(data, true);
      }
      finally
      {
        if (opaqueBitmap != null)
        {
          opaqueBitmap.Dispose();
        }

        if (transparentBitmapStream != null)
        {
          transparentBitmapStream.Dispose();
        }

        if (transparentBitmap != null)
        {
          transparentBitmap.Dispose();
        }
      }
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this.CopyImageToClipboard(_simpleSkylineGenerator.Image);
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to copy image. {0}", ex.GetBaseException().Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void ExportImage(Bitmap bitmap, string fileName)
    {
      try
      {
        bitmap.Save(fileName, ImageFormat.Png);
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to export image. {0}", ex.GetBaseException().Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private SimpleSkylineGenerator _simpleSkylineGenerator;

    private void generateToolStripButton_Click(object sender, EventArgs e)
    {
      _simpleSkylineGenerator.Generate();
    }

    private void exportImageToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (SaveFileDialog dialog = new SaveFileDialog
                                     {
                                       Title = "Save Image As",
                                       Filter = "PNG Files (*.png)|*.png|All Files (*.*)|*.*",
                                       DefaultExt = "png"
                                     })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          this.ExportImage(_simpleSkylineGenerator.Image, dialog.FileName);
        }
      }
    }

    private void SimpleSkylineGeneratorGeneratedHandler(object sender, EventArgs e)
    {
      previewImageBox.Image = _simpleSkylineGenerator.Image;
      seedToolStripStatusLabel.Text = string.Concat("Seed: ", _simpleSkylineGenerator.ActualSeed.ToString());
    }

    private void sizeToFitToolStripButton_Click(object sender, EventArgs e)
    {
      previewImageBox.ZoomToFit();
    }

    #endregion

    private void presetToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LoadPreset(Path.Combine(this.PresetFolder, Path.ChangeExtension(presetToolStripComboBox.Text, ".json")));
    }

    private void LoadPreset(string fileName)
    {
      try
      {
        SimpleSkylineGeneratorSettings newSettings;

        newSettings = JsonConvert.DeserializeObject<SimpleSkylineGeneratorSettings>(File.ReadAllText(fileName), new SimpleSkylineGeneratorSettingsConverter());

        _simpleSkylineGenerator.Settings = newSettings;

        previewImageBox.ZoomToFit();

        propertyGrid.Refresh();
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to load preset. {0}", ex.GetBaseException().Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (AboutDialog dialog = new AboutDialog())
      {
        dialog.ShowDialog(this);
      }
    }

    private void savePresetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (SaveFileDialog dialog = new SaveFileDialog
                                     {
                                       Title = "Save Preset As",
                                       Filter = "Preset Files (*.json)|*.json|All Files (*.*)|*.*",
                                       DefaultExt = "json",
                                       InitialDirectory = this.PresetFolder
                                     })
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          this.SavePreset(_simpleSkylineGenerator.Settings, dialog.FileName);
        }
      }
    }

    private void SavePreset(SimpleSkylineGeneratorSettings settings, string fileName)
    {
      try
      {
        using (StreamWriter stream = File.CreateText(fileName))
        {
          JsonSerializer serializer;

          serializer = new JsonSerializer
                       {
                         Formatting = Formatting.Indented
                       };

          serializer.Serialize(stream, settings);

          this.LoadPresets();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to save preset. {0}", ex.GetBaseException().Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
  }
}
