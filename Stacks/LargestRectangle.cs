using HackerRankCtrl;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Stacks
{
  public class LargestRectangle : HackerRankController
  {
    public LargestRectangle()
    {
      ChallengeTitle = "Largest rectangle challenge";
    }

    /// <summary>
    ///  It should return an integer representing the largest rectangle 
    ///  that can be formed within the bounds of consecutive buildings. 
    /// </summary>
    /// <param name="h"></param>
    /// <returns></returns>
    static long Solve(int[] h)
    {
      long maxArea = 0;

      Stack<int> hIndex = new Stack<int>();

      List<int> append = new List<int>(h)
      {
        0
      };
      h = append.ToArray();

      int i = 0;
      while (i < h.Length)
      {
        //Find a local maximum then calculate all the rectangular areas until
        // local minimum is found
        //If first iteration or the next value is larger than the previous
        if (hIndex.Count == 0 || h[i] >= h[hIndex.Peek()])
        {
          //Save this unchanged or larger value's index
          hIndex.Push(i);
          i += 1;
        }
        else
        {
          //Max(maxArea, last increasing value (stack.pop)
          // * (position of the last increasing value minus the 
          maxArea = Math.Max(maxArea,
            h[hIndex.Pop()] * (hIndex.Count > 0 ? (i - 1) - hIndex.Peek() : i));
          //^^^ height ^^^  *                       ^^^    width   ^^^   || ^
        }
      }

      return maxArea;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"LargestRectangle.txt");

      int n = Convert.ToInt32(reader.ReadLine());

      int[] h = Array.ConvertAll(reader.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp));

      long result = Solve(h);

      Console.WriteLine(result);
    }

  }
}
