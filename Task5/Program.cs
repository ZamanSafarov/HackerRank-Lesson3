using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public IList<string> WordBreak(string s, IList<string> wordDict)
	{
		HashSet<string> wordSet = new HashSet<string>(wordDict);

		Dictionary<string, IList<string>> memo = new Dictionary<string, IList<string>>();

		return WordBreakHelper(s, wordSet, memo);
	}

	private IList<string> WordBreakHelper(string s, HashSet<string> wordSet, Dictionary<string, IList<string>> memo)
	{

		if (memo.ContainsKey(s))
		{
			return memo[s];
		}

		IList<string> result = new List<string>();

		if (wordSet.Contains(s))
		{
			result.Add(s);
		}

		for (int i = 1; i < s.Length; i++)
		{
			string prefix = s.Substring(0, i);
			if (wordSet.Contains(prefix))
			{
				string suffix = s.Substring(i);
				IList<string> suffixBreaks = WordBreakHelper(suffix, wordSet, memo);
				foreach (string suffixBreak in suffixBreaks)
				{
					result.Add(prefix + " " + suffixBreak);
				}
			}
		}

		memo[s] = result;
		return result;
	}
}

class Program
{
	static void Main()
	{
		Solution solution = new Solution();

		string s = "catsanddog";
		IList<string> wordDict = new List<string> { "cat", "cats", "and", "sand", "dog" };

		IList<string> result = solution.WordBreak(s, wordDict);

		foreach (string sentence in result)
		{
			Console.WriteLine(sentence);
		}
	}
}
