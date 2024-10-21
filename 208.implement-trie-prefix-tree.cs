/*
 * @lc app=leetcode id=208 lang=csharp
 *
 * [208] Implement Trie (Prefix Tree)
 *
 * https://leetcode.com/problems/implement-trie-prefix-tree/description/
 *
 * algorithms
 * Medium (66.49%)
 * Likes:    11732
 * Dislikes: 144
 * Total Accepted:    1.2M
 * Total Submissions: 1.7M
 * Testcase Example:  '["Trie","insert","search","search","startsWith","insert","search"]\n' +
  '[[],["apple"],["apple"],["app"],["app"],["app"],["app"]]'
 *
 * A trie (pronounced as "try") or prefix tree is a tree data structure used to
 * efficiently store and retrieve keys in a dataset of strings. There are
 * various applications of this data structure, such as autocomplete and
 * spellchecker.
 * 
 * Implement the Trie class:
 * 
 * 
 * Trie() Initializes the trie object.
 * void insert(String word) Inserts the string word into the trie.
 * boolean search(String word) Returns true if the string word is in the trie
 * (i.e., was inserted before), and false otherwise.
 * boolean startsWith(String prefix) Returns true if there is a previously
 * inserted string word that has the prefix prefix, and false otherwise.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input
 * ["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
 * [[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
 * Output
 * [null, null, true, false, true, null, true]
 * 
 * Explanation
 * Trie trie = new Trie();
 * trie.insert("apple");
 * trie.search("apple");   // return True
 * trie.search("app");     // return False
 * trie.startsWith("app"); // return True
 * trie.insert("app");
 * trie.search("app");     // return True
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= word.length, prefix.length <= 2000
 * word and prefix consist only of lowercase English letters.
 * At most 3 * 10^4 calls in total will be made to insert, search, and
 * startsWith.
 * 
 * 
 */

// @lc code=start

public class TrieNode
{
    public Dictionary<char, TrieNode> childnode { get; set; }
    public bool isEndOfWord { get; set; }
    public TrieNode()
    {
        childnode = new Dictionary<char, TrieNode>();
    }
}

public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode curr = root;
        foreach (char c in word)
        {
            if (!curr.childnode.ContainsKey(c))
                curr.childnode[c] = new TrieNode();
            curr = curr.childnode[c];
        }
        curr.isEndOfWord = true;
    }

    private TrieNode traverse(string word)
    {
        TrieNode curr = root;
        foreach (char c in word)
        {
            if (!curr.childnode.ContainsKey(c))
                return null;
            curr = curr.childnode[c];
        }
        return curr;
    }

    public bool Search(string word)
    {
        TrieNode node = traverse(word);
        return node != null && node.isEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode node = traverse(prefix);
        return node != null;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
// @lc code=end

