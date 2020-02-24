using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class FindMergePoint : HackerRankController
  {
    public FindMergePoint()
    {
      ChallengeTitle = "Merge two sorted linked lists";
    }

    /// <summary>
    /// Given pointers to the head nodes of linked lists that merge together at some point, 
    /// find the Node where the two lists merge. It is guaranteed that the two 
    /// head Nodes will be different, and neither will be NULL.
    /// </summary>
    /// <param name="head1"></param>
    /// <param name="head2"></param>
    /// <returns></returns>
    static int Solve(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
      SinglyLinkedListNode traverse = null;
      int data = 0;

      while (head2 != null)
      {
        traverse = head1;
        while(traverse != null)
        {
          if (Object.ReferenceEquals(traverse, head2))
          {
            data = traverse.data;
            traverse = null;
            head2 = null;
          }
          else
          {
          traverse = traverse.next;
          }
        }
        head2 = head2?.next;
      }

      return data;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"FindMergePoint.txt");

      int tests = Convert.ToInt32(reader.ReadLine());

      for (int testsItr = 0; testsItr < tests; testsItr++)
      {
        int index = Convert.ToInt32(reader.ReadLine());

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

        SinglyLinkedListNode ptr1 = llist1.head;
        SinglyLinkedListNode ptr2 = llist2.head;

        for (int i = 0; i < llist1Count; i++)
        {
          if (i < index)
          {
            ptr1 = ptr1.next;
          }
        }

        for (int i = 0; i < llist2Count; i++)
        {
          if (i != llist2Count - 1)
          {
            ptr2 = ptr2.next;
          }
        }

        ptr2.next = ptr1;

        int result = Solve(llist1.head, llist2.head);

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
