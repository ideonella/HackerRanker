using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class MergeSortedLLists : HackerRankController
  {
    public MergeSortedLLists()
    {
      ChallengeTitle = "Merge two sorted linked lists";
    }

    /// <summary>
    /// You’re given the pointer to the head nodes of two sorted linked lists. 
    /// The data in both lists will be sorted in ascending order. 
    /// Change the next pointers to obtain a single, 
    /// merged linked list which also has data in ascending order.
    /// Either head pointer given may be null meaning that the corresponding list is empty.
    /// </summary>
    /// <param name="head"></param>
    /// <param name="data"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    static SinglyLinkedListNode Solve(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
      SinglyLinkedListNode merged = null;
      SinglyLinkedListNode newNode = new SinglyLinkedListNode(0);

      if (head1 == null || head2 == null)
      {
        merged = null;
      }
      else
      {
        while (head1 != null || head2 != null)
        {
          if ((head1?.data <= head2?.data) || head2?.data == null)
          {
            if (merged == null)
            {
              merged = new SinglyLinkedListNode(head1.data);
              newNode = merged;
              head1 = head1.next;
            }
            else
            {
              newNode.next = new SinglyLinkedListNode(head1.data);
              newNode = newNode.next;
              head1 = head1.next;
            }
          }
          else if ((head2?.data <= head1?.data) || head1?.data == null)
          {
            if (merged == null)
            {
              merged = new SinglyLinkedListNode(head2.data);
              newNode = merged;
              head2 = head2.next;
            }
            else
            {
              newNode.next = new SinglyLinkedListNode(head2.data);
              newNode = newNode.next;
              head2 = head2.next;
            }
          }
        }
      }

      return merged;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"MergeSortedLLists.txt");

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

        SinglyLinkedListNode llist3 = Solve(llist1.head, llist2.head);

        PrintSinglyLinkedList(llist3, " ");
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
