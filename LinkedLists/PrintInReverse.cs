using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class PrintInReverse : HackerRankController
  {
    public PrintInReverse()
    {
      ChallengeTitle = "Print a linked list in reverse";
    }

    /// <summary>
    /// You are given the pointer to the head node of a linked list and you need to 
    /// print all its elements in reverse order from tail to head, one element per line. 
    /// The head pointer may be null meaning that the list is empty - 
    /// in that case, do not print anything!
    /// </summary>
    /// <param name="head"></param>
    static void Solve(SinglyLinkedListNode head)
    {
      if (head != null)
      {
        SinglyLinkedListNode reverseHead = new SinglyLinkedListNode(head.data), prevNode;
        head = head.next;
        while (head != null)
        {
          prevNode = reverseHead;
          reverseHead = head;
          head = head.next;
          reverseHead.next = prevNode;
        }

        PrintSinglyLinkedList(reverseHead, " ");
      }
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"PrintInReverse.txt");

      int tests = Convert.ToInt32(reader.ReadLine());

      for (int testsItr = 0; testsItr < tests; testsItr++)
      {
        SinglyLinkedList llist = new SinglyLinkedList();

        int llistCount = Convert.ToInt32(reader.ReadLine());

        for (int i = 0; i < llistCount; i++)
        {
          int llistItem = Convert.ToInt32(reader.ReadLine());
          llist.InsertNode(llistItem);
        }

        Solve(llist.head);
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

    //Provided by HackerRank
    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
    {
      while (node != null)
      {
        Console.Write(node.data);

        node = node.next;

        if (node != null)
        {
          Console.Write(sep);
        }
      }
    }
  }
}
