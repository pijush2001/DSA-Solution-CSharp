internal class Program
{
    private static void Main(string[] args)
    {
        Twitter twitter = new Twitter();
        twitter.PostTweet(1, 5);
        twitter.PostTweet(1, 3);
        twitter.PostTweet(1,101);
        twitter.PostTweet(1, 13);
        twitter.PostTweet(1, 10);
        twitter.PostTweet(1, 2);
        twitter.PostTweet(1, 94);
        twitter.PostTweet(1, 505);
        twitter.PostTweet(1, 333);
        twitter.PostTweet(1, 22);
        twitter.PostTweet(1, 11);
        IList<int> newsFeed1 = twitter.GetNewsFeed(1);
        

    }
}
public class Twitter
{
    int time;
    Dictionary<int, HashSet<int>> followers;  //userid, list of user the user folow
    Dictionary<int, Stack<(int, int)>> tweets; //userid, (tweetId, timee)
    int maxTweet;
    int currentTime;

    public Twitter()
    {
        followers = new Dictionary<int, HashSet<int>>();
        tweets = new Dictionary<int, Stack<(int, int)>>();
        maxTweet = 10;
        currentTime = 1;
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!tweets.ContainsKey(userId))
        {
            Stack<(int, int)> tweet = new Stack<(int, int)>();
            tweet.Push((tweetId, currentTime));
            tweets.Add(userId, tweet);
        }
        else
        {
            tweets[userId].Push((tweetId, currentTime));
        }


        currentTime++;
    }

    public IList<int> GetNewsFeed(int userId)
    {
        PriorityQueue<int, int> recentTweets = new PriorityQueue<int, int>();
        //follower's tweet
        HashSet<int> followersId;
        if (followers.ContainsKey(userId))
        {
            followersId = followers[userId];
        }
        else
        {
            followersId = new HashSet<int>();
        }
        if (tweets.ContainsKey(userId))
        {
            followersId.Add(userId);
        }
        //merged user tweet with follower tweet
        foreach (int followerId in followersId)
        {
            if (tweets.ContainsKey(followerId))
            {
                //Stack<(int, int)> allTweetsOfTheFollower = tweets[followerId];
                foreach (var item in tweets[followerId])
                {
                    
                    int tweetId = item.Item1;
                    int timeOfTweet = item.Item2;

                    recentTweets.Enqueue(tweetId, timeOfTweet);
                    if (recentTweets.Count > maxTweet)
                    {
                        recentTweets.Dequeue();
                    }
                    //tweets[followerId].Pop();
                }
            }
        }
        //string the result into a List
        IList<int> res = new List<int>();
        while (recentTweets.Count > 0)
        {
            // Dequeue elements in priority order and add them to the list
            res.Add(recentTweets.Dequeue());
        }
        List<int> reversedList = new List<int>(res);
        reversedList.Reverse();
        res = reversedList;
        //res.Reverse();
        return res;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!followers.ContainsKey(followerId))
        {
            HashSet<int> follower = new HashSet<int>();
            follower.Add(followeeId);
            followers.Add(followerId, follower);
        }
        else
        {
            followers[followerId].Add(followeeId);
        }
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (followers.ContainsKey(followerId))
        {
            followers[followerId].Remove(followeeId);
        }

    }
}