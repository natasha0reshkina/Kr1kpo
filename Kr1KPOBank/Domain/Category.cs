using System;

namespace Kr1kpo.Domain
{
    public enum CategoryType { Income, Expense }

    public class Category
    {
        public Guid Id { get; }
        public CategoryType Type { get; set; }
        public string Name { get; set; }

        public Category(Guid id, CategoryType type, string name)
        {
            Id = id;
            Type = type;
            Name = name;
        }
    }
}