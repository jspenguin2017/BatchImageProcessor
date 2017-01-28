using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_Image_Processor
{
    public partial class FormMain : Form
    {
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
        /// Update form title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = NAME;
        }

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
    }
}
