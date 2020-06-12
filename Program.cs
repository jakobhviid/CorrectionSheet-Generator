using System.Text;
using System;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CorrectionSheet_Generator {
    class Program {
        static void Main(string[] args) {
            string encoding = "iso-8859-1"; // iso-8859-1

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

            //TODO: Write correct encoding based - Convert ISO-8859-1 to... UTF8?
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "evaluation.txt")))
            {
                outputFile.WriteLine("|***************************************************************************");
                outputFile.WriteLine("| Generated Evaluation Sheet for the DM and VOP Course");
                outputFile.WriteLine("|***************************************************************************");
                outputFile.WriteLine("");
                
                foreach (var student in students) {
                    outputFile.WriteLine("|***************************************************************************");
                    outputFile.WriteLine("| #" +student.StudentNumber + " - " + student.Name);
                    outputFile.WriteLine("|***************************************************************************");
                    outputFile.WriteLine("-----------------------------------");
                    outputFile.WriteLine("General Comments:");
                    outputFile.WriteLine("-----------");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("-----------------------------------");
                    outputFile.WriteLine("DM - Assignment 1 - Subtask 2:");
                    outputFile.WriteLine("-----------");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("-----------------------------------");
                    outputFile.WriteLine("DM - Assignment 1 - Subtask 2:");
                    outputFile.WriteLine("-----------");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("-----------------------------------");
                    outputFile.WriteLine("DM - Assignment 1 - Subtask 3");
                    outputFile.WriteLine("-----------");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("-----------------------------------");
                    outputFile.WriteLine("DM - Assignment 2");
                    outputFile.WriteLine("-----------");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("-----------------------------------");
                    outputFile.WriteLine("DM - Assignment 3 - Subtask 1");
                    outputFile.WriteLine("-----------");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("-----------------------------------");
                    outputFile.WriteLine("DM - Assignment 3 - Subtask 2");
                    outputFile.WriteLine("-----------");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("-----------------------------------");
                    outputFile.WriteLine("DM - Final Assessment");
                    outputFile.WriteLine("-----------");
                    outputFile.WriteLine("");
                    outputFile.WriteLine("");
                }
            }
        }
    }
}
