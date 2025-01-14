public class TransactionItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public string Tag { get; set; }
    public string Notes { get; set; }
    public bool IsPaid { get; set; }
    public string RelatedTransactionId { get; set; }
}