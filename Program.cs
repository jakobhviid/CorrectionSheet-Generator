using System.Linq;
using System.IO;

namespace CorrectionSheet_Generator {
    class Program {
        static void Main(string[] args) {
            var encoding = "iso-8859-1"; // iso-8859-15 or iso-8859-1
            var csvFile = "sample-studerende.csv";
            if (args.Count() > 0 && !string.IsNullOrEmpty(args[0])) csvFile = args[0]; //if args is set, use it instead.
            Helpers.PreprocessCSV(csvFile, encoding); //preprocessing non standard csv file 
            var students = Helpers.ReadCSVFile(encoding); //reading preprocessed data to list of DigitalEksamenModel

            //writing the correction sheet for all the students
            //TODO: Write correct encoding based - Convert ISO-8859-1 to... UTF8?
            using StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "evaluation.txt"));
            outputFile.GenerateHeader("Generated Evaluation Sheet for the DM and VOP Course").GenerateNewLines(1);

            foreach (var student in students) {
                outputFile.GenerateHeader("#" + student.StudentNumber + " - " + student.Name)
                    .GenerateSection("General Comments")
                    .GenerateAssignment("Assignment 1 - Subtask 1", "22 (A1=55)")
                    .GenerateAssignment("Assignment 1 - Subtask 2", "22 (A1=55)")
                    .GenerateAssignment("Assignment 1 - Subtask 3", "11 (A1=55)")
                    .GenerateAssignment("Assignment 2", "20")
                    .GenerateAssignment("Assignment 3 - Subtask 1", "10 (A3=20)")
                    .GenerateAssignment("Assignment 3 - Subtask 2", "10 (A3=20)")
                    .GenerateAssignment("Submission", "5", "5")
                    .GenerateFinalAssessment("Final Assessment", "100", "Grading Guide: 12 = 93-100%; 10 = 79-93%; 7 = 61-79%; 4 = 46-61%; 2 = 40-46%; 00 = 10-40%; -3 = 0-10%;");
            }
        }
    }
}
