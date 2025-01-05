namespace ExpenseTracker.Utilities
{
    public class Utils 
    {
        public static string FormatCurrency(decimal amount)
        {
            return amount.ToString("C", System.Globalization.CultureInfo.CurrentCulture);
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static decimal CalculateBalance(decimal inflows, decimal outflows)
        {
            return inflows - outflows;
        }
    }
}
