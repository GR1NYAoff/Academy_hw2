namespace Hw2.Exercise5.Models
{
    internal class TransactionRequest : ITransactionRequest
    {
        public string TransactionId { get; set; } = "";

        public decimal Amount { get; set; }

        public string Currency { get; set; } = "";

        public string SourceUserId { get; set; } = "";

        public string DestUserId { get; set; } = "";

        public string SourceBalance { get; set; } = "";

        public string DestBalance { get; set; } = "";

        public bool OverdraftAllowed { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public string Metadata { get; set; } = "";

    }
}
