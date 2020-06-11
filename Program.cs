using System.Text;
using System;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CorrectionSheet_Generator {
    class Program {
        static void Main(string[] args) {
            string encoding = "iso-8859-1"; // iso-8859-1

            // https://joshclose.github.io/CsvHelper/getting-started
            var lines = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "sample-studerende.csv"), Encoding.GetEncoding(encoding)).ReadToEnd().Replace("\"", String.Empty).Replace("=", String.Empty);
            var preprocessedDataFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "preprocessed.csv"));
            preprocessedDataFile.Write(lines);
            preprocessedDataFile.Close();

            var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "preprocessed.csv"), Encoding.GetEncoding(encoding));
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.MissingFieldFound = null;
            csv.Configuration.Delimiter = ";";
            csv.Configuration.Encoding = Encoding.GetEncoding(encoding);
            var students = csv.GetRecords<DigitalEksamenModel>();

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "EVALUATION-DOCUMENT.md")))
            {
                outputFile.WriteLine("# Generated Evaluation Sheet for the DM and VOP Course");
                outputFile.WriteLine("");
                
                foreach (var student in students) {
                    outputFile.WriteLine("## " + student.Name + " with #StudentNumber " + student.StudentNumber);
                    outputFile.WriteLine("");
                    outputFile.WriteLine("### General Comments");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("### Assignment 1 - Subtask 2");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("- Bulletpoint here");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("### Assignment 1 - Subtask 2");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("- Bulletpoint here");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("### Assignment 1 - Subtask 2");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("- Bulletpoint here");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("### Assignment 1 - Subtask 2");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("- Bulletpoint here");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("### Assignment 1 - Subtask 2");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("- Bulletpoint here");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("### Assignment 1 - Subtask 2");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("- Bulletpoint here");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("### Final Assessment");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("- Bulletpoint here");
                    outputFile.WriteLine("");
                }
            }
        }
    }
}
