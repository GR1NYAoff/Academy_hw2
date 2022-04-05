namespace Hw2.Exercise1
{
    /// <summary>
    /// Brackets sequence validator.
    /// </summary>
    public class BracketsValidator
    {
        /// <summary>
        /// Validates chars sequence if all brackets are closed in right order.
        /// Supported brackets : '{', '}', '[', ']', '(', ')', '<', '>'.
        /// </summary>
        /// <param name="sequence">Char sequence.</param>
        /// <returns>
        /// Returns <c>true</c> if all brackets are closed in the right order (or no brackets at all). 
        /// Otherwise returns <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Sequence is null.</exception>
        public bool IsSequenceValid(string sequence)
        {
            if (sequence is null)
                throw new ArgumentNullException(nameof(sequence));
            var charStack = new Stack<char>();
            var open = new char[] { '(', '[', '{', '<' };
            var close = new char[] { ')', ']', '}', '>' };
            foreach (var item in sequence)
            {
                if (open.Contains(item))
                {
                    charStack.Push(item);
                }
                else if (charStack.Count >= 1 && close.Contains(item))
                {
                    var result = charStack.Pop();
                    if (Check(result, item))
                    {
                        continue;
                    }
                    return false;
                }
                else if (charStack.Count < 1 && close.Contains(item))
                {
                    return false;
                }

            }
            return charStack.Count == 0;
        }
        internal static bool Check(char a, char b)
        {
            return (a == '(' && b == ')') ||
          (a == '[' && b == ']') ||
          (a == '{' && b == '}') ||
          (a == '<' && b == '>');

        }
    }
}
