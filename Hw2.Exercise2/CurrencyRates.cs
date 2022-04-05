namespace Hw2.Exercise2
{
    /// <summary>
    /// Currency exchange service.
    /// </summary>
    public class CurrencyRates
    {
        /// <summary>
        /// Creates new instance of <see cref="CurrencyRates"/>.
        /// </summary>
        /// <param name="rates">Currency rates</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <paramref name="rates"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when <paramref name="rates"/> is invalid :
        /// contains negative rates
        /// or
        /// contains duplicated currency codes (in different cases).
        /// </exception>

        private readonly Dictionary<string, decimal> _currency = new();

        public CurrencyRates(IDictionary<string, decimal> rates)
        {
            if (rates is null)
                throw new ArgumentNullException(nameof(rates));

            foreach (var keyValuePair in rates)
            {
                if (keyValuePair.Value <= 0)
                    throw new ArgumentException(null, nameof(rates));
                else if (!keyValuePair.Key.All(char.IsUpper))
                    throw new ArgumentException(null, nameof(rates));

                _currency.Add(keyValuePair.Key, keyValuePair.Value);

            }

        }

        /// <summary>
        /// Exchanges currencies.
        /// </summary>
        /// <param name="request">Currency exchange request.</param>
        /// <returns>
        /// Returns amount of desired currency or <c>null</c> if requested currency is unknown.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws when <see cref="ExchangeRequest.IsValid"/> indicates invalid request.
        /// </exception>
        public decimal? Exchange(ExchangeRequest request)
        {
            if (!request.IsValid)
                throw new ArgumentException(null, nameof(request));

            var result = _currency.TryGetValue(request.SourceCurrnecy, out var exchangeRate);

            return result ? request.Amount * exchangeRate : null;

        }
    }
}
