namespace BaobabRidgeWildlifeRecords
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
            btnAdd.Location = new Point(182, 379);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(107, 36);
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
            dataGridView1.Location = new Point(370, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(396, 321);
            dataGridView1.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
