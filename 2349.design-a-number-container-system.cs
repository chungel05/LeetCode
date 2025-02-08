/*
 * @lc app=leetcode id=2349 lang=csharp
 *
 * [2349] Design a Number Container System
 *
 * https://leetcode.com/problems/design-a-number-container-system/description/
 *
 * algorithms
 * Medium (44.80%)
 * Likes:    486
 * Dislikes: 35
 * Total Accepted:    38.1K
 * Total Submissions: 77.7K
 * Testcase Example:  '["NumberContainers","find","change","change","change","change","find","change","find"]\n' +
  '[[],[10],[2,10],[1,10],[3,10],[5,10],[10],[1,20],[10]]'
 *
 * Design a number container system that can do the following:
 * 
 * 
 * Insert or Replace a number at the given index in the system.
 * Return the smallest index for the given number in the system.
 * 
 * 
 * Implement the NumberContainers class:
 * 
 * 
 * NumberContainers() Initializes the number container system.
 * void change(int index, int number) Fills the container at index with the
 * number. If there is already a number at that index, replace it.
 * int find(int number) Returns the smallest index for the given number, or -1
 * if there is no index that is filled by number in the system.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input
 * ["NumberContainers", "find", "change", "change", "change", "change", "find",
 * "change", "find"]
 * [[], [10], [2, 10], [1, 10], [3, 10], [5, 10], [10], [1, 20], [10]]
 * Output
 * [null, -1, null, null, null, null, 1, null, 2]
 * 
 * Explanation
 * NumberContainers nc = new NumberContainers();
 * nc.find(10); // There is no index that is filled with number 10. Therefore,
 * we return -1.
 * nc.change(2, 10); // Your container at index 2 will be filled with number
 * 10.
 * nc.change(1, 10); // Your container at index 1 will be filled with number
 * 10.
 * nc.change(3, 10); // Your container at index 3 will be filled with number
 * 10.
 * nc.change(5, 10); // Your container at index 5 will be filled with number
 * 10.
 * nc.find(10); // Number 10 is at the indices 1, 2, 3, and 5. Since the
 * smallest index that is filled with 10 is 1, we return 1.
 * nc.change(1, 20); // Your container at index 1 will be filled with number
 * 20. Note that index 1 was filled with 10 and then replaced with 20. 
 * nc.find(10); // Number 10 is at the indices 2, 3, and 5. The smallest index
 * that is filled with 10 is 2. Therefore, we return 2.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= index, number <= 10^9
 * At most 10^5 calls will be made in total to change and find.
 * 
 * 
 */
/*
 * Heap Approach
 * Time: O(m log n), Space: O(n)
 */

// @lc code=start
public class NumberContainers
{
    private Dictionary<int, int> container;
    private Dictionary<int, PriorityQueue<int, int>> indexing;

    // Binary Search Approach
    // use Binary search to search position in indexing List to add and remove index
    /* private int BSNumberContainers(List<int> list, int index)
    {
        int l = 0, r = list.Count;
        while (l < r)
        {
            int mid = (l + r) / 2;
            if (list[mid] == index)
                return mid;
            else if (list[mid] > index)
                r = mid;
            else
                l = mid + 1;
        }
        return l;
    } */

    public NumberContainers()
    {
        container = new Dictionary<int, int>();
        indexing = new Dictionary<int, PriorityQueue<int, int>>();
    }

    // Time: O(log n) because each Enqueue is log n time
    public void Change(int index, int number)
    {
        container[index] = number;
        if (!indexing.ContainsKey(number))
            indexing[number] = new PriorityQueue<int, int>();

        indexing[number].Enqueue(index, index);
    }

    // Time: O(m log n) because each Dequeue is log n time
    public int Find(int number)
    {
        if (!indexing.ContainsKey(number))
            return -1;
        PriorityQueue<int, int> minHeap = indexing[number];
        while (minHeap.Count > 0 && container[minHeap.Peek()] != number)
            minHeap.Dequeue();
        return minHeap.Count > 0 ? minHeap.Peek() : -1;
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */
// @lc code=end

