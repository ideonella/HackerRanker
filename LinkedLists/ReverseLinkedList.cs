using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class ReverseLinkedList : HackerRankController
  {
    public ReverseLinkedList()
    {
      ChallengeTitle = "Reverse a linked list";
    }
    /// <summary>
    /// You’re given the pointer to the head node of a linked list.
    /// Change the next pointers of the nodes so that their order is reversed.
    /// The head pointer given may be null meaning that the initial list is empty.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    static SinglyLinkedListNode Solve(SinglyLinkedListNode head)
    {
      SinglyLinkedListNode reverseHead = new SinglyLinkedListNode(0), prevNode;
      if (head != null)
      {
        reverseHead.data = head.data;
        head = head.next;
        while (head != null)
        {
          prevNode = reverseHead;
          reverseHead = head;
          head = head.next;
          reverseHead.next = prevNode;
        }
      }
      return reverseHead;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"ReverseLinkedList.txt");

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

        SinglyLinkedListNode llist1 = Solve(llist.head);

        PrintSinglyLinkedList(llist1, " ");
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
