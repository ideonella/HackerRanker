using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class CompareLinkedLists : HackerRankController
  {
    public CompareLinkedLists()
    {
      ChallengeTitle = "Reverse a linked list";
    }
    /// <summary>
    /// You’re given the pointer to the head nodes of two linked lists. 
    /// Compare the data in the nodes of the linked lists to check if they are equal. 
    /// The lists are equal only if they have the same number of nodes 
    /// and corresponding nodes contain the same data. 
    /// Either head pointer given may be null meaning that the corresponding list is empty.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    static bool Solve(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
      //I don't like that this works. I don't understand it but somehow wrote it.
      bool same;
      if (head1 == null && head2 == null)
      {
        same = true;
      }
      else if (head1 == null || head2 == null)
      {
        same = false;
      }
      else
      {
        same = head1.data == head2.data ? true : false;

        while (same && (head1?.next != null || head2?.next != null))
        {
          head1 = head1.next;
          head2 = head2.next;
          same = head1?.data == head2?.data ? true : false;
        }
      }

      return same;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"CompareLinkedLists.txt");

      int tests = Convert.ToInt32(reader.ReadLine());

      for (int testsItr = 0; testsItr < tests; testsItr++)
      {
        SinglyLinkedList llist1 = new SinglyLinkedList();

        int llist1Count = Convert.ToInt32(reader.ReadLine());

        for (int i = 0; i < llist1Count; i++)
        {
          int llist1Item = Convert.ToInt32(reader.ReadLine());
          llist1.InsertNode(llist1Item);
        }

        SinglyLinkedList llist2 = new SinglyLinkedList();

        int llist2Count = Convert.ToInt32(reader.ReadLine());

        for (int i = 0; i < llist2Count; i++)
        {
          int llist2Item = Convert.ToInt32(reader.ReadLine());
          llist2.InsertNode(llist2Item);
        }

        bool result = Solve(llist1.head, llist2.head);

        Console.WriteLine((result ? 1 : 0));
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
