public class ExpenseService
{
    private List<ExpenseItem> expenses = new();

    public IReadOnlyList<ExpenseItem> GetExpenses() => expenses;

    public void AddExpense(ExpenseItem expense)
    {
        if (expense != null)
        {
            expenses.Add(expense);
        }
    }
}

public class ExpenseItem
{
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public string Tag { get; set; }
}
