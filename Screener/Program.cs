/* Author: Luke Familo */
using System.Windows.Forms;

namespace Screener
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    private static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScreenerForm());
        }
    }
}
