internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        var ans = solution.FindLadders("hit", "cog", ["hot", "dot", "dog", "lot", "log", "cog"]);
    }
}
public class Solution
{
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> st = new HashSet<string>(wordList);
        List<IList<string>> ans = new List<IList<string>>();
        Queue<List<string>> ladderQ = new Queue<List<string>>();

        if (!st.Contains(endWord)) return ans;

        st.Remove(beginWord);
        ladderQ.Enqueue(new List<string> { beginWord });
        bool found = false;


        while (ladderQ.Count > 0 && !found)
        {
            int levelSize = ladderQ.Count;
            for (int l = 0; l < levelSize; l++)
            {
                List<string> ladders = ladderQ.Dequeue();
                HashSet<string> newWords = new HashSet<string>();
                //var lastStringLen = ladders.Count;
                string word = ladders.Last();
                char[] wordChars = word.ToCharArray();
                for (int i = 0; i < word.Length; i++)
                {
                    char original = wordChars[i];
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        wordChars[i] = ch;
                        string newWord = new string(wordChars);

                        if (st.Contains(newWord))
                        {
                            List<string> newLadder = new List<string>(ladders) { newWord };
                            if (newWord == endWord)
                            {
                                ans.Add(newLadder);
                                //break;
                                found = true; // stop processing once endWord is found
                            }
                            else
                            {
                                ladderQ.Enqueue(newLadder);
                                newWords.Add(newWord);
                            }

                            //st.Remove(newWord);
                        }
                    }
                    wordChars[i] = original;//backtracking


                }
                //removing those words only after that level s completed
                st.Except(newWords);
            }
            


        }
        return ans;
    }
}
public class Pair
{

    public List<string> words;
    public int length;
    public Pair(List<string> words, int length)
    {
        this.words = words;
        this.length = length;
    }
}