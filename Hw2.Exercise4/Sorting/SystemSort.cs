namespace Hw2.Exercise4.Sorting
{
    internal class SystemSort : SortBase
    {
        public override void Sort(int[] array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            Array.Sort(array);
        }

    }
}
