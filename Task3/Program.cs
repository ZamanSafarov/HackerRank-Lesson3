namespace Task3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/*
			 Word1 və word2 iki sətri var, word1-i word2-ə çevirmək üçün tələb olunan minimum əməliyyat sayını tapın. 
				Əməliyyatlara daxiletmə, silmə və əvəzetmə daxildir. 
			 */
			string word1 = "kitten";
			string word2 = "sitting";
			(int operations, string word) a = NumberOfOperations(word1,word2);
            Console.WriteLine($"Number of Minimum Operation: {a.operations}");
            Console.WriteLine($"Changed Word: {word2} -----> {a.word}");

		}
		static (int,string) NumberOfOperations(string str1, string str2)
		{
			int minOp = 0;
			int n1 = str1.Length;
			int n2 = str2.Length;

			if (n1 < n2)
			{
				str2 = str2.Substring(0, n1);
				minOp += n2 - n1;
			}
			else if (n1 > n2)
			{
				str2 = str2.PadRight(n1);
				minOp += n1 - n2;
			}

			char[] str2Arr = str2.ToCharArray();
			for (int i = 0; i < n1; i++)
			{
				if (str1[i] != str2Arr[i])
				{
					str2Arr[i] = str1[i];
					minOp++;
				}
			}
			str2 = new string(str2Arr);


            return (minOp,str2);
		}

		
	}
}
