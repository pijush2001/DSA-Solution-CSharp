internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5 };

        Node head = LlController.ConverTArrayToLL(arr);

        //head = LlController.InsertNewValueAtEnd(head, 6);

        head = LlController.ReverseList(head);
    }
    public void InsertFirstNode()
    {

    }
}
    

public class Node
{
    public int data;
    public Node next { get; set; }
    public Node(int data, Node node)
    {
        this.data = data;
        this.next = node;
    }
    public Node(int data)
    {
        this.data = data;
        this.next = null;
    }



}
    public static class LlController
    {
        public static Node ConverTArrayToLL(int[] arr)
        {
            Node head = new Node(arr[0]);
            Node mover = head;
            for (int i = 1; i < arr.Length; i++)
            {
                Node temp = new Node(arr[i], null);
                mover.next = temp;
                mover = mover.next;
            }
            return head;
        }

        public static Node InsertNewValueAtEnd(Node head,int data)
        {
            Node temp = head;
            Node newNode = new Node(data);
            while(temp != null)
            {
                temp = temp.next;


            }
            temp.next = newNode;
            return newNode;
        }

    public static Node ReverseList(Node head)
    {
        if (head == null) return head;
        Node prev = null;
        Node current = head;
        Node next = null;

        while (current != null)
        {
            next = current.next;  // Store next node
            current.next = prev;  // Reverse current node's pointer
            prev = current;       // Move prev to current
            current = next;       // Move to next node
        }

        return prev;
    }
}



