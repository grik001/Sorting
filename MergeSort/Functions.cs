using System;
using System.Diagnostics;
using System.Linq;

namespace MergeSort
{
    public static class Functions
    {
        public static void Sort(int[] numbers)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            MergeSortFunction(numbers);
            watch.Stop();
            Console.WriteLine($"MergeSort - Values sorted : Timetaken: {watch.ElapsedMilliseconds}ms - First and Last values - {numbers.First()} - {numbers.Last()}");
        }

        public static void MergeSortFunction(int[] numbers)
        {
            decimal arrayLen = numbers.Length;

            if (arrayLen < 2)
                return;

            int mid = Convert.ToInt32(Math.Ceiling(arrayLen / 2));

            var left = numbers.Take(mid).ToArray();
            var right = numbers.Skip(mid).ToArray();

            MergeSortFunction(left);
            MergeSortFunction(right);
            Merge(left, right, numbers);
        }

        static void Merge(int[] left, int[] right, int[] numbers)
        {
            var leftLen = 0;
            var rightLen = 0;
            var numbersLen = 0;

            while (leftLen < left.Length && rightLen < right.Length)
            {
                if (left[leftLen] < right[rightLen])
                {
                    numbers[numbersLen] = left[leftLen];
                    leftLen++;
                }
                else
                {
                    numbers[numbersLen] = right[rightLen];
                    rightLen++;
                }

                numbersLen++;
            }

            while (leftLen < left.Length)
            {
                numbers[numbersLen] = left[leftLen];
                leftLen++;
                numbersLen++;
            }

            while (rightLen < right.Length)
            {
                numbers[numbersLen] = right[rightLen];
                rightLen++;
                numbersLen++;
            }
        }
    }
}
