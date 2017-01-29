using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        /// The title of the main form
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
        /// Log textbox focus enter handler
        /// Select all text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBLog_Enter(object sender, EventArgs e)
        {
            TBLog.SelectAll();
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
            if (!ImLib.ValidateDimention(TBEmptyImgWidth.Text, out width))
            {
                MessageBox.Show("The width entered is not valid. ");
                TBEmptyImgWidth.Focus();
                return;
            }
            if (!ImLib.ValidateDimention(TBEmptyImgHeight.Text, out height))
            {
                MessageBox.Show("The height entered is not valid. ");
                TBEmptyImgHeight.Focus();
                return;
            }
            //Set file type
            SaveFileDialogMain.FilterIndex = ComboBoxOutFormat.SelectedIndex + 1;
            //Show dialogue
            if (SaveFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                //Lock UI while processing
                GroupBoxCreateEmptyImg.Enabled = false;
                //OK clicked, save file
                bool success = await ImLib.ImEmpty(width, height, SaveFileDialogMain.FileName, IOLib.parseFormat(SaveFileDialogMain.FilterIndex - 1));
                //Launch directory if successful and checkbox checked
                if (success && CBLaunchWhenDone.Checked)
                {
                    await Task.Run(() =>
                    {
                        Process.Start(Path.GetDirectoryName(SaveFileDialogMain.FileName));
                    });
                }
                //Log
                TBLog.Text += (success ? "Created" : "Failed to create") + " empty image of size " + width.ToString() + "x" + height.ToString() + " to " + SaveFileDialogMain.FileName + Environment.NewLine;
                //Unlock UI
                GroupBoxCreateEmptyImg.Enabled = true;
            }
        }

        #endregion

    }
}
