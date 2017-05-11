using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_Image_Processor
{
    public partial class FormMain : Form
    {

        #region Initialization

        /// <summary>
        /// Constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The name of this software
        /// </summary>
        public const string NAME = "Batch Image Processor v1.1 by jspenguin2017";

        /// <summary>
        /// Form Load event handler
        /// Initialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            //Set form title
            this.Text = NAME;
            //Set about text
            LinkLabelAbout.Text = NAME + " - Click to enter project page";
            //Set default output format
            ComboBoxOutFormat.SelectedIndex = 3;
            //Initialize file save dialogue
            SaveFileDialogMain.Filter = "Bitmap|*.bmp|Graphics Interchange Format|*.gif|Joint Photographic Experts Group|*.jpg|W3C Portable Network Graphics|*.png|Tagged Image File Format|*.tiff|All Files|*.*";
        }

        #endregion

        #region UI Logic

        /// <summary>
        /// Input directory browse button click or input directory textbox double click handler
        /// Show browse dialogue for input directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDirIn_Click(object sender, EventArgs e)
        {
            IOLib.ChooseDir(TBDirIn, FolderBrowserDialogMain);
        }

        /// <summary>
        /// Output directory browse button click or output directory textbox double click handler
        /// Show browse dialogue for output directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDirOut_Click(object sender, EventArgs e)
        {
            IOLib.ChooseDir(TBDirOut, FolderBrowserDialogMain);
        }

        /// <summary>
        /// Limit image resolution checkbox state change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBLimRes_CheckedChanged(object sender, EventArgs e)
        {
            TBResizeWidth.Enabled = CBResize.Checked;
            TBResizeHeight.Enabled = CBResize.Checked;
            CBNoUpscale.Enabled = CBResize.Checked;
        }

        /// <summary>
        /// Keep original file name checkbox state change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBKeepFileName_CheckedChanged(object sender, EventArgs e)
        {
            TBRenamePrefix.Enabled = !CBKeepFileName.Checked;
            TBRenameSuffix.Enabled = !CBKeepFileName.Checked;
        }

        /// <summary>
        /// Log textbox focus enter (only for Tab key) handler
        /// Select all text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBLog_Enter(object sender, EventArgs e)
        {
            TBLog.SelectAll();
        }

        /// <summary>
        /// Log textbox text change handler
        /// Reset group box title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBLog_TextChanged(object sender, EventArgs e)
        {
            GroupBoxLog.Text = "Log (Double Click to Copy)";
        }

        /// <summary>
        /// Log textbox double click handler
        /// Copy all text to clipboard when log textbox is double clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBLog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (TBLog.Text != "")
            {
                try
                {
                    Clipboard.SetText(TBLog.Text);
                    GroupBoxLog.Text = "Log (Copied)";
                }
                catch (Exception err) when (err is ExternalException || err is ThreadStateException)
                {
                    MessageBox.Show("Failed to copy log to clipboard. ");
                }
            }
        }

        /// <summary>
        /// About label click handler
        /// Send to project page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LinkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Use await here to prevent slow starting browser to stuck our software
            await Task.Run(() =>
            {
                Process.Start("https://github.com/jspenguin2017/BatchImageProcessor");
            });
        }

        #endregion

        #region Button Handlers

        /// <summary>
        /// Start button handler
        /// Start batch processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnStart_Click(object sender, EventArgs e)
        {
            //Lock UI
            GroupBoxConvert.Enabled = false;
            //Call core function
            await ProcessImages();
            //Unlock UI
            GroupBoxConvert.Enabled = true;
        }

        /// <summary>
        /// Create empty image button click hander
        /// Create an empty image and prompt the user to save the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnCreateEmptyImg_Click(object sender, EventArgs e)
        {
            int width;
            int height;
            //Parse width and height
            if (!ValidateDimensions(TBEmptyImgWidth, TBEmptyImgHeight, out width, out height))
            {
                return;
            }
            //Set file type
            SaveFileDialogMain.FilterIndex = ComboBoxOutFormat.SelectedIndex + 1;
            //Show dialogue
            if (SaveFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                //Lock UI
                GroupBoxCreateEmptyImg.Enabled = false;
                //OK clicked, save file
                bool success = await Task.Run(() =>
                {
                    return ImLib.ImEmpty(width, height, SaveFileDialogMain.FileName, IOLib.ParseFormat(SaveFileDialogMain.FilterIndex - 1), true);
                });
                //Launch directory if successful and checkbox checked
                if (success && CBLaunchWhenDone.Checked)
                {
                    await Task.Run(() =>
                    {
                        Process.Start(Path.GetDirectoryName(SaveFileDialogMain.FileName));
                    });
                }
                //Log
                PutLog((success ? "Created" : "ERROR: Failed to create") + " empty image of size " + width.ToString() + "x" + height.ToString() + " to " + SaveFileDialogMain.FileName);
                //Unlock UI
                GroupBoxCreateEmptyImg.Enabled = true;
            }
        }

        #endregion

        #region Helper Functions

        /// <summary>
        /// Write log into log textbox, a new line will be automatically added
        /// This method can be called from another thread
        /// </summary>
        /// <param name="msg">The message to write</param>
        private void PutLog(string msg)
        {
            if (TBLog.InvokeRequired)
            {
                Invoke((MethodInvoker)(() =>
                {
                    TBLog.Text += msg + Environment.NewLine;
                }));
            }
            else
            {
                TBLog.Text += msg + Environment.NewLine;
            }
        }

        /// <summary>
        /// Validate dimension inputs
        /// </summary>
        /// <param name="width">The width output variable</param>
        /// <param name="height">The height output varialbe</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        private bool ValidateDimensions(TextBox tbWidth, TextBox tbHeight, out int width, out int height)
        {
            if (!ImLib.ValidateDimension(tbWidth.Text, out width))
            {
                MessageBox.Show("The width entered is not valid. ");
                tbWidth.Focus();
                height = -1;
                return false;
            }
            if (!ImLib.ValidateDimension(tbHeight.Text, out height))
            {
                MessageBox.Show("The height entered is not valid. ");
                tbHeight.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region Core Code

        /// <summary>
        /// The core code of this software
        /// </summary>
        private async Task ProcessImages()
        {
            //Check input directory
            string dirIn = TBDirIn.Text;
            if (!Directory.Exists(dirIn))
            {
                MessageBox.Show("Input directory does not exist. ");
                TBDirIn.Focus();
                return;
            }
            //Check output directory
            string dirOut = TBDirOut.Text;
            if (!Directory.Exists(dirOut))
            {
                if (MessageBox.Show("Output directory does not exist, would you like to create it? ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool dirCreateResult = await Task.Run(() =>
                    {
                        try
                        {
                            Directory.CreateDirectory(dirOut);
                        }
                        catch (Exception err) when (err is IOException || err is UnauthorizedAccessException || err is ArgumentException || err is ArgumentNullException || err is PathTooLongException || err is DirectoryNotFoundException || err is NotSupportedException)
                        {
                            MessageBox.Show("Could not create output directory. ");
                            return false;
                        }
                        return true;
                    });
                    //Check if directory was successfully created
                    if (!dirCreateResult)
                    {
                        TBDirOut.Focus();
                        return;
                    }
                }
                else
                {
                    TBDirOut.Focus();
                    return;
                }
            }
            //Check resize dimensions
            bool resize = CBResize.Checked;
            bool noUpscale = CBNoUpscale.Checked;
            int width = -1;
            int height = -1;
            if (resize)
            {
                if (!ValidateDimensions(TBResizeWidth, TBResizeHeight, out width, out height))
                {
                    return;
                }
            }
            //Check file names
            bool keepFileName = CBKeepFileName.Checked;
            string fileNamePrefix = TBRenamePrefix.Text;
            string fileNameSuffix = TBRenameSuffix.Text;
            if (!keepFileName)
            {
                if (!IOLib.CheckFileName(fileNamePrefix))
                {
                    MessageBox.Show("File name prefix is not valid. ");
                    GroupBoxConvert.Enabled = true;
                    TBRenamePrefix.Focus();
                    return;
                }
                if (!IOLib.CheckFileName(fileNameSuffix))
                {
                    MessageBox.Show("File name suffix is not valid. ");
                    TBRenameSuffix.Focus();
                    GroupBoxConvert.Enabled = true;
                    return;
                }
            }
            //Get output format
            ImageFormat format = IOLib.ParseFormat(ComboBoxOutFormat.SelectedIndex);
            //Start processing
            int total = 0;
            int error = 0;
            await Task.Run(() =>
            {
                //Get potential files to process
                string[] files = Directory.GetFiles(dirIn);
                //Find files that are images
                List<string> validFiles = new List<string>();
                for (int i = 0; i < files.Length; i++)
                {
                    if (IOLib.FormatCanRead(Path.GetExtension(files[i])))
                    {
                        validFiles.Add(files[i]);
                    }
                }
                //Write file count
                Interlocked.Add(ref total, validFiles.Count);
                //Start processing each image
                Parallel.For(0, validFiles.Count, (i) =>
                {
                    //Load the image
                    Image img;
                    if (!ImLib.ImLoad(validFiles[i], out img, false))
                    {
                        PutLog("ERROR: Could not read " + validFiles[i]);
                        //Update counter
                        Interlocked.Add(ref error, 1);
                        return;
                    }
                    //Scale the image
                    Image scaledImg = new Bitmap(1, 1);
                    if (resize)
                    {
                        if (!ImLib.ImScale(img, width, height, "", out scaledImg, noUpscale, false))
                        {
                            PutLog("ERROR: Could not allocate memory to process " + validFiles[i]);
                            img.Dispose();
                            return;
                        }
                        else
                        {
                            img.Dispose();
                        }
                    }
                    //Find output file name
                    string outFile;
                    if (keepFileName)
                    {
                        outFile = Path.Combine(dirOut, Path.GetFileNameWithoutExtension(validFiles[i]) + IOLib.FormatToString(format));
                    }
                    else
                    {
                        outFile = Path.Combine(dirOut, fileNamePrefix + i.ToString() + fileNameSuffix + IOLib.FormatToString(format));
                    }
                    //Convert and write out
                    if (!ImLib.ImSave(resize ? scaledImg : img, outFile, format, false))
                    {
                        PutLog("ERROR: Could not write to " + outFile);
                    }
                    else
                    {
                        PutLog("Processed " + validFiles[i] + " and is saved to " + outFile);
                    }
                });
            });
            //Tell the user that we finished
            MessageBox.Show("Processing finished, successfully proccessed " + (total - error).ToString() + " images out of " + total.ToString() + ". Please check the log for more details. ");
            if (CBLaunchWhenDone.Checked)
            {
                await Task.Run(() =>
                {
                    Process.Start(dirOut);
                });
            }
        }

        #endregion

    }
}
