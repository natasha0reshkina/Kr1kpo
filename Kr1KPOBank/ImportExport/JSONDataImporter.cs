using System;

namespace Kr1kpo.ImportExport
{
    public class JSONDataImporter : DataImporter
    {
        protected override object ParseData(string data)
        {
            Console.WriteLine("Парсинг JSON данных...");
            return data; // Симуляция парсинга
        }
    }
}