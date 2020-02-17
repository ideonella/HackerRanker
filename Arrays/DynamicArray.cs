using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using HackerRankCtrl;

namespace Arrays
{

	public class DynamicArray : HackerRankController
	{
		public DynamicArray()
		{
			ChallengeTitle = "Dynamic Array";
		}

		/*
     * Complete the 'dynamicArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY queries
     */

		static List<int> Solve(int n, List<List<int>> queries)
		{
			List<int> lastAnswers = new List<int>();
			int lastAnswer = 0;
			List<List<int>> seq = new List<List<int>>();

			int mod = n;
			int index;

			for (int i = 0; i < queries.Count; i++)
			{
				index = (queries[i][1] ^ lastAnswer) % mod;

				// Current appending index doesn't exist
				while (seq.Count <= index)
				{
					seq.Add(new List<int>());
				}

				switch (queries[i][0])
				{
					case 1:

						//Console.WriteLine(String.Format("{0,1} {1,5} {2, 5}", queries[i][0], index, seq.Count));
						seq[index].Add(queries[i][2]);

						//Console.WriteLine(String.Format("{0,1} {1,5} {2, 5}", queries[i][0], index, seq[index].Count));

						break;

					case 2:

						//Console.WriteLine(String.Format("{0,1} {1,5} {2, 5}", queries[i][0], index, seq.Count));

						//Console.WriteLine(String.Format("{0,1} {1,5} {2, 5}", queries[i][0], index, seq[index].Count));
						lastAnswer = seq[index][queries[i][2] % seq[index].Count];
						lastAnswers.Add(lastAnswer);

						break;

					default:
						break;
				}
			}

			return lastAnswers;
		}

		public override void CompleteChallenge()
		{
			using StreamReader reader = new StreamReader(@"DynamicArray.txt");

			string[] firstMultipleInput = reader.ReadLine().TrimEnd().Split(' ');

			int n = Convert.ToInt32(firstMultipleInput[0]);

			int q = Convert.ToInt32(firstMultipleInput[1]);

			List<List<int>> queries = new List<List<int>>();

			for (int i = 0; i < q; i++)
			{
				queries.Add(reader.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
			}

			List<int> result = Solve(n, queries);

			Console.WriteLine(String.Join("\n", result));
		}
	}
}
