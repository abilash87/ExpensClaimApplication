using ExpenseClaimApplication.ExpenseClaim.Models;
using ExpenseClaimApplication.Helpers;
using ExpenseClaimApplication.Model;
using ExpenseClaimApplication.Utilities.Constants;
using ExpenseClaimApplication.Utilities.Interfaces;

namespace ExpenseClaimApplication.ExpenseClaim.ExpenseClaimServices
{
    public class ExpenseClaimService : IExpenseClaimService
    {
        private readonly IXmlService _xmlService;
        public ExpenseClaimService(IXmlService xmlService)
        {
            _xmlService = xmlService ?? throw new ArgumentNullException(nameof(xmlService));
        }
        public ApiResponse<ExpenseClaimResponse> ExpenseClaim(string inputText)
        {
            try
            {
                if (string.IsNullOrEmpty(inputText)) return new ApiResponse<ExpenseClaimResponse>(null, false, Messages.ErrorInputText);
                var extractedData = _xmlService.ExtractTagsAndValues(inputText);
                if (extractedData == null) return new ApiResponse<ExpenseClaimResponse>(null, false, Messages.ErrorInputText);
                if (!DictionaryHelper.KeyExistsInListOfDictionaries(extractedData, "total"))
                {
                    return new ApiResponse<ExpenseClaimResponse>(null, false, Messages.ErrorMissingTotal);
                }
                string? costCentre = DictionaryHelper.KeyExistsInListOfDictionaries(extractedData, "cost_centre") ? DictionaryHelper.GetValuesFromKey(extractedData, "cost_centre") : null;
                decimal totalIncludingTax = 1;
                decimal salesTax = CalculateSalesTax(totalIncludingTax); // Assuming 20% sales tax
                decimal totalExcludingTax = totalIncludingTax - salesTax;
                var responseData = new ExpenseClaimResponse
                {
                    CostCentre = !string.IsNullOrEmpty(costCentre) ? costCentre : Messages.DefaultCostCentre,
                    TotalExcludingTax = totalExcludingTax,
                    SalesTax = salesTax,
                    ExtractedData = extractedData
                };
                return new ApiResponse<ExpenseClaimResponse>(responseData);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ExpenseClaimResponse>(null, false, $"An error occurred: {ex.Message}");
            }

        }
        private decimal CalculateSalesTax(decimal total)
        {
            // Assuming 20% sales tax
            return total * 0.2m;
        }


    }

}
