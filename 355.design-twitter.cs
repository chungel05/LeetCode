/*
 * @lc app=leetcode id=355 lang=csharp
 *
 * [355] Design Twitter
 *
 * https://leetcode.com/problems/design-twitter/description/
 *
 * algorithms
 * Medium (40.76%)
 * Likes:    4026
 * Dislikes: 555
 * Total Accepted:    208.3K
 * Total Submissions: 510.1K
 * Testcase Example:  '["Twitter","postTweet","getNewsFeed","follow","postTweet","getNewsFeed","unfollow","getNewsFeed"]\n' +
  '[[],[1,5],[1],[1,2],[2,6],[1],[1,2],[1]]'
 *
 * Design a simplified version of Twitter where users can post tweets,
 * follow/unfollow another user, and is able to see the 10 most recent tweets
 * in the user's news feed.
 * 
 * Implement the Twitter class:
 * 
 * 
 * Twitter() Initializes your twitter object.
 * void postTweet(int userId, int tweetId) Composes a new tweet with ID tweetId
 * by the user userId. Each call to this function will be made with a unique
 * tweetId.
 * List<Integer> getNewsFeed(int userId) Retrieves the 10 most recent tweet IDs
 * in the user's news feed. Each item in the news feed must be posted by users
 * who the user followed or by the user themself. Tweets must be ordered from
 * most recent to least recent.
 * void follow(int followerId, int followeeId) The user with ID followerId
 * started following the user with ID followeeId.
 * void unfollow(int followerId, int followeeId) The user with ID followerId
 * started unfollowing the user with ID followeeId.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input
 * ["Twitter", "postTweet", "getNewsFeed", "follow", "postTweet",
 * "getNewsFeed", "unfollow", "getNewsFeed"]
 * [[], [1, 5], [1], [1, 2], [2, 6], [1], [1, 2], [1]]
 * Output
 * [null, null, [5], null, null, [6, 5], null, [5]]
 * 
 * Explanation
 * Twitter twitter = new Twitter();
 * twitter.postTweet(1, 5); // User 1 posts a new tweet (id = 5).
 * twitter.getNewsFeed(1);  // User 1's news feed should return a list with 1
 * tweet id -> [5]. return [5]
 * twitter.follow(1, 2);    // User 1 follows user 2.
 * twitter.postTweet(2, 6); // User 2 posts a new tweet (id = 6).
 * twitter.getNewsFeed(1);  // User 1's news feed should return a list with 2
 * tweet ids -> [6, 5]. Tweet id 6 should precede tweet id 5 because it is
 * posted after tweet id 5.
 * twitter.unfollow(1, 2);  // User 1 unfollows user 2.
 * twitter.getNewsFeed(1);  // User 1's news feed should return a list with 1
 * tweet id -> [5], since user 1 is no longer following user 2.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= userId, followerId, followeeId <= 500
 * 0 <= tweetId <= 10^4
 * All the tweets have unique IDs.
 * At most 3 * 10^4 calls will be made to postTweet, getNewsFeed, follow, and
 * unfollow.
 * 
 * 
 */

// @lc code=start
using System.Runtime.InteropServices;

public class Twitter
{
    private Dictionary<int, List<int>> followMap;
    private Dictionary<int, List<int[]>> tweetMap; // Key: userId, Value: [0] authorId, [1] tweetId, [2] time
    private int timeCount;


    public Twitter()
    {
        followMap = new Dictionary<int, List<int>>();
        tweetMap = new Dictionary<int, List<int[]>>();
        timeCount = 0;
    }

    private void AddPost(int userId, int authorId, int tweetId, int time)
    {
        if (!tweetMap.ContainsKey(userId))
            tweetMap[userId] = new List<int[]>();
        tweetMap[userId].Add(new int[] { authorId, tweetId, time });
    }

    private void DeletePost(int userId, int followeeId)
    {
        if (tweetMap.ContainsKey(userId))
        {
            List<int[]> newsFeed = new List<int[]>();
            foreach (var tmp in tweetMap[userId].FindAll(x => x[0] != followeeId))
            {
                newsFeed.Add(new int[] { tmp[0], tmp[1], tmp[2] });
            }
            tweetMap[userId] = newsFeed;
        }
    }

    public void PostTweet(int userId, int tweetId)
    {
        // add to personal news feed
        AddPost(userId, userId, tweetId, timeCount);

        // add to follower's news feed
        foreach (var user in followMap)
        {
            if (user.Key != userId)
            {
                if (user.Value.Contains(userId))
                {
                    AddPost(user.Key, userId, tweetId, timeCount);
                }
            }
        }
        timeCount++;
    }

    public IList<int> GetNewsFeed(int userId)
    {
        if (tweetMap.ContainsKey(userId))
            return tweetMap[userId].OrderByDescending(x => x[2]).Select(x => x[1]).Take(10).ToList();
        return new List<int>();
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!followMap.ContainsKey(followerId))
            followMap[followerId] = new List<int>();
        if (!followMap[followerId].Contains(followeeId))
        {
            followMap[followerId].Add(followeeId);

            if (tweetMap.ContainsKey(followeeId))
            {
                foreach (var tweet in tweetMap[followeeId].FindAll(x => x[0] == followeeId))
                {
                    AddPost(followerId, followeeId, tweet[1], tweet[2]);
                }
            }
        }
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (followMap.ContainsKey(followerId))
            followMap[followerId].Remove(followeeId);
        DeletePost(followerId, followeeId);
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */
// @lc code=end

