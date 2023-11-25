using ExpenseClaimApplication.ExpenseClaim.Models;
using ExpenseClaimApplication.Model;

namespace ExpenseClaimApplication.ExpenseClaim.ExpenseClaimServices
{
    public interface IExpenseClaimService
    {
        ApiResponse<ExpenseClaimResponse> ExpenseClaim(string inputText);
    }
}
