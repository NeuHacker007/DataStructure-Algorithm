﻿Approach 1: Brute Force
Algorithm

The simplest method is to consider every possible subarray of the given numsnums array, find the sum of the elements of each of those subarrays and check for the equality of the sum obtained with the given kk. Whenver the sum equals kk, we can increment the countcount used to store the required result.
```Java
public class Solution {
    public int subarraySum(int[] nums, int k) {
        int count = 0;
        for (int start = 0; start < nums.length; start++) {
            for (int end = start + 1; end <= nums.length; end++) {
                int sum = 0;
                for (int i = start; i < end; i++)
                    sum += nums[i];
                if (sum == k)
                    count++;
            }
        }
        return count;
    }
}
```

Complexity Analysis

Time complexity : O(n^3)O(n 
3
 ). Considering every possible subarray takes O(n^2)O(n 
2
 ) time. For each of the subarray we calculate the sum taking O(n)O(n) time in the worst case, taking a total of O(n^3)O(n 
3
 ) time.

Space complexity : O(1)O(1). Constant space is used.


Approach 2: Using Cumulative Sum
Algorithm

Instead of determining the sum of elements everytime for every new subarray considered, we can make use of a cumulative sum array , sumsum. Then, in order to calculate the sum of elements lying between two indices, we can subtract the cumulative sum corresponding to the two indices to obtain the sum directly, instead of iterating over the subarray to obtain the sum.

In this implementation, we make use of a cumulative sum array, sumsum, such that sum[i]sum[i] is used to store the cumulative sum of numsnums array upto the element corresponding to the (i-1)^{th}(i−1) 
th
  index. Thus, to determine the sum of elements for the subarray nums[i:j]nums[i:j], we can directly use sum[j+1] - sum[i]sum[j+1]−sum[i].

```Java
public class Solution {
    public int subarraySum(int[] nums, int k) {
        int count = 0;
        int[] sum = new int[nums.length + 1];
        sum[0] = 0;
        for (int i = 1; i <= nums.length; i++)
            sum[i] = sum[i - 1] + nums[i - 1];
        for (int start = 0; start < nums.length; start++) {
            for (int end = start + 1; end <= nums.length; end++) {
                if (sum[end] - sum[start] == k)
                    count++;
            }
        }
        return count;
    }
}
```

Complexity Analysis

Time complexity : O(n^2)O(n 
2
 ). Considering every possible subarray takes O(n^2)O(n 
2
 ) time. Finding out the sum of any subarray takes O(1)O(1) time after the initial processing of O(n)O(n) for creating the cumulative sum array.

Space complexity : O(n)O(n). Cumulative sum array sumsum of size n+1n+1 is used.


Approach 3: Without Space
Algorithm

Instead of considering all the startstart and endend points and then finding the sum for each subarray corresponding to those points, we can directly find the sum on the go while considering different endend points. i.e. We can choose a particular startstart point and while iterating over the endend points, we can add the element corresponding to the endend point to the sum formed till now. Whenver the sumsum equals the required kk value, we can update the countcount value. We do so while iterating over all the endend indices possible for every startstart index. Whenver, we update the startstart index, we need to reset the sumsum value to 0.
```Java
public class Solution {
    public int subarraySum(int[] nums, int k) {
        int count = 0;
        for (int start = 0; start < nums.length; start++) {
            int sum=0;
            for (int end = start; end < nums.length; end++) {
                sum+=nums[end];
                if (sum == k)
                    count++;
            }
        }
        return count;
    }
}
```

 **Complexity Analysis**
Time complexity : O(n^2)O(n 
2
 ). We need to consider every subarray possible.

Space complexity : O(1)O(1). Constant space is used.


Approach 4: Using Hashmap
Algorithm

The idea behind this approach is as follows: If the cumulative sum(repreesnted by sum[i]sum[i] for sum upto i^{th}i 
th
  index) upto two indices is the same, the sum of the elements lying in between those indices is zero. Extending the same thought further, if the cumulative sum upto two indices, say ii and jj is at a difference of kk i.e. if sum[i] - sum[j] = ksum[i]−sum[j]=k, the sum of elements lying between indices ii and jj is kk.

Based on these thoughts, we make use of a hashmap mapmap which is used to store the cumulative sum upto all the indices possible along with the number of times the same sum occurs. We store the data in the form: (sum_i, no. of occurences of sum_i)(sum 
i
​	
 ,no.ofoccurencesofsum 
i
​	
 ). We traverse over the array numsnums and keep on finding the cumulative sum. Every time we encounter a new sum, we make a new entry in the hashmap corresponding to that sum. If the same sum occurs again, we increment the count corresponding to that sum in the hashmap. Further, for every sum encountered, we also determine the number of times the sum sum-ksum−k has occured already, since it will determine the number of times a subarray with sum kk has occured upto the current index. We increment the countcount by the same amount.

After the complete array has been traversed, the countcount gives the required result.

```Java
public class Solution {
    public int subarraySum(int[] nums, int k) {
        int count = 0, sum = 0;
        HashMap < Integer, Integer > map = new HashMap < > ();
        map.put(0, 1);
        for (int i = 0; i < nums.length; i++) {
            sum += nums[i];
            if (map.containsKey(sum - k))
                count += map.get(sum - k);
            map.put(sum, map.getOrDefault(sum, 0) + 1);
        }
        return count;
    }
}
```

Current
1 / 9
 **Complexity Analysis**
Time complexity : O(n)O(n). The entire numsnums array is traversed only once.

Space complexity : O(n)O(n). Hashmap mapmap can contain upto nn distinct entries in the worst case.