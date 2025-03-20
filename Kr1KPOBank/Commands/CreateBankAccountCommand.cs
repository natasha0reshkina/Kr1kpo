using System;
using Kr1kpo.Facades;
using Kr1kpo.Domain;

namespace Kr1kpo.Commands
{
    public class CreateBankAccountCommand : ICommand
    {
        private readonly BankAccountFacade _facade;
        private readonly string _name;
        private readonly decimal _initialBalance;

        public BankAccount CreatedAccount { get; private set; }

        public CreateBankAccountCommand(BankAccountFacade facade, string name, decimal initialBalance)
        {
            _facade = facade;
            _name = name;
            _initialBalance = initialBalance;
        }

        public void Execute()
        {
            CreatedAccount = _facade.CreateAccount(_name, _initialBalance);
            System.Console.WriteLine($"Счет '{CreatedAccount.Name}' создан. Баланс: {CreatedAccount.Balance}");
        }
    }
}