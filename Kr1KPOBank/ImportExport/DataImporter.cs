using System;
using System.IO;

namespace Kr1kpo.ImportExport
{
    public abstract class DataImporter
    {
        public void Import(string filePath)
        {
            string data = File.ReadAllText(filePath);
            var parsedData = ParseData(data);
            ProcessData(parsedData);
        }

        protected abstract object ParseData(string data);

        protected virtual void ProcessData(object parsedData)
        {
            Console.WriteLine("Данные успешно обработаны.");
        }
    }
}