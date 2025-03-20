using System;
using System.Collections.Generic;
using Kr1kpo.Domain;
using Kr1kpo.Repositories;

namespace Kr1kpo.Facades
{
    public class OperationFacade
    {
        private readonly OperationRepository _repo;
        private readonly BankAccountRepository _bankRepo;

        public OperationFacade(OperationRepository opRepo, BankAccountRepository bankRepo)
        {
            _repo = opRepo;
            _bankRepo = bankRepo;
        }

        public Operation CreateOperation(OperationType type, Guid bankAccountId, decimal amount, DateTime date, Guid categoryId, string description = "")
        {
            var operation = DomainObjectFactory.CreateOperation(type, bankAccountId, amount, date, categoryId, description);
            var account = _bankRepo.GetById(bankAccountId);
            if (account == null)
                throw new Exception("Счет не найден.");

            if (type == OperationType.Income)
                account.Deposit(amount);
            else if (type == OperationType.Expense)
                account.Withdraw(amount);

            _repo.Add(operation);
            return operation;
        }

        public void UpdateOperation(Operation operation) => _repo.Update(operation);

        public void DeleteOperation(Guid id) => _repo.Delete(id);

        public Operation GetOperation(Guid id) => _repo.GetById(id);

        public IEnumerable<Operation> GetAllOperations() => _repo.GetAll();
    }
}