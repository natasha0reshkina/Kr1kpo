using System;

namespace Kr1kpo.ImportExport
{
    public class YAMLDataImporter : DataImporter
    {
        protected override object ParseData(string data)
        {
            Console.WriteLine("Парсинг YAML данных...");
            return data; // Симуляция парсинга
        }
    }
}