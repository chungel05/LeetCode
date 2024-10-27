/*
 * @lc app=leetcode id=127 lang=csharp
 *
 * [127] Word Ladder
 *
 * https://leetcode.com/problems/word-ladder/description/
 *
 * algorithms
 * Hard (40.58%)
 * Likes:    12285
 * Dislikes: 1899
 * Total Accepted:    1.2M
 * Total Submissions: 2.9M
 * Testcase Example:  '"hit"\n"cog"\n["hot","dot","dog","lot","log","cog"]'
 *
 * A transformation sequence from word beginWord to word endWord using a
 * dictionary wordList is a sequence of words beginWord -> s1 -> s2 -> ... ->
 * sk such that:
 * 
 * 
 * Every adjacent pair of words differs by a single letter.
 * Every si for 1 <= i <= k is in wordList. Note that beginWord does not need
 * to be in wordList.
 * sk == endWord
 * 
 * 
 * Given two words, beginWord and endWord, and a dictionary wordList, return
 * the number of words in the shortest transformation sequence from beginWord
 * to endWord, or 0 if no such sequence exists.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: beginWord = "hit", endWord = "cog", wordList =
 * ["hot","dot","dog","lot","log","cog"]
 * Output: 5
 * Explanation: One shortest transformation sequence is "hit" -> "hot" -> "dot"
 * -> "dog" -> cog", which is 5 words long.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: beginWord = "hit", endWord = "cog", wordList =
 * ["hot","dot","dog","lot","log"]
 * Output: 0
 * Explanation: The endWord "cog" is not in wordList, therefore there is no
 * valid transformation sequence.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= beginWord.length <= 10
 * endWord.length == beginWord.length
 * 1 <= wordList.length <= 5000
 * wordList[i].length == beginWord.length
 * beginWord, endWord, and wordList[i] consist of lowercase English
 * letters.
 * beginWord != endWord
 * All the words in wordList are unique.
 * 
 * 
 */
/*
 * BFS implementation
 * Create the adj list by using pattern, i.e. *ot, h*t, ho*
 * actually it is separate the whole adj list into different pattern
 * but it can reduce time from O(n^2 * m)[each word n compare with other word n and m char comparison]
 * to O(n * m^2) [each word n looping the m char to deduct and add to the m list]
 */

// @lc code=start
public partial class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if (!wordList.Contains(endWord))
            return 0;

        Dictionary<string, List<string>> adj = new Dictionary<string, List<string>>();

        wordList.Add(beginWord);
        foreach (string word in wordList)
        {
            for (int i = 0; i < word.Length; i++)
            {
                string pattern = word.Substring(0, i) + "*" + word.Substring(i + 1);
                if (!adj.ContainsKey(pattern))
                    adj.Add(pattern, new List<string>());
                adj[pattern].Add(word);
            }
        }

        int minLength = 1;
        Queue<string> q = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();

        q.Enqueue(beginWord);
        while (q.Count > 0)
        {
            int len = q.Count;
            for (int i = 0; i < len; i++)
            {
                string c = q.Dequeue();
                if (c == endWord)
                    return minLength;

                for (int j = 0; j < c.Length; j++)
                {
                    string pattern = c.Substring(0, j) + "*" + c.Substring(j + 1);
                    if (adj.ContainsKey(pattern))
                    {
                        foreach (string word in adj[pattern])
                        {
                            if (!visited.Contains(word))
                            {
                                visited.Add(word);
                                q.Enqueue(word);
                            }
                        }
                    }
                }
            }
            minLength++;
        }
        return 0;
    }
}
// @lc code=end

