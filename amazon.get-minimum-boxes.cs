public partial class Solution
{
    public int GetMinimumBoxes(int[] boxes, int capacity)
    {
        Array.Sort(boxes);
        int n = boxes.Length, r = 0, ans = 0;

        for (int i = 0; i < n; i++)
        {
            r = i;
            while (r < n && boxes[r] <= capacity * boxes[i])
                r++;

            ans = Math.Max(ans, r - i);
            if (r == n)
                return n - ans;
        }

        return n - ans;
    }
}