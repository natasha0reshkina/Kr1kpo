using System;
using Kr1kpo.Domain;
using Kr1kpo.Repositories;
using Kr1kpo.Facades;
using Kr1kpo.Commands;

namespace FinancialAccounting
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bankRepo = new BankAccountRepository();
            var categoryRepo = new CategoryRepository();
            var operationRepo = new OperationRepository();

            var bankFacade = new BankAccountFacade(bankRepo);
            var categoryFacade = new CategoryFacade(categoryRepo);
            var operationFacade = new OperationFacade(operationRepo, bankRepo);
            var analyticsFacade = new AnalyticsFacade(operationRepo);

            Console.WriteLine("Добро пожаловать в модуль 'Учет финансов'");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Создать счет");
                Console.WriteLine("2. Создать категорию");
                Console.WriteLine("3. Создать операцию");
                Console.WriteLine("4. Показать все счета");
                Console.WriteLine("5. Показать все категории");
                Console.WriteLine("6. Показать все операции");
                Console.WriteLine("7. Аналитика: разница доходов и расходов за период");
                Console.WriteLine("8. Выход");

                Console.Write("Ваш выбор: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (input)
                    {
                        case "1":
                            Console.Write("Введите название счета: ");
                            string accName = Console.ReadLine();
                            Console.Write("Введите начальный баланс: ");
                            decimal balance = decimal.Parse(Console.ReadLine());
                            ICommand createAccountCmd = new CreateBankAccountCommand(bankFacade, accName, balance);
                            ICommand timedCmd = new TimingCommandDecorator(createAccountCmd);
                            timedCmd.Execute();
                            break;

                        case "2":
                            Console.Write("Введите название категории: ");
                            string catName = Console.ReadLine();
                            Console.Write("Введите тип (0 - Income, 1 - Expense): ");
                            int catTypeNum = int.Parse(Console.ReadLine());
                            CategoryType catType = (CategoryType)catTypeNum;
                            var category = categoryFacade.CreateCategory(catType, catName);
                            Console.WriteLine($"Категория '{category.Name}' создана с Id: {category.Id}");
                            break;

                        case "3":
                            Console.Write("Введите Id счета: ");
                            Guid accountId = Guid.Parse(Console.ReadLine());
                            Console.Write("Введите Id категории: ");
                            Guid categoryId = Guid.Parse(Console.ReadLine());
                            Console.Write("Введите тип операции (0 - Income, 1 - Expense): ");
                            int opTypeNum = int.Parse(Console.ReadLine());
                            OperationType opType = (OperationType)opTypeNum;
                            Console.Write("Введите сумму операции: ");
                            decimal opAmount = decimal.Parse(Console.ReadLine());
                            Console.Write("Введите описание (необязательно): ");
                            string description = Console.ReadLine();
                            DateTime opDate = DateTime.Now;

                            var op = operationFacade.CreateOperation(opType, accountId, opAmount, opDate, categoryId, description);
                            Console.WriteLine($"Операция создана с Id: {op.Id}");
                            break;

                        case "4":
                            Console.WriteLine("Список счетов:");
                            foreach (var acc in bankFacade.GetAllAccounts())
                            {
                                Console.WriteLine($"Id: {acc.Id} | Название: {acc.Name} | Баланс: {acc.Balance}");
                            }
                            break;

                        case "5":
                            Console.WriteLine("Список категорий:");
                            foreach (var cat in categoryFacade.GetAllCategories())
                            {
                                Console.WriteLine($"Id: {cat.Id} | Название: {cat.Name} | Тип: {cat.Type}");
                            }
                            break;

                        case "6":
                            Console.WriteLine("Список операций:");
                            foreach (var oper in operationFacade.GetAllOperations())
                            {
                                Console.WriteLine($"Id: {oper.Id} | Тип: {oper.Type} | Счет: {oper.BankAccountId} | Сумма: {oper.Amount} | Дата: {oper.Date}");
                            }
                            break;

                        case "7":
                            Console.Write("Введите дату начала (например, 2023-01-01): ");
                            DateTime start = DateTime.Parse(Console.ReadLine());
                            Console.Write("Введите дату окончания (например, 2023-12-31): ");
                            DateTime end = DateTime.Parse(Console.ReadLine());
                            decimal diff = analyticsFacade.CalculateIncomeExpenseDifference(start, end);
                            Console.WriteLine($"Разница доходов и расходов за выбранный период: {diff}");
                            break;

                        case "8":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Неверный выбор, попробуйте снова.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }

            Console.WriteLine("Работа приложения завершена.");
        }
    }
}
