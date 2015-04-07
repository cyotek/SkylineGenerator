using System;
using System.Windows.Forms;
using Cyotek.SkylineGenerator;

namespace SkylineGenerator
{
  internal static class Program
  {
    #region Static Methods

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }

    #endregion
  }
}
