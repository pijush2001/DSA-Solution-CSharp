internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class Node
{
    public int key;
    public int value;
    public Node next;
    public Node prev;

    public Node(int key, int value)
    {
        this.key = key;
        this.value = value;
        this.next = null;
        this.prev = null;

    }


}

public class LRUCache
{
    Node dummyHead = new Node(-1, -1);

    Node dummyTail = new Node(-1, -1);
    int capacity = 0;

    Dictionary<int, Node> avaiableNodes = new Dictionary<int, Node>();
    private readonly Dictionary<int, int> cache;
    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        dummyHead.next = dummyTail;
        dummyTail.prev = dummyHead;
    }

    public int Get(int key)
    {
        if (avaiableNodes.ContainsKey(key))
        {
            Node node = avaiableNodes[key];
            DeleteFromTail(node);
            InsertFromHead(node);
            return node.value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if(!avaiableNodes.ContainsKey(key))
        {
            //if the node asking is not in our linked list, add it to the head so that it is most recently used

            //before that check if capacity exceeded
            if (avaiableNodes.Count >= capacity)
            {
                Node node = dummyTail.prev;
                DeleteFromTail(node);
                avaiableNodes.Remove(node.key);
                Node newNode = new Node(key, value);
                InsertFromHead(newNode);
                avaiableNodes.Add(key, newNode);
            }
            else
            {
                Node newNode = new Node(key, value);
                InsertFromHead(newNode);
                avaiableNodes.Add(key, newNode);

            }
        }
        else
        {
            //update value
            Node node = avaiableNodes[key];
            node.value = value;
            DeleteFromTail(node);
            InsertFromHead(node);
            
        }
        
    }

    public void DeleteFromTail(Node node)
    {
        Node prevNode = node.prev;
        Node nextNode = node.next;

        prevNode.next = nextNode;
        nextNode.prev = prevNode;

    }

    public void InsertFromHead(Node node)
    {
        Node nextNode = dummyHead.next;
        dummyHead.next = node;
        node.prev = dummyHead;
        node.next = nextNode;
        nextNode.prev = node;

    }

}