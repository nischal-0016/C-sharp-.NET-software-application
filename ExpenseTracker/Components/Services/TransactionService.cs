using System.IO;
using System.Text.Json;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class TransactionService
    {
        private readonly string FilePath = @"C:\Users\koira\Source\Repos\C-.NET-software-application\transactions.json";
        private List<TransactionItem> transactions = new();
        public event Action OnChange;

        public IReadOnlyList<TransactionItem> Transactions => transactions;

        // Constructor to load transactions when the service is initialized
        public TransactionService()
        {
            LoadTransactions(); 
        }

        // Add a new transaction
        public void AddTransaction(TransactionItem transaction)
        {
            var newTransaction = new TransactionItem
            {
                Date = transaction.Date,
                Title = transaction.Title,
                Type = transaction.Type,
                Amount = transaction.Amount,
                Notes = transaction.Notes,
                Tag = transaction.Tag
            };

            transactions.Add(newTransaction);
            SaveTransactions(); // Save after adding
            OnChange?.Invoke();
        }

        // Load transactions from the file
        private void LoadTransactions()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var json = File.ReadAllText(FilePath);
                    transactions = JsonSerializer.Deserialize<List<TransactionItem>>(json) ?? new List<TransactionItem>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading transactions: {ex.Message}");
                transactions = new List<TransactionItem>(); // Initialize empty list if there's an error
            }
        }

        // Save transactions to the file
        private void SaveTransactions()
        {
            try
            {
                // Ensure the directory exists
                var directory = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Serialize and save the transactions to the file
                var json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);

                Console.WriteLine("Transactions saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving transactions: {ex.Message}");
            }
        }


        // Clear all transactions
        public void ClearAllTransactions()
        {
            transactions.Clear();
            SaveTransactions(); 
            OnChange?.Invoke();
        }
    }
}
