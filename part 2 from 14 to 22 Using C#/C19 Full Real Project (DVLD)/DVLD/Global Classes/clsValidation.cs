using System.Text.RegularExpressions;

namespace DVLD.Global_Classes
{
    public class clsValidation
    {
        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }
        public static bool ValidateString(string StringInput)
        {
            var pattern = @"^[a-zA-Z]";

            var regex = new Regex(pattern);

            return regex.IsMatch(StringInput);
        }
        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }
        public static bool IsInteger(string Number)
        {
            return (ValidateInteger(Number));
        }
        public static bool IsFloat(string Number)
        {
            return (ValidateFloat(Number));
        }

    }
}
