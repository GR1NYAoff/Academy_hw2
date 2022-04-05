namespace Hw2.Exercise4.Sorting
{
    /// <summary>
    /// Sort algorithm factory
    /// </summary>
    public class SortFactory
    {
        /// <summary>
        /// Tries to resolve sort algorithm.
        /// Supported algorithms :
        /// Bubble;
        /// System (<see cref="Array.Sort(Array)"/>);
        /// Quick.
        /// </summary>
        /// <param name="algorithm">Desired algorithm name.</param>
        /// <returns>Returns requested sort algorithm; returns <c>null</c> if algorithm wasn't resolved.</returns>
        public SortBase? ResolveSort(string algorithm)
        {
            if (algorithm != null && algorithm.Length > 0)
            {
                algorithm = algorithm.ToLowerInvariant();

                return algorithm switch
                {
                    "bubble" => new BubbleSort(),
                    "system" => new SystemSort(),
                    "quick" => new QuickSort(),
                    _ => null
                };
            }
            else
            {
                return null;
            }
        }
    }
}
