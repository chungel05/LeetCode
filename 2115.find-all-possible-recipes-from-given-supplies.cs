/*
 * @lc app=leetcode id=2115 lang=csharp
 *
 * [2115] Find All Possible Recipes from Given Supplies
 *
 * https://leetcode.com/problems/find-all-possible-recipes-from-given-supplies/description/
 *
 * algorithms
 * Medium (50.27%)
 * Likes:    1970
 * Dislikes: 96
 * Total Accepted:    109K
 * Total Submissions: 214.5K
 * Testcase Example:  '["bread"]\n[["yeast","flour"]]\n["yeast","flour","corn"]'
 *
 * You have information about n different recipes. You are given a string array
 * recipes and a 2D string array ingredients. The i^th recipe has the name
 * recipes[i], and you can create it if you have all the needed ingredients
 * from ingredients[i]. A recipe can also be an ingredient for other recipes,
 * i.e., ingredients[i] may contain a string that is in recipes.
 * 
 * You are also given a string array supplies containing all the ingredients
 * that you initially have, and you have an infinite supply of all of them.
 * 
 * Return a list of all the recipes that you can create. You may return the
 * answer in any order.
 * 
 * Note that two recipes may contain each other in their ingredients.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: recipes = ["bread"], ingredients = [["yeast","flour"]], supplies =
 * ["yeast","flour","corn"]
 * Output: ["bread"]
 * Explanation:
 * We can create "bread" since we have the ingredients "yeast" and "flour".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: recipes = ["bread","sandwich"], ingredients =
 * [["yeast","flour"],["bread","meat"]], supplies = ["yeast","flour","meat"]
 * Output: ["bread","sandwich"]
 * Explanation:
 * We can create "bread" since we have the ingredients "yeast" and "flour".
 * We can create "sandwich" since we have the ingredient "meat" and can create
 * the ingredient "bread".
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: recipes = ["bread","sandwich","burger"], ingredients =
 * [["yeast","flour"],["bread","meat"],["sandwich","meat","bread"]], supplies =
 * ["yeast","flour","meat"]
 * Output: ["bread","sandwich","burger"]
 * Explanation:
 * We can create "bread" since we have the ingredients "yeast" and "flour".
 * We can create "sandwich" since we have the ingredient "meat" and can create
 * the ingredient "bread".
 * We can create "burger" since we have the ingredient "meat" and can create
 * the ingredients "bread" and "sandwich".
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == recipes.length == ingredients.length
 * 1 <= n <= 100
 * 1 <= ingredients[i].length, supplies.length <= 100
 * 1 <= recipes[i].length, ingredients[i][j].length, supplies[k].length <=
 * 10
 * recipes[i], ingredients[i][j], and supplies[k] consist only of lowercase
 * English letters.
 * All the values of recipes and supplies combined are unique.
 * Each ingredients[i] does not contain any duplicate values.
 * 
 * 
 */
/*
 * BFS - Topological Sorting
 * Time: O(V + E + S), Space: O(V + E + S)
 */

// @lc code=start
public partial class Solution
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        int n = recipes.Length;
        // create hashset for initial ingredients for easy lookup
        HashSet<string> hash = new HashSet<string>(supplies);
        // create dict for adj. node to construct graph
        Dictionary<string, List<int>> adj = new Dictionary<string, List<int>>();
        // create array to count the incoming edges
        int[] in_degree = new int[n];

        // loop through all recipes and corresponding ingredients
        for (int i = 0; i < recipes.Length; i++)
        {
            foreach (string ing in ingredients[i])
            {
                // if not exists, it maybe missing ingredient or another recipe
                if (!hash.Contains(ing))
                {
                    // so it will have edge point to current recipes[i]
                    if (!adj.ContainsKey(ing))
                        adj[ing] = new List<int>();
                    adj[ing].Add(i);
                    // incoming edge of recipes[i] + 1
                    in_degree[i]++;
                }
            }
        }

        // Topological sorting
        Queue<int> q = new Queue<int>();
        List<string> ans = new List<string>();
        for (int i = 0; i < n; i++)
        {
            // if the recipes[i] no missing ingredient/recipe, add to queue
            if (in_degree[i] == 0)
                q.Enqueue(i);
        }

        while (q.Count > 0)
        {
            int idx = q.Dequeue();
            // since no missing ingredient/recipe, so add to ans
            ans.Add(recipes[idx]);

            if (adj.ContainsKey(recipes[idx]))
            {
                // move to next node
                foreach (int next in adj[recipes[idx]])
                {
                    // reduce the incoming edge of recipes[next] because pre-recipe already made
                    in_degree[next]--;
                    // if the recipes[next] no missing ingredient/recipe, add to queue
                    if (in_degree[next] == 0)
                        q.Enqueue(next);
                }
            }
        }
        return ans;
    }
}
// @lc code=end

