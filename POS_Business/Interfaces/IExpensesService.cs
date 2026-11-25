using POS_Business.Security.Expenses;
using System.Data;

namespace POS_Business.Interfaces
{
    public interface IExpensesService
    {
        DataTable GetAllExpenses();
        bool DeleteExpense(int expenseID);
        bool AddExpense(ExpenseDto expense);
        bool UpdateExpense(ExpenseDto expense);

    }
}
