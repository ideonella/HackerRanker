using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
	public class InsertAtTail : HackerRankController
	{
		public InsertAtTail()
		{
			ChallengeTitle = "Insert at Tail of a Linked List";
		}

		/// <summary>
		/// You are given the pointer to the head node of a linked list and an 
		/// integer to add to the list. Create a new node with the given integer. 
		/// Insert this node at the tail of the linked list and return 
		/// the head node of the linked list formed after inserting this new node. 
		/// The given head pointer may be null, meaning that the initial list is empty.
		/// </summary>
		/// <param name="head"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		static SinglyLinkedListNode Solve(SinglyLinkedListNode head, int data)
		{
			SinglyLinkedListNode tail = new SinglyLinkedListNode(data);
			if (head == null)
			{
				head = tail;
			}
			else
			{
				SinglyLinkedListNode node = head;
				while (node.next != null)
				{
					node = node.next;
				}
				node.next = tail;
			}

			return head;
		}

		public override void CompleteChallenge()
		{
			using StreamReader reader = new StreamReader(@"InsertAtTail.txt");

			SinglyLinkedList llist = new SinglyLinkedList();

			int llistCount = Convert.ToInt32(reader.ReadLine());

			for (int i = 0; i < llistCount; i++)
			{
				int llistItem = Convert.ToInt32(reader.ReadLine());
				SinglyLinkedListNode llist_head = Solve(llist.head, llistItem);
				llist.head = llist_head;

			}

			PrintSinglyLinkedList(llist.head, "\n");
		}

		//Provided by HackerRank
		static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
		{
			while (node != null)
			{
				Console.WriteLine(node.data);

				node = node.next;

				if (node != null)
				{
					Console.WriteLine(sep);
				}
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

			public SinglyLinkedList()
			{
				this.head = null;
			}
		}
	}
}
