namespace Task2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/*
			 Tam ədədlər massivini cəmləri bərabər olan iki alt massivə bölmək mümkün olub-olmadığını yoxlayın. 
			Mümkünsə, bu alt massivləri qaytarın. Məsələn: [6,13,8,1] array var əgər nəticə true olarsa o zaman -> [6,8] ve [1,13] cıxmaılıdır.
			 */
			int[] nums = { 6, 13, 8, 1 };
			var result = CanPartition(nums);
			if (result.Item1)
			{
				Console.WriteLine("Possible to partition:");
				Console.WriteLine("Subset 1: [" + string.Join(", ", result.Item2) + "]");
				Console.WriteLine("Subset 2: [" + string.Join(", ", result.Item3) + "]");
			}
			else
			{
				Console.WriteLine("Not possible to partition.");
			}
		}

		static (bool, List<int>, List<int>) CanPartition(int[] nums)
		{
			int totalSum = nums.Sum();
			if (totalSum % 2 != 0)
			{
				return (false, null, null);
			}

			int target = totalSum / 2;
			int n = nums.Length;
			bool[] dp = new bool[target + 1];
			dp[0] = true;

			for (int i = 0; i < n; i++)
			{
				for (int j = target; j >= nums[i]; j--)
				{
					dp[j] = dp[j] || dp[j - nums[i]];
				}
			}

			if (!dp[target])
			{
				return (false, null, null);
			}

			List<int> subset1 = new List<int>();
			List<int> subset2 = new List<int>(nums);

			int currTarget = target;
			for (int i = n - 1; i >= 0 && currTarget > 0; i--)
			{
				if (currTarget >= nums[i] && dp[currTarget - nums[i]])
				{
					subset1.Add(nums[i]);
					subset2.Remove(nums[i]);
					currTarget -= nums[i];
				}
			}

			return (true, subset1, subset2);
		}
	}
}
