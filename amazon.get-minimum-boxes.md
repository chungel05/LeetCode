The supply chain manager at one of Amazon's warehouses is shipping the last container of the day. All n boxes have been loaded into the truck with their sizes represented in the array boxes. The truck may not have enough capacity to store all the boxes though, so some of the boxes may have to be unloaded. The remaining boxes must satisfy the condition max(boxes) ≤ capacity \* min(boxes).

Given the array, boxes, and capacity, find the minimum number of boxes that need to be unloaded.

Function Description

Complete the function getMinimumBoxes in the editor.

getMinimumBoxes has the following parameters:

1. int[] boxes: an array of integers representing the sizes of the boxes
2. int capacity: the capacity of the truck
   Returns

int: the minimum number of boxes that need to be unloaded

Test Case:

Input: boxes = [1, 4, 3, 2], capacity = 2
Output: 1

![This satisfies the required condition. Hence the answer is 1.](image.png)

[1, 1, 2, 3, 4, 7], capacity = 2
Output: 3
drop 1, 1, 7
