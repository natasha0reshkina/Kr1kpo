using System;
using System.Collections.Generic;
using Kr1kpo.Domain;

namespace Kr1kpo.Repositories
{
    public class OperationRepository
    {
        private readonly Dictionary<Guid, Operation> _cache = new Dictionary<Guid, Operation>();

        public void Add(Operation op) => _cache[op.Id] = op;

        public void Update(Operation op) => _cache[op.Id] = op;

        public void Delete(Guid id) => _cache.Remove(id);

        public Operation GetById(Guid id) => _cache.ContainsKey(id) ? _cache[id] : null;

        public IEnumerable<Operation> GetAll() => _cache.Values;
    }
}