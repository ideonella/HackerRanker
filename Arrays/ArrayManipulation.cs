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
	/// Starting with a 1-indexed array of zeros and a list of operations,
	///  for each operation add a value to each of the array element between two given indices, inclusive.
	/// Once all operations have been performed, return the maximum value in your array. 
	/// </summary>
	public class ArrayManipulation : HackerRankController
	{
		public ArrayManipulation()
		{
			ChallengeTitle = "Array Manipulation";
		}

		static long Solve(int n, int[][] queries)
		{
			long result = long.MinValue;

			//n + 1 to accomodate the linear algorithm setup. Still not sure why it works.
			long[] total = new long[n + 1];

			//O(n^2) efficiency. Times out during the challenge...
			/*
			foreach (var qry in queries)
			{
				int start = qry[0] - 1;
				int end = qry[1];
				int val = qry[2];
				for (int i = start; i < end; i++)
				{
					total[i] += val;
				}
			}
			*/

			//Thanks to Dici on stackoverflow for explaining this solution.
			//Dici also explained they hadn't figured it out without some help either.
			foreach (var qry in queries)
			{
				int start = qry[0] - 1;
				int end = qry[1];
				int val = qry[2];

				total[start] += val;
				total[end] -= val;
			}

			long runningMax = 0;
			foreach (var item in total)
			{
				runningMax += item;
				result = result < runningMax ? runningMax : result;
			}

			return result;
		}

		public override void CompleteChallenge()
		{
			using StreamReader reader = new StreamReader(@"ArrayManipulation.txt");

			string[] nm = reader.ReadLine().Split(' ');

			int n = Convert.ToInt32(nm[0]);

			int m = Convert.ToInt32(nm[1]);

			int[][] queries = new int[m][];

			for (int i = 0; i < m; i++)
			{
				queries[i] = Array.ConvertAll(reader.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
			}

			long result = Solve(n, queries);

			Console.WriteLine(String.Join("\n", result));
		}
	}
}
