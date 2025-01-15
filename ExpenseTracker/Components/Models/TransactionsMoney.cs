using System;

namespace ExpenseTracker.Models
{
    public class TransactionMoney
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } 
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } 
        public List<Tag> Tags { get; set; } 

        public TransactionMoney()
        {
            Tags = new List<Tag>();
        }
    }
}
