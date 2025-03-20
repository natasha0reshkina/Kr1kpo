using System;
using Kr1kpo.Domain;

namespace Kr1kpo.ImportExport
{
    public class CSVExportVisitor : IDataExportVisitor
    {
        public void Export(BankAccount account)
        {
            Console.WriteLine($"{account.Id}, {account.Name}, {account.Balance}");
        }

        public void Export(Category category)
        {
            Console.WriteLine($"{category.Id}, {category.Type}, {category.Name}");
        }

        public void Export(Operation operation)
        {
            Console.WriteLine($"{operation.Id}, {operation.Type}, {operation.BankAccountId}, {operation.Amount}, {operation.Date}, {operation.CategoryId}, {operation.Description}");
        }
    }
}