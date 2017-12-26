using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Enter values to generate: ");
                var value = Console.ReadLine();

                if (int.TryParse(value, out int maxRangeValue))
                {
                    var tBubble = Task.Run(() => BubbleSort(maxRangeValue));
                    var tMerge = Task.Run(() => MergeSort(maxRangeValue));
                    Task.WaitAll(tBubble, tMerge);
                }

                Console.ReadKey();
            } while (true);
        }

        #region MergeSort
        static void MergeSort(int maxRangeValue)
        {
            int[] numbers = GenerateNumbers(maxRangeValue);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            MergeSortFunction(numbers);
            watch.Stop();
            Console.WriteLine($"MergeSort - Values sorted : Timetaken: {watch.ElapsedMilliseconds}ms - First and Last values - {numbers.First()} - {numbers.Last()}");
        }

        static void MergeSortFunction(int[] numbers)
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
        #endregion

        #region BubbleSort
        static void BubbleSort(int maxRangeValue)
        {
            int[] numbers = GenerateNumbers(maxRangeValue);

            var tempValue = 0;
            Stopwatch watch = new Stopwatch();

            watch.Start();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int x = 0; x < numbers.Length - 1; x++)
                {
                    var currentNumber = numbers[x];
                    var nextNumber = numbers[x + 1];

                    if (currentNumber > nextNumber)
                    {
                        tempValue = currentNumber;
                        numbers[x] = nextNumber;
                        numbers[x + 1] = tempValue;
                    }
                }
            }
            watch.Stop();

            Console.WriteLine($"BubbleSort - Values sorted : Timetaken: {watch.ElapsedMilliseconds}ms - First and Last values - {numbers.First()} - {numbers.Last()}");
        }

        private static int[] GenerateNumbers(int maxRangeValue)
        {
            return Enumerable.Range(0, maxRangeValue).OrderBy(x => Guid.NewGuid()).ToArray();
        }
        #endregion
    }
}
