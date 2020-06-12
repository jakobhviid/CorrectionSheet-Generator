using System.Text;
using System;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CorrectionSheet_Generator {
    static class StreamWriterHelpers {
        public static StreamWriter GenerateSubHeader(this StreamWriter outputFile, string title) {
            outputFile.WriteLine("-----------------------------------");
            outputFile.WriteLine(title + ":");
            outputFile.WriteLine("-----------");
            return outputFile;
        }

        public static StreamWriter GenerateHeader(this StreamWriter outputFile, string title) {
            outputFile.WriteLine("|***************************************************************************");
            outputFile.WriteLine("| " + title);
            outputFile.WriteLine("|***************************************************************************");
            return outputFile;
        }

        public static StreamWriter GenerateNewLines(this StreamWriter outputFile, int number) {
            for (int i = 0; i < number; i++)
            {
                outputFile.WriteLine("");
            }
            return outputFile;
        }
    }
}