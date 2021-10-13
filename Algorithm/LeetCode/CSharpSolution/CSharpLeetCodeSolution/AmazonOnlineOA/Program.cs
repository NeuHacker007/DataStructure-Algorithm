using System;
using OASolution;

namespace AmazonOnlineOA
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(3);
            node.Next = new SinglyLinkedListNode(1);
            node.Next.Next = new SinglyLinkedListNode(1);
            node.Next.Next.Next = new SinglyLinkedListNode(3);

            Code1Solution solution = new Code1Solution();

            System.Console.WriteLine(solution.GetMaxReadPages(node));
        }
    }
}
