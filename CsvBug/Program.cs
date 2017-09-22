using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace CsvBug
{
    class Program
    {
        const string CsvOk = "Name\r\nA B\r\n";
        const string CsvOk2 = "Name\r\nA-B";
        const string CsvNotOk = "Name\r\nA B";

        static void Main(string[] args)
        {
            Console.WriteLine("Ok");
            ReadCsv(CsvOk);

            Console.WriteLine("Ok");
            ReadCsv(CsvOk2);

            Console.WriteLine("Will fail");
            ReadCsv(CsvNotOk);
            Console.WriteLine("Is it fixed?");
        }

        private static void ReadCsv(string content)
        {
            var csvConfig = new Configuration
            {
                TrimOptions = TrimOptions.Trim
            };

            var records = new List<Row>();
            using (var fileStream = new StringReader(content))
            {
                using (var reader = new CsvReader(fileStream, csvConfig))
                {
                    records.AddRange(reader.GetRecords<Row>());
                }
            }
        }

        public class Row
        {
            public string Name { get; set; }
        }
    }


}
