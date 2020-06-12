using System.Text;
using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using System.Collections.Generic;

namespace CorrectionSheet_Generator {
    static class Helpers {
        public static StreamWriter GenerateHeader(this StreamWriter outputFile, string title) {
            outputFile.WriteLine("|***************************************************************************");
            outputFile.WriteLine("| " + title);
            outputFile.WriteLine("|***************************************************************************");
            return outputFile;
        }

        public static StreamWriter GenerateSubHeader(this StreamWriter outputFile, string title) {
            outputFile.WriteLine("-----------------------------------");
            outputFile.WriteLine("| " + title + ":");
            outputFile.WriteLine("-----------");
            return outputFile;
        }

        public static StreamWriter GenerateGradingScale(this StreamWriter outputFile, int pointsPossible) {
            outputFile.WriteLine("| Points Possible: " + pointsPossible + "; Points Given: ");
            outputFile.WriteLine("----");
            return outputFile;
        }

        public static StreamWriter GenerateAssignment(this StreamWriter outputFile, string title, int pointsPossible) {
            outputFile.GenerateSubHeader(title).GenerateGradingScale(pointsPossible).GenerateNewLines(3);
            return outputFile;
        }

        public static StreamWriter GenerateSection(this StreamWriter outputFile, string title) {
            outputFile.GenerateSubHeader(title).GenerateNewLines(3);
            return outputFile;
        }

        public static StreamWriter GenerateNewLines(this StreamWriter outputFile, int number) {
            for (int i = 0; i < number; i++)
            {
                outputFile.WriteLine("");
            }
            return outputFile;
        }

        public static void PreprocessCSV(string csvFile, string encoding){
            var lines = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), csvFile), Encoding.GetEncoding(encoding)).ReadToEnd().Replace("\"", String.Empty).Replace("=", String.Empty);
            var preprocessedDataFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "preprocessed.csv"));
            preprocessedDataFile.Write(lines);
            preprocessedDataFile.Close();
        }

        public static IEnumerable<DigitalEksamenModel> ReadCSVFile (string encoding) {
            var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "preprocessed.csv"), Encoding.GetEncoding(encoding));
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.MissingFieldFound = null;
            csv.Configuration.Delimiter = ";";
            csv.Configuration.Encoding = Encoding.GetEncoding(encoding);
            return csv.GetRecords<DigitalEksamenModel>();
        }
    }
}