using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyotek.SkylineGenerator
{
  internal sealed class SequenceBuilder : IEnumerable<Bitmap>, IDisposable
  {
    private readonly Bitmap _bitmap;
    private readonly int _stepCount;

    public SequenceBuilder(Bitmap bitmap, int stepCount)
    {
      _bitmap = bitmap;
      _stepCount = stepCount;
    }

    private Bitmap[] _images;
    private bool _disposedValue;

    public void Build()
    {
      int count;
      Bitmap frame;
      int x;
      int w;
      int h;

      this.CleanUp();

      w = _bitmap.Width;
      h = _bitmap.Height;

      count = _bitmap.Width / _stepCount;
      _images = new Bitmap[count];
      x = 0;

      for (int i = 0; i < count; i++)
      {
        frame = new Bitmap(w, h);

        using (Graphics g = Graphics.FromImage(frame))
        {
          g.DrawImage(_bitmap, new Rectangle(x, 0, w - x, h), new Rectangle(0, 0, w - x, h), GraphicsUnit.Pixel);

          if (x > 0)
          {
            g.DrawImage(_bitmap, new Rectangle(0, 0, x, h), new Rectangle(w - x, 0, x, h), GraphicsUnit.Pixel);
          }
        }

        _images[i] = frame;
        x += _stepCount;
      }
    }

    public Bitmap GetImage(int index)
    {
      return _images[index];
    }

    public IEnumerator<Bitmap> GetEnumerator()
    {
      return ((IEnumerable<Bitmap>)_images).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _images.GetEnumerator();
    }

    private void Dispose(bool disposing)
    {
      if (!_disposedValue)
      {
        if (disposing)
        {
          this.CleanUp();
        }

        _disposedValue = true;
      }
    }

    private void CleanUp()
    {
      if (_images != null)
      {
        for (int i = 0; i < _images.Length; i++)
        {
          _images[i].Dispose();
        }
        _images = null;
      }
    }

    public void Dispose()
    {
      this.Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    public int ImageCount
    {
      get { return _images.Length; }
    }
  }
}
