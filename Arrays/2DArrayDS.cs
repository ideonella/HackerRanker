
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
	public class _2DArrayDS : HackerRankController
	{
		public _2DArrayDS()
		{
			ChallengeTitle = "2D Array - DS";
		}

		// Complete the hourglassSum function below.
		static int Solve(int[][] arr)
		{
			int max = -9 * 7;
			int sum;

			for (int i = 0; i < 4; i++)
			{
				for (int k = 0; k < 4; k++)
				{
					sum = 0;
					sum += arr[i][k];
					sum += arr[i][k + 1];
					sum += arr[i][k + 2];

					sum += arr[i + 1][k + 1];

					sum += arr[i + 2][k];
					sum += arr[i + 2][k + 1];
					sum += arr[i + 2][k + 2];

					max = (sum > max) ? sum : max;
				}
			}

			return max;
		}

		public override void CompleteChallenge()
		{
			using StreamReader reader = new StreamReader(@"2DArrayDS.txt");

			int[][] arr = new int[6][];

			for (int i = 0; i < 6; i++)
			{
				arr[i] = Array.ConvertAll(reader.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
			}

			int result = Solve(arr);

			Console.WriteLine(result);
		}

	}
}
