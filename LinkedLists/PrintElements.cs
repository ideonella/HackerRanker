using HackerRankCtrl;
using System;
using System.IO;

namespace LinkedLists
{
	public class PrintElements : HackerRankController
	{
		public PrintElements()
		{
			ChallengeTitle = "Print the Elements of a linked list";
		}

		static void Solve(SinglyLinkedListNode head)
		{
			if (head != null)
			{
				Console.WriteLine(head.data);
				while (head.next != null)
				{
					head = head.next;
					Console.WriteLine(head.data);
				}
			}
		}

		public override void CompleteChallenge()
		{
			using StreamReader reader = new StreamReader(@"PrintElements.txt");

			SinglyLinkedList llist = new SinglyLinkedList();

			int llistCount = Convert.ToInt32(reader.ReadLine());

			for (int i = 0; i < llistCount; i++)
			{
				int llistItem = Convert.ToInt32(reader.ReadLine());
				llist.InsertNode(llistItem);
			}

			Solve(llist.head);
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
	}
}
