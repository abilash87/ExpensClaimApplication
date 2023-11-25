namespace ExpenseClaimApplication.Helpers
{
    public  static class DictionaryHelper
    {

       public static bool KeyExistsInListOfDictionaries(List<Dictionary<string, string>> listOfDictionaries, string keyToCheck)
        {
            foreach (var dictionary in listOfDictionaries)
            {
                if (dictionary.ContainsKey(keyToCheck))
                {
                    return true;
                }
            }

            return false;
        }
        public static string GetValuesFromKey(List<Dictionary<string, string>> listOfDictionaries, string keyToRetrieve)
        {
            List<string> values = new List<string>();

            foreach (var dictionary in listOfDictionaries)
            {
                if (dictionary.TryGetValue(keyToRetrieve, out string value))
                {
                    return value;
                }
            }

            return null;
        }

    }
}
