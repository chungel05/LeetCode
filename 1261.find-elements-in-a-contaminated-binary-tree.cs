/*
 * @lc app=leetcode id=1261 lang=csharp
 *
 * [1261] Find Elements in a Contaminated Binary Tree
 *
 * https://leetcode.com/problems/find-elements-in-a-contaminated-binary-tree/description/
 *
 * algorithms
 * Medium (77.62%)
 * Likes:    1016
 * Dislikes: 95
 * Total Accepted:    70.3K
 * Total Submissions: 90.3K
 * Testcase Example:  '["FindElements","find","find"]\n[[[-1,null,-1]],[1],[2]]'
 *
 * Given a binary tree with the following rules:
 * 
 * 
 * root.val == 0
 * For any treeNode:
 * 
 * If treeNode.val has a value x and treeNode.left != null, then
 * treeNode.left.val == 2 * x + 1
 * If treeNode.val has a value x and treeNode.right != null, then
 * treeNode.right.val == 2 * x + 2
 * 
 * 
 * 
 * 
 * Now the binary tree is contaminated, which means all treeNode.val have been
 * changed to -1.
 * 
 * Implement the FindElements class:
 * 
 * 
 * FindElements(TreeNode* root) Initializes the object with a contaminated
 * binary tree and recovers it.
 * bool find(int target) Returns true if the target value exists in the
 * recovered binary tree.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input
 * ["FindElements","find","find"]
 * [[[-1,null,-1]],[1],[2]]
 * Output
 * [null,false,true]
 * Explanation
 * FindElements findElements = new FindElements([-1,null,-1]); 
 * findElements.find(1); // return False 
 * findElements.find(2); // return True 
 * 
 * Example 2:
 * 
 * 
 * Input
 * ["FindElements","find","find","find"]
 * [[[-1,-1,-1,-1,-1]],[1],[3],[5]]
 * Output
 * [null,true,true,false]
 * Explanation
 * FindElements findElements = new FindElements([-1,-1,-1,-1,-1]);
 * findElements.find(1); // return True
 * findElements.find(3); // return True
 * findElements.find(5); // return False
 * 
 * Example 3:
 * 
 * 
 * Input
 * ["FindElements","find","find","find","find"]
 * [[[-1,null,-1,-1,null,-1]],[2],[3],[4],[5]]
 * Output
 * [null,true,false,false,true]
 * Explanation
 * FindElements findElements = new FindElements([-1,null,-1,-1,null,-1]);
 * findElements.find(2); // return True
 * findElements.find(3); // return False
 * findElements.find(4); // return False
 * findElements.find(5); // return True
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * TreeNode.val == -1
 * The height of the binary tree is less than or equal to 20
 * The total number of nodes is between [1, 10^4]
 * Total calls of find() is between [1, 10^4]
 * 0 <= target <= 10^6
 * 
 * 
 */
/*
 * Bit Manipulation Approach
 * Time: O(log n), Space: O(1)
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class FindElements
{
    private TreeNode _root;

    // Time: O(1), Space: O(1)
    public FindElements(TreeNode root)
    {
        _root = root;
    }

    // Time: O(log n), Space: O(1)
    // imagine bitwise structure like this
    //         1                = 1
    //    10        11          = 2, 3
    // 100  101  110  111       = 4, 5, 6, 7
    // which is similar to the question, for each num + 1
    // by obervation, 0 bit will go to left, 1 bit will go to right in every level
    // so from the leftmost bit we go through the root and check whether the target node exists or not
    public bool Find(int target)
    {
        // edge case, target = 0 => root
        if (target == 0)
            return _root != null;

        // by above example, need to +1 to find out the target
        int num = target + 1;
        // calc the leftmost bit
        int depth = int.Log2(num);
        // start from root which is always 1, so the mask = leftmost - 1 bit
        int mask = 1 << (depth - 1);
        TreeNode curr = _root;
        // when mask = 0, target level arrived
        // when curr = null, no more level can arrive
        while (mask != 0 && curr != null)
        {
            // check to left or right
            curr = (num & mask) == 0 ? curr.left : curr.right;
            // move bit mask from leftmost to rightmost
            mask >>= 1;
        }
        // until arrived target node, if curr exists, then true, otherwise false
        return curr != null;
    }
}

/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * bool param_1 = obj.Find(target);
 */
// @lc code=end

