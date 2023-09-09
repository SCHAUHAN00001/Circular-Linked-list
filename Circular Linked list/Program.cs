using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circular_Linked_list
{
    internal class Program
    {
        public class Node
        {
            public int element;
            public Node next;
            public Node( int e, Node n)
            { 
                element = e;
                next = n;
            }
        }
        class Circular_Linked_List
        {
            private Node head;
            private Node tail;
            private int size;
            public  Circular_Linked_List()
            {
                head = null;
                tail = null;
                size = 0;

            }
            public int length()
            {
                return size;
            }
            public bool isEmpty()
            {
                return size == 0;
            }
            public void addLast(int e)
            {
                Node newest = new Node(e, null);
                if(isEmpty())
                {
                    newest.next = newest;
                    head = newest;
                }
                else
                {
                    newest.next = tail.next;
                    tail.next = newest;
                }
                tail = newest;
                size++;
            }
            public void addFirst(int e)
            {
                Node newest = new Node(e, null);
                if (isEmpty())
                {
                    newest.next = newest;
                    head = newest;
                    tail = newest;
                }
                else
                {
                    tail.next = newest;
                    newest.next = head;
                    head = newest;
                }
                size++;
            }
            public void addAnywhere(int e, int position) 
            {
                Node newest = new Node(e, null);
                Node p = head;
                int i = 1;
                while (i < position - 1)
                {
                    p = p.next;
                    i++;
                }
                newest.next = p.next;
                p.next = newest;
                size++;
            }
            public int removeFirst()
            {
                if (isEmpty())
                {
                    Console.WriteLine("List is empty");
                    return -1;
                }
                int e = head.element;
                tail.next = head.next;
                head = head.next;
                size--;
                if (isEmpty())
                {
                    head = null;
                    tail = null;
                }
                return e;
            }
            public int removelast()
            {
                if(isEmpty())
                {
                    Console.WriteLine("List is empty");
                    return -1;
                }
                Node p = head;
                int i = 1;
                while (i < length()-1)
                {
                    p = p.next;
                    i++;
                }
                tail = p;
                tail.next = head;
                int e =p.element;
                size--;
                return e;

            }
            public int removeAnywhere(int position)
            {
                Node p = head;
                int i = 1;
                while (i < position - 1)
                {
                    p = p.next;
                    i++;

                }
                int e = p.next.element;
                p.next = p.next.next;
                size--;
                return e;
            }

            public void display()
            {
                Node p = head;
                int i = 0;
                while (i < length())
                {
                    Console.WriteLine(p.element);
                    p= p.next;
                    i++;
                }
            }
        }
        static void Main(string[] args)
        {
            Circular_Linked_List Circular = new Circular_Linked_List();
            Circular.addLast(1);
            Circular.addLast(2);
            Circular.addLast(3);
            Circular.addLast(4);
            Circular.addLast(5);
            Circular.addLast(6);
            Circular.display();
            Console.WriteLine("Size --> " + Circular.length());
            Console.WriteLine();
            Console.WriteLine("Creating Circular link list by adding then element in first place: ");
            Circular.addFirst(15);
            Circular.display();
            Console.WriteLine("Size --> " + Circular.length());
            Console.WriteLine();
            Console.WriteLine("Creating Circular link list by adding Anywhere user wants to insert: ");
            Circular.addAnywhere(20, 3);
            Circular.display();
            Console.WriteLine("Size --> " + Circular.length());
            Console.WriteLine();
            Console.WriteLine("Removing first element from the list: ");
            Circular.removeFirst();
            Circular.display();
            Console.WriteLine("Size --> " + Circular.length());
            Console.WriteLine();
            Console.WriteLine("Removing last element from the list");
            Circular.removelast();
            Circular.display();
            Console.WriteLine("Size --> " + Circular.length());
            Console.WriteLine();
            Console.WriteLine("Removing 4th element of the List: ");
            Circular.removeAnywhere(4);
            Circular.display();
            Console.WriteLine("Size --> " + Circular.length());




            Console.ReadLine();
        }
    }
}
