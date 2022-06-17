using System.Collections.Generic;

namespace Quicksort
{
    public class HoarePartition
    {
        public static int Partition(int[] array, int first, int last, int valeurDePartition)
        {
            int i = first;
            int j = last;

            while (i >= j)
            {
                while (array[i] < valeurDePartition)
                {
                    i++;
                }

                while (array[j] > valeurDePartition)
                {
                    j--;
                }

                if (i >= j) return j;

                (array[j], array[i]) = (array[i], array[j]);
            }
            return j;
        }
        public static int Partition<T>(T[] array, int first, int last, T valeurDePartition)
        {
            int i = first - 1;
            int j = last + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (((IComparer<T>)array[i]).Compare(array[i], valeurDePartition) < 0);

                do
                {
                    j--;
                } while (((IComparer<T>)array[i]).Compare(array[i], valeurDePartition) > 0);

                if (i >= j) return j;

                (array[j], array[i]) = (array[i], array[j]);
            }
        }
    }
}