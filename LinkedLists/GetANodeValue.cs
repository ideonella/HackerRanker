using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class GetANodeValue : HackerRankController
  {
    public GetANodeValue()
    {
      ChallengeTitle = "Get a node at a specific position from the tail of a linked list";
    }

    /// <summary>
    /// You’re given the pointer to the head node of a linked list and a specific position. 
    /// Counting backwards from the tail node of the linked list, get the value
    /// of the node at the given position. A position of 0 corresponds to the tail, 
    /// 1 corresponds to the node before the tail and so on. 
    /// </summary>
    /// <param name="head"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    static int Solve(SinglyLinkedListNode head, int positionFromTail)
    {
      //Traverse the list to get the node count
      int length = 0;
      SinglyLinkedListNode node = head;
      while (node != null)
      {
        length++;
        node = node.next;
      }

      //Calculate forward position
      int pos = length - positionFromTail - 1;
      node = head;

      //Navigate to the requested node
      for (int i = 0; i < pos; i++)
      {
        node = node.next;
      }

      return node.data;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"GetANodeValue.txt");

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

        int position = Convert.ToInt32(reader.ReadLine());

        int result = Solve(llist.head, position);

        Console.WriteLine(result);
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
