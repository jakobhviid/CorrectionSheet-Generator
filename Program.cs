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
                    .GenerateAssignment("Assignment 1 - Subtask 1", 12)
                    .GenerateAssignment("Assignment 1 - Subtask 2", 12)
                    .GenerateAssignment("Assignment 1 - Subtask 3", 6)
                    .GenerateAssignment("Assignment 2", 12)
                    .GenerateAssignment("Assignment 3 - Subtask 1", 6)
                    .GenerateAssignment("Assignment 3 - Subtask 2", 6)
                    .GenerateAssignment("Final Assessment", 60)
                    .GenerateSection("Feedback");
            }
        }
    }
}
