/*
 * @lc app=leetcode id=211 lang=csharp
 *
 * [211] Design Add and Search Words Data Structure
 *
 * https://leetcode.com/problems/design-add-and-search-words-data-structure/description/
 *
 * algorithms
 * Medium (46.01%)
 * Likes:    7681
 * Dislikes: 462
 * Total Accepted:    692.1K
 * Total Submissions: 1.5M
 * Testcase Example:  '["WordDictionary","addWord","addWord","addWord","search","search","search","search"]\n' +
  '[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]'
 *
 * Design a data structure that supports adding new words and finding if a
 * string matches any previously added string.
 * 
 * Implement the WordDictionary class:
 * 
 * 
 * WordDictionary() Initializes the object.
 * void addWord(word) Adds word to the data structure, it can be matched
 * later.
 * bool search(word) Returns true if there is any string in the data structure
 * that matches word or false otherwise. word may contain dots '.' where dots
 * can be matched with any letter.
 * 
 * 
 * 
 * Example:
 * 
 * 
 * Input
 * 
 * ["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
 * [[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
 * Output
 * [null,null,null,null,false,true,true,true]
 * 
 * Explanation
 * WordDictionary wordDictionary = new WordDictionary();
 * wordDictionary.addWord("bad");
 * wordDictionary.addWord("dad");
 * wordDictionary.addWord("mad");
 * wordDictionary.search("pad"); // return False
 * wordDictionary.search("bad"); // return True
 * wordDictionary.search(".ad"); // return True
 * wordDictionary.search("b.."); // return True
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= word.length <= 25
 * word in addWord consists of lowercase English letters.
 * word in search consist of '.' or lowercase English letters.
 * There will be at most 2 dots in word for search queries.
 * At most 10^4 calls will be made to addWord and search.
 * 
 * 
 */

// @lc code=start

public class WordDictionaryTree
{
    public Dictionary<char, WordDictionaryTree> childnode { get; set; }
    public bool isEndOfWord { get; set; }
    public WordDictionaryTree()
    {
        childnode = new Dictionary<char, WordDictionaryTree>();
    }
}
public class WordDictionary
{
    private WordDictionaryTree root;

    public WordDictionary()
    {
        root = new WordDictionaryTree();
    }

    public void AddWord(string word)
    {
        WordDictionaryTree curr = root;
        foreach (char c in word)
        {
            if (!curr.childnode.ContainsKey(c))
                curr.childnode[c] = new WordDictionaryTree();
            curr = curr.childnode[c];
        }
        curr.isEndOfWord = true;
    }

    private bool DFSSearch(string word, int index, WordDictionaryTree node)
    {
        WordDictionaryTree curr = node;
        for (int i = index; i < word.Length; i++)
        {
            if (word[i] == '.')
            {
                foreach (var tmp in curr.childnode)
                {
                    if (DFSSearch(word, i + 1, tmp.Value))
                        return true;
                }
                return false;
            }
            else
            {
                if (!curr.childnode.ContainsKey(word[i]))
                    return false;
                curr = curr.childnode[word[i]];
            }

        }
        return curr.isEndOfWord;
    }

    public bool Search(string word)
    {
        return DFSSearch(word, 0, root);
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
// @lc code=end

