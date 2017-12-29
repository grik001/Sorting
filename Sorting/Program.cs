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
                    var tBubble = Task.Run(() => BubbleSort.Functions.Sort(GenerateNumbers(maxRangeValue)));
                    var tMerge = Task.Run(() => MergeSort.Functions.Sort(GenerateNumbers(maxRangeValue)));
                    var tQuick = Task.Run(() => QuickSort.Functions.Sort(GenerateNumbers(maxRangeValue)));
                    Task.WaitAll(tBubble, tMerge);
                }

                Console.ReadKey();
            } while (true);
        }

        private static int[] GenerateNumbers(int maxRangeValue)
        {
            return Enumerable.Range(0, maxRangeValue).OrderBy(x => Guid.NewGuid()).ToArray();
        }
    }
}
