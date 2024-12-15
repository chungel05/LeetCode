/*
 * @lc app=leetcode id=1268 lang=csharp
 *
 * [1268] Search Suggestions System
 *
 * https://leetcode.com/problems/search-suggestions-system/description/
 *
 * algorithms
 * Medium (65.09%)
 * Likes:    4837
 * Dislikes: 251
 * Total Accepted:    349.8K
 * Total Submissions: 537.8K
 * Testcase Example:  '["mobile","mouse","moneypot","monitor","mousepad"]\n"mouse"'
 *
 * You are given an array of strings products and a string searchWord.
 * 
 * Design a system that suggests at most three product names from products
 * after each character of searchWord is typed. Suggested products should have
 * common prefix with searchWord. If there are more than three products with a
 * common prefix return the three lexicographically minimums products.
 * 
 * Return a list of lists of the suggested products after each character of
 * searchWord is typed.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: products = ["mobile","mouse","moneypot","monitor","mousepad"],
 * searchWord = "mouse"
 * Output:
 * [["mobile","moneypot","monitor"],["mobile","moneypot","monitor"],["mouse","mousepad"],["mouse","mousepad"],["mouse","mousepad"]]
 * Explanation: products sorted lexicographically =
 * ["mobile","moneypot","monitor","mouse","mousepad"].
 * After typing m and mo all products match and we show user
 * ["mobile","moneypot","monitor"].
 * After typing mou, mous and mouse the system suggests ["mouse","mousepad"].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: products = ["havana"], searchWord = "havana"
 * Output: [["havana"],["havana"],["havana"],["havana"],["havana"],["havana"]]
 * Explanation: The only word "havana" will be always suggested while typing
 * the search word.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= products.length <= 1000
 * 1 <= products[i].length <= 3000
 * 1 <= sum(products[i].length) <= 2 * 10^4
 * All the strings of products are unique.
 * products[i] consists of lowercase English letters.
 * 1 <= searchWord.length <= 1000
 * searchWord consists of lowercase English letters.
 * 
 * 
 */

// @lc code=start
public class SuggestedProductsTree
{
    public Dictionary<char, SuggestedProductsTree> childnode { get; set; }
    public bool isEndOfWord { get; set; }
    public List<int> wordIdx { get; set; }

    public SuggestedProductsTree()
    {
        childnode = new Dictionary<char, SuggestedProductsTree>();
        wordIdx = new List<int>();
    }

    // Time: O(l), where l is the length of word
    public void AddWord(string word, int idx)
    {
        SuggestedProductsTree curr = this;
        foreach (char c in word)
        {
            if (!curr.childnode.ContainsKey(c))
                curr.childnode[c] = new SuggestedProductsTree();
            curr = curr.childnode[c];
            if (curr.wordIdx.Count < 3)
                curr.wordIdx.Add(idx);
        }
        curr.isEndOfWord = true;
    }

    // Time: O(m^2), where m is the length of word
    public List<int>[] PrefixSearch(string word)
    {
        SuggestedProductsTree curr = this;
        List<int>[] output = new List<int>[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            if (!curr.childnode.ContainsKey(word[i]))
                break;

            curr = curr.childnode[word[i]];
            output[i] = curr.wordIdx;
        }
        return output;
    }
}

public partial class Solution
{
    private SuggestedProductsTree root;

    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        // In order to store the word in Trie in ascending order, we sort the producrs list
        // Time: O(l * n log n), p.s. int sorting = O(n log n), string with l length is O(l * n log n)
        Array.Sort(products);

        // Add products to the Trie
        // Time: O(n * l)
        root = new SuggestedProductsTree();
        for (int i = 0; i < products.Length; i++)
        {
            root.AddWord(products[i], i);
        }

        List<IList<string>> res = new List<IList<string>>();
        // Per each prefix we have the index list
        foreach (List<int> index in root.PrefixSearch(searchWord))
        {
            List<string> tmp = new List<string>();
            if (index != null)
            {
                foreach (int i in index)
                    tmp.Add(products[i]);
            }

            res.Add(tmp);
        }
        return res;
    }
}
// @lc code=end

