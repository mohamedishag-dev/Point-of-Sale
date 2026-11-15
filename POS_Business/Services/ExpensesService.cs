using POS_Business.DTOs.Expenses;
using POS_Business.Interfaces;
using POS_DataAccess.Interfaces;
using POS_DataAccess.Models;
using System.Data;

namespace POS_Business.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpenseRepository _repo;
        public ExpensesService(IExpenseRepository expensesRepository) => _repo = expensesRepository;

        public bool AddExpense(ExpenseDto expenseDto)
        {
            if (expenseDto == null) return false;

            Expense expense = new Expense
            {
                ExpenseType = expenseDto.ExpenseType,
                ExpenseDate = expenseDto.ExpenseDate,
                Amount = expenseDto.Amount,
                Notes = expenseDto.Notes,
                UserID = expenseDto.UserID
            };
            expense.ExpenseID = _repo.AddExpense(expense);

            return expense.ExpenseID > 0;
        }
        public bool UpdateExpense(ExpenseDto expenseDto)
        {
            if (expenseDto == null) return false;

            Expense expense = new Expense
            {
                ExpenseType = expenseDto.ExpenseType,
                ExpenseDate = expenseDto.ExpenseDate,
                Amount = expenseDto.Amount,
                Notes = expenseDto.Notes,
                UserID = expenseDto.UserID
            };

            return _repo.UpdateExpense(expense);

        }
        public DataTable GetAllExpenses() => _repo.GetAllExpenses();
        public bool DeleteExpense(int expenseID) => _repo.DeleteExpense(expenseID);


    }
}
