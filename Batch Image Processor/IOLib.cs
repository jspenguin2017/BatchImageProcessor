using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_Image_Processor
{
    static class IOLib
    {
        /// <summary>
        /// Show folder browser dialog and fill path into textbox if a folder is selected
        /// </summary>
        /// <param name="tb">The textbox to fill path into</param>
        /// <param name="dialog">A folder browser dialog</param>
        public static void chooseDir(TextBox tb, FolderBrowserDialog dialog)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tb.Text = dialog.SelectedPath;
            }
        }
    }
}
