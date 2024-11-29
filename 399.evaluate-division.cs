/*
 * @lc app=leetcode id=399 lang=csharp
 *
 * [399] Evaluate Division
 *
 * https://leetcode.com/problems/evaluate-division/description/
 *
 * algorithms
 * Medium (62.29%)
 * Likes:    9496
 * Dislikes: 978
 * Total Accepted:    534K
 * Total Submissions: 855.6K
 * Testcase Example:  '[["a","b"],["b","c"]]\n' +
  '[2.0,3.0]\n' +
  '[["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]'
 *
 * You are given an array of variable pairs equations and an array of real
 * numbers values, where equations[i] = [Ai, Bi] and values[i] represent the
 * equation Ai / Bi = values[i]. Each Ai or Bi is a string that represents a
 * single variable.
 * 
 * You are also given some queries, where queries[j] = [Cj, Dj] represents the
 * j^th query where you must find the answer for Cj / Dj = ?.
 * 
 * Return the answers to all queries. If a single answer cannot be determined,
 * return -1.0.
 * 
 * Note: The input is always valid. You may assume that evaluating the queries
 * will not result in division by zero and that there is no contradiction.
 * 
 * Note: The variables that do not occur in the list of equations are
 * undefined, so the answer cannot be determined for them.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries =
 * [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
 * Output: [6.00000,0.50000,-1.00000,1.00000,-1.00000]
 * Explanation: 
 * Given: a / b = 2.0, b / c = 3.0
 * queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? 
 * return: [6.0, 0.5, -1.0, 1.0, -1.0 ]
 * note: x is undefined => -1.0
 * 
 * Example 2:
 * 
 * 
 * Input: equations = [["a","b"],["b","c"],["bc","cd"]], values =
 * [1.5,2.5,5.0], queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
 * Output: [3.75000,0.40000,5.00000,0.20000]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: equations = [["a","b"]], values = [0.5], queries =
 * [["a","b"],["b","a"],["a","c"],["x","y"]]
 * Output: [0.50000,2.00000,-1.00000,-1.00000]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= equations.length <= 20
 * equations[i].length == 2
 * 1 <= Ai.length, Bi.length <= 5
 * values.length == equations.length
 * 0.0 < values[i] <= 20.0
 * 1 <= queries.length <= 20
 * queries[i].length == 2
 * 1 <= Cj.length, Dj.length <= 5
 * Ai, Bi, Cj, Dj consist of lower case English letters and digits.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private double DFSCalcEquation(Dictionary<string, List<(string, double)>> graph, string curr, string end, HashSet<string> visited)
    {
        if (curr == end)
            return 1.0;

        if (visited.Contains(curr) || !graph.ContainsKey(curr))
            return -1.0;

        visited.Add(curr);
        foreach ((string node, double value) in graph[curr])
        {
            if (!visited.Contains(node))
            {
                double result = DFSCalcEquation(graph, node, end, visited);
                if (result != -1)
                    return result * value;
            }
        }
        visited.Remove(curr);
        return -1.0;
    }

    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        Dictionary<string, List<(string, double)>> graph = new Dictionary<string, List<(string, double)>>();
        double[] res = new double[queries.Count];

        for (int i = 0; i < equations.Count; i++)
        {
            if (!graph.ContainsKey(equations[i][0]))
                graph[equations[i][0]] = new List<(string, double)>();
            graph[equations[i][0]].Add((equations[i][1], values[i]));

            if (!graph.ContainsKey(equations[i][1]))
                graph[equations[i][1]] = new List<(string, double)>();
            graph[equations[i][1]].Add((equations[i][0], 1 / values[i]));
        }

        for (int i = 0; i < queries.Count; i++)
        {
            if (!graph.ContainsKey(queries[i][0]) || !graph.ContainsKey(queries[i][1]))
                res[i] = -1.0;
            else if (queries[i][0] == queries[i][1])
                res[i] = 1.0;
            else
                res[i] = DFSCalcEquation(graph, queries[i][0], queries[i][1], new HashSet<string>());
        }
        return res;
    }
}
// @lc code=end

