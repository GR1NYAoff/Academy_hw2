namespace Hw2.Exercise4.Sorting
{
    internal class BubbleSort : SortBase
    {
        public override void Sort(int[] array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            BubbleSorting(array);
        }

        private static int[] BubbleSorting(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                        Swap(ref array[j], ref array[j + 1]);

                }
            }
            return array;

        }

        private static void Swap(ref int value1, ref int value2)
        {
            var tmp = value1;
            value1 = value2;
            value2 = tmp;
        }

    }
}
