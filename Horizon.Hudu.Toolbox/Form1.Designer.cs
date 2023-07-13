namespace Horizon.Hudu.Toolbox
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonGroupBox = new GroupBox();
            pictureBox5 = new PictureBox();
            rewriteUrlSettingsPic = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnCancel = new Button();
            btnBrokenImageReport = new Button();
            chkDryRun = new CheckBox();
            btnUrlRewrite = new Button();
            btnImportImages = new Button();
            groupBox2 = new GroupBox();
            textBox1 = new TextBox();
            saveFileDialog1 = new SaveFileDialog();
            grpBoxTargets = new GroupBox();
            chkTargetAssets = new CheckBox();
            chkProcessArticles = new CheckBox();
            txtFilter = new TextBox();
            settingsBtn = new Button();
            dryRunTip = new ToolTip(components);
            grpNameFilter = new GroupBox();
            aboutBtn = new Button();
            buttonGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rewriteUrlSettingsPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            grpBoxTargets.SuspendLayout();
            grpNameFilter.SuspendLayout();
            SuspendLayout();
            // 
            // buttonGroupBox
            // 
            buttonGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            buttonGroupBox.Controls.Add(pictureBox5);
            buttonGroupBox.Controls.Add(rewriteUrlSettingsPic);
            buttonGroupBox.Controls.Add(pictureBox3);
            buttonGroupBox.Controls.Add(pictureBox2);
            buttonGroupBox.Controls.Add(pictureBox1);
            buttonGroupBox.Controls.Add(btnCancel);
            buttonGroupBox.Controls.Add(btnBrokenImageReport);
            buttonGroupBox.Controls.Add(chkDryRun);
            buttonGroupBox.Controls.Add(btnUrlRewrite);
            buttonGroupBox.Controls.Add(btnImportImages);
            buttonGroupBox.Location = new Point(12, 127);
            buttonGroupBox.Name = "buttonGroupBox";
            buttonGroupBox.Size = new Size(200, 301);
            buttonGroupBox.TabIndex = 0;
            buttonGroupBox.TabStop = false;
            buttonGroupBox.Text = "Tools";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(142, 17);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(23, 21);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 9;
            pictureBox5.TabStop = false;
            dryRunTip.SetToolTip(pictureBox5, "Dry run will skip all write operations.");
            // 
            // rewriteUrlSettingsPic
            // 
            rewriteUrlSettingsPic.Cursor = Cursors.Hand;
            rewriteUrlSettingsPic.Image = (Image)resources.GetObject("rewriteUrlSettingsPic.Image");
            rewriteUrlSettingsPic.Location = new Point(142, 104);
            rewriteUrlSettingsPic.Name = "rewriteUrlSettingsPic";
            rewriteUrlSettingsPic.Size = new Size(23, 21);
            rewriteUrlSettingsPic.SizeMode = PictureBoxSizeMode.StretchImage;
            rewriteUrlSettingsPic.TabIndex = 8;
            rewriteUrlSettingsPic.TabStop = false;
            rewriteUrlSettingsPic.Click += rewriteUrlSettingsPic_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(171, 104);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(23, 21);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            dryRunTip.SetToolTip(pictureBox3, "Converts all link and image URLs that match user-defined patterns and convert them to new user-defined patterns. Configure via the gear icon to the left.");
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(171, 73);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(23, 21);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            dryRunTip.SetToolTip(pictureBox2, "Generates a report of broken images.");
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(171, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(23, 21);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            dryRunTip.SetToolTip(pictureBox1, "\"Import Images\" will detect all images with a source not hosted on Hudu and embed them as BASE64 string.");
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(6, 272);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(188, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnBrokenImageReport
            // 
            btnBrokenImageReport.Location = new Point(6, 73);
            btnBrokenImageReport.Name = "btnBrokenImageReport";
            btnBrokenImageReport.Size = new Size(159, 23);
            btnBrokenImageReport.TabIndex = 3;
            btnBrokenImageReport.Text = "Broken image report";
            btnBrokenImageReport.UseVisualStyleBackColor = true;
            btnBrokenImageReport.Click += btnBrokenImageReport_Click;
            // 
            // chkDryRun
            // 
            chkDryRun.AutoSize = true;
            chkDryRun.Checked = true;
            chkDryRun.CheckState = CheckState.Checked;
            chkDryRun.Location = new Point(66, 19);
            chkDryRun.Name = "chkDryRun";
            chkDryRun.Size = new Size(65, 19);
            chkDryRun.TabIndex = 2;
            chkDryRun.Text = "Dry run";
            chkDryRun.UseVisualStyleBackColor = true;
            // 
            // btnUrlRewrite
            // 
            btnUrlRewrite.Location = new Point(6, 102);
            btnUrlRewrite.Name = "btnUrlRewrite";
            btnUrlRewrite.Size = new Size(130, 23);
            btnUrlRewrite.TabIndex = 1;
            btnUrlRewrite.Text = "Rewrite URLs";
            btnUrlRewrite.UseVisualStyleBackColor = true;
            btnUrlRewrite.Click += btnUrlRewrite_Click;
            // 
            // btnImportImages
            // 
            btnImportImages.Location = new Point(6, 44);
            btnImportImages.Name = "btnImportImages";
            btnImportImages.Size = new Size(159, 23);
            btnImportImages.TabIndex = 0;
            btnImportImages.Text = "Import Images";
            btnImportImages.UseVisualStyleBackColor = true;
            btnImportImages.Click += btnImportImages_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(textBox1);
            groupBox2.Location = new Point(230, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(667, 474);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Output";
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 19);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(661, 452);
            textBox1.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "html";
            saveFileDialog1.Filter = "\"HTML files (*.html, *.htm)|*.html;*.htm|All files (*.*)|*.*\"";
            // 
            // grpBoxTargets
            // 
            grpBoxTargets.Controls.Add(chkTargetAssets);
            grpBoxTargets.Controls.Add(chkProcessArticles);
            grpBoxTargets.Location = new Point(12, 12);
            grpBoxTargets.Name = "grpBoxTargets";
            grpBoxTargets.Size = new Size(200, 43);
            grpBoxTargets.TabIndex = 2;
            grpBoxTargets.TabStop = false;
            grpBoxTargets.Text = "Processing targets";
            // 
            // chkTargetAssets
            // 
            chkTargetAssets.AutoSize = true;
            chkTargetAssets.Checked = true;
            chkTargetAssets.CheckState = CheckState.Checked;
            chkTargetAssets.Location = new Point(91, 22);
            chkTargetAssets.Name = "chkTargetAssets";
            chkTargetAssets.Size = new Size(59, 19);
            chkTargetAssets.TabIndex = 1;
            chkTargetAssets.Text = "Assets";
            chkTargetAssets.UseVisualStyleBackColor = true;
            // 
            // chkProcessArticles
            // 
            chkProcessArticles.AutoSize = true;
            chkProcessArticles.Checked = true;
            chkProcessArticles.CheckState = CheckState.Checked;
            chkProcessArticles.Location = new Point(6, 22);
            chkProcessArticles.Name = "chkProcessArticles";
            chkProcessArticles.Size = new Size(65, 19);
            chkProcessArticles.TabIndex = 0;
            chkProcessArticles.Text = "Articles";
            chkProcessArticles.UseVisualStyleBackColor = true;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(6, 22);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(188, 23);
            txtFilter.TabIndex = 2;
            // 
            // settingsBtn
            // 
            settingsBtn.Location = new Point(12, 463);
            settingsBtn.Name = "settingsBtn";
            settingsBtn.Size = new Size(200, 23);
            settingsBtn.TabIndex = 3;
            settingsBtn.Text = "Settings";
            settingsBtn.UseVisualStyleBackColor = true;
            settingsBtn.Click += settingsBtn_Click;
            // 
            // dryRunTip
            // 
            dryRunTip.ToolTipIcon = ToolTipIcon.Info;
            // 
            // grpNameFilter
            // 
            grpNameFilter.Controls.Add(txtFilter);
            grpNameFilter.Location = new Point(12, 66);
            grpNameFilter.Name = "grpNameFilter";
            grpNameFilter.Size = new Size(200, 55);
            grpNameFilter.TabIndex = 4;
            grpNameFilter.TabStop = false;
            grpNameFilter.Text = "Name filter";
            // 
            // aboutBtn
            // 
            aboutBtn.Location = new Point(12, 434);
            aboutBtn.Name = "aboutBtn";
            aboutBtn.Size = new Size(200, 23);
            aboutBtn.TabIndex = 5;
            aboutBtn.Text = "About";
            aboutBtn.UseVisualStyleBackColor = true;
            aboutBtn.Click += aboutBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 498);
            Controls.Add(aboutBtn);
            Controls.Add(grpNameFilter);
            Controls.Add(settingsBtn);
            Controls.Add(grpBoxTargets);
            Controls.Add(groupBox2);
            Controls.Add(buttonGroupBox);
            Name = "Form1";
            Text = "Horizon Hudu Toolbox";
            buttonGroupBox.ResumeLayout(false);
            buttonGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)rewriteUrlSettingsPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            grpBoxTargets.ResumeLayout(false);
            grpBoxTargets.PerformLayout();
            grpNameFilter.ResumeLayout(false);
            grpNameFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox buttonGroupBox;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private Button btnImportImages;
        private Button btnUrlRewrite;
        private CheckBox chkDryRun;
        private Button btnBrokenImageReport;
        private SaveFileDialog saveFileDialog1;
        private GroupBox grpBoxTargets;
        private CheckBox chkTargetAssets;
        private CheckBox chkProcessArticles;
        private Button btnCancel;
        private TextBox txtFilter;
        private PictureBox pictureBox5;
        private PictureBox rewriteUrlSettingsPic;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button settingsBtn;
        private ToolTip dryRunTip;
        private GroupBox grpNameFilter;
        private Button aboutBtn;
    }
}