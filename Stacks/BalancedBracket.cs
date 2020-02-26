using HackerRankCtrl;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Stacks
{
  public class BalancedBracket : HackerRankController
  {
    public BalancedBracket()
    {
      ChallengeTitle = "Balanced Brackets challenge () [] {}";
    }

    static string Solve(string s)
    {
      bool isBalanced = true;

      Stack<char> brackets = new Stack<char>();
      char[] charArray = s.ToCharArray();
      Array.Reverse(charArray);
      Stack<char> charStack = new Stack<char>(charArray);

      while (isBalanced && charStack.Count > 0)
      {
        char c = charStack.Pop();
        switch (c)
        {
          case '(':
            brackets.Push(c);
            break;
          case ')':
            if (brackets.Count == 0 || brackets.Pop() != '(')
              isBalanced = false;
            break;
          case '[':
            brackets.Push(c);
            break;
          case ']':
            if (brackets.Count == 0 || brackets.Pop() != '[')
              isBalanced = false;
            break;
          case '{':
            brackets.Push(c);
            break;
          case '}':
            if (brackets.Count == 0 || brackets.Pop() != '{')
            {
              isBalanced = false;
            }
            break;
          default:
            break;
        }
      }

      if (brackets.Count > 0)
        isBalanced = false;

      return isBalanced ? "YES" : "NO";
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"BalancedBracket.txt");

      int t = Convert.ToInt32(reader.ReadLine());

      for (int tItr = 0; tItr < t; tItr++)
      {
        string s = reader.ReadLine();

        string result = Solve(s);

        Console.WriteLine(result);
      }
    }

  }
}
