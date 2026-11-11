using POS_DataAccess.Models;
using System.Data;

namespace POS_Business.Services
{
    public interface IExpensesRepository
    {
        DataTable GetAllExpenses();
        int AddExpense(Expense expense);
        bool DeleteExpense(int expenseID);
        bool UpdateExpense(Expense expense);
    }
}