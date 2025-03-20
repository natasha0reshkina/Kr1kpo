using System;

namespace Kr1kpo.ImportExport
{
    public class CSVDataImporter : DataImporter
    {
        protected override object ParseData(string data)
        {
            Console.WriteLine("Парсинг CSV данных...");
            return data.Split(new char[] { ',' });
        }
    }
}