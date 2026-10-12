using System;
using System.Collections.Generic;
using System.Text;

namespace BaobabRidgeWildlifeRecords
{
 // Represents an individual animal record at Baobab Ridge Wildlife Rehabilitation Centre.
 
    public class Animal
    {
        public string AnimalID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string Status { get; set; }
        public string HousingUnit { get; set; }

        // Constructor to initialize an animal record and automatically classify status and housing unit.
        public Animal(string id, string name, string species, int age, int score)
        {
            AnimalID = id;
            Name = name;
            Species = species;
            Age = age;
            RecoveryScore = score;

            // Call the single required classification method
            ClassifyAnimal(score, out string calculatedStatus, out string calculatedHousing);
            Status = calculatedStatus;
            HousingUnit = calculatedHousing;
        }

        /// Single classification method determining Status and Housing Unit from the Recovery Score[cite: 7].
        /// Bands: 0-19 (Critical), 20-39 (Serious), 40-59 (Stable), 60-79 (Recovering), 80-100 (Release-Ready)[cite: 7].
        public static void ClassifyAnimal(int score, out string status, out string housingUnit)
        {
            if (score >= 0 && score <= 19)
            {
                status = "Critical";
                housingUnit = "Intensive Care Unit";
            }
            else if (score >= 20 && score <= 39)
            {
                status = "Serious";
                housingUnit = "High-Dependency Ward";
            }
            else if (score >= 40 && score <= 59)
            {
                status = "Stable";
                housingUnit = "Recovery Ward";
            }
            else if (score >= 60 && score <= 79)
            {
                status = "Recovering";
                housingUnit = "Outdoor Enclosure";
            }
            else if (score >= 80 && score <= 100)
            {
                status = "Release-Ready";
                housingUnit = "Pre-Release Camp";
            }
            else
            {
                status = "Unknown";
                housingUnit = "Unknown";
            }
        }
    }
}
