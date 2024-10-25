internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
public class ListNode
{
      public int val;
       public ListNode next;
      public ListNode(int val = 0, ListNode next = null)
        {
        this.val = val;
        this.next = next;
         }
}

public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        PriorityQueue< ListNode, int> pq = new PriorityQueue< ListNode, int>(); // actually second item(int) is workig as a key

        for (int i = 0; i < lists.Length; i++)
        {
            if (lists[i] != null)
            pq.Enqueue( lists[i], lists[i].val);//logk        }

        }

        ListNode dummyNode = new ListNode(-1);
        ListNode temp =dummyNode;

        while(pq.Count > 0)
        {
            ListNode tuple = pq.Dequeue();
            temp.next = tuple;
            temp = temp.next;
            if (tuple.next != null)
            {
                pq.Enqueue(tuple.next, tuple.next.val);
                //tuple = tuple.next;
            }
            

            
        }
        return dummyNode.next;

    }

}