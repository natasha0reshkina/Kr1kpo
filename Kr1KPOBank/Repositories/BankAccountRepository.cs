using System;
using System.Collections.Generic;
using Kr1kpo.Domain;

namespace Kr1kpo.Repositories
{
    public class BankAccountRepository
    {
        private readonly Dictionary<Guid, BankAccount> _cache = new Dictionary<Guid, BankAccount>();

        public void Add(BankAccount account) => _cache[account.Id] = account;

        public void Update(BankAccount account) => _cache[account.Id] = account;

        public void Delete(Guid id) => _cache.Remove(id);

        public BankAccount GetById(Guid id) => _cache.ContainsKey(id) ? _cache[id] : null;

        public IEnumerable<BankAccount> GetAll() => _cache.Values;
    }
}