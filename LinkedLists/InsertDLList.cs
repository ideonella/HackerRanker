using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class InsertDLList : HackerRankController
  {
    public InsertDLList()
    {
      ChallengeTitle = "Insert a node into a sorted doubly linked list";
    }

    /// <summary>
    /// Given a reference to the head of a doubly-linked list and an integer, data, 
    /// create a new DoublyLinkedListNode object having data value data and insert it 
    /// into a sorted linked list while maintaining the sort.
    /// </summary>
    /// <param name="head"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)
    {
      DoublyLinkedListNode newNode = new DoublyLinkedListNode(data), traverse = head;
      bool first = true;

      if (head == null)
      {
        head = newNode;
      }
      else
      {
        //Not the pretiest thing I've ever seen but hey. It works and is linear.
        while (traverse != null && newNode.prev == null && newNode.next == null)
        {
          if (traverse.data >= newNode.data)
          {
            newNode.prev = traverse.prev;
            if (!first)
            {
              traverse.prev.next = newNode;
            }
            newNode.next = traverse;
            traverse.prev = newNode;

            head = first ? newNode : head;
          }
          else if (traverse.next == null)
          {
            traverse.next = newNode;
            newNode.prev = traverse;
          }
          traverse = traverse.next;
          first = false;
        }
      }

      return head;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"InsertDLList.txt");

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

        int data = Convert.ToInt32(reader.ReadLine());

        DoublyLinkedListNode llist1 = sortedInsert(llist.head, data);

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
