## Solution

------

#### Approach 1: String Index Manipulation

**Intuition**

There is no doubt that this is an easy problem. Yet, it could be a good exercise for one to practice string manipulation, which is definitely common during interviews.

In this article, we start with some approaches that manipulate string indexes, then we look at how to use the built-in string functions to solve the problem.

> The intuition is simple, as it pretty much given away from the name of the problem, *i.e.* first we **locate** the last word, then we **count** the length of the last word.

One should pay attention to some edge cases though:

- The input string could be empty.
- There could be some trailing spaces in the input string, *e.g.* `hello <space>`.
- There might only be one word in the given string.

The challenge is to build a *concise* yet *comprehensive* solution that could handle all above cases.

**Algorithm**

One can break down the solution into two steps:

- First, we would try to locate the last word, starting from the end of the string. We iterate the string in reverse order, consuming the empty spaces. When we first come across a non-space character, we know that we are at the last character of the last word.
- Second, once we locate the last word. We count its length, starting from its last character. Again, we could use a loop here.

![two loop](https://leetcode.com/problems/length-of-last-word/Figures/58/58_two_loops.png)

Here is what it looks like, a solution with **two loops**:



````java
class Solution {
    public int lengthOfLastWord(String s) {
        // trim the trailing spaces
        int p = s.length() - 1;
        while (p >= 0 && s.charAt(p) == ' ') {
            p--;
        }

        // compute the length of last word
        int length = 0;
        while (p >= 0 && s.charAt(p) != ' ') {
            p--;
            length++;
        }
        return length;
    }
}
````

**Complexity**

- Time Complexity: \mathcal{O}(N)O(*N*), where N*N* is the length of the input string.

  In the worst case, the input string might contain only a single word, which implies that we would need to iterate through the entire string to obtain the result.

- Space Complexity: \mathcal{O}(1)O(1), only constant memory is consumed, regardless the input.

---

#### Approach 2: One-loop Iteration

**Intuition**

In the above approach, we applied two loops. One is used to locate the last word, and the other one to calculate its length.

> We could actually complete the same tasks within a single loop.

The trick is that we could define a condition, *i.e.* the precise moment that we should start to count the length of the word.

![one loop](https://leetcode.com/problems/length-of-last-word/Figures/58/58_one_loop.png)

In the following animation, we demonstrate how the above algorithm works.

```java
class Solution {
    public int lengthOfLastWord(String s) {
        int p = s.length(), length = 0;
        while (p > 0) {
            p--;
            // we're in the middle of the last word
            if (s.charAt(p) != ' ') {
                length++;
            }
            // here is the end of last word
            else if (length > 0) {
                return length;
            }
        }
        return length;
  }
}
```

**Complexity**

- Time Complexity: \mathcal{O}(N)O(*N*), where N*N* is the length of the input string.

  This approach has the same time complexity as the previous approach. The only difference is that we combined two loops into one.

- Space Complexity: \mathcal{O}(1)O(1), again a constant memory is consumed, regardless the input.

  

------

#### Approach 3: Built-in String Functions

**Intuition**

As we mentioned at the beginning of the article, we could also resort to the ***built-in\*** functions of the String data structure, in order to solve the problem.

In fact, String is such an important data type in many programming languages, that often it comes with a rich set of *built-in* functions that can help one to accomplish many common tasks, such as trimming the empty spaces in the string *etc.*

It would be really helpful to get proficient with those built-in functions.

**Algorithm**

In different programming languages, the sets of built-in functions associated with String are different though. In this section, we showcase some examples.

In Python, we would use the following built-in functions to accomplish the tasks:

- `str.isspace()`: this function determines if the `str` contains only spaces.
- `str.split(delimiter)`: this function could split the input string into several substrings, based on the given *delimiter* (by default, the delimiter is space).

One can find the list of built-in functions in Python from the [official documentation](https://docs.python.org/3/library/stdtypes.html#str).

In Java, here is a list of built-in functions that we would use:

- `String.trim()`: this function returns a copy of the string, with the leading and trailing whitespaces trimmed.
- `String.length()`: this function returns the length of the string.
- `String.lastIndexOf(char)`: this function returns the index of the last occurrence of the given character.

Again, one can find more details about the APIs for the String data structure in Java, from the [official documentation](https://docs.oracle.com/javase/7/docs/api/java/lang/String.html).

```java
class Solution {
    public int lengthOfLastWord(String s) {
        s = s.trim();  // trim the trailing spaces in the string
        return s.length() - s.lastIndexOf(" ") - 1;
    }
}
```

**Complexity Analysis**

- Time Complexity: \mathcal{O}(N)O(*N*), where N*N* is the length of the input string.

  Since we use some built-in function from the String data type, we should look into the complexity of each built-in function that we used, in order to obtain the overall time complexity of our algorithm.

  It would be safe to assume the time complexity of the methods such as `str.split()` and `String.lastIndexOf()` to be \mathcal{O}(N)O(*N*), since in the worst case we would need to scan the entire string for both methods.

- Space Complexity: \mathcal{O}(N)O(*N*). Again, we should look into the built-in functions that we used in the algorithm.

  In the Java implementation, we used the function `String.trim()` which returns a ***copy*** of the input string without leading and trailing whitespace. Therefore, we would need \mathcal{O}(N)O(*N*) space for our algorithm to hold this copy.

  In the Python implementation, we used `str.split()`, which returns a list of ***substrings\*** that are separated by the space delimiter. As a result, we would need \mathcal{O}(N)O(*N*) space for our algorithm to store this list.