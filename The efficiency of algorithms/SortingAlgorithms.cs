using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace The_efficiency_of_algorithms
{
	public static class SortingAlgorithms
	{
		#region InsertionSort

		public static int[] InsertionSort(int[] arr)
		{
			int n = arr.Length;
			for (int i = 1; i < n; ++i)
			{
				int key = arr[i];
				int j = i - 1;

				while (j >= 0 && arr[j] > key)
				{
					arr[j + 1] = arr[j];
					j = j - 1;
				}
				arr[j + 1] = key;
			}
			return arr;
		}
		#endregion
		#region MergeSort
		public static int[] MergeSort(int[] arr, int l, int r)
		{
			if (l < r)
			{
				int m = l + (r - l) / 2;

				MergeSort(arr, l, m);
				MergeSort(arr, m + 1, r);
				return Merge(arr, l, m, r);
			}
			else
			{
				return new int[0];
			}
		}
		private static int[] Merge(int[] arr, int l, int m, int r)
		{
			int n1 = m - l + 1;
			int n2 = r - m;

			int[] L = new int[n1];
			int[] R = new int[n2];
			int i, j;

			for (i = 0; i < n1; ++i)
				L[i] = arr[l + i];
			for (j = 0; j < n2; ++j)
				R[j] = arr[m + 1 + j];

			i = 0;
			j = 0;

			int k = l;
			while (i < n1 && j < n2)
			{
				if (L[i] <= R[j])
				{
					arr[k] = L[i];
					i++;
				}
				else
				{
					arr[k] = R[j];
					j++;
				}
				k++;
			}
			while (i < n1)
			{
				arr[k] = L[i];
				i++;
				k++;
			}
			while (j < n2)
			{
				arr[k] = R[j];
				j++;
				k++;
			}
			return arr;
		}
		#endregion
		#region QuickSortClassical
		public static int[] QuickSortClassical(int[] arr, int low, int high)
		{
			if (low < high)
			{

				int pi = Partition(arr, low, high);

				QuickSortClassical(arr, low, pi - 1);
				QuickSortClassical(arr, pi + 1, high);
				return arr;
			}
			else
			return new int[0];
		}

		private static void Swap(int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}

		private static int Partition(int[] arr, int low, int high)
		{
			int pivot = arr[high];
			int i = (low - 1);

			for (int j = low; j <= high - 1; j++)
			{
				if (arr[j] < pivot)
				{
					i++;
					Swap(arr, i, j);
				}
			}
			Swap(arr, i + 1, high);
			return (i + 1);
		}
		#endregion
		#region Quicksort
		public static int[] QuickSort(int[] arr)
		{
			if (arr != null)
			{
				Array.Sort(arr);
				return arr;
			}
			else
				return new int[0];
		}
		#endregion
		#region Print Array
		public static void PrintArray(int [] arr)
		{
			for (int i = 0; i < arr.Length-1; i++)
			{
				Console.Write($"{arr[i]} ");
			}
			Console.WriteLine();
			Console.WriteLine("===============================================");
		}
		#endregion
	}
}
