using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
	public class InsertAtHead : HackerRankController
	{
		public InsertAtHead()
		{
			ChallengeTitle = "Insert at Head of a linked list";
		}

		/// <summary>
		/// You’re given the pointer to the head node of a linked list and an integer 
		/// to add to the list. Create a new node with the given integer, 
		/// insert this node at the head of the linked list and return the new head node. 
		/// </summary>
		/// <param name="llist"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		static SinglyLinkedListNode Solve(SinglyLinkedListNode llist, int data)
		{
			SinglyLinkedListNode headNew = new SinglyLinkedListNode(data);
			if (llist == null)
			{
				headNew = llist;
			}
			else
			{
				headNew.next = llist;
			}

			return headNew;
		}

		public override void CompleteChallenge()
		{
			using StreamReader reader = new StreamReader(@"InsertAtHead.txt");

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
			public SinglyLinkedListNode tail;

			public SinglyLinkedList()
			{
				this.head = null;
				this.tail = null;
			}
		}
	}
}
