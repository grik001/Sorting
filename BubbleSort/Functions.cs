using System;
using System.Diagnostics;
using System.Linq;

namespace BubbleSort
{
    public static class Functions
    {
        public static void Sort(int[] numbers)
        {
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

    }
}
