using System;
using System.Diagnostics;
using System.Linq;

namespace QuickSort
{
    public class Functions
    {
        public static void Sort(int[] numbers)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            QuickSort(numbers, 0, numbers.Length - 1);
            watch.Stop();
            Console.WriteLine($"QuickSort - Values sorted : Timetaken: {watch.ElapsedMilliseconds}ms - First and Last values - {numbers.First()} - {numbers.Last()}");
        }

        public static void QuickSort(int[] numbers, int p, int r)
        {
            if (p < r)
            {
                var q = Partition(numbers, p, r);
                QuickSort(numbers, p, q - 1);
                QuickSort(numbers, q + 1, r);
            }
        }

        public static int Partition(int[] numbers, int p, int r)
        {
            int x = numbers[r];
            int i = p - 1;

            for (int j = p; j < r; j++)
            {
                if (numbers[j] <= x)
                {
                    i++;
                    Swap(numbers, i, j);
                }
            }

            Swap(numbers, i + 1, r);
            return i + 1;
        }

        private static void Swap(int[] numbers, int i, int j)
        {
            var temp = numbers[j];
            numbers[j] = numbers[i];
            numbers[i] = temp;
        }
    }
}
