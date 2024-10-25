internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.IsSubstringPresent("Hello, World!"));
    }
}
public class Solution
{
    public bool IsSubstringPresent(string s)
    {
        char[] stringArray = s.ToCharArray();
        Array.Reverse(stringArray);
        string rs = new string(stringArray);
        Console.WriteLine(rs);


        List<string> sList = new List<string>();
        List<string> rsList = new List<string>();
        /*sList = Enumerable.Range(0, s.Length / 2)
                                                .Select(i => s.Substring(i * 2, 2))
                                                .ToList();
        var rsList = Enumerable.Range(0, rs.Length / 2)
                                                 .Select(i => rs.Substring(i * 2, 2))
                                                 .ToList();*/
        for (int i = 0; i < s.Length-1 ; i++)
        {
            sList.Add(s.Substring(i, 2));
            rsList.Add(rs.Substring(i, 2));
        }

        foreach (var element in sList)
        {
            if (rsList.Contains(element))
            {
                return true;
            }
        }

        return false;

    }
}