using System;

namespace ExpenseTracker.Models
{
    public class TransactionMoney
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "Inflow" or "Outflow"
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } // E.g., "Groceries", "Salary", etc.
        public List<Tag> Tags { get; set; } // Many-to-many relationship with tags

        public TransactionMoney()
        {
            Tags = new List<Tag>();
        }
    }
}
