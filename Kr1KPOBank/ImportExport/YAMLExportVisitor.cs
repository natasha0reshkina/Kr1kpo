using System;
using Kr1kpo.Domain;

namespace Kr1kpo.ImportExport
{
    public class YAMLExportVisitor : IDataExportVisitor
    {
        public void Export(BankAccount account)
        {
            Console.WriteLine($"Id: {account.Id}\nName: {account.Name}\nBalance: {account.Balance}");
        }

        public void Export(Category category)
        {
            Console.WriteLine($"Id: {category.Id}\nType: {category.Type}\nName: {category.Name}");
        }

        public void Export(Operation operation)
        {
            Console.WriteLine($"Id: {operation.Id}\nType: {operation.Type}\nBankAccountId: {operation.BankAccountId}\nAmount: {operation.Amount}\nDate: {operation.Date}\nCategoryId: {operation.CategoryId}\nDescription: {operation.Description}");
        }
    }
}