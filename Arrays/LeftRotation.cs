using HackerRankCtrl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Arrays
{
	public class LeftRotation : HackerRankController
	{
		public LeftRotation()
		{
			ChallengeTitle = "Left Rotation";
		}

		static int[] Solve(int n, int q, int[] arr)
		{
			List<int> result = new List<int>();

			int rotate = q % n;

			//Rebuild front from end
			for (int i = rotate; i < n; i++)
			{
				result.Add(arr[i]);
			}

			//Rebuild end from front
			for (int i = 0; i < rotate; i++)
			{
				result.Add(arr[i]);
			}

			return result.ToArray();
		}

		public override void CompleteChallenge()
		{
			using StreamReader reader = new StreamReader(@"LeftRotation.txt");

			string[] firstMultipleInput = reader.ReadLine().TrimEnd().Split(' ');

			int n = Convert.ToInt32(firstMultipleInput[0]);

			int q = Convert.ToInt32(firstMultipleInput[1]);

			int[] arr = new int[n];

			arr = Array.ConvertAll(reader.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

			int[] result = Solve(n, q, arr);

			Console.WriteLine(String.Join(" ", result));
		}
	}
}
