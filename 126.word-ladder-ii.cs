/*
 * @lc app=leetcode id=126 lang=csharp
 *
 * [126] Word Ladder II
 *
 * https://leetcode.com/problems/word-ladder-ii/description/
 *
 * algorithms
 * Hard (27.14%)
 * Likes:    6107
 * Dislikes: 783
 * Total Accepted:    386.3K
 * Total Submissions: 1.4M
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
 * all the shortest transformation sequences from beginWord to endWord, or an
 * empty list if no such sequence exists. Each sequence should be returned as a
 * list of the words [beginWord, s1, s2, ..., sk].
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: beginWord = "hit", endWord = "cog", wordList =
 * ["hot","dot","dog","lot","log","cog"]
 * Output: [["hit","hot","dot","dog","cog"],["hit","hot","lot","log","cog"]]
 * Explanation: There are 2 shortest transformation sequences:
 * "hit" -> "hot" -> "dot" -> "dog" -> "cog"
 * "hit" -> "hot" -> "lot" -> "log" -> "cog"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: beginWord = "hit", endWord = "cog", wordList =
 * ["hot","dot","dog","lot","log"]
 * Output: []
 * Explanation: The endWord "cog" is not in wordList, therefore there is no
 * valid transformation sequence.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= beginWord.length <= 5
 * endWord.length == beginWord.length
 * 1 <= wordList.length <= 500
 * wordList[i].length == beginWord.length
 * beginWord, endWord, and wordList[i] consist of lowercase English
 * letters.
 * beginWord != endWord
 * All the words in wordList are unique.
 * The sum of all shortest transformation sequences does not exceed 10^5.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private void DFSFindLadders(Dictionary<string, HashSet<string>> graph, Dictionary<string, int> dist, List<IList<string>> res, List<string> path, string currWord, string beginWord)
    {
        if (currWord == beginWord)
        {
            res.Add(new List<string>(path));
            return;
        }

        if (!graph.ContainsKey(currWord))
            return;

        foreach (string prev in graph[currWord])
        {
            // Since the graph contains all possible adj. nodes, so we need distance map to find out the prev level nodes
            if (dist[prev] + 1 == dist[currWord])
            {
                path.Insert(0, prev);
                DFSFindLadders(graph, dist, res, path, prev, beginWord);
                path.RemoveAt(0);
            }
        }
    }

    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        List<IList<string>> res = new List<IList<string>>();
        // change List to HashSet for better performance
        HashSet<string> wordSet = new HashSet<string>(wordList);
        if (!wordSet.Contains(endWord))
            return res;

        // Create whole graph and distance map
        Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();
        Dictionary<string, int> dist = new Dictionary<string, int>();

        Queue<string> q = new Queue<string>();
        int steps = 1;
        bool finish = false;

        // source: beginWord, distance = 0
        q.Enqueue(beginWord);
        dist.Add(beginWord, 0);

        while (q.Count > 0 && !finish)
        {
            for (int i = q.Count; i > 0; i--)
            {
                string currWord = q.Dequeue();
                char[] chs = currWord.ToCharArray();
                for (int j = 0; j < chs.Length; j++)
                {
                    // for every char in currWord, we try to check the possible word
                    char old = chs[j];
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        // if it is same as currWord, skip it
                        if (c == old)
                            continue;

                        chs[j] = c;
                        string newWord = new string(chs);

                        // if we found the new Word
                        if (wordSet.Contains(newWord))
                        {
                            // Create graph, which key is new Word, and corresponding predecessors
                            if (!graph.ContainsKey(newWord))
                                graph[newWord] = new HashSet<string>();
                            graph[newWord].Add(currWord);

                            // Create distance map, from 0 to k steps
                            // it is the shortest distance to source
                            if (!dist.ContainsKey(newWord))
                            {
                                // if we found the endWord, we will break at next level
                                if (newWord == endWord)
                                    finish = true;

                                // add new Word with curr steps
                                dist.Add(newWord, steps);

                                // Enqueue to move on to next level
                                q.Enqueue(newWord);
                            }
                        }
                    }

                    chs[j] = old;
                }
            }
            steps++;
        }

        // DFS backtracking from endWord to beginWord
        DFSFindLadders(graph, dist, res, new List<string>() { endWord }, endWord, beginWord);

        return res;
    }
}
// @lc code=end

