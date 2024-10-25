using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
       Solution solution = new Solution();
        Console.WriteLine(solution.LadderLength("hit", "cog", ["hot", "dot", "dog", "lot", "log", "cog"]));
    }
}
public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if(!wordList.Contains(endWord))
        {
            return 0;

        }
        Queue<Pair> bfsQ= new Queue<Pair>();
        bfsQ.Enqueue(new Pair(beginWord, 1));
        int length = 1;
        wordList.Remove(beginWord);
        while(bfsQ.Count > 0)
        {
            var nodeWord=bfsQ.Peek();
            bfsQ.Dequeue();
            string word = nodeWord.word;
             length = nodeWord.length ;

            for(int i = 0;i<word.Length;i++)
            {
                for(var j = 'a'; j <= 'z'; j++)
                {
                    var newWord = new StringBuilder(word);
                    newWord.Remove(i,1);
                    newWord.Insert(i, j.ToString());
                    var replaceWord = newWord.ToString();
                   // newWord = newWord.Remove(i).Insert(i, j.ToString());
                    if(wordList.Contains(replaceWord))
                    {
                        bfsQ.Enqueue(new Pair(replaceWord, length+1));
                        wordList.Remove(replaceWord);
                    }
                }
            }

        }




        return length;

    }
}
public class Pair
{

    public string word;
    public int length;
    public Pair(string word, int length)
    {
        this.word = word;
        this.length = length;
    }
}