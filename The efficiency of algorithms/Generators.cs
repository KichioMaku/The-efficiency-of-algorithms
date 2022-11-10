using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_efficiency_of_algorithms
{
	public static class Generators
	{
		public static int[] GenerateRandom(int size, int minValue, int maxValue)
		{
			Random random = new Random();
			int[] arr = new int[size];
			for (int i = 0; i <= size - 1; i++)
			{
				arr[i] =random.Next(minValue,maxValue);
			}
			return arr;
		}

		public static int[] GenerateSorted(int size, int minValue, int maxValue)
		{
			int[] arr = GenerateRandom(size, minValue, maxValue);
			Array.Sort(arr);
			return arr;
		}

		public static int[] GenerateReversed(int size, int minValue, int maxValue)
		{
			var arr = GenerateSorted(size, minValue, maxValue);
			Array.Reverse(arr);
			return arr;
		}
		public static int[] GenerateAlmostSorted(int size, int minValue, int maxValue)
		{
			var arr = GenerateSorted(size, minValue, maxValue);
			Random random = new Random();
			for (int i = 0; i < arr.Length - 1; i++)
			{
				if (i % 10 == 0)
				{
					arr[i] = random.Next(minValue, maxValue);
				}
			}
			return arr;
		}

	}
}
