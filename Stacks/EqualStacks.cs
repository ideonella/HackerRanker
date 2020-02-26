using HackerRankCtrl;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Stacks
{
  public class EqualStacks : HackerRankController
  {
    public EqualStacks()
    {
      ChallengeTitle = "Find the max of three stacks such that each is the same height";
    }

    static int Solve(int[] h1, int[] h2, int[] h3)
    {
      int sum1, sum2, sum3;

      sum1 = h1.Sum();
      Array.Reverse(h1);
      sum2 = h2.Sum();
      Array.Reverse(h2);
      sum3 = h3.Sum();
      Array.Reverse(h3);

      Stack<int> s1, s2, s3;

      s1 = new Stack<int>(h1);
      s2 = new Stack<int>(h2);
      s3 = new Stack<int>(h3);

      if (sum1 != 0 && sum2 != 0 && sum3 != 0)
      {
        while (sum1 != sum2 || sum1 != sum3 || sum2 != sum3)
        {
          if (sum1 > sum2 || sum1 > sum3)
          {
            sum1 -= s1.Pop();
          }
          else if (sum2 > sum1 || sum2 > sum3)
          {
            sum2 -= s2.Pop();
          }
          else if(sum3 > sum1 || sum3 > sum2)
          {
            sum3 -= s3.Pop();
          }
        }
      }

      Console.WriteLine(sum1);
      Console.WriteLine(sum2);
      Console.WriteLine(sum3);

      return sum1;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"EqualStacks.txt");

      string[] n1N2N3 = reader.ReadLine().Split(' ');

      int n1 = Convert.ToInt32(n1N2N3[0]);

      int n2 = Convert.ToInt32(n1N2N3[1]);

      int n3 = Convert.ToInt32(n1N2N3[2]);

      int[] h1 = Array.ConvertAll(reader.ReadLine().Split(' '), h1Temp => Convert.ToInt32(h1Temp));

      int[] h2 = Array.ConvertAll(reader.ReadLine().Split(' '), h2Temp => Convert.ToInt32(h2Temp));

      int[] h3 = Array.ConvertAll(reader.ReadLine().Split(' '), h3Temp => Convert.ToInt32(h3Temp))
        ;
      int result = Solve(h1, h2, h3);


      Console.WriteLine(result);
    }

  }
}
