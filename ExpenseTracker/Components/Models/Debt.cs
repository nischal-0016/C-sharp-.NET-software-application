namespace ExpenseTracker.Models
{
    public class Debt
    {
        public int Id { get; set; }
        public string Creditor { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Title { get; set; } 
        public string Notes { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public bool IsPaid { get; set; } 
    }
}
