using System;
using System.Collections.Generic;
using Kr1kpo.Domain;
using Kr1kpo.Repositories;

namespace Kr1kpo.Facades
{
    public class CategoryFacade
    {
        private readonly CategoryRepository _repo;

        public CategoryFacade(CategoryRepository repo)
        {
            _repo = repo;
        }

        public Category CreateCategory(CategoryType type, string name)
        {
            var category = DomainObjectFactory.CreateCategory(type, name);
            _repo.Add(category);
            return category;
        }

        public void UpdateCategory(Category category) => _repo.Update(category);

        public void DeleteCategory(Guid id) => _repo.Delete(id);

        public Category GetCategory(Guid id) => _repo.GetById(id);

        public IEnumerable<Category> GetAllCategories() => _repo.GetAll();
    }
}