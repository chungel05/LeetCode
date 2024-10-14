public partial class Solution
{
    public int GetLongestSubstring(String s)
    {
        PriorityQueue<(char, int), char> queue = new PriorityQueue<(char, int), char>();
        int maxLength = 0;
        char minChar = s[0];

        queue.Enqueue((s[0], 0), s[0]);
        for (int i = 1; i < s.Length; i++)
        {
            foreach (var a in queue.UnorderedItems.OrderBy(x => x.Priority).Select(x => x.Element))
            {
                var (c, index) = a;
                if (c < s[i])
                    maxLength = Math.Max(maxLength, i - index + 1);
                else
                    break;
            }

            if (s[i] < minChar)
            {
                queue.Enqueue((s[i], i), s[i]);
                minChar = s[i];
            }
        }
        return maxLength;
    }
}