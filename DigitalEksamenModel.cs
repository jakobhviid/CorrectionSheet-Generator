using System;
using CsvHelper.Configuration.Attributes;

namespace CorrectionSheet_Generator
{
    class DigitalEksamenModel
    {
        [Index(0)]
        public string StudentNumber { get; set; }
        [Index(1)]
        public string Name { get; set; }
        [Index(2)]
        public string Grade { get; set; }
        [Index(3)]
        public string OralExamStartDate { get; set; }
        [Index(4)]
        public string OralExamStartTime { get; set; }
        [Index(5)]
        public string OralExamEndTime { get; set; }
        [Index(6)]
        public string OralExamLocale { get; set; }
    }
}