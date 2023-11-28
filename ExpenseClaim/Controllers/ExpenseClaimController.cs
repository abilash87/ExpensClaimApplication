using ExpenseClaimApplication.ExpenseClaim.ExpenseClaimServices;
using ExpenseClaimApplication.ExpenseClaim.Models;
using ExpenseClaimApplication.Model;
using ExpenseClaimApplication.Utilities.Interfaces;
using ExpenseClaimApplication.Utilities.XmlService;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseClaimApplication.ExpenseClaim.Controllers
{
    [Route("api/ExpenseClaim")]
    [ApiController]
    public class ExpenseClaimController : ControllerBase
    {
        private readonly IExpenseClaimService _expenseClaimService;
        public ExpenseClaimController(IExpenseClaimService expenseClaimService)
        {
            _expenseClaimService = expenseClaimService ?? throw new ArgumentNullException(nameof(expenseClaimService));
        }
        // POST api/<ExpenseClaimController>
        [HttpPost]
        public ActionResult Post([FromBody] ExpenseClaimRequest expenseClaimRequest)
        {
            var result = _expenseClaimService.ExpenseClaim(expenseClaimRequest.Text);
            return Ok(result);
        }


    }
}
