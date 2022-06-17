namespace Quicksort
{
    public class HoarePartition
    {
        public static int Partition(int[] array, int first, int last, int pivot)
        {
            int i = first - 1;
            int j = last + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (array[i] < pivot);

                do
                {
                    j--;
                } while (array[j] > pivot);

                if (i >= j) return j;

                (array[j], array[i]) = (array[i], array[j]);
            }
        }
    }
}