public partial class Solution
{
    public int[] getMinConnectionCost(int[] warehouseCapacity, int[][] additionalHubs)
    {
        int n = warehouseCapacity.Length;
        int[] prefixSum = new int[n + 1];
        for (int i = 1; i < n; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + (warehouseCapacity[i] - warehouseCapacity[i - 1]) * i;
        }

        int[] res = new int[additionalHubs.Length];
        for (int i = 0; i < additionalHubs.Length; i++)
        {
            int hubA = additionalHubs[i][0];
            int hubB = additionalHubs[i][1];
            res[i] = prefixSum[hubA] +
                    (prefixSum[hubB] - prefixSum[hubA] - (warehouseCapacity[hubB - 1] - warehouseCapacity[hubA - 1]) * hubA) +
                    (prefixSum[n] - prefixSum[hubB] - (warehouseCapacity[n - 1] - warehouseCapacity[hubB - 1]) * hubB);
        }
        return res;
    }
}