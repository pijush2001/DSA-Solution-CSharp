internal class Program
{
    private static void Main(string[] args)
    {
       Solution solution = new Solution();
        int ans = solution.longestKSubstr("aabacbebebe", 3);
        
    }
}
class Solution
{
    //Complete this function
    public int longestKSubstr(string s, int k)
    {
        Dictionary<char,int> map = new Dictionary<char,int>();
        int ans = 0, start = 0, end = 0;
        while(end< s.Length)
        {

            if (!map.ContainsKey(s[end]))
            {
                map.Add(s[end],1);
            }
            else
            {
                map[s[end]]++;
            }
            if (map.Count == k)
            {
                
                ans = Math.Max(ans, end-start+1);
            }
            else if (map.Count > k)
            {
                map[s[start]]--;
                if (map[s[start]] == 0) map.Remove(s[start]);
                start++;
            }
            
            end++;

        }
        return ans==0 ? -1 : ans;
        // your code here
    }
}