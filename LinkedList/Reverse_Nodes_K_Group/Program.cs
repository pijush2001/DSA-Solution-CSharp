using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = [1, 2, 3, 4, 5];
        int k = 2;


        ListNode head = Solution.ConverTArrayToLL(arr);

        Solution solution = new Solution();
        var ans = solution.ReverseKGroup(head, k);


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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode temp = head;
        ListNode prevNode = null;
       

        while(temp!= null)
        {
            ListNode kNode = FindKthNode(temp, k);
            if (kNode == null)
            {
                //means no need to reverese, not enogh element present
                if(prevNode != null)
                {
                    //if there was a previous group, connect it with this group
                    prevNode.next = temp;
                   
                }
                break;
            }
            //separate the curent group
            ListNode nextNode = kNode.next;
            kNode.next = null;

            //Reverse
            ReverseLL(temp);
            //check if it is the 1st group or not
            // Adjust the head if the reversal
            // starts from the head
            if (temp == head)
            {
                head = kNode;
            }
            // Link the last node of the previous
            // group to the reversed group
            else
            {
                prevNode.next = kNode;
            }
            //storing the prev node as temp for next iteration
            prevNode = temp;
            temp = nextNode;
        }
        return head;

    }

    private ListNode FindKthNode(ListNode head, int k)
    {
        ListNode temp = head;
        k -= 1;

        while(temp != null && k > 0)
        {
            temp = temp.next;
            k--;
        }
      return temp ;
       
    }

    private ListNode ReverseLL(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;

        while (current != null)
        {
            ListNode next = current.next; // Save the next node
            current.next = prev; // Reverse the link
            prev = current; // Move prev to current
            current = next; // Move current to next
        }

        return prev; // Prev becomes the new head of the reversed list


    }
    public static ListNode ConverTArrayToLL(int[] arr)
    {
        ListNode head = new ListNode(arr[0]);
        ListNode mover = head;
        for (int i = 1; i < arr.Length; i++)
        {
            ListNode temp = new ListNode(arr[i], null);
            mover.next = temp;
            mover = mover.next;
        }
        return head;
    }
}
