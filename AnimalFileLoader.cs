using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace BaobabRidgeWildlifeRecords
{
     
    /// keeps the Status and Housing Unit exactly as stored in the file.
    
    public class AnimalRecord
    {
        public string AnimalID { get; }
        public string Name { get; }
        public string Species { get; }
        public int Age { get; }
        public int RecoveryScore { get; }
        public string Status { get; }
        public string HousingUnit { get; }

        public AnimalRecord(string id, string name, string species, int age,
            int score, string status, string housingUnit)
        {
            AnimalID = id;
            Name = name;
            Species = species;
            Age = age;
            RecoveryScore = score;
            Status = status;
            HousingUnit = housingUnit;
        }
    }

    
    public static class AnimalFileLoader
    {
        ///A valid Animal ID is "WR-" followed by exactly four digits (for example WR-0001)
        public static readonly Regex IdPattern = new Regex(@"^WR-\d{4}$");

        
        /// Attempts to parse a single line from animals.txt.
        /// Returns false when the line is malformed: it does not have seven
        
        public static bool TryParseLine(string line, out AnimalRecord? record)
        {
            record = null;

            // Blank lines and lines that are not made of exactly seven fields are malformed.
            if (string.IsNullOrWhiteSpace(line)) return false;

            string[] parts = line.Split('|');
            if (parts.Length != 7) return false;

            string id = parts[0].Trim();
            string name = parts[1].Trim();
            string species = parts[2].Trim();
            string ageText = parts[3].Trim();
            string scoreText = parts[4].Trim();
            string status = parts[5].Trim();
            string housingUnit = parts[6].Trim();

            // The ID must match the WR-#### pattern and Age/Score must be whole numbers.
            if (!IdPattern.IsMatch(id)) return false;
            if (!int.TryParse(ageText, out int age)) return false;
            if (!int.TryParse(scoreText, out int score)) return false;

            record = new AnimalRecord(id, name, species, age, score, status, housingUnit);
            return true;
        }


        /// Loads every valid record from the given file, preserving the order in
        /// which the records appear in the file. When the file does not exist an
        /// empty file is created and an empty list is returned (no error).
        /// Malformed lines are skipped; the number skipped is reported through  <paramref name="skippedCount"/>
        public static List<AnimalRecord> Load(string filePath, out int skippedCount)
        {
            skippedCount = 0;
            var records = new List<AnimalRecord>();

            // Missing file: create it empty and return an empty list without an error.
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
                return records;
            }

            foreach (string line in File.ReadAllLines(filePath))
            {
                // Blank lines are not records; ignore them silently.
                if (string.IsNullOrWhiteSpace(line)) continue;

                if (TryParseLine(line, out AnimalRecord? record) && record != null)
                {
                    records.Add(record);
                }
                else
                {
                    skippedCount++;
                }
            }

            return records;
        }
    }
}
