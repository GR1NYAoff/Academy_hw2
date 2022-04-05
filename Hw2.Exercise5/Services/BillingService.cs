using Hw2.Exercise5.Models;

namespace Hw2.Exercise5.Services
{
    /// <summary>
    /// Billing system core.
    /// </summary>
    public class BillingService : IBillingService
    {
        /// <inheritdoc/>
        private readonly Dictionary<string, Dictionary<string, Dictionary<string, decimal>>> _users = new();
        public ITransactionResponse ProcessTransaction(ITransactionRequest request)
        {
            try
            {
                var check = request.SourceUserId == request.DestUserId && request.SourceBalance == request.DestBalance;

                if (request.Amount <= 0 || request.TransactionId is null || request is null || check)
                {
                    return new TransactionResponse
                    {
                        Currency = "",
                        DestBalances = new Dictionary<string, decimal>(),
                        SourceBalances = new Dictionary<string, decimal>(),
                        Result = TransactionResult.InvalidRequest
                    };
                }


                if (!_users.ContainsKey(request.SourceUserId))
                {
                    _users.Add(request.SourceUserId, new Dictionary<string, Dictionary<string, decimal>>());
                }

                if (!_users.ContainsKey(request.DestUserId))
                {
                    _users.Add(request.DestUserId, new Dictionary<string, Dictionary<string, decimal>>());
                }

                if (!_users[request.SourceUserId].ContainsKey(request.Currency))
                {
                    _users[request.SourceUserId].Add(request.Currency, new Dictionary<string, decimal>());
                }

                if (!_users[request.DestUserId].ContainsKey(request.Currency))
                {
                    _users[request.DestUserId].Add(request.Currency, new Dictionary<string, decimal>());
                }

                if (!_users[request.SourceUserId][request.Currency].ContainsKey(request.SourceBalance))
                {
                    _users[request.SourceUserId][request.Currency].Add(request.SourceBalance, 0.0m);
                }

                if (!_users[request.DestUserId][request.Currency].ContainsKey(request.DestBalance))
                {
                    _users[request.DestUserId][request.Currency].Add(request.DestBalance, 0.0m);
                }

                if (_users[key: request.SourceUserId] is null)
                {
                    throw new ArgumentNullException(request.SourceUserId);
                }

                _users[request.SourceUserId][request.Currency][request.SourceBalance] -= request.Amount;

                if (_users[request.SourceUserId][request.Currency][request.SourceBalance] <= 0 && request.OverdraftAllowed is false)
                {
                    _users[request.SourceUserId][request.Currency][request.SourceBalance] += request.Amount;
                    return new TransactionResponse
                    {
                        Currency = request.Currency,
                        DestBalances = _users[request.DestUserId][request.Currency],
                        SourceBalances = _users[request.SourceUserId][request.Currency],
                        Result = TransactionResult.InsufficientFunds
                    };
                }
                _users[request.DestUserId][request.Currency][request.DestBalance] += request.Amount;

                return new TransactionResponse
                {
                    Currency = request.Currency,
                    DestBalances = _users[request.DestUserId][request.Currency],
                    SourceBalances = _users[request.SourceUserId][request.Currency],
                    Result = TransactionResult.Success
                };


            }
            catch (ArgumentNullException)
            {
                return new TransactionResponse
                {
                    Currency = "",
                    DestBalances = new Dictionary<string, decimal>(),
                    SourceBalances = new Dictionary<string, decimal>(),
                    Result = TransactionResult.InvalidRequest
                };
            }
            catch (NullReferenceException)
            {
                return new TransactionResponse
                {
                    Currency = "",
                    DestBalances = new Dictionary<string, decimal>(),
                    SourceBalances = new Dictionary<string, decimal>(),
                    Result = TransactionResult.InvalidRequest
                };
            }
            catch (KeyNotFoundException)
            {
                return new TransactionResponse
                {
                    Currency = "",
                    DestBalances = new Dictionary<string, decimal>(),
                    SourceBalances = new Dictionary<string, decimal>(),
                    Result = TransactionResult.InvalidRequest
                };
            }
            catch (Exception)
            {
                return new TransactionResponse
                {
                    Currency = request.Currency,
                    DestBalances = _users[request.DestUserId][request.Currency],
                    SourceBalances = _users[request.SourceUserId][request.Currency],
                    Result = TransactionResult.Fail
                };
            }

        }

        public IUserBalancesResponse? GetUserBalances(string userId)
        {
            return !_users.ContainsKey(userId)
                ? null
                : new UserBalancesResponse { Balances = _users[userId] };

        }
    }
}
