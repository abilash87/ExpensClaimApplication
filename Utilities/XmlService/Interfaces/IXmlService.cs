using ExpenseClaimApplication.Utilities.XmlService.Model;

namespace ExpenseClaimApplication.Utilities.Interfaces
{
    public interface IXmlService
    {
        List<Dictionary<string, string>> ExtractTagsAndValues(string inputText);
    }
}
