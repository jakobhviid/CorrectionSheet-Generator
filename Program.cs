using System;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CorrectionSheet_Generator {
    class Program {
        static void Main(string[] args) {
            // https://joshclose.github.io/CsvHelper/getting-started
            
            var reader = new StreamReader("path\\to\\file.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var students = csv.GetRecords<DigitalEksamenModel>();
            
        }
    }
}
