using System;
using Kr1kpo.Domain;

namespace Kr1kpo.Domain
{
    public static class DomainObjectFactory
    {
        public static BankAccount CreateBankAccount(string name, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название счета не может быть пустым.");
            if (initialBalance < 0)
                throw new ArgumentException("Начальный баланс не может быть отрицательным.");

            return new BankAccount(Guid.NewGuid(), name, initialBalance);
        }

        public static Category CreateCategory(CategoryType type, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название категории не может быть пустым.");
            return new Category(Guid.NewGuid(), type, name);
        }

        public static Operation CreateOperation(OperationType type, Guid bankAccountId, decimal amount, DateTime date, Guid categoryId, string description = "")
        {
            if (amount < 0)
                throw new ArgumentException("Сумма операции не может быть отрицательной.");
            return new Operation(Guid.NewGuid(), type, bankAccountId, amount, date, categoryId, description);
        }
    }
}