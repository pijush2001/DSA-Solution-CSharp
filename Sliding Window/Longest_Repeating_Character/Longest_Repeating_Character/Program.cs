using Longest_Repeating_Character;

internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        //int ans= solution.CharacterReplacement("AABABBA", 1);
        int niceSubarray=NiceSubarray.NumberOfSubarrays([2, 2, 2, 1, 2, 2, 1, 2, 2, 2], 2);
         BinarySubarraysWithSum binarySubarraysWithSum = new BinarySubarraysWithSum();
       int count= binarySubarraysWithSum.NumSubarraysWithSum([1, 0, 1, 0, 1], 2);
    }
}
public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        int st = 0, end = 0, maxLength = 0;
        int size = s.Length;
        int maxFreq = 0;
        int[] hash = new int[26];
        for (int i = 0; i < 26; i++)
        {
            hash[i] = 0;
        }

        while (end < size)
        {
            hash[s[end] - 'A']++;
            maxFreq = Math.Max(maxFreq, hash[s[end]-'A']);
            int len = end - st + 1;
            //char ch=s[end];
            if (len - maxFreq <= k)
            {
                maxLength = Math.Max(maxLength, len);
            }
            else
            {
                hash[s[st] - 'A']--;
                st++;
            }
            end++;

        }
        maxLength = Math.Max(maxLength, end - st + 1);
        return maxLength;

    }
}

