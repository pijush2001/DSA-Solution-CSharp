internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int ans = solution.LargestRectangleArea([1,1]);
    }
}

public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        int[] nsl = NSL(heights);
        int[] nsr = NSR(heights);
        int maxArea = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            //(1+1-1)
            int currentMax = (nsr[i] - nsl[i] - 1) * heights[i];
            maxArea = Math.Max(currentMax, maxArea);
        }
        return maxArea;
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