using System.Resources;

namespace ExpenseClaimApplication.Utilities.Constants
{
    public static class Messages
    {
        public static string ErrorOpeningTagsWithoutClosingTags = "Opening tags without corresponding closing tags. The entire message is rejected.";
        public static string ErrorMissingTotal = "Missing <total>. The entire text is rejected.";
        public static string ErrorInputText = "Please provide a vallid text";
        public static string DefaultCostCentre = "UNKNOWN";

    }
}
