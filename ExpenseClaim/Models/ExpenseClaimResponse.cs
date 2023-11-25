namespace ExpenseClaimApplication.ExpenseClaim.Models
{
    public class ExpenseClaimResponse
    {
        public string? CostCentre { get; set; }
        public decimal TotalExcludingTax { get; set; }
        public decimal SalesTax { get; set; }
        public List<Dictionary<string, string>>? ExtractedData { get; set; }
    }
}
