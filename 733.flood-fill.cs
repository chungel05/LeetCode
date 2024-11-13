/*
 * @lc app=leetcode id=733 lang=csharp
 *
 * [733] Flood Fill
 *
 * https://leetcode.com/problems/flood-fill/description/
 *
 * algorithms
 * Easy (65.00%)
 * Likes:    8597
 * Dislikes: 889
 * Total Accepted:    1M
 * Total Submissions: 1.6M
 * Testcase Example:  '[[1,1,1],[1,1,0],[1,0,1]]\n1\n1\n2'
 *
 * You are given an image represented by an m x n grid of integers image, where
 * image[i][j] represents the pixel value of the image. You are also given
 * three integers sr, sc, and color. Your task is to perform a flood fill on
 * the image starting from the pixel image[sr][sc].
 * 
 * To perform a flood fill:
 * 
 * 
 * Begin with the starting pixel and change its color to color.
 * Perform the same process for each pixel that is directly adjacent (pixels
 * that share a side with the original pixel, either horizontally or
 * vertically) and shares the same color as the starting pixel.
 * Keep repeating this process by checking neighboring pixels of the updated
 * pixels and modifying their color if it matches the original color of the
 * starting pixel.
 * The process stops when there are no more adjacent pixels of the original
 * color to update.
 * 
 * 
 * Return the modified image after performing the flood fill.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: image = [[1,1,1],[1,1,0],[1,0,1]], sr = 1, sc = 1, color = 2
 * 
 * Output: [[2,2,2],[2,2,0],[2,0,1]]
 * 
 * Explanation:
 * 
 * 
 * 
 * From the center of the image with position (sr, sc) = (1, 1) (i.e., the red
 * pixel), all pixels connected by a path of the same color as the starting
 * pixel (i.e., the blue pixels) are colored with the new color.
 * 
 * Note the bottom corner is not colored 2, because it is not horizontally or
 * vertically connected to the starting pixel.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: image = [[0,0,0],[0,0,0]], sr = 0, sc = 0, color = 0
 * 
 * Output: [[0,0,0],[0,0,0]]
 * 
 * Explanation:
 * 
 * The starting pixel is already colored with 0, which is the same as the
 * target color. Therefore, no changes are made to the image.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == image.length
 * n == image[i].length
 * 1 <= m, n <= 50
 * 0 <= image[i][j], color < 2^16
 * 0 <= sr < m
 * 0 <= sc < n
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        Queue<(int, int)> q = new Queue<(int, int)>();
        int originalColor = image[sr][sc];
        q.Enqueue((sr, sc));

        while (q.Count > 0)
        {
            (int r, int c) = q.Dequeue();
            if (image[r][c] == color || image[r][c] != originalColor)
                continue;

            image[r][c] = color;

            if (r + 1 < image.Length)
                q.Enqueue((r + 1, c));
            if (r - 1 >= 0)
                q.Enqueue((r - 1, c));
            if (c + 1 < image[0].Length)
                q.Enqueue((r, c + 1));
            if (c - 1 >= 0)
                q.Enqueue((r, c - 1));
        }
        return image;
    }
}
// @lc code=end

