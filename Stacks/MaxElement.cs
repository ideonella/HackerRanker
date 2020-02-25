using HackerRankCtrl;
using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace Stacks
{
  public class MaxElement : HackerRankController
  {
    public MaxElement()
    {
      ChallengeTitle = "Print max of the current stack at any given time";
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"MaxElement.txt");
      using StreamWriter stdout = new StreamWriter(Console.OpenStandardOutput());

    int operations = Convert.ToInt32(reader.ReadLine());
      string[] query = new string[2];
      int value, index;
      Stack<int> stack = new Stack<int>();
      List<int> orderedValues = new List<int>();

      Stopwatch stopwatch = new Stopwatch();

      stopwatch.Start();

      for (int i = 0; i < operations; i++)
      {
        query = reader.ReadLine().Split(' ');
        switch (query[0])
        {
          case "1":
            value = Convert.ToInt32(query[1]);
            stack.Push(value);

            //Sorted list for Max
            index = orderedValues.BinarySearch(value);
            if (index < 0) index = ~index;
            orderedValues.Insert(index, value);
            break;
          case "2":
            orderedValues.Remove(stack.Pop());
            break;
          case "3":
            foreach (var c in orderedValues[orderedValues.Count - 1].ToString())
              stdout.Write(c);
            stdout.Write('\n');
            //Console.WriteLine was too slow to solve all the puzzles...
            //~0.075s execution with no output
            //~4.3s execution with Console.WriteLine
            //Console.WriteLine(orderedValues[orderedValues.Count - 1]);
            break;
          default:
            Console.WriteLine("Invalid query");
            break;
        }
      }
      stdout.Flush();
      stdout.Close();
      stopwatch.Stop();

      Console.WriteLine("END Execution Time: " + stopwatch.Elapsed.TotalSeconds);
    }

  }
}
