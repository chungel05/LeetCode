/*
 * @lc app=leetcode id=332 lang=csharp
 *
 * [332] Reconstruct Itinerary
 *
 * https://leetcode.com/problems/reconstruct-itinerary/description/
 *
 * algorithms
 * Hard (43.31%)
 * Likes:    5963
 * Dislikes: 1887
 * Total Accepted:    456.1K
 * Total Submissions: 1.1M
 * Testcase Example:  '[["MUC","LHR"],["JFK","MUC"],["SFO","SJC"],["LHR","SFO"]]'
 *
 * You are given a list of airline tickets where tickets[i] = [fromi, toi]
 * represent the departure and the arrival airports of one flight. Reconstruct
 * the itinerary in order and return it.
 * 
 * All of the tickets belong to a man who departs from "JFK", thus, the
 * itinerary must begin with "JFK". If there are multiple valid itineraries,
 * you should return the itinerary that has the smallest lexical order when
 * read as a single string.
 * 
 * 
 * For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than
 * ["JFK", "LGB"].
 * 
 * 
 * You may assume all tickets form at least one valid itinerary. You must use
 * all the tickets once and only once.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: tickets = [["MUC","LHR"],["JFK","MUC"],["SFO","SJC"],["LHR","SFO"]]
 * Output: ["JFK","MUC","LHR","SFO","SJC"]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: tickets =
 * [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
 * Output: ["JFK","ATL","JFK","SFO","ATL","SFO"]
 * Explanation: Another possible reconstruction is
 * ["JFK","SFO","ATL","JFK","ATL","SFO"] but it is larger in lexical order.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= tickets.length <= 300
 * tickets[i].length == 2
 * fromi.length == 3
 * toi.length == 3
 * fromi and toi consist of uppercase English letters.
 * fromi != toi
 * 
 * 
 */
/*
 * Hierholzer's Algorithm implementation
 * check Eulerian path exists by counting the in and out
 * if in - out > 1 || out - in > 1, then false
 * start: out - in == 1
 * end: in - out == 1
 * Eulerian path exists when (start == 0 and end == 0) || (start == 1 and end == 1)
 * Start from start point and do DFS,
 * if no more adj, then add to result
 * backtracking and looping all adj, if no more adj, then add to result again
 * reverse the list (or add to result at 0 index everytime)
 */

// @lc code=start
public partial class Solution
{
    public void DFSFindItinerary(Dictionary<string, List<string>> map, string from, List<string> res)
    {
        while (map.ContainsKey(from) && map[from].Count > 0)
        {
            string to = map[from][map[from].Count - 1];
            map[from].RemoveAt(map[from].Count - 1);
            DFSFindItinerary(map, to, res);
        }
        res.Add(from);
    }

    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        List<string> res = new List<string>();
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        tickets = tickets.OrderByDescending(x => x[1]).ToList();
        foreach (var t in tickets)
        {
            if (!map.ContainsKey(t[0]))
                map[t[0]] = new List<string>();
            map[t[0]].Add(t[1]);
        }

        DFSFindItinerary(map, "JFK", res);
        res.Reverse();

        return res;
    }
}
// @lc code=end

