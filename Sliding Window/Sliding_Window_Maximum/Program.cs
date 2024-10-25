internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        //int maxIndex = 0;
        //int maxValue = (int)1e9;
        int[] res = new int[nums.Length - k + 1];
        int left = 0, right = 0;
        int j = 0;

        LinkedList<int> deque = new LinkedList<int>();

        while (right != nums.Length)
        {
            while (deque.Count>0 && nums[right] > nums[deque.Last.Value])
            {
                //remove all the element from the queue that is less than current value
                deque.RemoveLast();
            }
            deque.AddLast(nums[right]);
            if(deque.Count > 0 && left > deque.First.Value )
            {
                //if the left index was hlding maximum value, then remove it from the queue
                deque.RemoveFirst() ;

            }

            if (right+1 >=k && deque.Count > 0 )
            {
                
                res[left] = deque.First.Value;
                left++;
                
            }
            


            right++;
        }
        return res;

    }
    
}