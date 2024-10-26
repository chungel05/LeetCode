/*
 * @lc app=leetcode id=207 lang=csharp
 *
 * [207] Course Schedule
 *
 * https://leetcode.com/problems/course-schedule/description/
 *
 * algorithms
 * Medium (47.62%)
 * Likes:    16490
 * Dislikes: 755
 * Total Accepted:    1.8M
 * Total Submissions: 3.7M
 * Testcase Example:  '2\n[[1,0]]'
 *
 * There are a total of numCourses courses you have to take, labeled from 0 to
 * numCourses - 1. You are given an array prerequisites where prerequisites[i]
 * = [ai, bi] indicates that you must take course bi first if you want to take
 * course ai.
 * 
 * 
 * For example, the pair [0, 1], indicates that to take course 0 you have to
 * first take course 1.
 * 
 * 
 * Return true if you can finish all courses. Otherwise, return false.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: numCourses = 2, prerequisites = [[1,0]]
 * Output: true
 * Explanation: There are a total of 2 courses to take. 
 * To take course 1 you should have finished course 0. So it is possible.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
 * Output: false
 * Explanation: There are a total of 2 courses to take. 
 * To take course 1 you should have finished course 0, and to take course 0 you
 * should also have finished course 1. So it is impossible.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= numCourses <= 2000
 * 0 <= prerequisites.length <= 5000
 * prerequisites[i].length == 2
 * 0 <= ai, bi < numCourses
 * All the pairs prerequisites[i] are unique.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public bool DFSCanFinish(List<int>[] course, int currCourse, HashSet<int> visited)
    {
        // course already visited before, so cycle detected
        if (visited.Contains(currCourse))
            return false;

        // no prerequisites
        if (course[currCourse].Count == 0)
            return true;

        visited.Add(currCourse);
        foreach (int tmp in course[currCourse])
        {
            if (!DFSCanFinish(course, tmp, visited))
                return false;
        }
        visited.Remove(currCourse);
        // Clear prerequisites because all the prerequisites can be completed
        course[currCourse].Clear();
        return true;
    }

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<int>[] course = new List<int>[numCourses];
        HashSet<int> visited = new HashSet<int>();

        for (int i = 0; i < numCourses; i++)
            course[i] = new List<int>();

        foreach (int[] prereq in prerequisites)
        {
            course[prereq[0]].Add(prereq[1]);
        }

        for (int i = 0; i < numCourses; i++)
        {
            if (!DFSCanFinish(course, i, visited))
                return false;
        }

        return true;
    }
}
// @lc code=end

