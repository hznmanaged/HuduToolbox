namespace Horizon.Hudu.Toolbox
{
    partial class RewriteUrlSettingsEntryForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RewriteUrlSettingsEntryForm));
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            searchPatternText = new TextBox();
            label1 = new Label();
            saveBtn = new Button();
            groupBox2 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            textBox1 = new TextBox();
            label2 = new Label();
            groupBox3 = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            replacementPatternText = new TextBox();
            label3 = new Label();
            groupBox4 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            textBox2 = new TextBox();
            label4 = new Label();
            groupBox5 = new GroupBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            replacementDisplayPatternText = new TextBox();
            label5 = new Label();
            groupBox6 = new GroupBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            textBox4 = new TextBox();
            label6 = new Label();
            groupBox7 = new GroupBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            textBox5 = new TextBox();
            label7 = new Label();
            groupBox8 = new GroupBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            label8 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            testText = new TextBox();
            testButton = new Button();
            label9 = new Label();
            label10 = new Label();
            outputText = new TextBox();
            displayOutputText = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox5.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            groupBox8.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 80);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search pattern";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(searchPatternText, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(754, 58);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // searchPatternText
            // 
            searchPatternText.Dock = DockStyle.Fill;
            searchPatternText.Location = new Point(3, 3);
            searchPatternText.Name = "searchPatternText";
            searchPatternText.Size = new Size(748, 23);
            searchPatternText.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 28);
            label1.Name = "label1";
            label1.Size = new Size(748, 30);
            label1.TabIndex = 1;
            label1.Text = "The RegEx pattern specified here will be used to search for the URLs to replace. RegEx groups will be passed into the templates below to construct the new URLs.";
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.Location = new Point(697, 430);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(75, 23);
            saveBtn.TabIndex = 50;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.AutoSize = true;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 100);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.Size = new Size(200, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(194, 23);
            textBox1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 29);
            label2.Name = "label2";
            label2.Size = new Size(194, 75);
            label2.TabIndex = 1;
            label2.Text = "The RegEx pattern specified here will be used to search for the URLs to replace. RegEx groups will be passed into the templates below to construct the new URLs.";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.AutoSize = true;
            groupBox3.Controls.Add(tableLayoutPanel3);
            groupBox3.Location = new Point(12, 89);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(760, 82);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Replacement pattern";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(replacementPatternText, 0, 0);
            tableLayoutPanel3.Controls.Add(label3, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 19);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(754, 60);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // replacementPatternText
            // 
            replacementPatternText.Dock = DockStyle.Fill;
            replacementPatternText.Location = new Point(3, 3);
            replacementPatternText.Name = "replacementPatternText";
            replacementPatternText.Size = new Size(748, 23);
            replacementPatternText.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 30);
            label3.Name = "label3";
            label3.Size = new Size(748, 30);
            label3.TabIndex = 1;
            label3.Text = resources.GetString("label3.Text");
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.AutoSize = true;
            groupBox4.Location = new Point(0, 0);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(200, 100);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(textBox2, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.Size = new Size(200, 100);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(3, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(194, 23);
            textBox2.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 29);
            label4.Name = "label4";
            label4.Size = new Size(194, 135);
            label4.TabIndex = 1;
            label4.Text = resources.GetString("label4.Text");
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.AutoSize = true;
            groupBox5.Controls.Add(tableLayoutPanel5);
            groupBox5.Location = new Point(12, 177);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(760, 99);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "Replacement display pattern";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(replacementDisplayPatternText, 0, 0);
            tableLayoutPanel5.Controls.Add(label5, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 19);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle());
            tableLayoutPanel5.Size = new Size(754, 77);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // replacementDisplayPatternText
            // 
            replacementDisplayPatternText.Dock = DockStyle.Fill;
            replacementDisplayPatternText.Location = new Point(3, 3);
            replacementDisplayPatternText.Name = "replacementDisplayPatternText";
            replacementDisplayPatternText.Size = new Size(748, 23);
            replacementDisplayPatternText.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 32);
            label5.Name = "label5";
            label5.Size = new Size(748, 45);
            label5.TabIndex = 1;
            label5.Text = resources.GetString("label5.Text");
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox6.AutoSize = true;
            groupBox6.Location = new Point(0, 0);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(200, 100);
            groupBox6.TabIndex = 0;
            groupBox6.TabStop = false;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(textBox4, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.Size = new Size(200, 100);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(3, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(194, 23);
            textBox4.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 29);
            label6.Name = "label6";
            label6.Size = new Size(194, 135);
            label6.TabIndex = 1;
            label6.Text = resources.GetString("label6.Text");
            // 
            // groupBox7
            // 
            groupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox7.AutoSize = true;
            groupBox7.Location = new Point(0, 0);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(200, 100);
            groupBox7.TabIndex = 0;
            groupBox7.TabStop = false;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(textBox5, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.Size = new Size(200, 100);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // textBox5
            // 
            textBox5.Dock = DockStyle.Fill;
            textBox5.Location = new Point(3, 3);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(194, 23);
            textBox5.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 29);
            label7.Name = "label7";
            label7.Size = new Size(194, 135);
            label7.TabIndex = 1;
            label7.Text = resources.GetString("label7.Text");
            // 
            // groupBox8
            // 
            groupBox8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox8.AutoSize = true;
            groupBox8.Controls.Add(tableLayoutPanel8);
            groupBox8.Location = new Point(12, 282);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(760, 137);
            groupBox8.TabIndex = 4;
            groupBox8.TabStop = false;
            groupBox8.Text = "Test";
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 593F));
            tableLayoutPanel8.Controls.Add(label8, 0, 1);
            tableLayoutPanel8.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel8.Controls.Add(label9, 0, 2);
            tableLayoutPanel8.Controls.Add(label10, 0, 3);
            tableLayoutPanel8.Controls.Add(outputText, 1, 2);
            tableLayoutPanel8.Controls.Add(displayOutputText, 1, 3);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 19);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 4;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle());
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel8.Size = new Size(754, 115);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            tableLayoutPanel8.SetColumnSpan(label8, 2);
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(3, 38);
            label8.Name = "label8";
            label8.Size = new Size(748, 15);
            label8.TabIndex = 1;
            label8.Text = "Enter a URL above to test it against the patterns defined above. The resulting rewrites will be shown below.";
            // 
            // flowLayoutPanel1
            // 
            tableLayoutPanel8.SetColumnSpan(flowLayoutPanel1, 2);
            flowLayoutPanel1.Controls.Add(testText);
            flowLayoutPanel1.Controls.Add(testButton);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(748, 32);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // testText
            // 
            testText.Location = new Point(3, 3);
            testText.Name = "testText";
            testText.Size = new Size(656, 23);
            testText.TabIndex = 30;
            // 
            // testButton
            // 
            testButton.Location = new Point(665, 3);
            testButton.Name = "testButton";
            testButton.Size = new Size(75, 23);
            testButton.TabIndex = 40;
            testButton.Text = "Test";
            testButton.UseVisualStyleBackColor = true;
            testButton.Click += testButton_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(3, 53);
            label9.Name = "label9";
            label9.Size = new Size(155, 29);
            label9.TabIndex = 3;
            label9.Text = "Output";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(3, 82);
            label10.Name = "label10";
            label10.Size = new Size(155, 33);
            label10.TabIndex = 4;
            label10.Text = "Display output";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // outputText
            // 
            outputText.Dock = DockStyle.Fill;
            outputText.Location = new Point(164, 56);
            outputText.Name = "outputText";
            outputText.ReadOnly = true;
            outputText.Size = new Size(587, 23);
            outputText.TabIndex = 5;
            outputText.TabStop = false;
            // 
            // displayOutputText
            // 
            displayOutputText.Dock = DockStyle.Fill;
            displayOutputText.Location = new Point(164, 85);
            displayOutputText.Name = "displayOutputText";
            displayOutputText.ReadOnly = true;
            displayOutputText.Size = new Size(587, 23);
            displayOutputText.TabIndex = 6;
            displayOutputText.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // RewriteUrlSettingsEntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 465);
            Controls.Add(groupBox8);
            Controls.Add(groupBox5);
            Controls.Add(groupBox3);
            Controls.Add(saveBtn);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RewriteUrlSettingsEntryForm";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "URL Rewrite Settings";
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            groupBox3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            groupBox5.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            groupBox8.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox searchPatternText;
        private Label label1;
        private Button saveBtn;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBox1;
        private Label label2;
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox replacementPatternText;
        private Label label3;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox textBox2;
        private Label label4;
        private GroupBox groupBox5;
        private TableLayoutPanel tableLayoutPanel5;
        private TextBox replacementDisplayPatternText;
        private Label label5;
        private GroupBox groupBox6;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox textBox4;
        private Label label6;
        private GroupBox groupBox7;
        private TableLayoutPanel tableLayoutPanel7;
        private TextBox textBox5;
        private Label label7;
        private GroupBox groupBox8;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label8;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox testText;
        private Button testButton;
        private Label label9;
        private Label label10;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox outputText;
        private TextBox displayOutputText;
        private ContextMenuStrip contextMenuStrip2;
    }
}