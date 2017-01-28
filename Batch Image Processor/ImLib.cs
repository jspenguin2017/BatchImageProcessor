using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_Image_Processor
{
    static class ImLib
    {
        /// <summary>
        /// Scale image keeping ratio, the new image will fit into maxWidth x maxHeight area
        /// </summary>
        /// <param name="imIn">The input image</param>
        /// <param name="maxWidth">The maximum width of output image</param>
        /// <param name="maxHeight">The maximum height of output image</param>
        /// <param name="id">A string to identify the image, shown to the user if there is an error</param>
        /// <returns></returns>
        public static Image ImScale(Image imIn, int maxWidth, int maxHeight, string id)
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
                MessageBox.Show("Failed to allocate memeory while processing " + id + Environment.NewLine + Environment.NewLine + "Error message: " + err.Message);
                return newImage;
            }
            //Scale image
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(imIn, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        /// <summary>
        /// Save an image to a file, supports following formats: 
        /// 
        /// Bitmap (BMP, .bmp)
        /// Enhanced Metafile (EMF, .emf)
        /// Exchangeable Image File (Exif, .exif)
        /// Graphics Interchange Format (GIF, .gif)
        /// Windows icon (ICON, .ico)
        /// Joint Photographic Experts Group (JPEG, .jpg)
        /// W3C Portable Network Graphics (PNG, .png)
        /// Tagged Image File Format (TIFF, .tiff)
        /// Windows metafile (WMF, .wmf)
        /// </summary>
        /// <param name="img"></param>
        /// <param name="outFile"></param>
        /// <param name="format"></param>
        public static void saveImage(Image img, string outFile, ImageFormat format)
        {
            try
            {
                img.Save(outFile, format);
            }
            catch (Exception err) when (err is ArgumentNullException || err is ExternalException)
            {
                MessageBox.Show("Failed to save image to " + outFile + Environment.NewLine + Environment.NewLine + "Error message: " + err.Message);
            }
        }
    }
}
