namespace ExpenseClaimApplication.Utilities.XmlService.Model
{
    public class XmlResult
    {
        public Dictionary<string, string> ExtractedData { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}
