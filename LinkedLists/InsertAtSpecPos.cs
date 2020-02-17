using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class InsertAtSpecPos : HackerRankController
  {
    public InsertAtSpecPos()
    {
      ChallengeTitle = "Insert at specific position of a Linked List";
    }

    static void Solve(SinglyLinkedListNode head)
    {
      // The solution to this one is to complete method "insertNodeAtHead"
    }

    static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
    {
      SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

      if (position == 0)
      {
        newNode.next = head;
        return newNode;
      }
      else
      {
        SinglyLinkedListNode pos = head;
        int i = 0;
        while (i < position)
        {
          pos = pos.next;
        }
      }
      return head;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"InsertAtSpecPos.txt");

      SinglyLinkedList llist = new SinglyLinkedList();

      int llistCount = Convert.ToInt32(reader.ReadLine());

      for (int i = 0; i < llistCount; i++)
      {
        int llistItem = Convert.ToInt32(reader.ReadLine());
        llist.InsertNode(llistItem);
      }

      int data = Convert.ToInt32(reader.ReadLine());

      int position = Convert.ToInt32(reader.ReadLine());

      SinglyLinkedListNode llist_head = insertNodeAtPosition(llist.head, data, position);

      PrintSinglyLinkedList(llist_head, " ");
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
