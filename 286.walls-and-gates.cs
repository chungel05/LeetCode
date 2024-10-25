/*
 * @lc app=leetcode id=286 lang=csharp
 *
 * [286] Walls And Gates
*/

// @lc code=start
public partial class Solution
{
    public void WallsAndGates(int[][] rooms)
    {
        Queue<int[]> q = new Queue<int[]>();

        for (int i = 0; i < rooms.Length; i++)
        {
            for (int j = 0; j < rooms[0].Length; j++)
            {
                if (rooms[i][j] == 0)
                    q.Enqueue(new int[] { i, j });
            }
        }

        int[] direction = new int[] { -1, 0, 1, 0, -1 };
        int distance = 1;
        while (q.Count > 0)
        {
            int len = q.Count;
            for (int i = 0; i < len; i++)
            {
                int[] cell = q.Dequeue();
                for (int j = 0; j < 4; j++)
                {
                    int r = cell[0] + direction[j];
                    int c = cell[1] + direction[j + 1];
                    if (r < 0 || c < 0 || r >= rooms.Length || c >= rooms[0].Length || rooms[r][c] != int.MaxValue)
                        continue;

                    rooms[r][c] = distance;
                    q.Enqueue(new int[] { r, c });
                }
            }
            distance++;
        }
    }
}
// @lc code=end

