using System;
using System.Collections.Generic;
using Kr1kpo.Domain;

namespace Kr1kpo.Repositories
{
    public class CategoryRepository
    {
        private readonly Dictionary<Guid, Category> _cache = new Dictionary<Guid, Category>();

        public void Add(Category category) => _cache[category.Id] = category;

        public void Update(Category category) => _cache[category.Id] = category;

        public void Delete(Guid id) => _cache.Remove(id);

        public Category GetById(Guid id) => _cache.ContainsKey(id) ? _cache[id] : null;

        public IEnumerable<Category> GetAll() => _cache.Values;
    }
}