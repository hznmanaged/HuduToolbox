namespace Horizon.Hudu.Toolbox
{
    partial class RewriteUrlSettingsForm
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
            dataGridView1 = new DataGridView();
            SearchPattern = new DataGridViewTextBoxColumn();
            ReplacePattern = new DataGridViewTextBoxColumn();
            ReplacementDisplayPattern = new DataGridViewTextBoxColumn();
            EditButton = new DataGridViewButtonColumn();
            DeleteButton = new DataGridViewButtonColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            addBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { SearchPattern, ReplacePattern, ReplacementDisplayPattern, EditButton, DeleteButton });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(794, 412);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // SearchPattern
            // 
            SearchPattern.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SearchPattern.DataPropertyName = "SearchRegex";
            SearchPattern.HeaderText = "Search Pattern";
            SearchPattern.Name = "SearchPattern";
            SearchPattern.ReadOnly = true;
            // 
            // ReplacePattern
            // 
            ReplacePattern.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ReplacePattern.DataPropertyName = "ReplacementPattern";
            ReplacePattern.HeaderText = "Replacement Pattern";
            ReplacePattern.Name = "ReplacePattern";
            ReplacePattern.ReadOnly = true;
            // 
            // ReplacementDisplayPattern
            // 
            ReplacementDisplayPattern.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ReplacementDisplayPattern.DataPropertyName = "ReplacementDisplayPattern";
            ReplacementDisplayPattern.HeaderText = "Replacement Display Pattern";
            ReplacementDisplayPattern.Name = "ReplacementDisplayPattern";
            ReplacementDisplayPattern.ReadOnly = true;
            // 
            // EditButton
            // 
            EditButton.HeaderText = "";
            EditButton.Name = "EditButton";
            EditButton.ReadOnly = true;
            EditButton.Text = "Edit";
            EditButton.UseColumnTextForButtonValue = true;
            // 
            // DeleteButton
            // 
            DeleteButton.HeaderText = "";
            DeleteButton.Name = "DeleteButton";
            DeleteButton.ReadOnly = true;
            DeleteButton.Text = "Delete";
            DeleteButton.UseColumnTextForButtonValue = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel1.Controls.Add(addBtn, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // addBtn
            // 
            addBtn.Dock = DockStyle.Fill;
            addBtn.Location = new Point(3, 421);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(794, 26);
            addBtn.TabIndex = 1;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // RewriteUrlSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "RewriteUrlSettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rewrite Url Settings";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button addBtn;
        private DataGridViewTextBoxColumn SearchPattern;
        private DataGridViewTextBoxColumn ReplacePattern;
        private DataGridViewTextBoxColumn ReplacementDisplayPattern;
        private DataGridViewButtonColumn EditButton;
        private DataGridViewButtonColumn DeleteButton;
    }
}