using System;
using System.Collections.Generic;
using Kr1kpo.Domain;
using Kr1kpo.Repositories;

namespace Kr1kpo.Facades
{
    public class BankAccountFacade
    {
        private readonly BankAccountRepository _repo;

        public BankAccountFacade(BankAccountRepository repo)
        {
            _repo = repo;
        }

        public BankAccount CreateAccount(string name, decimal initialBalance)
        {
            var account = DomainObjectFactory.CreateBankAccount(name, initialBalance);
            _repo.Add(account);
            return account;
        }

        public void UpdateAccount(BankAccount account) => _repo.Update(account);

        public void DeleteAccount(Guid id) => _repo.Delete(id);

        public BankAccount GetAccount(Guid id) => _repo.GetById(id);

        public IEnumerable<BankAccount> GetAllAccounts() => _repo.GetAll();
    }
}