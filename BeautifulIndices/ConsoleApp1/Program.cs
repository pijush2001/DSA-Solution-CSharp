public class Solution
{
    public IList<int> BeautifulIndices(string s, string a, string b, int k)
    {
        var rs = new List<int>();
        var candidates = GetBeautifulIndices(s, a);
        if (candidates.Count == 0) return rs;
        var list = GetBeautifulIndices(s, b);
        if (list.Count == 0) return rs;
        for (int i = 0; i < candidates.Count; i++)
        {
            if (ExistRightIndex(candidates[i], k, list))
            {
                rs.Add(candidates[i]);
            }
            else
            {
                if (ExistLeftIndex(candidates[i], k, list))
                {
                    rs.Add(candidates[i]);
                }
            }
        }
        return rs;
    }
    private bool ExistLeftIndex(int val, int k, List<int> list)
    {
        var index = FindLeftIndex(val, list);
        if (-1 < index)
        {
            var rs = val - list[index] <= k;
            return rs;
        }
        return false;
    }
    private int FindLeftIndex(int val, List<int> list)
    {
        // list[index0] <= val < list[index1]
        var index0 = 0;
        if (val < list[index0]) return index0 - 1;
        var index1 = list.Count - 1;
        if (list[index1] <= val) return index1;
        while (index1 - index0 > 1)
        {
            var indexMid = (index0 + index1) / 2;
            if (list[indexMid] <= val)
            {
                index0 = indexMid;
            }
            else
            {
                index1 = indexMid;
            }
        }
        return index0;
    }
    private bool ExistRightIndex(int val, int k, List<int> list)
    {
        var index = FindRightIndex(val, list);
        if (index < list.Count)
        {
            var rs = list[index] - val <= k;
            return rs;
        }
        return false;
    }
    private int FindRightIndex(int val, List<int> list)
    {
        // list[index0] < val <= list[index1]
        var index0 = 0;
        if (val <= list[index0]) return index0;
        var index1 = list.Count - 1;
        if (list[index1] < val) return index1 + 1;
        while (index1 - index0 > 1)
        {
            var indexMid = (index0 + index1) / 2;
            if (list[indexMid] < val)
            {
                index0 = indexMid;
            }
            else
            {
                index1 = indexMid;
            }
        }
        return index1;
    }
    private List<int> GetBeautifulIndices(string s, string a)
    {
        var rs = new List<int>();
        var index = s.IndexOf(a);
        while (index >= 0)
        {
            rs.Add(index);
            index = s.IndexOf(a, index + 1);
        }
        return rs;
    }
}
