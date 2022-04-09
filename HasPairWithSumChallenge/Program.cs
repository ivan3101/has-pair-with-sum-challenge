// Given an array of numbers (integers) and a sum number (integer)
// Find the first two elements inside of the array that added together make the sum number

using System.Diagnostics;

// var numbersInvalid = new int[] { 1, 2, 3, 9 };
// var numbersValid = new int[] { 1, 2, 4, 4 };

var nums = CreateArrayFilledWithRandomInts(1000000000);

const int sum = 8;
var watch = new Stopwatch();

Console.WriteLine("***** Unoptimized Algorithm *****");

watch.Reset();
watch.Start();
UnoptimizedWay(nums, sum);
watch.Stop();

Console.WriteLine($"{watch.ElapsedMilliseconds} ms");
Console.WriteLine("**********");

Console.WriteLine();

Console.WriteLine("***** Optimized Algorithm *****");

watch.Reset();
watch.Start();
OptimizedWay(nums, sum);
watch.Stop();

Console.WriteLine($"{watch.ElapsedMilliseconds} ms");
Console.WriteLine("**********");

static void UnoptimizedWay(IReadOnlyList<int> numbers, int sum)
{
    var low = 0;
    var high = numbers.Count - 1;

    while (low < high)
    {
        var sumX = numbers[low] + numbers[high];

        if (sumX > sum)
        {
            high--;
        } 
        else if (sumX < sum)
        {
            low++;
        }
        else
        {
            break;
        }
    }
}

static void OptimizedWay(IReadOnlyCollection<int> numbers, int sum)
{
    var complements = new HashSet<int>();

    for (var i = 0; i < numbers.Count; i++)
    {
        if (complements.Contains(i)) break;
    
        complements.Add(sum - i);
    }
}

static int[] CreateArrayFilledWithRandomInts(int arrayLength)
{
    var rand = new Random();

    var array = Enumerable
        .Repeat(0, arrayLength)
        .Select(i => rand.Next(1, int.MaxValue))
        .ToArray();

    return array;
}