namespace Bank
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public bool IsValid { get; set; }
        public string Notes { get; set; }
    }
}