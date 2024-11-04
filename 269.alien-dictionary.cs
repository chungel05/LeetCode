/*
 * @lc app=leetcode id=269 lang=csharp
 *
 * [269] Alien Dictionary
 */

// @lc code=start
public partial class Solution
{
    private Dictionary<char, HashSet<char>> adj;
    private Dictionary<char, bool> visited;
    private List<char> res;

    private bool DFSAlienDictionary(char c)
    {
        if (visited.ContainsKey(c))
            return visited[c];

        visited[c] = true;
        foreach (var a in adj[c])
        {
            if (DFSAlienDictionary(a))
                return true;
        }
        visited[c] = false;
        res.Add(c);
        return false;
    }

    public string AlienDictionary(string[] words)
    {
        adj = new Dictionary<char, HashSet<char>>();
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                if (!adj.ContainsKey(words[i][j]))
                    adj[words[i][j]] = new HashSet<char>();
            }
        }

        for (int i = 0; i < words.Length - 1; i++)
        {
            string w1 = words[i];
            string w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);
            if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0, minLen))
                return "";

            for (int j = 0; j < minLen; j++)
            {
                if (w1[j] != w2[j])
                {
                    adj[w1[j]].Add(w2[j]);
                    break;
                }
            }
        }

        visited = new Dictionary<char, bool>();
        res = new List<char>();

        foreach (var c in adj)
        {
            if (DFSAlienDictionary(c.Key))
                return "";
        }

        res.Reverse();
        return new string(res.ToArray());
    }
}
// @lc code=end