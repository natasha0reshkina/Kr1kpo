using System;
using Kr1kpo.Domain;

namespace Kr1kpo.ImportExport
{
    public class JSONExportVisitor : IDataExportVisitor
    {
        public void Export(BankAccount account)
        {
            Console.WriteLine($"{{ \"Id\": \"{account.Id}\", \"Name\": \"{account.Name}\", \"Balance\": {account.Balance} }}");
        }

        public void Export(Category category)
        {
            Console.WriteLine($"{{ \"Id\": \"{category.Id}\", \"Type\": \"{category.Type}\", \"Name\": \"{category.Name}\" }}");
        }

        public void Export(Operation operation)
        {
            Console.WriteLine($"{{ \"Id\": \"{operation.Id}\", \"Type\": \"{operation.Type}\", \"BankAccountId\": \"{operation.BankAccountId}\", \"Amount\": {operation.Amount}, \"Date\": \"{operation.Date}\", \"CategoryId\": \"{operation.CategoryId}\", \"Description\": \"{operation.Description}\" }}");
        }
    }
}