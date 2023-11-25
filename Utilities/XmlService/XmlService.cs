using ExpenseClaimApplication.Utilities.Constants;
using ExpenseClaimApplication.Utilities.Interfaces;
using ExpenseClaimApplication.Utilities.XmlService.Model;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace ExpenseClaimApplication.Utilities.XmlService
{
    public class XmlService : IXmlService
    {
        public XmlService() { }
        public List<Dictionary<string, string>> ExtractTagsAndValues(string inputText)
        {
            try
            {
                var xmlContent = ExtractXmlContent(inputText);
                var xml = XElement.Parse(xmlContent);

                var extractedXmlDataList = new List<Dictionary<string, string>>();

                foreach (var element in xml.DescendantsAndSelf())
                {
                    var extractedValues = new Dictionary<string, string>
                {
                    { element.Name.LocalName, element.Value }
                };

                    extractedXmlDataList.Add(extractedValues);
                }

                return extractedXmlDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing XML: {ex.Message}");
                return null;
            }
        }

        private string ExtractXmlContent(string inputText)
        {
            string pattern = RegexConstants.xmlParser;
            Regex regex = new Regex(pattern, RegexOptions.Singleline);
            MatchCollection matches = regex.Matches(inputText);
            string xmlContent = string.Join("", matches.Select(match => match.Value));
            return xmlContent;
        }


    }
}
