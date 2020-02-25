using HackerRankCtrl;
using System;
using System.IO;
using System.Collections;

namespace LinkedLists
{
  public class CycleDetection : HackerRankController
  {
    public CycleDetection()
    {
      ChallengeTitle = "Determine if a linked list is cyclical";
    }

    /// <summary>
    /// A linked list is said to contain a cycle if any node is visited more than 
    /// once while traversing the list. If there is a cycle, return true; 
    /// otherwise, return false.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    static bool Solve(SinglyLinkedListNode head)
    {
      bool cyclical = false;

      if (head != null)
      {
        int power = 1;
        int lam = 1;
        SinglyLinkedListNode slow = head;
        SinglyLinkedListNode fast = slow?.next;

        while (!Object.ReferenceEquals(slow, fast) && fast != null)
        {
          if (power == lam)
          {
            slow = fast;
            power *= 2;
            lam = 0;
          }
          fast = fast.next;
          lam++;
        }

        cyclical = fast != null ? true : false;
      }

      return cyclical;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"CycleDetection.txt");

      int tests = Convert.ToInt32(reader.ReadLine());

      for (int testsItr = 0; testsItr < tests; testsItr++)
      {
        int index = Convert.ToInt32(reader.ReadLine());

        SinglyLinkedList llist = new SinglyLinkedList();

        int llistCount = Convert.ToInt32(reader.ReadLine());

        for (int i = 0; i < llistCount; i++)
        {
          int llistItem = Convert.ToInt32(reader.ReadLine());
          llist.InsertNode(llistItem);
        }

        SinglyLinkedListNode extra = new SinglyLinkedListNode(-1);
        SinglyLinkedListNode temp = llist.head;

        for (int i = 0; i < llistCount; i++)
        {
          if (i == index)
          {
            extra = temp;
          }

          if (i != llistCount - 1)
          {
            temp = temp.next;
          }
        }

        temp.next = extra;

        bool result = Solve(llist.head);

        Console.WriteLine((result ? 1 : 0));
      }
    }

    //Provided by HackerRank
    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
    {
      while (node != null)
      {
        Console.WriteLine(node.data);

        node = node.next;

        if (node != null)
        {
          Console.WriteLine(sep);
        }
      }
    }

    //Provided by HackerRank
    class SinglyLinkedListNode
    {
      public int data;
      public SinglyLinkedListNode next;

      public SinglyLinkedListNode(int nodeData)
      {
        this.data = nodeData;
        this.next = null;
      }
    }

    //Provided by HackerRank
    class SinglyLinkedList
    {
      public SinglyLinkedListNode head;
      public SinglyLinkedListNode tail;

      public SinglyLinkedList()
      {
        this.head = null;
        this.tail = null;
      }

      public void InsertNode(int nodeData)
      {
        SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

        if (this.head == null)
        {
          this.head = node;
        }
        else
        {
          this.tail.next = node;
        }

        this.tail = node;
      }
    }
  }
}
