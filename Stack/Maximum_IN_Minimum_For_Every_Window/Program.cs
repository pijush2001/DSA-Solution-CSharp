internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        var res = solution.maxOfMin([35, 22, 74, 33, 88], 5);
    }
}

class Solution
{
    //Complete this function
    //Function to find maximum of minimums of every window size.
    public List<int> maxOfMin(int[] arr, int n)
    {
        //Your code here

        int[] res = new int[n];
        for (int i = 0; i < n; i++)
        {
            res[i] = Int32.MinValue;
        }

        int[] nsl = NSL(arr);
        int[] nsr = NSR(arr);

        for (int i = 0; i < n; i++)
        {
            //checking on left which window it will be a minimum value
            int leftDist = i - nsl[i];
            int rightDist = nsr[i] - i;
            for (int j = 0; j < leftDist + rightDist -1; j++)
            {
                res[j] = Math.Max(res[j], arr[i]);
            }

            
            
            
        }

        return res.ToList();

    }
    public int[] NSL(int[] height)
    {
        Stack<(int, int)> st = new Stack<(int, int)>();
        int n = height.Length;
        int[] idx = new int[height.Length];

        for (int i = 0; i < n; i++)
        {
            if (st.Count == 0) idx[i] = -1;
            else if (st.Count > 0 && st.Peek().Item1 < height[i])
            {
                idx[i] = st.Peek().Item2;//index
            }
            else if (st.Count > 0 && st.Peek().Item1 >= height[i])
            {
                while (st.Count > 0 && st.Peek().Item1 >= height[i])
                {
                    st.Pop();
                }
                if (st.Count == 0) idx[i] = -1;
                else idx[i] = st.Peek().Item2;//index
            }
            st.Push((height[i], i));
        }
        return idx;
    }

    public int[] NSR(int[] height)
    {
        Stack<(int, int)> st = new Stack<(int, int)>();
        int n = height.Length;
        int[] idx = new int[height.Length];
        for (int i = n - 1; i >= 0; i--)
        {
            if (st.Count == 0) idx[i] = height.Length;
            else if (st.Count > 0 && st.Peek().Item1 < height[i])
            {
                idx[i] = st.Peek().Item2;//index
            }
            else if (st.Count > 0 && st.Peek().Item1 >= height[i])
            {
                while (st.Count > 0 && st.Peek().Item1 >= height[i])
                {
                    st.Pop();
                }
                if (st.Count == 0) idx[i] = n;
                else idx[i] = st.Peek().Item2;//index
            }
            st.Push((height[i], i));
        }
        return idx;
    }

}