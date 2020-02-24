using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
  public class DeleteAdjDup : HackerRankController
  {
    public DeleteAdjDup()
    {
      ChallengeTitle = "Delete adjacent duplicates from a linked list";
    }

    /// <summary>
    /// You're given the pointer to the head node of a sorted linked list, 
    /// where the data in the nodes is in ascending order. Delete as few nodes 
    /// as possible so that the list does not contain any value more than once. 
    /// The given head pointer may be null indicating that the list is empty.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    static SinglyLinkedListNode Solve(SinglyLinkedListNode head)
    {
      SinglyLinkedListNode prevNode = head, currentNode = head;
      while (currentNode?.next != null)
      {
        currentNode = currentNode.next;
        if (prevNode.data == currentNode?.data)
        {
          prevNode.next = currentNode.next;
        }
        else
        {
          prevNode = currentNode;
        }
      }

      return head;
    }

    public override void CompleteChallenge()
    {
      using StreamReader reader = new StreamReader(@"DeleteAdjDup.txt");

      int t = Convert.ToInt32(reader.ReadLine());

      for (int tItr = 0; tItr < t; tItr++)
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
        Console.WriteLine();
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
