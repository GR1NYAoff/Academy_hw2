namespace Hw2.Exercise5.Models
{
    internal class TransactionResponse : ITransactionResponse
    {
        public TransactionResult Result { get; set; }

        public string Currency { get; set; } = "";

        public IDictionary<string, decimal> SourceBalances { get; set; } = new Dictionary<string, decimal>();

        public IDictionary<string, decimal> DestBalances { get; set; } = new Dictionary<string, decimal>();

    }
}
