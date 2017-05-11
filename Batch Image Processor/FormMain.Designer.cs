namespace Batch_Image_Processor
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelDirIn = new System.Windows.Forms.Label();
            this.TBDirIn = new System.Windows.Forms.TextBox();
            this.TBDirOut = new System.Windows.Forms.TextBox();
            this.LabelDirOut = new System.Windows.Forms.Label();
            this.BtnDirIn = new System.Windows.Forms.Button();
            this.BtnDirOut = new System.Windows.Forms.Button();
            this.FolderBrowserDialogMain = new System.Windows.Forms.FolderBrowserDialog();
            this.GroupBoxResize = new System.Windows.Forms.GroupBox();
            this.CBNoUpscale = new System.Windows.Forms.CheckBox();
            this.LabelLimHeight = new System.Windows.Forms.Label();
            this.LabelLimWidth = new System.Windows.Forms.Label();
            this.TBResizeHeight = new System.Windows.Forms.TextBox();
            this.TBResizeWidth = new System.Windows.Forms.TextBox();
            this.CBResize = new System.Windows.Forms.CheckBox();
            this.GroupBoxConvert = new System.Windows.Forms.GroupBox();
            this.CBLaunchWhenDone = new System.Windows.Forms.CheckBox();
            this.TBRenameSuffix = new System.Windows.Forms.TextBox();
            this.TBRenamePrefix = new System.Windows.Forms.TextBox();
            this.LabelRenameSuffix = new System.Windows.Forms.Label();
            this.LabelRenamePrefix = new System.Windows.Forms.Label();
            this.CBKeepFileName = new System.Windows.Forms.CheckBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.LabelOutFormat = new System.Windows.Forms.Label();
            this.ComboBoxOutFormat = new System.Windows.Forms.ComboBox();
            this.GroupBoxCreateEmptyImg = new System.Windows.Forms.GroupBox();
            this.BtnCreateEmptyImg = new System.Windows.Forms.Button();
            this.TBEmptyImgHeight = new System.Windows.Forms.TextBox();
            this.TBEmptyImgWidth = new System.Windows.Forms.TextBox();
            this.LabelEmptyImgHeight = new System.Windows.Forms.Label();
            this.LabelEmptyImgWidth = new System.Windows.Forms.Label();
            this.GroupBoxLog = new System.Windows.Forms.GroupBox();
            this.TBLog = new System.Windows.Forms.RichTextBox();
            this.LinkLabelAbout = new System.Windows.Forms.LinkLabel();
            this.SaveFileDialogMain = new System.Windows.Forms.SaveFileDialog();
            this.GroupBoxResize.SuspendLayout();
            this.GroupBoxConvert.SuspendLayout();
            this.GroupBoxCreateEmptyImg.SuspendLayout();
            this.GroupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelDirIn
            // 
            this.LabelDirIn.AutoSize = true;
            this.LabelDirIn.Location = new System.Drawing.Point(13, 16);
            this.LabelDirIn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelDirIn.Name = "LabelDirIn";
            this.LabelDirIn.Size = new System.Drawing.Size(143, 15);
            this.LabelDirIn.TabIndex = 0;
            this.LabelDirIn.Text = "Input Directory: ";
            // 
            // TBDirIn
            // 
            this.TBDirIn.Location = new System.Drawing.Point(178, 13);
            this.TBDirIn.Margin = new System.Windows.Forms.Padding(4);
            this.TBDirIn.Name = "TBDirIn";
            this.TBDirIn.Size = new System.Drawing.Size(741, 25);
            this.TBDirIn.TabIndex = 1;
            this.TBDirIn.DoubleClick += new System.EventHandler(this.BtnDirIn_Click);
            // 
            // TBDirOut
            // 
            this.TBDirOut.Location = new System.Drawing.Point(178, 46);
            this.TBDirOut.Margin = new System.Windows.Forms.Padding(4);
            this.TBDirOut.Name = "TBDirOut";
            this.TBDirOut.Size = new System.Drawing.Size(741, 25);
            this.TBDirOut.TabIndex = 3;
            this.TBDirOut.DoubleClick += new System.EventHandler(this.BtnDirOut_Click);
            // 
            // LabelDirOut
            // 
            this.LabelDirOut.AutoSize = true;
            this.LabelDirOut.Location = new System.Drawing.Point(13, 51);
            this.LabelDirOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelDirOut.Name = "LabelDirOut";
            this.LabelDirOut.Size = new System.Drawing.Size(151, 15);
            this.LabelDirOut.TabIndex = 3;
            this.LabelDirOut.Text = "Output Directory: ";
            // 
            // BtnDirIn
            // 
            this.BtnDirIn.Location = new System.Drawing.Point(927, 13);
            this.BtnDirIn.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDirIn.Name = "BtnDirIn";
            this.BtnDirIn.Size = new System.Drawing.Size(124, 26);
            this.BtnDirIn.TabIndex = 2;
            this.BtnDirIn.Text = "Browse...";
            this.BtnDirIn.UseVisualStyleBackColor = true;
            this.BtnDirIn.Click += new System.EventHandler(this.BtnDirIn_Click);
            // 
            // BtnDirOut
            // 
            this.BtnDirOut.Location = new System.Drawing.Point(927, 45);
            this.BtnDirOut.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDirOut.Name = "BtnDirOut";
            this.BtnDirOut.Size = new System.Drawing.Size(124, 26);
            this.BtnDirOut.TabIndex = 4;
            this.BtnDirOut.Text = "Browse...";
            this.BtnDirOut.UseVisualStyleBackColor = true;
            this.BtnDirOut.Click += new System.EventHandler(this.BtnDirOut_Click);
            // 
            // GroupBoxResize
            // 
            this.GroupBoxResize.Controls.Add(this.CBNoUpscale);
            this.GroupBoxResize.Controls.Add(this.LabelLimHeight);
            this.GroupBoxResize.Controls.Add(this.LabelLimWidth);
            this.GroupBoxResize.Controls.Add(this.TBResizeHeight);
            this.GroupBoxResize.Controls.Add(this.TBResizeWidth);
            this.GroupBoxResize.Controls.Add(this.CBResize);
            this.GroupBoxResize.Location = new System.Drawing.Point(17, 78);
            this.GroupBoxResize.Name = "GroupBoxResize";
            this.GroupBoxResize.Size = new System.Drawing.Size(395, 130);
            this.GroupBoxResize.TabIndex = 5;
            this.GroupBoxResize.TabStop = false;
            this.GroupBoxResize.Text = "Resize";
            // 
            // CBNoUpscale
            // 
            this.CBNoUpscale.AutoSize = true;
            this.CBNoUpscale.Checked = true;
            this.CBNoUpscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBNoUpscale.Location = new System.Drawing.Point(255, 24);
            this.CBNoUpscale.Name = "CBNoUpscale";
            this.CBNoUpscale.Size = new System.Drawing.Size(130, 19);
            this.CBNoUpscale.TabIndex = 1;
            this.CBNoUpscale.Text = "Don\'t Upscale";
            this.CBNoUpscale.UseVisualStyleBackColor = true;
            // 
            // LabelLimHeight
            // 
            this.LabelLimHeight.AutoSize = true;
            this.LabelLimHeight.Location = new System.Drawing.Point(6, 84);
            this.LabelLimHeight.Name = "LabelLimHeight";
            this.LabelLimHeight.Size = new System.Drawing.Size(199, 15);
            this.LabelLimHeight.TabIndex = 4;
            this.LabelLimHeight.Text = "Maximum Height (Pixel): ";
            // 
            // LabelLimWidth
            // 
            this.LabelLimWidth.AutoSize = true;
            this.LabelLimWidth.Location = new System.Drawing.Point(5, 53);
            this.LabelLimWidth.Name = "LabelLimWidth";
            this.LabelLimWidth.Size = new System.Drawing.Size(191, 15);
            this.LabelLimWidth.TabIndex = 3;
            this.LabelLimWidth.Text = "Maximum Width (Pixel): ";
            // 
            // TBResizeHeight
            // 
            this.TBResizeHeight.Location = new System.Drawing.Point(211, 81);
            this.TBResizeHeight.Name = "TBResizeHeight";
            this.TBResizeHeight.Size = new System.Drawing.Size(174, 25);
            this.TBResizeHeight.TabIndex = 3;
            this.TBResizeHeight.Text = "720";
            // 
            // TBResizeWidth
            // 
            this.TBResizeWidth.Location = new System.Drawing.Point(211, 50);
            this.TBResizeWidth.Name = "TBResizeWidth";
            this.TBResizeWidth.Size = new System.Drawing.Size(174, 25);
            this.TBResizeWidth.TabIndex = 2;
            this.TBResizeWidth.Text = "1280";
            // 
            // CBResize
            // 
            this.CBResize.AutoSize = true;
            this.CBResize.Checked = true;
            this.CBResize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBResize.Location = new System.Drawing.Point(8, 25);
            this.CBResize.Name = "CBResize";
            this.CBResize.Size = new System.Drawing.Size(138, 19);
            this.CBResize.TabIndex = 0;
            this.CBResize.Text = "Resize to Fit:";
            this.CBResize.UseVisualStyleBackColor = true;
            this.CBResize.CheckedChanged += new System.EventHandler(this.CBLimRes_CheckedChanged);
            // 
            // GroupBoxConvert
            // 
            this.GroupBoxConvert.Controls.Add(this.CBLaunchWhenDone);
            this.GroupBoxConvert.Controls.Add(this.TBRenameSuffix);
            this.GroupBoxConvert.Controls.Add(this.TBRenamePrefix);
            this.GroupBoxConvert.Controls.Add(this.LabelRenameSuffix);
            this.GroupBoxConvert.Controls.Add(this.LabelRenamePrefix);
            this.GroupBoxConvert.Controls.Add(this.CBKeepFileName);
            this.GroupBoxConvert.Controls.Add(this.BtnStart);
            this.GroupBoxConvert.Controls.Add(this.LabelOutFormat);
            this.GroupBoxConvert.Controls.Add(this.ComboBoxOutFormat);
            this.GroupBoxConvert.Location = new System.Drawing.Point(418, 78);
            this.GroupBoxConvert.Name = "GroupBoxConvert";
            this.GroupBoxConvert.Size = new System.Drawing.Size(633, 227);
            this.GroupBoxConvert.TabIndex = 6;
            this.GroupBoxConvert.TabStop = false;
            this.GroupBoxConvert.Text = "Convert and Output";
            // 
            // CBLaunchWhenDone
            // 
            this.CBLaunchWhenDone.AutoSize = true;
            this.CBLaunchWhenDone.Checked = true;
            this.CBLaunchWhenDone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBLaunchWhenDone.Location = new System.Drawing.Point(9, 144);
            this.CBLaunchWhenDone.Name = "CBLaunchWhenDone";
            this.CBLaunchWhenDone.Size = new System.Drawing.Size(234, 19);
            this.CBLaunchWhenDone.TabIndex = 5;
            this.CBLaunchWhenDone.Text = "Launch Directory When Done";
            this.CBLaunchWhenDone.UseVisualStyleBackColor = true;
            // 
            // TBRenameSuffix
            // 
            this.TBRenameSuffix.Enabled = false;
            this.TBRenameSuffix.Location = new System.Drawing.Point(86, 112);
            this.TBRenameSuffix.Name = "TBRenameSuffix";
            this.TBRenameSuffix.Size = new System.Drawing.Size(541, 25);
            this.TBRenameSuffix.TabIndex = 4;
            // 
            // TBRenamePrefix
            // 
            this.TBRenamePrefix.Enabled = false;
            this.TBRenamePrefix.Location = new System.Drawing.Point(86, 78);
            this.TBRenamePrefix.Name = "TBRenamePrefix";
            this.TBRenamePrefix.Size = new System.Drawing.Size(541, 25);
            this.TBRenamePrefix.TabIndex = 3;
            // 
            // LabelRenameSuffix
            // 
            this.LabelRenameSuffix.AutoSize = true;
            this.LabelRenameSuffix.Location = new System.Drawing.Point(9, 115);
            this.LabelRenameSuffix.Name = "LabelRenameSuffix";
            this.LabelRenameSuffix.Size = new System.Drawing.Size(71, 15);
            this.LabelRenameSuffix.TabIndex = 5;
            this.LabelRenameSuffix.Text = "Suffix: ";
            // 
            // LabelRenamePrefix
            // 
            this.LabelRenamePrefix.AutoSize = true;
            this.LabelRenamePrefix.Location = new System.Drawing.Point(9, 81);
            this.LabelRenamePrefix.Name = "LabelRenamePrefix";
            this.LabelRenamePrefix.Size = new System.Drawing.Size(71, 15);
            this.LabelRenamePrefix.TabIndex = 4;
            this.LabelRenamePrefix.Text = "Prefix: ";
            // 
            // CBKeepFileName
            // 
            this.CBKeepFileName.AutoSize = true;
            this.CBKeepFileName.Checked = true;
            this.CBKeepFileName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBKeepFileName.Location = new System.Drawing.Point(9, 53);
            this.CBKeepFileName.Name = "CBKeepFileName";
            this.CBKeepFileName.Size = new System.Drawing.Size(210, 19);
            this.CBKeepFileName.TabIndex = 2;
            this.CBKeepFileName.Text = "Keep original file name";
            this.CBKeepFileName.UseVisualStyleBackColor = true;
            this.CBKeepFileName.CheckedChanged += new System.EventHandler(this.CBKeepFileName_CheckedChanged);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(9, 169);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(618, 47);
            this.BtnStart.TabIndex = 6;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LabelOutFormat
            // 
            this.LabelOutFormat.AutoSize = true;
            this.LabelOutFormat.Location = new System.Drawing.Point(6, 27);
            this.LabelOutFormat.Name = "LabelOutFormat";
            this.LabelOutFormat.Size = new System.Drawing.Size(127, 15);
            this.LabelOutFormat.TabIndex = 1;
            this.LabelOutFormat.Text = "Output Format: ";
            // 
            // ComboBoxOutFormat
            // 
            this.ComboBoxOutFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxOutFormat.FormattingEnabled = true;
            this.ComboBoxOutFormat.Items.AddRange(new object[] {
            ".bmp (Bitmap)",
            ".gif (Graphics Interchange Format)",
            ".jpg (Joint Photographic Experts Group)",
            ".png (W3C Portable Network Graphics)",
            ".tiff (Tagged Image File Format)"});
            this.ComboBoxOutFormat.Location = new System.Drawing.Point(139, 24);
            this.ComboBoxOutFormat.Name = "ComboBoxOutFormat";
            this.ComboBoxOutFormat.Size = new System.Drawing.Size(488, 23);
            this.ComboBoxOutFormat.TabIndex = 1;
            // 
            // GroupBoxCreateEmptyImg
            // 
            this.GroupBoxCreateEmptyImg.Controls.Add(this.BtnCreateEmptyImg);
            this.GroupBoxCreateEmptyImg.Controls.Add(this.TBEmptyImgHeight);
            this.GroupBoxCreateEmptyImg.Controls.Add(this.TBEmptyImgWidth);
            this.GroupBoxCreateEmptyImg.Controls.Add(this.LabelEmptyImgHeight);
            this.GroupBoxCreateEmptyImg.Controls.Add(this.LabelEmptyImgWidth);
            this.GroupBoxCreateEmptyImg.Location = new System.Drawing.Point(418, 311);
            this.GroupBoxCreateEmptyImg.Name = "GroupBoxCreateEmptyImg";
            this.GroupBoxCreateEmptyImg.Size = new System.Drawing.Size(633, 94);
            this.GroupBoxCreateEmptyImg.TabIndex = 7;
            this.GroupBoxCreateEmptyImg.TabStop = false;
            this.GroupBoxCreateEmptyImg.Text = "Create Empty Image";
            // 
            // BtnCreateEmptyImg
            // 
            this.BtnCreateEmptyImg.Location = new System.Drawing.Point(416, 24);
            this.BtnCreateEmptyImg.Name = "BtnCreateEmptyImg";
            this.BtnCreateEmptyImg.Size = new System.Drawing.Size(211, 56);
            this.BtnCreateEmptyImg.TabIndex = 3;
            this.BtnCreateEmptyImg.Text = "Create...";
            this.BtnCreateEmptyImg.UseVisualStyleBackColor = true;
            this.BtnCreateEmptyImg.Click += new System.EventHandler(this.BtnCreateEmptyImg_Click);
            // 
            // TBEmptyImgHeight
            // 
            this.TBEmptyImgHeight.Location = new System.Drawing.Point(107, 55);
            this.TBEmptyImgHeight.Name = "TBEmptyImgHeight";
            this.TBEmptyImgHeight.Size = new System.Drawing.Size(303, 25);
            this.TBEmptyImgHeight.TabIndex = 2;
            // 
            // TBEmptyImgWidth
            // 
            this.TBEmptyImgWidth.Location = new System.Drawing.Point(107, 24);
            this.TBEmptyImgWidth.Name = "TBEmptyImgWidth";
            this.TBEmptyImgWidth.Size = new System.Drawing.Size(303, 25);
            this.TBEmptyImgWidth.TabIndex = 1;
            // 
            // LabelEmptyImgHeight
            // 
            this.LabelEmptyImgHeight.AutoSize = true;
            this.LabelEmptyImgHeight.Location = new System.Drawing.Point(6, 58);
            this.LabelEmptyImgHeight.Name = "LabelEmptyImgHeight";
            this.LabelEmptyImgHeight.Size = new System.Drawing.Size(71, 15);
            this.LabelEmptyImgHeight.TabIndex = 2;
            this.LabelEmptyImgHeight.Text = "Height: ";
            // 
            // LabelEmptyImgWidth
            // 
            this.LabelEmptyImgWidth.AutoSize = true;
            this.LabelEmptyImgWidth.Location = new System.Drawing.Point(6, 27);
            this.LabelEmptyImgWidth.Name = "LabelEmptyImgWidth";
            this.LabelEmptyImgWidth.Size = new System.Drawing.Size(63, 15);
            this.LabelEmptyImgWidth.TabIndex = 1;
            this.LabelEmptyImgWidth.Text = "Width: ";
            // 
            // GroupBoxLog
            // 
            this.GroupBoxLog.Controls.Add(this.TBLog);
            this.GroupBoxLog.Location = new System.Drawing.Point(16, 214);
            this.GroupBoxLog.Name = "GroupBoxLog";
            this.GroupBoxLog.Size = new System.Drawing.Size(396, 228);
            this.GroupBoxLog.TabIndex = 8;
            this.GroupBoxLog.TabStop = false;
            this.GroupBoxLog.Text = "Log (Double Click to Copy)";
            // 
            // TBLog
            // 
            this.TBLog.Location = new System.Drawing.Point(6, 24);
            this.TBLog.Name = "TBLog";
            this.TBLog.Size = new System.Drawing.Size(384, 198);
            this.TBLog.TabIndex = 0;
            this.TBLog.Text = "";
            this.TBLog.WordWrap = false;
            this.TBLog.TextChanged += new System.EventHandler(this.TBLog_TextChanged);
            this.TBLog.Enter += new System.EventHandler(this.TBLog_Enter);
            this.TBLog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TBLog_MouseDoubleClick);
            // 
            // LinkLabelAbout
            // 
            this.LinkLabelAbout.AutoSize = true;
            this.LinkLabelAbout.Location = new System.Drawing.Point(418, 412);
            this.LinkLabelAbout.Name = "LinkLabelAbout";
            this.LinkLabelAbout.Size = new System.Drawing.Size(87, 15);
            this.LinkLabelAbout.TabIndex = 8;
            this.LinkLabelAbout.TabStop = true;
            this.LinkLabelAbout.Text = "Loading...";
            this.LinkLabelAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAbout_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 454);
            this.Controls.Add(this.LinkLabelAbout);
            this.Controls.Add(this.GroupBoxCreateEmptyImg);
            this.Controls.Add(this.GroupBoxLog);
            this.Controls.Add(this.GroupBoxConvert);
            this.Controls.Add(this.GroupBoxResize);
            this.Controls.Add(this.BtnDirOut);
            this.Controls.Add(this.BtnDirIn);
            this.Controls.Add(this.LabelDirOut);
            this.Controls.Add(this.TBDirOut);
            this.Controls.Add(this.TBDirIn);
            this.Controls.Add(this.LabelDirIn);
            this.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Starting...";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.GroupBoxResize.ResumeLayout(false);
            this.GroupBoxResize.PerformLayout();
            this.GroupBoxConvert.ResumeLayout(false);
            this.GroupBoxConvert.PerformLayout();
            this.GroupBoxCreateEmptyImg.ResumeLayout(false);
            this.GroupBoxCreateEmptyImg.PerformLayout();
            this.GroupBoxLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelDirIn;
        private System.Windows.Forms.TextBox TBDirIn;
        private System.Windows.Forms.TextBox TBDirOut;
        private System.Windows.Forms.Label LabelDirOut;
        private System.Windows.Forms.Button BtnDirIn;
        private System.Windows.Forms.Button BtnDirOut;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialogMain;
        private System.Windows.Forms.GroupBox GroupBoxResize;
        private System.Windows.Forms.GroupBox GroupBoxConvert;
        private System.Windows.Forms.CheckBox CBResize;
        private System.Windows.Forms.Label LabelLimHeight;
        private System.Windows.Forms.Label LabelLimWidth;
        private System.Windows.Forms.TextBox TBResizeHeight;
        private System.Windows.Forms.TextBox TBResizeWidth;
        private System.Windows.Forms.ComboBox ComboBoxOutFormat;
        private System.Windows.Forms.Label LabelOutFormat;
        private System.Windows.Forms.TextBox TBRenameSuffix;
        private System.Windows.Forms.TextBox TBRenamePrefix;
        private System.Windows.Forms.Label LabelRenameSuffix;
        private System.Windows.Forms.Label LabelRenamePrefix;
        private System.Windows.Forms.CheckBox CBKeepFileName;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.GroupBox GroupBoxCreateEmptyImg;
        private System.Windows.Forms.Button BtnCreateEmptyImg;
        private System.Windows.Forms.TextBox TBEmptyImgHeight;
        private System.Windows.Forms.TextBox TBEmptyImgWidth;
        private System.Windows.Forms.Label LabelEmptyImgHeight;
        private System.Windows.Forms.Label LabelEmptyImgWidth;
        private System.Windows.Forms.GroupBox GroupBoxLog;
        private System.Windows.Forms.LinkLabel LinkLabelAbout;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogMain;
        private System.Windows.Forms.CheckBox CBLaunchWhenDone;
        private System.Windows.Forms.RichTextBox TBLog;
        private System.Windows.Forms.CheckBox CBNoUpscale;
    }
}

