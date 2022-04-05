namespace Hw2.Exercise4.Sorting
{
    internal class QuickSort : SortBase
    {
        public override void Sort(int[] array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            QuickSorting(array);
        }
        private static int[] QuickSorting(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
                return array;

            var pivotIndex = GetPivotIndex(array, minIndex, maxIndex);
            QuickSorting(array, minIndex, pivotIndex - 1);
            QuickSorting(array, pivotIndex + 1, maxIndex);

            return array;
        }

        private static int[] QuickSorting(int[] array)
        {
            return QuickSorting(array, 0, array.Length - 1);
        }

        private static int GetPivotIndex(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);

            return pivot;
        }

        private static void Swap(ref int leftItem, ref int rightItem)
        {
            var tmp = leftItem;
            leftItem = rightItem;
            rightItem = tmp;
        }

    }
}
