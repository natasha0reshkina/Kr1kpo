using System;

namespace Kr1kpo.Domain
{
    public class BankAccount
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(Guid id, string name, decimal initialBalance)
        {
            Id = id;
            Name = name;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма пополнения должна быть положительной.");
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма списания должна быть положительной.");
            if (amount > Balance)
                throw new InvalidOperationException("Недостаточно средств для списания.");
            Balance -= amount;
        }
    }
}