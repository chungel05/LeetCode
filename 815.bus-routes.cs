/*
 * @lc app=leetcode id=815 lang=csharp
 *
 * [815] Bus Routes
 *
 * https://leetcode.com/problems/bus-routes/description/
 *
 * algorithms
 * Hard (47.41%)
 * Likes:    4335
 * Dislikes: 125
 * Total Accepted:    222.6K
 * Total Submissions: 471K
 * Testcase Example:  '[[1,2,7],[3,6,7]]\n1\n6'
 *
 * You are given an array routes representing bus routes where routes[i] is a
 * bus route that the i^th bus repeats forever.
 * 
 * 
 * For example, if routes[0] = [1, 5, 7], this means that the 0^th bus travels
 * in the sequence 1 -> 5 -> 7 -> 1 -> 5 -> 7 -> 1 -> ... forever.
 * 
 * 
 * You will start at the bus stop source (You are not on any bus initially),
 * and you want to go to the bus stop target. You can travel between bus stops
 * by buses only.
 * 
 * Return the least number of buses you must take to travel from source to
 * target. Return -1 if it is not possible.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: routes = [[1,2,7],[3,6,7]], source = 1, target = 6
 * Output: 2
 * Explanation: The best strategy is take the first bus to the bus stop 7, then
 * take the second bus to the bus stop 6.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: routes = [[7,12],[4,5,15],[6],[15,19],[9,12,13]], source = 15, target
 * = 12
 * Output: -1
 * 
 * 
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= routes.length <= 500.
 * 1 <= routes[i].length <= 10^5
 * All the values of routes[i] are unique.
 * sum(routes[i].length) <= 10^5
 * 0 <= routes[i][j] < 10^6
 * 0 <= source, target < 10^6
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        // edge case: source == target, no need to take any bus, return 0
        if (source == target)
            return 0;

        Dictionary<int, List<int>> stopMap = new Dictionary<int, List<int>>();
        Queue<int> q = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();

        // create a map which [stop, {bus route}]
        for (int i = 0; i < routes.Length; i++)
        {
            for (int j = 0; j < routes[i].Length; j++)
            {
                if (!stopMap.ContainsKey(routes[i][j]))
                    stopMap[routes[i][j]] = new List<int>();
                stopMap[routes[i][j]].Add(i);
            }
        }

        // add all bus route such that it have source stop
        if (stopMap.ContainsKey(source))
        {
            foreach (int bus in stopMap[source])
            {
                q.Enqueue(bus);
                visited.Add(bus);
            }
        }

        int count = 0;
        while (q.Count > 0)
        {
            count++;
            for (int i = q.Count; i > 0; i--)
            {
                int bus = q.Dequeue();

                // check all the stop of current bus
                foreach (int stop in routes[bus])
                {
                    // if current bus route have target stop, return level count
                    if (stop == target)
                        return count;

                    if (stopMap.ContainsKey(stop))
                    {
                        // for each stop of current bus route, we add the possible next bus route
                        foreach (int nextBus in stopMap[stop])
                        {
                            // check visited to prevent go back to prev bus route
                            if (!visited.Contains(nextBus))
                            {
                                visited.Add(nextBus);
                                q.Enqueue(nextBus);
                            }
                        }
                    }
                }
            }
        }

        return -1;
    }
}
// @lc code=end

