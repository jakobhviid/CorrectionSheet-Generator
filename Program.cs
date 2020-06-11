using System;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CorrectionSheet_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("path\\to\\file.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {    
                var records = csv.GetRecords<Foo>();
            }
        }
    }
}
