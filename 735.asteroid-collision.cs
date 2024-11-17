/*
 * @lc app=leetcode id=735 lang=csharp
 *
 * [735] Asteroid Collision
 *
 * https://leetcode.com/problems/asteroid-collision/description/
 *
 * algorithms
 * Medium (44.77%)
 * Likes:    8243
 * Dislikes: 1144
 * Total Accepted:    636.3K
 * Total Submissions: 1.4M
 * Testcase Example:  '[5,10,-5]'
 *
 * We are given an array asteroids of integers representing asteroids in a
 * row.
 * 
 * For each asteroid, the absolute value represents its size, and the sign
 * represents its direction (positive meaning right, negative meaning left).
 * Each asteroid moves at the same speed.
 * 
 * Find out the state of the asteroids after all collisions. If two asteroids
 * meet, the smaller one will explode. If both are the same size, both will
 * explode. Two asteroids moving in the same direction will never meet.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: asteroids = [5,10,-5]
 * Output: [5,10]
 * Explanation: The 10 and -5 collide resulting in 10. The 5 and 10 never
 * collide.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: asteroids = [8,-8]
 * Output: []
 * Explanation: The 8 and -8 collide exploding each other.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: asteroids = [10,2,-5]
 * Output: [10]
 * Explanation: The 2 and -5 collide resulting in -5. The 10 and -5 collide
 * resulting in 10.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= asteroids.length <= 10^4
 * -1000 <= asteroids[i] <= 1000
 * asteroids[i] != 0
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < asteroids.Length; i++)
        {
            int remaining = asteroids[i];
            while (stack.Count > 0 && remaining < 0 && stack.Peek() > 0)
            {
                int prev = Math.Abs(stack.Peek());
                int curr = Math.Abs(remaining);

                if (prev > curr)
                    remaining = stack.Peek();
                else if (curr == prev)
                    remaining = 0;

                stack.Pop();
            }
            if (remaining != 0)
                stack.Push(remaining);
        }

        int[] res = new int[stack.Count];
        int j = stack.Count - 1;
        while (stack.Count > 0 && j >= 0)
        {
            res[j] = stack.Pop();
            j--;
        }

        return res;
    }
}
// @lc code=end

