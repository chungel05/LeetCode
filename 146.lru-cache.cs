/*
 * @lc app=leetcode id=146 lang=csharp
 *
 * [146] LRU Cache
 *
 * https://leetcode.com/problems/lru-cache/description/
 *
 * algorithms
 * Medium (43.41%)
 * Likes:    21033
 * Dislikes: 1071
 * Total Accepted:    1.8M
 * Total Submissions: 4.2M
 * Testcase Example:  '["LRUCache","put","put","get","put","get","put","get","get","get"]\n' +
  '[[2],[1,1],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]'
 *
 * Design a data structure that follows the constraints of a Least Recently
 * Used (LRU) cache.
 * 
 * Implement the LRUCache class:
 * 
 * 
 * LRUCache(int capacity) Initialize the LRU cache with positive size
 * capacity.
 * int get(int key) Return the value of the key if the key exists, otherwise
 * return -1.
 * void put(int key, int value) Update the value of the key if the key exists.
 * Otherwise, add the key-value pair to the cache. If the number of keys
 * exceeds the capacity from this operation, evict the least recently used
 * key.
 * 
 * 
 * The functions get and put must each run in O(1) average time complexity.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input
 * ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
 * [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
 * Output
 * [null, null, null, 1, null, -1, null, -1, 3, 4]
 * 
 * Explanation
 * LRUCache lRUCache = new LRUCache(2);
 * lRUCache.put(1, 1); // cache is {1=1}
 * lRUCache.put(2, 2); // cache is {1=1, 2=2}
 * lRUCache.get(1);    // return 1
 * lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
 * lRUCache.get(2);    // returns -1 (not found)
 * lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
 * lRUCache.get(1);    // return -1 (not found)
 * lRUCache.get(3);    // return 3
 * lRUCache.get(4);    // return 4
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= capacity <= 3000
 * 0 <= key <= 10^4
 * 0 <= value <= 10^5
 * At most 2 * 10^5 calls will be made to get and put.
 * 
 * 
 */

// @lc code=start
public class LRUNode
{
    public int key { get; set; }
    public int value { get; set; }
    public LRUNode prev { get; set; }
    public LRUNode next { get; set; }
    public LRUNode(int key, int value)
    {
        this.key = key;
        this.value = value;
        this.prev = null;
        this.next = null;
    }
}

public class LRUCache
{
    private int capacity;
    private Dictionary<int, LRUNode> cache;
    private LRUNode left;
    private LRUNode right;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        this.cache = new Dictionary<int, LRUNode>();
        this.left = new LRUNode(0, 0);
        this.right = new LRUNode(0, 0);
        left.next = right;
        right.prev = left;
    }

    private void Remove(LRUNode node)
    {
        LRUNode prev = node.prev;
        LRUNode next = node.next;
        prev.next = next;
        next.prev = prev;
    }

    private void Insert(LRUNode node)
    {
        LRUNode prev = right.prev;
        prev.next = node;
        node.prev = prev;
        node.next = right;
        right.prev = node;
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
            return -1;
        else
        {
            LRUNode node = cache[key];
            Remove(node);
            Insert(node);
            return node.value;
        }
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
            Remove(cache[key]);
        LRUNode newNode = new LRUNode(key, value);
        cache[key] = newNode;
        Insert(newNode);

        if (cache.Count > capacity)
        {
            LRUNode remove = left.next;
            cache.Remove(remove.key);
            Remove(remove);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
// @lc code=end

