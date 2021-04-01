### Solution

---

#### How to make the encoded string as compact as possible

This question is similar to the [Google interview question discussed last week](https://leetcode.com/discuss/interview-experience/297576/google-onsite-interview-sde1-new-grad-mountain-view-ca).

[To serialize](https://en.wikipedia.org/wiki/Serialization) a binary tree means to

- Encode tree structure.
- Encode node values.
- Choose delimiters to separate the values in the encoded string.

![](C:\Drive H Work\DataStructure-Algorithm\Algorithm\LeetCode\CSharpSolution\CSharpLeetCodeSolution\Solution\L.449.Serialize.And.Deserialize.BST.Medium\img\tree_struct.png)

Hence there are three axes of optimisation here.



------

#### Approach 1: Postorder traversal to optimise space for the tree structure.

**Intuition**

Let's use here the fact that BST could be constructed from preorder or postorder traversal only. Please [check this article](https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/solution/) for the detailed discussion. In brief, it's a consequence of two facts:

- [Binary tree could be constructed from preorder/postorder and inorder traversal](https://leetcode.com/articles/construct-binary-tree-from-postorder-and-inorder-t/).
- [Inorder traversal of BST is an array sorted in the ascending order: `inorder = sorted(preorder)`](https://leetcode.com/articles/delete-node-in-a-bst/).

That means that BST structure is already encoded in the preorder or postorder traversal and hence they are both suitable for the compact serialization.

Serialization could be easily implemented with both strategies, but for optimal deserialization better to choose the postorder traversal because member/global/static variables are not allowed here.

![](C:\Drive H Work\DataStructure-Algorithm\Algorithm\LeetCode\CSharpSolution\CSharpLeetCodeSolution\Solution\L.449.Serialize.And.Deserialize.BST.Medium\img\approach1.png)

```java
public class Codec {
    public StringBuilder postorder(TreeNode root, StringBuilder sb) {
        if (root == null)
            return sb;
        postorder(root.left, sb);
        postorder(root.right, sb);
        sb.append(root.val);
        sb.append(' ');
        return sb;
    }

    // Encodes a tree to a single string.
    public String serialize(TreeNode root) {
        StringBuilder sb = postorder(root, new StringBuilder());
        if (sb.length() > 0)
            sb.deleteCharAt(sb.length() - 1);
        return sb.toString();
    }

    public TreeNode helper(Integer lower, Integer upper, ArrayDeque<Integer> nums) {
        if (nums.isEmpty())
            return null;
        int val = nums.getLast();
        if (val < lower || val > upper)
            return null;

        nums.removeLast();
        TreeNode root = new TreeNode(val);
        root.right = helper(val, upper, nums);
        root.left = helper(lower, val, nums);
        return root;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(String data) {
        if (data.isEmpty())
            return null;
        ArrayDeque<Integer> nums = new ArrayDeque<Integer>();
        for (String s : data.split("\\s+"))
            nums.add(Integer.valueOf(s));
        return helper(Integer.MIN_VALUE, Integer.MAX_VALUE, nums);
    }
}
```

**Complexity Analysis**

- Time complexity : \mathcal{O}(N)O(*N*) both for serialization and deserialization. Let's compute the solution with the help of [master theorem](https://en.wikipedia.org/wiki/Master_theorem_(analysis_of_algorithms)) T(N) = aT\left(\frac{b}{N}\right) + \Theta(N^d)*T*(*N*)=*a**T*(*N**b*)+Θ(*N**d*). The equation represents dividing the problem up into a*a* subproblems of size \frac{N}{b}*b**N* in \Theta(N^d)Θ(*N**d*) time. Here one divides the problem in two subproblemes `a = 2`, the size of each subproblem (to compute left and right subtree) is a half of initial problem `b = 2`, and all this happens in a constant time `d = 0`. That means that \log_b(a) > dlog*b*(*a*)>*d* and hence we're dealing with [case 1](https://en.wikipedia.org/wiki/Master_theorem_(analysis_of_algorithms)#Case_1_example) that means \mathcal{O}(N^{\log_b(a)}) = \mathcal{O}(N)O(*N*log*b*(*a*))=O(*N*) time complexity.
- Space complexity : \mathcal{O}(N)O(*N*), since we store the entire tree. Encoded string: one needs to store (N - 1)(*N*−1) delimiters, and N*N* node values in the encoded string. Tree structure is encoded in the order of values and uses no space.

---

#### Approach 2: Convert int to 4-bytes string to optimise space for node values.

**Intuition**

Approach 1 works fine with the small node values but starts to consume more and more space in the case of large ones.

For example, the tree `[2,null,3,null,4]` is encoded as a string `"4 3 2"` which uses `5` bytes to store the values and delimiters, `1` byte per value or delimiter. So far everything is fine.

Let's consider now the tree `[12345,null,12346,null,12347]` which is encoded as `"12347 12346 12345"` and consumes `17` bytes to store 3 integers and 2 delimiters, `15` bytes for node values only. At the same time it's known that `4` bytes is enough to store an int value, *i.e.* `12` bytes should be enough for 3 integers. `15 > 12` and hence the storage of values could be optimised.

> How to do it? Convert each integer into 4-bytes string.

![](C:\Drive H Work\DataStructure-Algorithm\Algorithm\LeetCode\CSharpSolution\CSharpLeetCodeSolution\Solution\L.449.Serialize.And.Deserialize.BST.Medium\img\four_bytes.png)

```python
class Codec:
    def postorder(self, root):
        return self.postorder(root.left) + self.postorder(root.right) + [root.val] if root else []
        
    def int_to_str(self, x):
        """
        Encodes integer to bytes string.
        """
        bytes = [chr(x >> (i * 8) & 0xff) for i in range(4)]
        bytes.reverse()
        bytes_str = ''.join(bytes)
        return bytes_str
        
    def serialize(self, root):
        """
        Encodes a tree to a single string.
        """
        lst = self.postorder(root)
        lst = [self.int_to_str(x) for x in lst]
        return 'ç'.join(map(str, lst))
    
    def str_to_int(self, bytes_str):
        """
        Decodes bytes string to integer.
        """
        result = 0
        for ch in bytes_str:
            result = result * 256 + ord(ch)
        return result
        
    def deserialize(self, data):
        """
        Decodes your encoded data to tree.
        """
        def helper(lower = float('-inf'), upper = float('inf')):
            if not data or data[-1] < lower or data[-1] > upper:
                return None
            
            val = data.pop()
            root = TreeNode(val)
            root.right = helper(val, upper)
            root.left = helper(lower, val)
            return root
        
        data = [self.str_to_int(x) for x in data.split('ç') if x]
        return helper() 
```

**Complexity Analysis**

- Time complexity : \mathcal{O}(N)O(*N*) both for serialization and deserialization.
- Space complexity : \mathcal{O}(N)O(*N*), since we store the entire tree. Encoded string: one needs 2(N - 1)2(*N*−1) bytes for the delimiters, and 4 N4*N* bytes for the node values in the encoded string. Tree structure is encoded in the order of node values and uses no space.

---

#### Approach 3: Get rid of delimiters.

**Intuition**

Approach 2 works well except for delimiter usage.

Since all node values are now encoded as 4-bytes strings, one could just split the encoded string into 4-bytes chunks, convert each chunk back to the integer and proceed further.

```java
public class Codec {
    // Encodes a tree to a list.
    public void postorder(TreeNode root, StringBuilder sb) {
        if (root == null)
            return;
        postorder(root.left, sb);
        postorder(root.right, sb);
        sb.append(intToString(root.val));
    }

    // Encodes integer to bytes string
    public String intToString(int x) {
        char[] bytes = new char[4];
        for (int i = 3; i > -1; --i) {
            bytes[3 - i] = (char) (x >> (i * 8) & 0xff);
        }
        return new String(bytes);
    }

    // Encodes a tree to a single string.
    public String serialize(TreeNode root) {
        StringBuilder sb = new StringBuilder();
        postorder(root, sb);
        return sb.toString();
    }

    // Decodes list to tree.
    public TreeNode helper(Integer lower, Integer upper, ArrayDeque<Integer> nums) {
        if (nums.isEmpty())
            return null;
        int val = nums.getLast();
        if (val < lower || val > upper)
            return null;

        nums.removeLast();
        TreeNode root = new TreeNode(val);
        root.right = helper(val, upper, nums);
        root.left = helper(lower, val, nums);
        return root;
    }

    // Decodes bytes string to integer
    public int stringToInt(String bytesStr) {
        int result = 0;
        for (char b : bytesStr.toCharArray()) {
            result = (result << 8) + (int) b;
        }
        return result;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(String data) {
        ArrayDeque<Integer> nums = new ArrayDeque<Integer>();
        int n = data.length();
        for (int i = 0; i < (int) (n / 4); ++i) {
            nums.add(stringToInt(data.substring(4 * i, 4 * i + 4)));
        }

        return helper(Integer.MIN_VALUE, Integer.MAX_VALUE, nums);
    }
}
```

**Complexity Analysis**

- Time complexity : \mathcal{O}(N)O(*N*) both for serialization and deserialization.
- Space complexity : \mathcal{O}(N)O(*N*), since we store the entire tree. Encoded string: no delimiters, no additional space for the tree structure, just 4 N4*N* bytes for the node values in the encoded string.