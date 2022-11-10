using System;
using System.Diagnostics;
using System.Globalization;

namespace The_efficiency_of_algorithms
{
	internal class Program
	{
		static void Main(string[] args)
		{

			RunAlgorithms("Przypadek 1", "mala", Generators.GenerateRandom(5000, 1, 1000), 10, "random");
			RunAlgorithms("Przypadek 2", "mala", Generators.GenerateSorted(5000, 1, 1000), 10, "sorted");
			RunAlgorithms("Przypadek 3", "mala", Generators.GenerateAlmostSorted(5000, 1, 1000), 10, "almost sorted");
			RunAlgorithms("Przypadek 4", "mala", Generators.GenerateReversed(5000, 1, 1000), 10, "reversed");

			RunAlgorithms("Przypadek 5", "srednia", Generators.GenerateRandom(50000, 1, 1000), 10, "random");
			RunAlgorithms("Przypadek 6", "srednia", Generators.GenerateSorted(50000, 1, 1000), 10, "sorted");
			RunAlgorithms("Przypadek 7", "srednia", Generators.GenerateAlmostSorted(50000, 1, 1000), 10, "almost sorted");
			RunAlgorithms("Przypadek 8", "srednia", Generators.GenerateReversed(50000, 1, 1000), 10, "raversed");

			RunAlgorithms("Przypadek 9", "duza", Generators.GenerateRandom(100000, 1, 1000), 10, "random");
			RunAlgorithms("Przypadek 10", "duza", Generators.GenerateSorted(100000, 1, 1000), 10, "sorted");
			RunAlgorithms("Przypadek 11", "duza", Generators.GenerateAlmostSorted(100000, 1, 1000), 10, "almost sorted");
			RunAlgorithms("Przypadek 12", "duza", Generators.GenerateReversed(100000, 1, 1000), 10, "reversed");


		}

		static void RunAlgorithms(string testNumber,string name, int[] arr, int n, string arrayType)
		{
			var times = new List<double>();
			for (int i = 0; i < n; i++)
			{
				Stopwatch stopwatch = new Stopwatch();
				int[] tab = (int[])arr.Clone();
				stopwatch.Start();
				SortingAlgorithms.InsertionSort(tab);
				stopwatch.Stop();
				double elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.00;
				times.Add(elapsedSeconds);
			}
			var averageTime = CountAverageTime(times);
			var standardDeviation = StandardDeviation(times, averageTime);
			Console.WriteLine($"{testNumber}: próba {name} (n = {arr.Length}), {arrayType}");
			Console.WriteLine($"* InsertionSort: t = {averageTime} +/- {standardDeviation}");


			times = new List<double>();
			for (int i = 0; i < n; i++)
			{
				Stopwatch stopwatch = new Stopwatch();
				int[] tab = (int[])arr.Clone();
				stopwatch.Start();
				SortingAlgorithms.MergeSort(tab,0,tab.Length-1);
				stopwatch.Stop();
				double elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.00;
				times.Add(elapsedSeconds);
			}
			averageTime = CountAverageTime(times);
			standardDeviation = StandardDeviation(times, averageTime);

			Console.WriteLine($"* MergeSort: t = {averageTime} +/- {standardDeviation}");


			times = new List<double>();
			for (int i = 0; i < n; i++)
			{
				Stopwatch stopwatch = new Stopwatch();
				int[] tab = (int[])arr.Clone();
				stopwatch.Start();
				SortingAlgorithms.QuickSortClassical(tab, 0, tab.Length - 1);
				stopwatch.Stop();
				double elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.00;
				times.Add(elapsedSeconds);
			}
			averageTime = CountAverageTime(times);
			standardDeviation = StandardDeviation(times, averageTime);

			Console.WriteLine($"* QuickSortClassical: t = {averageTime} +/- {standardDeviation}");

			times = new List<double>();
			for (int i = 0; i < n; i++)
			{
				Stopwatch stopwatch = new Stopwatch();
				int[] tab = (int[])arr.Clone();
				stopwatch.Start();
				SortingAlgorithms.QuickSort(tab);
				stopwatch.Stop();
				double elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.00;
				times.Add(elapsedSeconds);
			}
			averageTime = CountAverageTime(times);
			standardDeviation = StandardDeviation(times, averageTime);

			Console.WriteLine($"* QuickSort: t = {averageTime} +/- {standardDeviation}");


			Console.WriteLine("...........................................................\n\n");
		}
		static double CountAverageTime(List<double> times)
		{
			double averageTime = 0;
			for (int i = 0; i < times.Count; i++)
			{
				averageTime += times[i];
			}
			return averageTime / (times.Count);
		}

		static double StandardDeviation(List<double> times, double averageTime)
		{
			double result = 0;

			if (times.Any())
			{
				double average = averageTime;
				double sum = times.Sum(d => Math.Pow(d - average, 2));
				result = Math.Sqrt((sum) / times.Count());
			}
			return result;
		}
	}
}