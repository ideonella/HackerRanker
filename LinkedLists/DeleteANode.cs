using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class DeleteANode : HackerRankController
  {
    public DeleteANode()
    {
      ChallengeTitle = "Delete a node at specific position of a Linked List";
    }

    /// <summary>
    /// You’re given the pointer to the head node of a linked list and the position 
    /// of a node to delete. Delete the node at the given position and return the head node. 
    /// </summary>
    /// <param name="head"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    static SinglyLinkedListNode Solve(SinglyLinkedListNode head, int position)
    {
      if (position == 0)
      {
        if (head.next == null)
        {
          head = null;
        }
        else
        {
          head = head.next;
        }
      }
      else
      {
        SinglyLinkedListNode previous = head;
        int i = 0;
        while (i < position - 1)
        {
          previous = previous.next;
          i++;
        }
        if (previous.next.next == null)
        {
          previous.next = null;
        }
        else
        {
          previous.next = previous.next.next;
        }
      }
      return head;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"DeleteANode.txt");

      SinglyLinkedList llist = new SinglyLinkedList();

      int llistCount = Convert.ToInt32(reader.ReadLine());

      for (int i = 0; i < llistCount; i++)
      {
        int llistItem = Convert.ToInt32(reader.ReadLine());
        llist.InsertNode(llistItem);
      }

      int position = Convert.ToInt32(reader.ReadLine());

      SinglyLinkedListNode llist_head = Solve(llist.head, position);

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
