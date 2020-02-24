using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class InsertAtSpecPos : HackerRankController
  {
    public InsertAtSpecPos()
    {
      ChallengeTitle = "Insert at specific position of a linked list";
    }

    /// <summary>
    /// You’re given the pointer to the head node of a linked list, an integer to 
    /// add to the list and the position at which the integer must be inserted. 
    /// Create a new node with the given integer, insert this node 
    /// at the desired position and return the head node. 
    /// </summary>
    /// <param name="head"></param>
    /// <param name="data"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    static SinglyLinkedListNode Solve(SinglyLinkedListNode head, int data, int position)
    {
      SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

      if (position == 1)
      {
        newNode.next = head;
        return newNode;
      }
      else
      {
        SinglyLinkedListNode current = head;
        int i = 1;
        while (i < position)
        {
          current = current.next;
          i++;
        }
        newNode.next = current.next;
        current.next = newNode;
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

      SinglyLinkedListNode llist_head = Solve(llist.head, data, position);

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
