using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Cyotek.SkylineGenerator
{
  public partial class MainForm : Form
  {
    #region Fields

    private IDictionary<string, SimpleSkylineGenerator> _presets;

    #endregion

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
      Type baseType;

      base.OnShown(e);

      _presets = new ConcurrentDictionary<string, SimpleSkylineGenerator>();
      baseType = typeof(SimpleSkylineGenerator);

      // ReSharper disable once LoopCanBePartlyConvertedToQuery
      foreach (Type type in this.GetType().Assembly.GetTypes())
      {
        if (!type.IsAbstract && baseType.IsAssignableFrom(type) && type != baseType)
        {
          this.AddPreset(type);
        }
      }

      simpleSkylineGenerator.Generate();

      previewImageBox.ZoomToFit();
    }

    private void AddPreset(Type type)
    {
      string name;

      name = type.Name;
      if (name.EndsWith("Preset"))
      {
        name = name.Substring(0, name.Length - 6);
      }

      if (name == "Default")
      {
        name = "(Default)";
      }

      _presets.Add(name, (SimpleSkylineGenerator)Activator.CreateInstance(type));

      presetToolStripComboBox.Items.Add(name);
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
        this.CopyImageToClipboard(simpleSkylineGenerator.Image);
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

    private void generateToolStripButton_Click(object sender, EventArgs e)
    {
      simpleSkylineGenerator.Generate();
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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
          this.ExportImage(simpleSkylineGenerator.Image, dialog.FileName);
        }
      }
    }

    private void simpleSkylineGenerator_Generated(object sender, EventArgs e)
    {
      previewImageBox.Image = simpleSkylineGenerator.Image;
    }

    private void sizeToFitToolStripButton_Click(object sender, EventArgs e)
    {
      previewImageBox.ZoomToFit();
    }

    #endregion

    private void presetToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      simpleSkylineGenerator.CopyFrom(_presets[presetToolStripComboBox.Text]);

      previewImageBox.ZoomToFit();

      propertyGrid.Refresh();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (AboutDialog dialog = new AboutDialog())
      {
        dialog.ShowDialog(this);
      }
    }
  }
}
