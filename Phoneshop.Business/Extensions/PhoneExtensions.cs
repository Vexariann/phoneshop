namespace Phoneshop.Business.Extensions
{
    public static class PhoneExtensions
    {
        // kijken naar tuple, anonymous object, mini class
        // result class
        public static bool IsValid(this List<string> inputFields, out string message)
        {
            message = null;

            foreach (var textbox in inputFields)
            {
                if (string.IsNullOrWhiteSpace(textbox))
                {
                    message = $"One or more fields are empty!";
                    return false;
                }
            }
            bool price = decimal.TryParse(inputFields[3], out decimal priceResult);
            bool stock = int.TryParse(inputFields[4], out int stockResult);
            if (price && stock && priceResult >= 0 && stockResult >= 0)
                return true;
            else
            {
                message = "Price or Stock fields do not have valid numbers.";
                return false;
            }
        }
    }
}
