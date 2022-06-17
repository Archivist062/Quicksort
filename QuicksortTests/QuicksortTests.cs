using Quicksort;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

[TestClass]
public class QuicksortTests
{
    static int[] MakeRandomIntArray(int length, int max)
    {
        var ints = new int[length];
        var random = new Random();

        for (int i = 0; i < length; i++) {
            ints[i] = random.Next(max);
        }

        return ints;
    }

    static bool IsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1]) return false;
        }

        return true;
    }

    static bool IsPermutation(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;

        var map = new Dictionary<int, int>();

        for (int i = 0; i < a.Length; i++)
        {
            int value = a[i];

            if (!map.ContainsKey(value))
            {
                map.Add(value, 1);
            } else
            {
                map[value]++;
            }
        }

        foreach (int value in map.Keys)
        {
            int count = 0;

            foreach (int x in b)
            {
                if (x == value) count++;
            }

            if (count != map[value])
            {
                return false;
            }
        }

        return true;
    }

    void TestSort(Func<int[], int, int, int, int> partition)
    {
        for (int i = 0; i < 1000; i++)
        {
            {
                var single = MakeRandomIntArray(1, 10);
                Assert.AreEqual(single.Length, 1);
                Assert.IsTrue(IsSorted(single));

                var value = single[0];

                Quicksort.Quicksort.Sort(partition, single, 0, 0);
                Assert.AreEqual(single.Length, 1);
                Assert.IsTrue(IsSorted(single));

                Assert.AreEqual(single[0], value);
            }

            for (int length = 2; length <= 10; length++)
            {
                int[] ints;

                do
                {
                    ints = MakeRandomIntArray(length, 10);
                } while (IsSorted(ints));

                Assert.AreEqual(ints.Length, length);
                // PARANOIA Assert.IsFalse(IsSorted(ints));

                var sortedInts = ints.ToArray();

                Quicksort.Quicksort.Sort(partition, ints, 0, length - 1);

                Assert.AreEqual(ints.Length, length);
                Assert.IsTrue(IsSorted(ints));

                IsPermutation(ints, sortedInts);
            }
        }
    }

    void TestSelect(Func<int[], int, int, int, int> partition)
    {
        for (int i = 0; i < 1000; i++)
        {
            {
                var single = MakeRandomIntArray(1, 10);
                Assert.AreEqual(single.Length, 1);
                Assert.IsTrue(IsSorted(single));

                var value = single[0];
                var target = 0;
                Quicksort.Quickselect.Select(partition, single, 0, 0, target);
                Assert.AreEqual(single.Length, 1);
                int[] cpy = single.OrderBy(x => x).ToArray();
				Assert.AreEqual(cpy[target], single[target]);

                Assert.AreEqual(single[0], value);
            }

            for (int length = 2; length <= 10; length++)
            {
                int[] ints;

                do
                {
                    ints = MakeRandomIntArray(length, 10);
                } while (IsSorted(ints));

                Assert.AreEqual(ints.Length, length);
                Assert.IsFalse(IsSorted(ints));

                var sortedInts = ints.ToArray();
                var random = new Random();
                var target = random.Next(length);

                var retour = Quicksort.Quickselect.Select(partition, ints, 0, 0, target);
                Assert.AreEqual(ints.Length, length);
                Assert.AreEqual(sortedInts[target], ints[target], retour);

                IsPermutation(ints, sortedInts);
            }
        }
    }

    [TestMethod]
    public void TestSortWithHoarePartition()
    {
        TestSort(HoarePartition.Partition);
    }

    [TestMethod]
    public void TestSelectWithHoarePartition()
    {
        TestSelect(HoarePartition.Partition);
    }
}
