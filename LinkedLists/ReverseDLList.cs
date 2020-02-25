using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class ReverseDLList : HackerRankController
  {
    public ReverseDLList()
    {
      ChallengeTitle = "Reverse a doubly linked list";
    }

    /// <summary>
    /// You’re given the pointer to the head node of a doubly linked list. Reverse the 
    /// order of the nodes in the list. The head node might be NULL to indicate that the 
    /// list is empty. Change the next and prev pointers of all the nodes so that the 
    /// direction of the list is reversed. Return a reference to the head node of the 
    /// reversed list. 
    /// </summary>
    /// <param name="head"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    static DoublyLinkedListNode Solve(DoublyLinkedListNode head)
    {
      DoublyLinkedListNode reverseHead = new DoublyLinkedListNode(0), prevNode;
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
          prevNode.prev = reverseHead;
        }
      }
      return reverseHead;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"ReverseDLList.txt");

      int t = Convert.ToInt32(reader.ReadLine());

      for (int tItr = 0; tItr < t; tItr++)
      {
        DoublyLinkedList llist = new DoublyLinkedList();

        int llistCount = Convert.ToInt32(reader.ReadLine());

        for (int i = 0; i < llistCount; i++)
        {
          int llistItem = Convert.ToInt32(reader.ReadLine());
          llist.InsertNode(llistItem);
        }

        DoublyLinkedListNode llist1 = Solve(llist.head);

        PrintDoublyLinkedList(llist1, " ");
        Console.WriteLine();
      }

    }

    //Provided by HackerRank
    class DoublyLinkedListNode
    {
      public int data;
      public DoublyLinkedListNode next;
      public DoublyLinkedListNode prev;

      public DoublyLinkedListNode(int nodeData)
      {
        this.data = nodeData;
        this.next = null;
        this.prev = null;
      }
    }

    //Provided by HackerRank
    class DoublyLinkedList
    {
      public DoublyLinkedListNode head;
      public DoublyLinkedListNode tail;

      public DoublyLinkedList()
      {
        this.head = null;
        this.tail = null;
      }

      //Provided by HackerRank
      public void InsertNode(int nodeData)
      {
        DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);
        if (this.head == null)
        {
          this.head = node;
        }
        else
        {
          this.tail.next = node;
          node.prev = this.tail;
        }
        this.tail = node;
      }
    }

    //Provided by HackerRank
    static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep)
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
