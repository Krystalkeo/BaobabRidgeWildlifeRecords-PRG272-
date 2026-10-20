using System;
using System.Globalization;
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtAnimalID.Text.Trim().ToUpper();
                string name = txtName.Text.Trim();
                string species = txtSpecies.Text.Trim();
                string ageText = txtAge.Text.Trim();
                string scoreText = txtRecoveryScore.Text.Trim();

                // Validate Name
                if (string.IsNullOrEmpty(name) || name.Length > 30 || name.Contains("|"))
                {
                    MessageBox.Show("Validation failed: Invalid Name.", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate Species
                if (string.IsNullOrEmpty(species) || species.Length > 30 || species.Contains("|"))
                {
                    MessageBox.Show("Validation failed: Invalid Species.", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate Age
                if (!int.TryParse(ageText, out int age) || age < 0 || age > 100)
                {
                    MessageBox.Show("Validation failed: Invalid Age.", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate Recovery Score
                if (!int.TryParse(scoreText, out int score) || score < 0 || score > 100)
                {
                    MessageBox.Show("Validation failed: Invalid Score.", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
        }// Handles deleting a selected animal record
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = txtAnimalID.Text.Trim().ToUpper();

                // Check if a record is selected (ID box should be disabled/locked when selected)
                if (string.IsNullOrEmpty(id) || txtAnimalID.Enabled)
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
                            found = true; 
                            continue;
                        }
                        updatedLines.Add(line);
                    }

                    if (found)
                    {
                        File.WriteAllLines(filePath, updatedLines);
                        LoadAnimalsToGrid();

                        MessageBox.Show("Animal record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear inputs 
                        txtAnimalID.Clear();
                        txtName.Clear();
                        txtSpecies.Clear();
                        txtAge.Clear();
                        txtRecoveryScore.Clear();
                        txtAnimalID.Enabled = true;
                        txtAnimalID.Focus();
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
        }//////End of delete button click 
        // Loads selected grid row data into textboxes for editing
        private void btnDelete_Click(object sender, EventArgs e)
        {
        }//////End of delete button click 
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

                // Lock the ID field during updates so the primary key cannot be changed
                txtAnimalID.Enabled = false;
            }
        }

        // Dummy event handler to support designer references 
        private void lblSpecies_Click(object sender, EventArgs e)
        {
        }
        // Filters the DataGridView dynamically as text is typed into the search box
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "animals.txt";
                List<string> lines = new List<string>();

                if (File.Exists(filePath))
                {
                    // Read all lines into a List; File.
                    lines = File.ReadAllLines(filePath).ToList();
                }

                int totalAnimals = 0;
                double totalAge = 0;
                double totalScore = 0;

                // Use OrdinalIgnoreCase so status lookups are case-insensitive (e.g. "stable" and "Stable" both count)
                Dictionary<string, int> statusCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
                    {
                        { "Critical", 0 },
                        { "Serious", 0 },
                        { "Stable", 0 },
                        { "Recovering", 0 },
                        { "Release-Ready", 0 }
                    };

                foreach (string line in lines)
                {
                    // Split the line using the pipe character '|' as a custom delimiter separating each data field
                    string[] parts = line.Split('|');
                    // Expected format: ID | Name | Species | Age | Score | Status | Housing Unit
                    if (parts.Length >= 7)
                    {
                        // Use TryParse to safely validate numbers and prevent crashes 
                        if (int.TryParse(parts[3], out int age) && int.TryParse(parts[4], out int score))
                        {
                            totalAnimals++;
                            totalAge += age;
                            totalScore += score;

                            string status = parts[5].Trim();
                            if (statusCounts.ContainsKey(status))
                            {
                                statusCounts[status]++;
                            }
                        }
                    }
                }

                // Calculate averages using InvariantCulture to ensure full stop decimal separator
                string avgAgeStr = totalAnimals > 0 ? (totalAge / totalAnimals).ToString("0.00", CultureInfo.InvariantCulture) : "N/A";
                string avgScoreStr = totalAnimals > 0 ? (totalScore / totalAnimals).ToString("0.00", CultureInfo.InvariantCulture) : "N/A";

                // Display results on some labels
                lblTotalAnimals.Text = $"Total Animals: {totalAnimals}";
                lblAvgAge.Text = $"Average Age: {avgAgeStr}";
                lblAvgScore.Text = $"Average Recovery Score: {avgScoreStr}";

                lblCriticalCount.Text = $"Critical: {statusCounts["Critical"]}";
                lblSeriousCount.Text = $"Serious: {statusCounts["Serious"]}";
                lblStableCount.Text = $"Stable: {statusCounts["Stable"]}";
                lblRecoveringCount.Text = $"Recovering: {statusCounts["Recovering"]}";
                lblReleaseReadyCount.Text = $"Release-Ready: {statusCounts["Release-Ready"]}";

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                List<string> summaryLines = new List<string>
                        {
                        "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE",
                        "ANIMAL SUMMARY REPORT",
                        $"Generated: {timestamp}",
                        "----------------------------------------",
                        $"Total animals:            {totalAnimals}",
                        $"Average age (years):      {avgAgeStr}",
                        $"Average recovery score:   {avgScoreStr}",
                        "----------------------------------------",
                        "Animals per status:",
                        $" Critical:               {statusCounts["Critical"]}",
                        $" Serious:                {statusCounts["Serious"]}",
                        $" Stable:                 {statusCounts["Stable"]}",
                        $" Recovering:             {statusCounts["Recovering"]}",
                        $" Release-Ready:          {statusCounts["Release-Ready"]}"
                        };

                // Overwrite summary.txt
                File.WriteAllLines("summary.txt", summaryLines);

                MessageBox.Show("Summary report generated and saved successfully to summary.txt.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied while writing summary.txt.",
                    "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("Could not write summary.txt because it is in use by another program.",
                    "File In Use", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the summary: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
