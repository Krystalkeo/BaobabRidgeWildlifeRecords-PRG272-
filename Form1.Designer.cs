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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.BackColor = SystemColors.InactiveCaption;
            lblId.Location = new Point(23, 81);
            lblId.Name = "lblId";
            lblId.Size = new Size(65, 15);
            lblId.TabIndex = 0;
            lblId.Text = "Animal ID: ";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = SystemColors.InactiveCaption;
            lblName.Location = new Point(23, 134);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.BackColor = SystemColors.InactiveCaption;
            lblSpecies.Location = new Point(23, 194);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(49, 15);
            lblSpecies.TabIndex = 2;
            lblSpecies.Text = "Species:";
            // 
            // lblRecoveryScore
            // 
            lblRecoveryScore.AutoSize = true;
            lblRecoveryScore.BackColor = SystemColors.InactiveCaption;
            lblRecoveryScore.Location = new Point(23, 317);
            lblRecoveryScore.Name = "lblRecoveryScore";
            lblRecoveryScore.Size = new Size(87, 15);
            lblRecoveryScore.TabIndex = 3;
            lblRecoveryScore.Text = "RecoveryScore:";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.BackColor = SystemColors.InactiveCaption;
            lblAge.Location = new Point(23, 240);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(31, 15);
            lblAge.TabIndex = 4;
            lblAge.Text = "Age:";
            // 
            // txtAnimalID
            // 
            txtAnimalID.BackColor = SystemColors.AppWorkspace;
            txtAnimalID.Location = new Point(189, 78);
            txtAnimalID.Name = "txtAnimalID";
            txtAnimalID.Size = new Size(100, 23);
            txtAnimalID.TabIndex = 5;
            // 
            // txtSpecies
            // 
            txtSpecies.BackColor = SystemColors.AppWorkspace;
            txtSpecies.Location = new Point(189, 191);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(100, 23);
            txtSpecies.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.AppWorkspace;
            txtName.Location = new Point(189, 134);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 7;
            // 
            // txtAge
            // 
            txtAge.BackColor = SystemColors.AppWorkspace;
            txtAge.Location = new Point(189, 240);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(100, 23);
            txtAge.TabIndex = 8;
            // 
            // txtRecoveryScore
            // 
            txtRecoveryScore.BackColor = SystemColors.AppWorkspace;
            txtRecoveryScore.Location = new Point(189, 300);
            txtRecoveryScore.Name = "txtRecoveryScore";
            txtRecoveryScore.Size = new Size(100, 23);
            txtRecoveryScore.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(255, 192, 128);
            btnAdd.Location = new Point(22, 357);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(87, 28);
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
            dataGridView1.Location = new Point(349, 78);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(575, 375);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.BackColor = SystemColors.ActiveCaption;
            lblSearch.Location = new Point(22, 414);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(48, 15);
            lblSearch.TabIndex = 12;
            lblSearch.Text = "Search: ";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.ScrollBar;
            txtSearch.Location = new Point(135, 414);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(143, 23);
            txtSearch.TabIndex = 13;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 192, 128);
            btnUpdate.Location = new Point(22, 464);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(108, 23);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update Animal";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 192, 128);
            btnDelete.Location = new Point(23, 523);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(107, 23);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete Animal";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 715);
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
    }
}
