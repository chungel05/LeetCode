/*
 * @lc app=leetcode id=1462 lang=csharp
 *
 * [1462] Course Schedule IV
 *
 * https://leetcode.com/problems/course-schedule-iv/description/
 *
 * algorithms
 * Medium (50.29%)
 * Likes:    1542
 * Dislikes: 69
 * Total Accepted:    74.8K
 * Total Submissions: 146.2K
 * Testcase Example:  '2\n[[1,0]]\n[[0,1],[1,0]]'
 *
 * There are a total of numCourses courses you have to take, labeled from 0 to
 * numCourses - 1. You are given an array prerequisites where prerequisites[i]
 * = [ai, bi] indicates that you must take course ai first if you want to take
 * course bi.
 * 
 * 
 * For example, the pair [0, 1] indicates that you have to take course 0 before
 * you can take course 1.
 * 
 * 
 * Prerequisites can also be indirect. If course a is a prerequisite of course
 * b, and course b is a prerequisite of course c, then course a is a
 * prerequisite of course c.
 * 
 * You are also given an array queries where queries[j] = [uj, vj]. For the
 * j^th query, you should answer whether course uj is a prerequisite of course
 * vj or not.
 * 
 * Return a boolean array answer, where answer[j] is the answer to the j^th
 * query.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: numCourses = 2, prerequisites = [[1,0]], queries = [[0,1],[1,0]]
 * Output: [false,true]
 * Explanation: The pair [1, 0] indicates that you have to take course 1 before
 * you can take course 0.
 * Course 0 is not a prerequisite of course 1, but the opposite is true.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: numCourses = 2, prerequisites = [], queries = [[1,0],[0,1]]
 * Output: [false,false]
 * Explanation: There are no prerequisites, and each course is independent.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: numCourses = 3, prerequisites = [[1,2],[1,0],[2,0]], queries =
 * [[1,0],[1,2]]
 * Output: [true,true]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= numCourses <= 100
 * 0 <= prerequisites.length <= (numCourses * (numCourses - 1) / 2)
 * prerequisites[i].length == 2
 * 0 <= ai, bi <= numCourses - 1
 * ai != bi
 * All the pairs [ai, bi] are unique.
 * The prerequisites graph has no cycles.
 * 1 <= queries.length <= 10^4
 * 0 <= ui, vi <= numCourses - 1
 * ui != vi
 * 
 * 
 */
/*
 * Topological Sorting Approach
 * Time: O(V * E + q), Space: O(V^2)
 */

// @lc code=start
public partial class Solution
{
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        // create a dict to store foreach node i is a prerequisite of j = dict[i][j]
        bool[][] dict = new bool[numCourses][];
        // create graph to store the reverse edges
        List<int>[] graph = new List<int>[numCourses];
        // create in_degree to count the incoming edges
        int[] in_degree = new int[numCourses];
        Queue<int> q = new Queue<int>();

        // Initialization
        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new List<int>();
            dict[i] = new bool[numCourses];
            // course i must be prerequisite of itself
            dict[i][i] = true;
        }

        // By reversing edges, store the prerequisites of each node
        for (int i = 0; i < prerequisites.Length; i++)
        {
            int a = prerequisites[i][0];
            int b = prerequisites[i][1];
            // count incoming edges
            in_degree[a]++;
            // add prerequisites in graph
            graph[b].Add(a);
        }

        for (int i = 0; i < numCourses; i++)
        {
            // if no incoming edges = not prerequisite of other course
            // add to Queue
            if (in_degree[i] == 0)
                q.Enqueue(i);
        }

        // start from the node which is not the prerequisite of other
        while (q.Count > 0)
        {
            int course = q.Dequeue();
            // foreach prerequisite of course
            foreach (int pre in graph[course])
            {
                // propagate the stored result to prerequisite
                for (int i = 0; i < numCourses; i++)
                    // since pre may be prerequisite of other course as well
                    // need to use logical or
                    dict[pre][i] = dict[pre][i] | dict[course][i];

                // reduce in_degree
                // and if no more in_degree, add to Queue
                in_degree[pre]--;
                if (in_degree[pre] == 0)
                    q.Enqueue(pre);
            }
        }

        List<bool> ans = new List<bool>();
        for (int i = 0; i < queries.Length; i++)
        {
            // add to result by using the dict map
            int u = queries[i][0];
            int v = queries[i][1];
            ans.Add(dict[u][v]);
        }
        return ans;
    }
}
// @lc code=end

