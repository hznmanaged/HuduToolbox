namespace Horizon.Hudu.Toolbox
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveBtn = new Button();
            huduUrlGro = new GroupBox();
            huduUrlTxt = new TextBox();
            groupBox2 = new GroupBox();
            huduApiKeyTxt = new TextBox();
            huduUrlGro.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.Location = new Point(593, 133);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(75, 23);
            saveBtn.TabIndex = 0;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // huduUrlGro
            // 
            huduUrlGro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            huduUrlGro.Controls.Add(huduUrlTxt);
            huduUrlGro.Location = new Point(12, 12);
            huduUrlGro.Name = "huduUrlGro";
            huduUrlGro.Size = new Size(656, 54);
            huduUrlGro.TabIndex = 1;
            huduUrlGro.TabStop = false;
            huduUrlGro.Text = "Hudu URL";
            // 
            // huduUrlTxt
            // 
            huduUrlTxt.Dock = DockStyle.Fill;
            huduUrlTxt.Location = new Point(3, 19);
            huduUrlTxt.Name = "huduUrlTxt";
            huduUrlTxt.Size = new Size(650, 23);
            huduUrlTxt.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(huduApiKeyTxt);
            groupBox2.Location = new Point(12, 72);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(656, 54);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hudu API Key";
            // 
            // huduApiKeyTxt
            // 
            huduApiKeyTxt.Dock = DockStyle.Fill;
            huduApiKeyTxt.Location = new Point(3, 19);
            huduApiKeyTxt.Name = "huduApiKeyTxt";
            huduApiKeyTxt.Size = new Size(650, 23);
            huduApiKeyTxt.TabIndex = 0;
            huduApiKeyTxt.UseSystemPasswordChar = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 168);
            Controls.Add(groupBox2);
            Controls.Add(huduUrlGro);
            Controls.Add(saveBtn);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            huduUrlGro.ResumeLayout(false);
            huduUrlGro.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button saveBtn;
        private GroupBox huduUrlGro;
        private TextBox huduUrlTxt;
        private GroupBox groupBox2;
        private TextBox huduApiKeyTxt;
    }
}