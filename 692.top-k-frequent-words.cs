/*
 * @lc app=leetcode id=692 lang=csharp
 *
 * [692] Top K Frequent Words
 *
 * https://leetcode.com/problems/top-k-frequent-words/description/
 *
 * algorithms
 * Medium (58.51%)
 * Likes:    7730
 * Dislikes: 351
 * Total Accepted:    655.4K
 * Total Submissions: 1.1M
 * Testcase Example:  '["i","love","leetcode","i","love","coding"]\n2'
 *
 * Given an array of strings words and an integer k, return the k most frequent
 * strings.
 * 
 * Return the answer sorted by the frequency from highest to lowest. Sort the
 * words with the same frequency by their lexicographical order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words = ["i","love","leetcode","i","love","coding"], k = 2
 * Output: ["i","love"]
 * Explanation: "i" and "love" are the two most frequent words.
 * Note that "i" comes before "love" due to a lower alphabetical order.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: words =
 * ["the","day","is","sunny","the","the","the","sunny","is","is"], k = 4
 * Output: ["the","is","sunny","day"]
 * Explanation: "the", "is", "sunny" and "day" are the four most frequent
 * words, with the number of occurrence being 4, 3, 2 and 1 respectively.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= words.length <= 500
 * 1 <= words[i].length <= 10
 * words[i] consists of lowercase English letters.
 * k is in the range [1, The number of unique words[i]]
 * 
 * 
 * 
 * Follow-up: Could you solve it in O(n log(k)) time and O(n) extra space?
 * 
 */

// @lc code=start
public partial class Solution
{
    public IList<string> TopKFrequent(string[] words, int k)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        PriorityQueue<string, (int, string)> minheap = new PriorityQueue<string, (int, string)>(
            Comparer<(int c, string s)>.Create(
                (x, y) =>
                {
                    if (x.c == y.c)
                        return y.s.CompareTo(x.s);
                    return x.c.CompareTo(y.c);
                }
            )
        );

        for (int i = 0; i < words.Length; i++)
        {
            if (!dict.ContainsKey(words[i]))
                dict[words[i]] = 0;
            dict[words[i]]++;
        }

        foreach (var pair in dict)
        {
            minheap.Enqueue(pair.Key, (pair.Value, pair.Key));
            if (minheap.Count > k)
                minheap.Dequeue();
        }

        List<string> res = new List<string>();
        while (minheap.Count > 0)
        {
            res.Insert(0, minheap.Dequeue());
        }
        return res;
    }
}
// @lc code=end

