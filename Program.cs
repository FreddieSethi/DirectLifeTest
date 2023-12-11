using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Path to the file containing names
        string namesData = "C:\\Users\\atukfesi\\OneDrive - Allergy Therapeutics PLC\\DirectLifeTest\\Data\\names.txt";

        // Read the names from the file
        string[] names = ReadNames(namesData);

        if (names != null && names.Length > 0)
        {
            Array.Sort(names); // Sort the names alphabetically

            // Calculate the total score of all the names combined
            long totalScore = CalculateTotalNameScores(names);
            Console.WriteLine($"The total of all the name scores in the file is: {totalScore}");
        }
        else
        {
            Console.WriteLine("No names found in the file.");
        }
    }

    // Function to read names from a file
    static string[] ReadNames(string namesData)
    {
        try
        {
            // Read the content of the file
            string content = File.ReadAllText(namesData);

            // Split the content based on comma, newline, or carriage return to extract individual names
            string[] names = content.Split(new char[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return names;
        }
        catch (Exception ex)
        {
            // Display an error message if there's an issue reading the file
            Console.WriteLine($"Error reading file: {ex.Message}");
            return null;
        }
    }

    // Function to calculate the total name scores
    static long CalculateTotalNameScores(string[] names)
    {
        long totalScore = 0;

        // Calculate the score for each name and accumulate the total score
        for (int i = 0; i < names.Length; i++)
        {
            string name = names[i];
            int nameValue = GetNameValue(name); // Calculate the value of the name
            totalScore += nameValue * (i + 1); // Multiply value by its position in the sorted list
        }

        return totalScore;
    }

    // Function to calculate the value of a name
    static int GetNameValue(string name)
    {
        int value = 0;

        // Calculate the value of the name by summing up the positions of its letters in the alphabet
        foreach (char c in name.ToUpper()) // Convert to uppercase to standardize values
        {
            if (char.IsLetter(c)) // Consider only alphabetic characters
            {
                value += (int)(c - 'A') + 1; // Calculate the value based on position in the alphabet
            }
        }

        return value;
    }
}
