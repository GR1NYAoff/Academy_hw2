namespace Hw2.Exercise5.Models
{
    /// <summary>
    /// User balances response.
    /// </summary>
    public interface IUserBalancesResponse
    {
        /// <summary>
        /// User balances. 
        /// Non nullable.
        /// </summary>
        Dictionary<string, Dictionary<string, decimal>> Balances { get; }
    }
}
