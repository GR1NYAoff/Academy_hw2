namespace Hw2.Exercise5.Models
{
    internal class UserBalancesResponse : IUserBalancesResponse
    {
        public Dictionary<string, Dictionary<string, decimal>> Balances { get; set; } = new Dictionary<string, Dictionary<string, decimal>>();

    }
}
