/*
 * @lc app=leetcode id=218 lang=csharp
 *
 * [218] The Skyline Problem
 *
 * https://leetcode.com/problems/the-skyline-problem/description/
 *
 * algorithms
 * Hard (43.14%)
 * Likes:    5981
 * Dislikes: 270
 * Total Accepted:    305.9K
 * Total Submissions: 705.8K
 * Testcase Example:  '[[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]'
 *
 * A city's skyline is the outer contour of the silhouette formed by all the
 * buildings in that city when viewed from a distance. Given the locations and
 * heights of all the buildings, return the skyline formed by these buildings
 * collectively.
 * 
 * The geometric information of each building is given in the array buildings
 * where buildings[i] = [lefti, righti, heighti]:
 * 
 * 
 * lefti is the x coordinate of the left edge of the i^th building.
 * righti is the x coordinate of the right edge of the i^th building.
 * heighti is the height of the i^th building.
 * 
 * 
 * You may assume all buildings are perfect rectangles grounded on an
 * absolutely flat surface at height 0.
 * 
 * The skyline should be represented as a list of "key points" sorted by their
 * x-coordinate in the form [[x1,y1],[x2,y2],...]. Each key point is the left
 * endpoint of some horizontal segment in the skyline except the last point in
 * the list, which always has a y-coordinate 0 and is used to mark the
 * skyline's termination where the rightmost building ends. Any ground between
 * the leftmost and rightmost buildings should be part of the skyline's
 * contour.
 * 
 * Note: There must be no consecutive horizontal lines of equal height in the
 * output skyline. For instance, [...,[2 3],[4 5],[7 5],[11 5],[12 7],...] is
 * not acceptable; the three lines of height 5 should be merged into one in the
 * final output as such: [...,[2 3],[4 5],[12 7],...]
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: buildings = [[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]
 * Output: [[2,10],[3,15],[7,12],[12,0],[15,10],[20,8],[24,0]]
 * Explanation:
 * Figure A shows the buildings of the input.
 * Figure B shows the skyline formed by those buildings. The red points in
 * figure B represent the key points in the output list.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: buildings = [[0,2,3],[2,5,3]]
 * Output: [[0,3],[5,0]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= buildings.length <= 10^4
 * 0 <= lefti < righti <= 2^31 - 1
 * 1 <= heighti <= 2^31 - 1
 * buildings is sorted by lefti in non-decreasing order.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public IList<IList<int>> GetSkyline(int[][] buildings)
    {
        // To prevent duplicate x coordinate, we use HashSet
        HashSet<int> xSet = new HashSet<int>();
        for (int i = 0; i < buildings.Length; i++)
        {
            xSet.Add(buildings[i][0]);
            xSet.Add(buildings[i][1]);
        }

        // Sort all the x coordinates and convert to List
        List<int> xList = xSet.OrderBy(x => x).ToList();
        // Based on the sort seq, we built dict for all the x coordinates (x, i)
        Dictionary<int, int> idxMap = new Dictionary<int, int>();
        for (int i = 0; i < xList.Count; i++)
        {
            idxMap[xList[i]] = i;
        }

        // create array to hold the max height of each x coordinate
        // base height = 0
        int[] height = new int[xList.Count];
        for (int i = 0; i < buildings.Length; i++)
        {
            // start x coordinate to end x coordinate
            int startIdx = idxMap[buildings[i][0]];
            int endIdx = idxMap[buildings[i][1]];

            // i.e. 2, 3, 5, 7, 9
            // we update from start = 2 until 9, 9 is not included
            for (int j = startIdx; j < endIdx; j++)
            {
                height[j] = Math.Max(height[j], buildings[i][2]);
            }
        }

        int prevHeight = -1;
        List<IList<int>> res = new List<IList<int>>();
        for (int i = 0; i < height.Length; i++)
        {
            // if leftmost (x, y), we add to result
            // if current height != prev height, we add to result
            // p.s. for same height, we only add the leftmost x coordinate
            if (prevHeight == -1 || height[i] != prevHeight)
            {
                List<int> tmp = new List<int>() { xList[i], height[i] };
                res.Add(tmp);
                prevHeight = height[i];
            }
        }
        return res;
    }
}
// @lc code=end

