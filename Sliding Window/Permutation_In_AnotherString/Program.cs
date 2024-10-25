using System.ComponentModel.Design;

internal class Program
{
    private static void Main(string[] args)
    {
        bool ans = CheckInclusion("hello", "ooolleoooleh");
    }
    public static  bool CheckInclusion(string s1, string s2)
    {
        if (s2.Contains(s1)) return true;
        int[] freq1 = new int[26];
        int count = 0;
        for (int i = 0; i < s1.Length; i++)
        {
            freq1[s1[i] - 'a']++;
            count++;
        }

        int st = 0, end = 0;
        Dictionary<char, int> map = new Dictionary<char, int>();

        while (end < s2.Length)
        {
            int x = s2[end] - 'a';
            if (freq1[x] != 0)
            {
                if (!map.ContainsKey(s2[end]))
                {
                    map.Add(s2[end], 1);
                }
                else
                {
                    map[s2[end]]++;
                }

                while (map[s2[end]] > freq1[x])
                {
                    map[s2[st]]--;
                    if (map[s2[st]] == 0) map.Remove(s2[st]);
                    st++;
                }

                if (count == end - st + 1)
                {
                    return true;
                }
                end++;
            }
            else
            {
                st = end + 1;
                end++;
                map.Clear();
            }
        }

        if (count == end - st ) return true;
        return false;
    }
}
