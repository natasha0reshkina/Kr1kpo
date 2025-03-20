using System;

namespace Kr1kpo.Domain
{
    public enum OperationType { Income, Expense }

    public class Operation
    {
        public Guid Id { get; }
        public OperationType Type { get; set; }
        public Guid BankAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public Operation(Guid id, OperationType type, Guid bankAccountId, decimal amount, DateTime date, Guid categoryId, string description = "")
        {
            if (amount < 0)
                throw new ArgumentException("Сумма операции не может быть отрицательной.");
            Id = id;
            Type = type;
            BankAccountId = bankAccountId;
            Amount = amount;
            Date = date;
            CategoryId = categoryId;
            Description = description;
        }
    }
}