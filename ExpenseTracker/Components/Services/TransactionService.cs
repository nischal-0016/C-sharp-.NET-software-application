using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class TransactionService
    {
        private readonly List<TransactionItem> transactions = new();
        public event Action OnChange;

        public IReadOnlyList<TransactionItem> Transactions => transactions;

        public void AddTransaction(TransactionItem transaction)
        {
            var newTransaction = new TransactionItem
            {
                Date = transaction.Date,
                Title = transaction.Title,
                Type = transaction.Type,
                Amount = transaction.Amount,
                Notes = transaction.Notes
            };

            transactions.Add(newTransaction);
            OnChange?.Invoke();
        }

        public List<TransactionItem> GetFilteredTransactions(DateTime startDate, DateTime endDate)
        {
            return transactions
                .Where(t => t.Date.Date >= startDate.Date && t.Date.Date <= endDate.Date)
                .OrderByDescending(t => t.Date)
                .ToList();
        }
    }
}