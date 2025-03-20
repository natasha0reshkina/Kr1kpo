using System;
using System.Collections.Generic;
using System.Linq;
using Kr1kpo.Domain;
using Kr1kpo.Repositories;

namespace Kr1kpo.Facades
{
    public class AnalyticsFacade
    {
        private readonly OperationRepository _opRepo;

        public AnalyticsFacade(OperationRepository opRepo)
        {
            _opRepo = opRepo;
        }

        // Подсчет разницы между доходами и расходами за выбранный период
        public decimal CalculateIncomeExpenseDifference(DateTime start, DateTime end)
        {
            var ops = _opRepo.GetAll().Where(op => op.Date >= start && op.Date <= end);
            decimal income = ops.Where(op => op.Type == OperationType.Income).Sum(op => op.Amount);
            decimal expense = ops.Where(op => op.Type == OperationType.Expense).Sum(op => op.Amount);
            return income - expense;
        }

       
        public Dictionary<Guid, decimal> GroupByCategory(CategoryType type)
        {
            var ops = _opRepo.GetAll().Where(op => op.Type == (type == CategoryType.Income ? OperationType.Income : OperationType.Expense));
            return ops.GroupBy(op => op.CategoryId)
                .ToDictionary(g => g.Key, g => g.Sum(op => op.Amount));
        }
    }
}