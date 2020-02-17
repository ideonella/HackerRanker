
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
	/// <summary>
	/// There is a collection of input strings and a collection of query strings.
	/// For each query string, determine how many times it occurs in the list of input strings. 
	/// </summary>
	public class SparseArrays : HackerRankController
	{
		public SparseArrays()
		{
			ChallengeTitle = "Sparse Arrays";
		}

		static int[] Solve(string[] strings, string[] queries)
		{
			int[] result = new int[queries.Length];

			//n^2 efficiency. There is 100% a better way to do this.
			//Perhaps culling the set as we go would speed it up.
			//Another thought would be to sort both lists.
			//Either way, I don't want to for this challenge.
			for (int i = 0; i < queries.Length; i++)
			{
				foreach (var str in strings)
				{
					if (queries[i] == str)
					{
						result[i] += 1;
					}
				}
			}

			return result;
		}

		public override void CompleteChallenge()
		{
			using StreamReader reader = new StreamReader(@"SparseArrays.txt");

			int stringsCount = Convert.ToInt32(reader.ReadLine());

			string[] strings = new string[stringsCount];

			for (int i = 0; i < stringsCount; i++)
			{
				string stringsItem = reader.ReadLine();
				strings[i] = stringsItem;
			}

			int queriesCount = Convert.ToInt32(reader.ReadLine());

			string[] queries = new string[queriesCount];

			for (int i = 0; i < queriesCount; i++)
			{
				string queriesItem = reader.ReadLine();
				queries[i] = queriesItem;
			}

			int[] result = Solve(strings, queries);

			Console.WriteLine(String.Join("\n", result));
		}
	}
}
