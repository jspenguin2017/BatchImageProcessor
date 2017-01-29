using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_Image_Processor
{
    static class ImLib
    {

        #region Helper Functions

        /// <summary>
        /// Save an image to a file, supports following formats: 
        /// 
        /// Bitmap (BMP, .bmp)
        /// Graphics Interchange Format (GIF, .gif)
        /// Joint Photographic Experts Group (JPEG, .jpg)
        /// W3C Portable Network Graphics (PNG, .png)
        /// Tagged Image File Format (TIFF, .tiff)
        /// </summary>
        /// <param name="img">Image to save</param>
        /// <param name="outFile">Path to write</param>
        /// <param name="format">Output format of the image</param>
        /// <param name="showErr">Set this argument to true to show error message to the user</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        public static bool ImSave(Image img, string outFile, ImageFormat format, bool showErr)
        {
            try
            {
                img.Save(outFile, format);
                return true;
            }
            catch (Exception err) when (err is ArgumentNullException || err is ExternalException)
            {
                if (showErr)
                {
                    MessageBox.Show("Failed to save image to " + outFile + Environment.NewLine + Environment.NewLine + "Error message: " + err.Message);
                }
                return false;
            }

        }

        /// <summary>
        /// Load an image from a file, supports following formats: 
        /// 
        /// Bitmap (BMP, .bmp)
        /// Graphics Interchange Format (GIF, .gif)
        /// Joint Photographic Experts Group (JPEG, .jpg)
        /// W3C Portable Network Graphics (PNG, .png)
        /// Tagged Image File Format (TIFF, .tiff)
        /// 
        /// Enhanced Metafile (EMF, .emf)
        /// Windows icon (ICON, .ico)
        /// Windows metafile (WMF, .wmf)
        /// </summary>
        /// <param name="path">Path to the file to load</param>
        /// <param name="img">The image read, will be 1x1 empty bitmap if the operation was not successful</param>
        /// <param name="showErr">Set this argument to true to show error message to the user</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        public static bool ImLoad(string path, out Image img, bool showErr)
        {

            try
            {
                img = Image.FromFile(path);
                return true;
            }
            catch (Exception err) when (err is OutOfMemoryException || err is FileNotFoundException || err is ArgumentException)
            {
                if (showErr)
                {
                    MessageBox.Show("Failed to load image from " + path + Environment.NewLine + Environment.NewLine + "Error message: " + err.Message);
                }
                img = new Bitmap(1, 1);
                return false;
            }

        }

        /// <summary>
        /// Scale image keeping ratio, the new image will fit into maxWidth x maxHeight area
        /// </summary>
        /// <param name="imIn">The input image</param>
        /// <param name="maxWidth">The maximum width of output image</param>
        /// <param name="maxHeight">The maximum height of output image</param>
        /// <param name="id">A string to identify the image, shown to the user if there is an error</param>
        /// <param name="img">The scaled image, will be 1x1 empty image if the operation was not successful</param>
        /// <param name="showErr">Set this argument to true to show error message to the user</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        public static bool ImScale(Image imIn, int maxWidth, int maxHeight, string id, out Image img, bool showErr)
        {
            //Find the ratio of old image to new image
            double ratioWidth = (double)maxWidth / imIn.Width;
            double ratioHeight = (double)maxHeight / imIn.Height;
            //Find which ratio to use
            double ratio = Math.Min(ratioWidth, ratioHeight);
            //Calculate new width and height
            int newWidth = (int)Math.Ceiling((imIn.Width * ratio));
            int newHeight = (int)Math.Ceiling((imIn.Height * ratio));
            //Allocate memory
            Bitmap newImage = new Bitmap(1, 1);
            try
            {
                newImage = new Bitmap(newWidth, newHeight);
            }
            catch (Exception err)
            {
                if (showErr)
                {
                    MessageBox.Show("Failed to allocate memeory while processing " + id + Environment.NewLine + Environment.NewLine + "Error message: " + err.Message);
                }
                img = newImage;
                return false;
            }
            //Scale image
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(imIn, 0, 0, newWidth, newHeight);
            }
            img = newImage;
            return true;

        }

        #endregion

        /// <summary>
        /// Create an empty image and save it to a file
        /// </summary>
        /// <param name="width">Width of the image</param>
        /// <param name="height">Height of the image</param>
        /// <param name="outPath">The output path</param>
        /// <param name="format">The format of the image</param>
        /// <param name="showErr">Set this argument to true to show error message to the user</param>
        /// <returns>True if operation was successful, false otherwise</returns>
        public static bool ImEmpty(int width, int height, string outPath, ImageFormat format, bool showErr)
        {
            //Create empty image
            Bitmap bmp = new Bitmap(1, 1);
            try
            {
                bmp = new Bitmap(width, height);
            }
            catch (Exception err)
            {
                if (showErr)
                {
                    MessageBox.Show("Failed to allocate memeory while creating empty image. " + Environment.NewLine + Environment.NewLine + "Error message: " + err.Message);
                }
                return false;
            }
            //Save the image
            return ImSave(bmp, outPath, format, showErr);
        }

        /// <summary>
        /// Parse a string into a dimension
        /// </summary>
        /// <param name="input">The dimension string</param>
        /// <param name="output">The output integer, will be -1 if parsing failed</param>
        /// <returns>True if succeed, false otherwise</returns>
        public static bool ValidateDimension(string input, out int output)
        {
            if (int.TryParse(input, out output))
            {
                //Parsed, check if it is positive
                if (output > 0)
                {
                    return true;
                }
                else
                {
                    output = -1;
                    return false;
                }
            }
            else
            {
                //Could not parse
                output = -1;
                return false;
            }
        }
    }
}
