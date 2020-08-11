using System;
using System.Diagnostics;

public class Test
{
	static Random Rng = new Random();
	static int NumOfRepetitions = 1;
	static string[] Titles = { "Bubble Sort", "Selection Sort", "Insertion Sort", "Array.Sort" };
	static int[] DataSizes = { 1000, 2000, 4000, 8000, 16000, 32000 };
	static double[,] Table = new double[Titles.Length, DataSizes.Length];

	public static void Main()
	{

		for (int i = 0; i < Titles.Length; i++)
		{
			Simulate(i);
		}
		ShowStat();

	}

	static void Simulate(int algoNo)
	{

		Console.Write("Simulating {0}: ", Titles[algoNo]);

		for (int i = 0; i < DataSizes.Length; i++)
		{

			for (int j = 1; j <= NumOfRepetitions; j++)
			{

				int[] A = ArrayGen(DataSizes[i]);
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				switch (algoNo)
				{
					case 0:
						BubbleSort(A);
						break;
					case 1:
						SelectionSort(A);
						break;
					case 2:
						InsertionSort(A);
						break;
					case 3:
						Array.Sort(A);
						break;
				}
				stopwatch.Stop();

				Table[algoNo, i] += 1000.0 * stopwatch.ElapsedTicks / Stopwatch.Frequency;
			}

			Console.Write("."); // progress bar
			Table[algoNo, i] /= NumOfRepetitions; // average the time cost
		}
		Console.WriteLine("done");

	}


	static void ShowStat()
	{

		Console.WriteLine("Benchmark (time unit: ms)");
		Console.Write("{0, 7}", "Size");
		foreach (String title in Titles)
			Console.Write("{0, 16}", title);
		Console.WriteLine();

		for (int i = 0; i < DataSizes.Length; i++)
		{
			Console.Write("{0, 7}", DataSizes[i]);
			for (int j = 0; j < Titles.Length; j++)
				Console.Write("{0, 16:F2}", Table[j, i]);
			Console.WriteLine();
		}

	}

	static int[] ArrayGen(int N)
	{

		int[] A = new int[N];
		for (int i = 0; i < A.Length; i++)
			A[i] = Rng.Next();
		return A;

	}
	static void Display(int[] A)
	{

		foreach (int item in A)
			Console.Write("{0} ", item);
		Console.WriteLine();

	}

	static void BubbleSort(int[] A)
	{
		int temp = A[0];
		for (int i = 0; i < A.Length; i++)
		{
			for (int j = 0; j < A.Length; j++)
			{
				if (A[i] > A[j])
				{
					temp = A[i];
					A[i] = A[j];
					A[j] = temp;
				}
			}
		}
	}

	static void SelectionSort(int[] A)
	{
		int min, temp;

		for (int i = 0; i < A.Length - 1; i++)
		{
			min = i;
			for (int j = i + 1; j < A.Length; j++)
			{
				if (A[j] > A[min])
				{
					min = j;
				}
			}
			if (min != i)
			{
				temp = A[i];
				A[i] = A[min];
				A[min] = temp;
			}
		}
	}

	static void InsertionSort(int[] A)
	{
		int j, temp;
		for (int i = 0; i < A.Length; i++)
		{
			j = i;
			while (j > 0 && A[j] < A[j - 1])
			{
				temp = A[j];
				A[j] = A[j - 1];
				A[j - 1] = temp;
				j--;
			}
		}
	}
}
