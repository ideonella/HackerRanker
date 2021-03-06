﻿using HackerRankCtrl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			//Array challenges
			List<HackerRankController> hackerRankControllers = new List<HackerRankController>();

			hackerRankControllers.Add(new Arrays._2DArrayDS());
			hackerRankControllers.Add(new Arrays.DynamicArray());
			hackerRankControllers.Add(new Arrays.LeftRotation());
			hackerRankControllers.Add(new Arrays.SparseArrays());
			hackerRankControllers.Add(new Arrays.ArrayManipulation());

			Console.WriteLine("++ BEGIN ARRAY CHALLENGES ++");
			foreach (HackerRankController ctrl in hackerRankControllers)
			{
				Console.WriteLine("BEGIN: " + ctrl.ChallengeTitle);
				Console.WriteLine();
				ctrl.CompleteChallenge();
				Console.WriteLine();
				Console.WriteLine("END: " + ctrl.ChallengeTitle);
				Console.WriteLine("--------------------------------------------------");
			}
			Console.WriteLine("++ END ARRAY CHALLENGES ++");
			Console.WriteLine();
			Console.WriteLine();

			//Linked list challenges
			hackerRankControllers = new List<HackerRankController>();

			hackerRankControllers.Add(new LinkedLists.PrintElements());
			hackerRankControllers.Add(new LinkedLists.InsertAtTail());
			hackerRankControllers.Add(new LinkedLists.InsertAtHead());
			hackerRankControllers.Add(new LinkedLists.InsertAtSpecPos());
			hackerRankControllers.Add(new LinkedLists.DeleteANode());
			hackerRankControllers.Add(new LinkedLists.PrintInReverse());
			hackerRankControllers.Add(new LinkedLists.CompareLinkedLists());
			hackerRankControllers.Add(new LinkedLists.MergeSortedLLists());
			hackerRankControllers.Add(new LinkedLists.GetANodeValue());
			hackerRankControllers.Add(new LinkedLists.DeleteAdjDup());
			hackerRankControllers.Add(new LinkedLists.FindMergePoint());
			hackerRankControllers.Add(new LinkedLists.InsertDLList());
			hackerRankControllers.Add(new LinkedLists.ReverseDLList());
		  hackerRankControllers.Add(new LinkedLists.CycleDetection());

			Console.WriteLine("++ BEGIN LINKED LIST CHALLENGES ++");
			foreach (HackerRankController ctrl in hackerRankControllers)
			{
				Console.WriteLine("BEGIN: " + ctrl.ChallengeTitle);
				Console.WriteLine();
				ctrl.CompleteChallenge();
				Console.WriteLine();
				Console.WriteLine("END: " + ctrl.ChallengeTitle);
				Console.WriteLine("--------------------------------------------------");
			}
			Console.WriteLine("++ END LINKED LIST CHALLENGES ++");

			//Stack challenges
			hackerRankControllers = new List<HackerRankController>();

			//Massive input file just clutters everything up
			//hackerRankControllers.Add(new Stacks.MaxElement());
			hackerRankControllers.Add(new Stacks.EqualStacks());
			hackerRankControllers.Add(new Stacks.BalancedBracket());
			hackerRankControllers.Add(new Stacks.LargestRectangle());

			Console.WriteLine("++ BEGIN STACK CHALLENGES ++");
			foreach (HackerRankController ctrl in hackerRankControllers)
			{
				Console.WriteLine("BEGIN: " + ctrl.ChallengeTitle);
				Console.WriteLine();
				ctrl.CompleteChallenge();
				Console.WriteLine();
				Console.WriteLine("END: " + ctrl.ChallengeTitle);
				Console.WriteLine("--------------------------------------------------");
			}
			Console.WriteLine("++ END STACK CHALLENGES ++");
		}
	}
}
