#### 1. Code Question 1

---

Amazon sellers sometimes provide a link to documentation about a product that they are offering. Documentation is usually large, so it broken into an **even** number of volumes for download.



Each volume:

* Is stored in a node instance as a `SinglelyLinkedListNode`
* Has a page count stored in data  
* Has a pointer to the next volume stored in next

A customer will read the first and last volumes each day, removing the volumes from the list after reading them.

Given a reference to the head of a singly-linked list, calculate the maximum number of pages read on any day.



**Note** : try to create a solution that has a space complexity of O(1);

**Example**

The linked list is as follows

1 -> 4->3->2

On the first day, the customer read the volumes with page counts 1 and 2, and remove them from the list. The number of pages read on the first day is 1 + 2 = 3. The new list is:

4 ->3

On the second day, the customer reads the two remaining volumes with page counts 4 and 3. The number of pages read on the second day is 4+ 3 = 7. The list is now empty.

Since 7 > 3, the maximum number of page reads is 7.

**Function Description**

  Complete the function `maximumPages` in the editor below 

 `maximumPages` has the following parameters:

​	head: a reference to the head of a singly-linked list of n integers.

**Returns**

`int` The maximum number of pages read on any day.

**Constraints** 

* `2 <= n <=10^5`, where n is even
* `1 <=SinglyLinkedListNode(i).data<=10^9, where 0<=i<=n`

**Input Format for Custom Testing**

The first line contains an integer n, the number of elements in the list.

Each i of the next n lines (where 0<=i<=n) contains an integer denoting the data of the ith node in the list.



**Sample Case 0**

