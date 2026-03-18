using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoRecycleBinCleaner.Src
{
    internal class BinCleaner
    {
        public static DateTime LastCleanupTime { get; private set; } = DateTime.MinValue;

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, uint dwFlags);

        const uint SHERB_NOCONFIRMATION = 0x00000001;
        const uint SHERB_NOPROGRESSUI = 0x00000002;
        const uint SHERB_NOSOUND = 0x00000004;

        public static void Clear()
        { 
            try
            {
                uint result = SHEmptyRecycleBin(IntPtr.Zero, null, SHERB_NOCONFIRMATION | SHERB_NOSOUND | SHERB_NOPROGRESSUI);

                if (result == 0)
                {
                    LastCleanupTime = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
