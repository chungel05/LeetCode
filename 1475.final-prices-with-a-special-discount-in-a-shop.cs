/*
 * @lc app=leetcode id=1475 lang=csharp
 *
 * [1475] Final Prices With a Special Discount in a Shop
 *
 * https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/description/
 *
 * algorithms
 * Easy (78.64%)
 * Likes:    2608
 * Dislikes: 133
 * Total Accepted:    278.4K
 * Total Submissions: 336K
 * Testcase Example:  '[8,4,6,2,3]'
 *
 * You are given an integer array prices where prices[i] is the price of the
 * i^th item in a shop.
 * 
 * There is a special discount for items in the shop. If you buy the i^th item,
 * then you will receive a discount equivalent to prices[j] where j is the
 * minimum index such that j > i and prices[j] <= prices[i]. Otherwise, you
 * will not receive any discount at all.
 * 
 * Return an integer array answer where answer[i] is the final price you will
 * pay for the i^th item of the shop, considering the special discount.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: prices = [8,4,6,2,3]
 * Output: [4,2,4,2,3]
 * Explanation: 
 * For item 0 with price[0]=8 you will receive a discount equivalent to
 * prices[1]=4, therefore, the final price you will pay is 8 - 4 = 4.
 * For item 1 with price[1]=4 you will receive a discount equivalent to
 * prices[3]=2, therefore, the final price you will pay is 4 - 2 = 2.
 * For item 2 with price[2]=6 you will receive a discount equivalent to
 * prices[3]=2, therefore, the final price you will pay is 6 - 2 = 4.
 * For items 3 and 4 you will not receive any discount at all.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: prices = [1,2,3,4,5]
 * Output: [1,2,3,4,5]
 * Explanation: In this case, for all items, you will not receive any discount
 * at all.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: prices = [10,1,1,6]
 * Output: [9,0,1,6]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= prices.length <= 500
 * 1 <= prices[i] <= 1000
 * 
 * 
 */
/*
 * Time: O(n), Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int[] FinalPrices(int[] prices)
    {
        // Monotonic increasing stack
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < prices.Length; i++)
        {
            // if top of stack >= prices[i], then prices[top] can receive prices[i] discount
            // while loop until the top is not >= prices[i]
            while (stack.Count > 0 && prices[stack.Peek()] >= prices[i])
            {
                prices[stack.Pop()] -= prices[i];
            }
            stack.Push(i);
        }
        return prices;
    }
}
// @lc code=end

