namespace BaobabRidgeWildlifeRecords
{
    partial class Form1
    {
      
        ///  Required designer variable.
        
        private System.ComponentModel.IContainer components = null;

        
        ///  Clean up any resources being used.
        
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
            lblId = new Label();
            lblName = new Label();
            lblSpecies = new Label();
            lblRecoveryScore = new Label();
            lblAge = new Label();
            txtAnimalID = new TextBox();
            txtSpecies = new TextBox();
            txtName = new TextBox();
            txtAge = new TextBox();
            txtRecoveryScore = new TextBox();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.BackColor = SystemColors.InactiveCaption;
            lblId.Location = new Point(26, 108);
            lblId.Name = "lblId";
            lblId.Size = new Size(82, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Animal ID: ";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = SystemColors.InactiveCaption;
            lblName.Location = new Point(26, 179);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.BackColor = SystemColors.InactiveCaption;
            lblSpecies.Location = new Point(26, 259);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(62, 20);
            lblSpecies.TabIndex = 2;
            lblSpecies.Text = "Species:";
            // 
            // lblRecoveryScore
            // 
            lblRecoveryScore.AutoSize = true;
            lblRecoveryScore.BackColor = SystemColors.InactiveCaption;
            lblRecoveryScore.Location = new Point(26, 423);
            lblRecoveryScore.Name = "lblRecoveryScore";
            lblRecoveryScore.Size = new Size(109, 20);
            lblRecoveryScore.TabIndex = 3;
            lblRecoveryScore.Text = "RecoveryScore:";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.BackColor = SystemColors.InactiveCaption;
            lblAge.Location = new Point(26, 320);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(39, 20);
            lblAge.TabIndex = 4;
            lblAge.Text = "Age:";
            // 
            // txtAnimalID
            // 
            txtAnimalID.BackColor = SystemColors.AppWorkspace;
            txtAnimalID.Location = new Point(216, 104);
            txtAnimalID.Margin = new Padding(3, 4, 3, 4);
            txtAnimalID.Name = "txtAnimalID";
            txtAnimalID.Size = new Size(114, 27);
            txtAnimalID.TabIndex = 5;
            // 
            // txtSpecies
            // 
            txtSpecies.BackColor = SystemColors.AppWorkspace;
            txtSpecies.Location = new Point(216, 255);
            txtSpecies.Margin = new Padding(3, 4, 3, 4);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(114, 27);
            txtSpecies.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.AppWorkspace;
            txtName.Location = new Point(216, 179);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(114, 27);
            txtName.TabIndex = 7;
            // 
            // txtAge
            // 
            txtAge.BackColor = SystemColors.AppWorkspace;
            txtAge.Location = new Point(216, 320);
            txtAge.Margin = new Padding(3, 4, 3, 4);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(114, 27);
            txtAge.TabIndex = 8;
            // 
            // txtRecoveryScore
            // 
            txtRecoveryScore.BackColor = SystemColors.AppWorkspace;
            txtRecoveryScore.Location = new Point(216, 400);
            txtRecoveryScore.Margin = new Padding(3, 4, 3, 4);
            txtRecoveryScore.Name = "txtRecoveryScore";
            txtRecoveryScore.Size = new Size(114, 27);
            txtRecoveryScore.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(255, 192, 128);
            btnAdd.Location = new Point(24, 555);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(99, 37);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add Animal";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(399, 104);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(657, 500);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.BackColor = SystemColors.ActiveCaption;
            lblSearch.Location = new Point(48, 611);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(60, 20);
            lblSearch.TabIndex = 12;
            lblSearch.Text = "Search: ";
            lblSearch.Click += lblSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.ScrollBar;
            txtSearch.Location = new Point(207, 608);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(163, 27);
            txtSearch.TabIndex = 13;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 192, 128);
            btnUpdate.Location = new Point(24, 729);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(123, 31);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update Animal";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 192, 128);
            btnDelete.Location = new Point(26, 783);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(122, 31);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete Animal";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(255, 192, 128);
            btnClear.Location = new Point(207, 489);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(123, 31);
            btnClear.TabIndex = 17;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(255, 192, 128);
            btnSearch.CausesValidation = false;
            btnSearch.Location = new Point(247, 669);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(123, 31);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 953);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(txtRecoveryScore);
            Controls.Add(txtAge);
            Controls.Add(txtName);
            Controls.Add(txtSpecies);
            Controls.Add(txtAnimalID);
            Controls.Add(lblAge);
            Controls.Add(lblRecoveryScore);
            Controls.Add(lblSpecies);
            Controls.Add(lblName);
            Controls.Add(lblId);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Baobab Ridge Wildlife Records";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private Label lblName;
        private Label lblSpecies;
        private Label lblRecoveryScore;
        private Label lblAge;
        private TextBox txtAnimalID;
        private TextBox txtSpecies;
        private TextBox txtName;
        private TextBox txtAge;
        private TextBox txtRecoveryScore;
        private Button btnAdd;
        private DataGridView dataGridView1;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSearch;
    }
}
