using System;

namespace Task1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// int[] myNum = {15,8,4,13,10,11,7,3}; bu array-i Marge Sort alqoritmi ile 3,4,7,8,10,11,13,15 bu formaya getirin.

			int[] myNum = { 15, 8, 4, 13, 10, 11, 7, 3 };

			Console.WriteLine("Verilen arr:");
			for (int i = 0; i < myNum.Length; ++i)
				Console.Write(myNum[i] + " ");

			Sort(myNum, 0, myNum.Length - 1);

			Console.WriteLine("\nSıralanmış arr:");
			for (int i = 0; i < myNum.Length; ++i)
				Console.Write(myNum[i] + " ");


		}
		
		static	void Merge(int[] arr, int l, int m, int r)
		{
			int n1 = m - l + 1;
			int n2 = r - m;

			int[] L = new int[n1];
			int[] R = new int[n2];

			for (int i1 = 0; i1 < n1; ++i1)
				L[i1] = arr[l + i1];

			for (int j2 = 0; j2 < n2; ++j2)
				R[j2] = arr[m + 1 + j2];

			int i = 0, j = 0;

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
		}

		// Ana Merge Sort fonksiyonu
		static void Sort(int[] arr, int l, int r)
		{
			if (l < r)
			{
				int m = l + (r - l) / 2;

				Sort(arr, l, m);
				Sort(arr, m + 1, r);

				Merge(arr, l, m, r);
			}
		}
	}
}
