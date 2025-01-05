using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class TransactionItem
    {
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        public string Notes { get; set; }
    }
}
