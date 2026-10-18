using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BaobabRidgeWildlifeRecords
{
    public partial class Form1 : Form
    {
        // Path to animals.txt stored next to the application executable
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");

        public Form1()
        {
            InitializeComponent();
            SetEditMode(false);
            // Set up grid columns when form opens
            InitializeGridColumns();

            // Load existing animals into the grid on startup
            LoadAnimalsToGrid();
        }

        // Configures the table headers for the grid
        private void InitializeGridColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("AnimalID", "Animal ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Species", "Species");
            dataGridView1.Columns.Add("Age", "Age");
            dataGridView1.Columns.Add("RecoveryScore", "Recovery Score");
            dataGridView1.Columns.Add("Status", "Status");
            dataGridView1.Columns.Add("HousingUnit", "Housing Unit");

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }



        private void LoadAnimalsToGrid()
        {
            // Clear existing rows first so repeated calls (Add/Update/Delete) never duplicate data.
            dataGridView1.Rows.Clear();

            try
            {
                // AnimalFileLoader creates the file when it is missing and returns
                // the valid records in file order, together with a count of skipped lines.
                var records = AnimalFileLoader.Load(filePath, out int skippedCount);

                foreach (var record in records)
                {
                    dataGridView1.Rows.Add(record.AnimalID, record.Name, record.Species,
                        record.Age, record.RecoveryScore, record.Status, record.HousingUnit);
                }

                // Tell the user once how many malformed lines were ignored.
                if (skippedCount > 0)
                {
                    MessageBox.Show(
                        $"{skippedCount} malformed line(s) were skipped while loading animals.txt.",
                        "Records Skipped", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handles file-loading errors such as locked files or access-denied problems.
                MessageBox.Show($"Error loading records: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handles adding a new animal when the Add button is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtAnimalID.Text.Trim().ToUpper();
                string name = txtName.Text.Trim();
                string species = txtSpecies.Text.Trim();
                string ageText = txtAge.Text.Trim();
                string scoreText = txtRecoveryScore.Text.Trim();

                // Validate Animal ID format
                if (string.IsNullOrEmpty(id) || !System.Text.RegularExpressions.Regex.IsMatch(id, @"^WR-\d{4}$"))
                {
                    MessageBox.Show("Animal ID must start with WR- followed by 4 digits (e.g., WR-0001).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAnimalID.Focus();
                    return;
                }

                // Check for duplicate ID
                if (File.Exists(filePath))
                {
                    foreach (var line in File.ReadAllLines(filePath))
                    {
                        var parts = line.Split('|');
                        if (parts.Length > 0 && parts[0].Trim().Equals(id, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("This Animal ID already exists. IDs must be unique.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAnimalID.Focus();
                            return;
                        }
                    }
                }

                // Validate Name
                if (string.IsNullOrEmpty(name) || name.Length > 30 || name.Contains("|"))
                {
                    MessageBox.Show("Name is required (1-30 characters) and cannot contain the pipe (|) character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }

                // Validate Species
                if (string.IsNullOrEmpty(species) || species.Length > 30 || species.Contains("|"))
                {
                    MessageBox.Show("Species is required (1-30 characters) and cannot contain the pipe (|) character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSpecies.Focus();
                    return;
                }

                // Validate Age
                if (!int.TryParse(ageText, out int age) || age < 0 || age > 100)
                {
                    MessageBox.Show("Age must be a whole number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAge.Focus();
                    return;
                }

                // Validate Recovery Score
                if (!int.TryParse(scoreText, out int score) || score < 0 || score > 100)
                {
                    MessageBox.Show("Recovery Score must be a whole number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRecoveryScore.Focus();
                    return;
                }

                // Create Animal object (calculates status and housing automatically)
                Animal newAnimal = new Animal(id, name, species, age, score);

                // Format record line
                string recordLine = $"{newAnimal.AnimalID} | {newAnimal.Name} | {newAnimal.Species} | {newAnimal.Age} | {newAnimal.RecoveryScore} | {newAnimal.Status} | {newAnimal.HousingUnit}";

                // Save to file
                File.AppendAllLines(filePath, new[] { recordLine });

                // Refresh grid and clear inputs
                LoadAnimalsToGrid();

                MessageBox.Show($"Animal added successfully!\nStatus: {newAnimal.Status}\nHousing Unit: {newAnimal.HousingUnit}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAnimalID.Clear();
                txtName.Clear();
                txtSpecies.Clear();
                txtAge.Clear();
                txtRecoveryScore.Clear();
                txtAnimalID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Validate Name Species age and Score
        private bool ValidateFields(out string name, out string species, out int age, out int score)
        {
            name = txtName.Text.Trim();
            species = txtSpecies.Text.Trim();
            age = 0;
            score = 0;

            if (name.Length == 0 || name.Length > 30 || name.Contains("|"))
            {
                MessageBox.Show("Name is required (1-30 characters) and cannot contain the pipe (|) character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (species.Length == 0 || species.Length > 30 || species.Contains("|"))
            {
                MessageBox.Show("Species is required (1-30 characters) and cannot contain the pipe (|) character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSpecies.Focus();
                return false;
            }
            if (!int.TryParse(txtAge.Text.Trim(), out age) || age < 0  || age > 100)
            {
                MessageBox.Show("Age must be a whole number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAge.Focus();
                return false;
            }
            if (!int.TryParse(txtRecoveryScore.Text.Trim(), out score) || score < 0 || score > 100)
            {
                MessageBox.Show("Recovery Score must be a whole number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRecoveryScore.Focus();
                return false;
            }
            return true;
        }

        //Save changes to selected animals with validate inputs
        //Rewrites animal.txt       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
                
            if (!editMode) return;

            try {
                if (!ValidateFields(out string name, out string species, out int age, out int score))
                { return; }

                string id = txtAnimalID.Text.Trim().ToUpper();
                Animal updatedAnimal = new Animal(id, name, species, age, score);
                string updatedLine = $"{updatedAnimal.AnimalID} | {updatedAnimal.Name} | {updatedAnimal.Species} | {updatedAnimal.Age} | {updatedAnimal.RecoveryScore} | {updatedAnimal.Status} | {updatedAnimal.HousingUnit}";

                if (!File.Exists(filePath))
                {
                    MessageBox.Show("File path does not exist: " + filePath, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);
                bool found = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;

                    var parts = lines[i].Split('|');
                    if (parts.Length > 0 && parts[0].Trim().Equals(id, StringComparison.OrdinalIgnoreCase))
                    {
                        lines[i] = updatedLine;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    File.WriteAllLines(filePath, lines);
                    LoadAnimalsToGrid();

                    MessageBox.Show("SUCCESS! Record updated in file and grid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtAnimalID.Clear();
                    txtName.Clear();
                    txtSpecies.Clear();
                    txtAge.Clear();
                    txtRecoveryScore.Clear();
                    txtAnimalID.Enabled = true;
                    SetEditMode(false);
                    txtAnimalID.Focus();
                }
                else
                {
                    MessageBox.Show($"Record with ID '{id}' was not found in the text file lines.", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Handles deleting a selected animal record
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = txtAnimalID.Text.Trim().ToUpper();

                // Check if a record is selected (ID box should be disabled/locked when selected)
                if (string.IsNullOrEmpty(id) || !editMode)
                {
                    MessageBox.Show("Please select an animal record from the grid to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm deletion with the user
                var confirmResult = MessageBox.Show($"Are you sure you want to delete animal record {id}?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show("Record file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string[] lines = File.ReadAllLines(filePath);
                    var updatedLines = new List<string>();
                    bool found = false;

                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var parts = line.Split('|');
                        if (parts.Length > 0 && parts[0].Trim().Equals(id, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true; // Skip this line to delete it
                            continue;
                        }
                        updatedLines.Add(line);
                    }

                    if (found)
                    {
                        File.WriteAllLines(filePath, updatedLines);
                        LoadAnimalsToGrid();

                        MessageBox.Show("Animal record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear inputs and re-enable ID field
                        txtAnimalID.Clear();
                        txtName.Clear();
                        txtSpecies.Clear();
                        txtAge.Clear();
                        txtRecoveryScore.Clear();
                        txtAnimalID.Enabled = true;
                        txtAnimalID.Focus();
                        SetEditMode(false);
                    }
                    else
                    {
                        MessageBox.Show("Record to delete was not found in the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        // Loads selected grid row data into textboxes for editing
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtAnimalID.Text = row.Cells["AnimalID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSpecies.Text = row.Cells["Species"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                txtRecoveryScore.Text = row.Cells["RecoveryScore"].Value.ToString();

                //Switch to EditMode when Selecting Cell
                SetEditMode(true);
            }
        }

        // Dummy event handler to support designer references
        private void lblSpecies_Click(object sender, EventArgs e)
        {
        }
        // Filters the DataGridView dynamically as text is typed into the search box
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Prevent conflict for Search button
            if (supressFilter)
            {  return; }
            string searchTerm = txtSearch.Text.Trim().ToLower();

            // If the search box is empty, reload all records from the file
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadAnimalsToGrid();
                return;
            }

            dataGridView1.Rows.Clear();

            if (!File.Exists(filePath)) return;

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split('|');
                    if (parts.Length != 7) continue;

                    string id = parts[0].Trim();
                    string name = parts[1].Trim();
                    string species = parts[2].Trim();
                    string ageStr = parts[3].Trim();
                    string scoreStr = parts[4].Trim();
                    string status = parts[5].Trim();
                    string housing = parts[6].Trim();

                    // Check if the search term matches the ID, Name, or Species
                    if (id.ToLower().Contains(searchTerm) ||
                        name.ToLower().Contains(searchTerm) ||
                        species.ToLower().Contains(searchTerm))
                    {
                        if (int.TryParse(ageStr, out int age) && int.TryParse(scoreStr, out int score))
                        {
                            dataGridView1.Rows.Add(id, name, species, age, score, status, housing);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
      
        private void lblSearch_Click(object sender, EventArgs e)
        {

        }
        private bool editMode = false;

        //switches form from add mode to edit mode
        private void SetEditMode(bool isEditing)
        { 
            editMode = isEditing;
            txtAnimalID.ReadOnly = editMode;
            btnAdd.Enabled = !isEditing;
            btnUpdate.Enabled = isEditing;
            //set btnUpdate.Text acts as save changes

        }
        // Loads one animal's values into the input boxes and switches to Edit mode.
        private void LoadIntoForm(string id, string name, string species, string age, string score)
        {
            txtAnimalID.Text = id;
            txtName.Text = name;
            txtSpecies.Text = species;
            txtAge.Text = age;
            txtRecoveryScore.Text = score;
            SetEditMode(true);
        }

        private bool supressFilter = false;

        //
        

        //Clear input boxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAnimalID.Clear();
            txtAge.Clear();
            txtName.Clear();
            txtRecoveryScore.Clear();
            txtSpecies.Clear();
            

            supressFilter = true;
            txtSearch.Clear();
            supressFilter = false;

            SetEditMode(false);        // back to Add mode
            LoadAnimalsToGrid();       // show all records again
            txtAnimalID.Focus();
        }

        

        //find animal (case insensitive) by ID for editing
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text.Trim();
            //prevents empty search
            if (string.IsNullOrEmpty(id)) 
            {
                MessageBox.Show("Please Enter ID to search");
                return;
            }

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("File not found");
                    return;
                }

                foreach (var line in File.ReadAllLines(filePath))
                {
                    var p = line.Split('|');
                    if (p.Length == 7 && p[0].Trim().Equals(id, StringComparison.OrdinalIgnoreCase))
                    {
                        LoadIntoForm(p[0].Trim(), p[1].Trim(), p[2].Trim(), p[3].Trim(), p[4].Trim());
                        return;
                    }
                }

                MessageBox.Show($"No animal found with ID {id} Not Found");
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}