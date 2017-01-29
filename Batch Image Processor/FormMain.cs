using System;
using System.Diagnostics;
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
        public const string NAME = "Image Batch Processor v0.1 by X01X012013";

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
            IOLib.chooseDir(TBDirIn, FolderBrowserDialogMain);
        }

        /// <summary>
        /// Output directory browse button click or output directory textbox double click handler
        /// Show browse dialogue for output directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDirOut_Click(object sender, EventArgs e)
        {
            IOLib.chooseDir(TBDirOut, FolderBrowserDialogMain);
        }

        /// <summary>
        /// Limit image resolution checkbox state change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBLimRes_CheckedChanged(object sender, EventArgs e)
        {
            TBLimWidth.Enabled = CBLimRes.Checked;
            TBLimHeight.Enabled = CBLimRes.Checked;
        }

        /// <summary>
        /// Limit file size checkbox state change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBLimFileSize_CheckedChanged(object sender, EventArgs e)
        {
            TBLimFileSize.Enabled = CBLimFileSize.Checked;
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
                Process.Start("https://github.com/X01X012013/BatchImageProcessor");
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
            if (!validateDimensions(TBEmptyImgWidth, TBEmptyImgHeight, out width, out height))
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
                    return ImLib.ImEmpty(width, height, SaveFileDialogMain.FileName, IOLib.parseFormat(SaveFileDialogMain.FilterIndex - 1));
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
                putLog((success ? "Created" : "Failed to create") + " empty image of size " + width.ToString() + "x" + height.ToString() + " to " + SaveFileDialogMain.FileName);
                //Unlock UI
                GroupBoxCreateEmptyImg.Enabled = true;
            }
        }

        #endregion

        /// <summary>
        /// Write log into log textbox, a new line will be automatically added
        /// This method can be called from another thread
        /// </summary>
        /// <param name="msg">The message to write</param>
        private void putLog(string msg)
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
        private bool validateDimensions(TextBox tbWidth, TextBox tbHeight, out int width, out int height)
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

        #region Core Code

        /// <summary>
        /// The core code of this software
        /// </summary>
        private async Task ProcessImages()
        {
            //Check input directory
            if (!Directory.Exists(TBDirIn.Text))
            {
                MessageBox.Show("Input directory does not exist. ");
                TBDirIn.Focus();
                return;
            }
            //Check output directory
            if (!Directory.Exists(TBDirOut.Text))
            {
                if (MessageBox.Show("Output directory does not exist, would you like to create it? ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool dirCreateResult = await Task.Run(() =>
                    {
                        try
                        {
                            Directory.CreateDirectory(TBDirOut.Text);
                        }
                        catch (Exception err) when (err is IOException || err is UnauthorizedAccessException || err is ArgumentException || err is ArgumentNullException || err is PathTooLongException || err is DirectoryNotFoundException)
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
            int width;
            int height;
            if (CBLimRes.Checked)
            {
                if (!validateDimensions(TBLimWidth, TBLimHeight, out width, out height))
                {
                    return;
                }
            }
            //Check file names
            if (!CBKeepFileName.Checked)
            {
                if (!IOLib.checkFileName(TBRenamePrefix.Text))
                {
                    MessageBox.Show("File name prefix is not valid. ");
                    TBRenamePrefix.Focus();
                    return;
                }
                if (!IOLib.checkFileName(TBRenameSuffix.Text))
                {
                    MessageBox.Show("File name suffix is not valid. ");
                    TBRenameSuffix.Focus();
                    return;
                }
            }
            //Start processing
            await Task.Run(() =>
            {

            });
        }

        #endregion

    }
}
