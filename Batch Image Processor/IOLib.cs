using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Parse an index into ImageFormat
        /// </summary>
        /// <param name="format">The format index</param>
        /// <returns>Equivalent ImageFormat, defaults to PNG if something went wrong</returns>
        public static ImageFormat parseFormat(int format)
        {
            switch (format)
            {
                case 0:
                    return ImageFormat.Bmp;
                case 1:
                    return ImageFormat.Gif;
                case 2:
                    return ImageFormat.Jpeg;
                case 3:
                    return ImageFormat.Png;
                case 4:
                    return ImageFormat.Tiff;
                default:
                    //This should never happen
                    return ImageFormat.Png;
            }
        }

        /// <summary>
        /// Invalid file name chars as string
        /// </summary>
        public static string InvalidFileNameChars
        {
            get
            {
                return new string(Path.GetInvalidFileNameChars());
            }
        }

        /// <summary>
        /// Check if a string can be a file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>True if the file name is valid, false otherwise</returns>
        public static bool checkFileName(string fileName)
        {
            Regex fileNameValidator = new Regex("[" + Regex.Escape(InvalidFileNameChars) + "]");
            return !fileNameValidator.IsMatch(fileName);
        }
    }
}
