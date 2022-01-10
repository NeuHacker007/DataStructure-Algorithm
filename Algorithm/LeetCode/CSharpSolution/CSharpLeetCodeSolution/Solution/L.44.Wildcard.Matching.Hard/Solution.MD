## Solution

------

#### Approach 1: Recursion with Memoization

**Intuition**

The first idea here is a recursion. It is a relatively straightforward approach but quite time consuming because of huge recursion depth for long input strings.

- If the strings are equal (`p == s`), then return `True`.
- If the pattern matches any string (`p == '*'`), then return `True`.
- If `p` is empty, or `s` is empty, return `False`.
- If the current characters match (`p[0] == s[0]` or `p[0] == '?'`), then compare the next ones and return `isMatch(s[1:], p[1:])`.
- If the current pattern character is a star (`p[0] == '*'`), then there are two possible situations:
  - The star matches no characters, and hence the answer is `isMatch(s, p[1:])`.
  - The star matches one or more characters, and so the answer is `isMatch(s[1:], p)`.
- If `p[0] != s[0]`, return `False`.

![pic](https://leetcode.com/problems/wildcard-matching/Figures/44/stupid.png)

The problem of this algorithm is that it doesn't pass all test cases because of time limit issue, and hence has to be optimised. Here is what could be done:

1. *Memoization*. That is a standard way to optimise the recursion. Let's have a memoization hashmap using pair `(s, p)` as a key and match/doesn't match as a boolean value. One could keep all already checked pairs `(s, p)` in this hashmap, so that if there are any duplicate checks, the answer is right here, and there is no need to proceed to the computations again.
2. *Clean up of the input data*. Whether the patterns with multiple stars in a row `a****bc**cc` are valid wildcards or not, they could be simplified without any data loss to `a*bc*cc`. Such a cleanup helps to decrease the recursion depth.

**Algorithm**

Here is the algorithm.

- Clean up the input by replacing more than one star in a row by a single star: `p = remove_duplicate_stars(p)`.
- Initiate the memoization hashmap `dp`.
- Return the helper function with a cleaned input: `helper(s, p)`.
- `helper(s, p)`:
  - If `(s, p)` is already known and stored in `dp`, return the value.
  - If the strings are equal (`p == s`), or the pattern matches any string (`p == '*'`), add `dp[(s, p)] = True`.
  - Else if `p` is empty, or `s` is empty, add `dp[(s, p)] = False`.
  - Else if the current characters match (`p[0] == s[0]` or `p[0] == '?'`), then compare the next ones and add `dp[(s, p)] = helper(s[1:], p[1:])`.
  - Else if the current pattern character is a star (`p[0] == '*'`), then there are two possible situations: the star matches no characters, and the star matches one or more characters: `dp[(s, p)] = helper(s, p[1:]) or helper(s[1:], p)`.
  - Else `p[0] != s[0]`, then add `dp[(s, p)] = False`.
  - Now when the value is computed, return it: `dp[(s, p)]`.

**Implementation**

```python
class Solution:        
    def isMatch(self, s: str, p: str) -> bool:
        
        def remove_duplicate_stars(p: str) -> str:
            new_string = []
            for char in p:
                if not new_string or char != '*':
                    new_string.append(char)
                elif new_string[-1] != '*':
                    new_string.append(char)
            return ''.join(new_string)

        def helper(s: str, p: str) -> bool:
            if (s, p) in dp:
                return dp[(s, p)]
            
            if p == s or p == '*':
                dp[(s, p)] = True
            elif p == '' or s == '':
                dp[(s, p)] = False
            elif p[0] == s[0] or p[0] == '?':
                dp[(s, p)] = helper(s[1:], p[1:])
            elif p[0] == '*':
                dp[(s, p)] = helper(s, p[1:]) or helper(s[1:], p)
            else:
                dp[(s, p)] = False
                
            return dp[(s, p)]
        
        dp = {}
        p = remove_duplicate_stars(p)        
        return helper(s, p)
```

**Complexity Analysis**

- Time complexity: O(S \cdot P \cdot (S + P))*O*(*S*⋅*P*⋅(*S*+*P*))

  - Removing duplicate stars requires us to traverse the string `p` once, this requires O(P)*O*(*P*) time.

  - Regarding the helper function, every non-memoized recursive call we will:

    1. Check if `helper(s, p)` has already been calculated. This takes O(S + P)*O*(*S*+*P*) time to create a hash of the tuple `(s, p)` the first time and O(1)*O*(1) time to check if the result has already been cached.
    2. Go through our if statements. If `(s, p)` is one of the base cases, this will take O(min(S, P))*O*(*m**i**n*(*S*,*P*)) time for the string equality check or just O(1)*O*(1) time for other checks, otherwise, it will take O(S + P)*O*(*S*+*P*) time to create a substring `s[1:]` and a substring `p[1:]`. Here, let's assume the worst-case scenario where most of the non-memoized recursive calls require O(S + P)*O*(*S*+*P*) time.
    3. Then we will cache our result, which takes O(1)*O*(1) time since the hash for tuple `(s, p)` was already created when we checked if the result for `(s, p)` is already cached.

    So in total, we spend O(2 \cdot (S + P)) = O(S + P)*O*(2⋅(*S*+*P*))=*O*(*S*+*P*) time on every non-memoized call (S + P*S*+*P* for creating a hash and S + P*S*+*P* for creating substrings). We can only have as many non-memoized calls as there are combinations of `s` and `p`. Therefore, in the worst case, we can have S \cdot P*S*⋅*P* non-memoized calls. This gives us a total time spent on non-memoized calls of O(S \cdot P \cdot (S + P))*O*(*S*⋅*P*⋅(*S*+*P*)).

  - As for the memoized calls, for each non-memoized call, we can make at most 2 additional calls to `helper`. This means that there will be at most S \cdot P*S*⋅*P* memoized calls. Each memoized call takes O(S + P)*O*(*S*+*P*) time to create the hash for `(s, p)` and O(1)*O*(1) time to get the cached result. So the total time spent on memoized calls is O(S \cdot P \cdot (S + P))*O*(*S*⋅*P*⋅(*S*+*P*)) which is a loose upper bound.

  - Adding all 3 time complexities together we get: O(P + 2 \cdot S \cdot P \cdot (S + P)) = O(S \cdot P \cdot (S + P))*O*(*P*+2⋅*S*⋅*P*⋅(*S*+*P*))=*O*(*S*⋅*P*⋅(*S*+*P*)).

    > Note: This approach can be optimized by using two pointers to track the current position on `s` and `p` instead of passing substrings of `s` and `p` as arguments. To improve readability, this was not implemented here, however, doing so will reduce the time complexity to O(S \cdot P)*O*(*S*⋅*P*) since hashing two integers takes O(1)*O*(1) time and each recursive call to `helper` would no longer require creating new substrings which takes linear time. Thus the total time complexity is O(1)*O*(1) per call for a maximum of S \cdot P*S*⋅*P* non-memoized calls and S \cdot P*S*⋅*P* memoized calls.

- Space complexity: O(S \cdot P)*O*(*S*⋅*P*). Creating a new string `p` requires O(P)*O*(*P*) space. The recursion call stack may exceed `max(S, P)` in cases such as `(s, p)` = `(aaab, *a*b)`, however, it is bounded by O(S + P)*O*(*S*+*P*). Lastly, the hashmap requires O(S \cdot P)*O*(*S*⋅*P*) space to memoize the result of each call to `helper`.

----

#### Approach 2: Dynamic Programming

**Intuition**

Recursion approach above shows how painful the large recursion depth could be, so let's try something more iterative.

Memoization from the first approach gives an idea to try a dynamic programming. The problem is very similar with [Edit Distance problem](https://leetcode.com/problems/edit-distance/solution/), so let's use exactly the same approach here.

The idea would be to reduce the problem to simple ones. For example, there is a string `adcebdk` and pattern `*a*b?k`, and we want to compute if there is a match for them: `D = True/False`. One could notice that it seems to be more simple for short strings and patterns and so it would be logical to relate a match `D[p_len][s_len]` with the lengths `p_len` and `s_len` of input pattern and string correspondingly.

Let's go further and introduce a match `D[p_idx][s_idx]` which is a match between the first `p_idx` characters of the pattern and the first `s_idx` characters of the string.

![pic](https://leetcode.com/problems/wildcard-matching/Figures/44/dp_match2_fixed.png)

It turns out that one could compute `D[p_idx][s_idx]`, knowing a match without the last characters `D[p_idx - 1][s_idx - 1]`.

If the last characters are the same or pattern character is '?', then

> D[p_{idx}][s_{idx}] = D[p_{idx} - 1][s_{idx} - 1] \qquad (1)*D*[*p**i**d**x*][*s**i**d**x*]=*D*[*p**i**d**x*−1][*s**i**d**x*−1](1)

![pic](https://leetcode.com/problems/wildcard-matching/Figures/44/word_match3.png)

If the pattern character is '*' and there was a match on the previous step `D[p_idx - 1][s_idx - 1] = True`, then

- The star at the end of pattern still results in a match.
- The star could match as many characters as you wish.

> D[p_{idx} - 1][i] = \textrm{True}, i \ge s_{idx} - 1 \qquad(2)*D*[*p**i**d**x*−1][*i*]=True,*i*≥*s**i**d**x*−1(2)

So each step of the computation would be done based on the previous ones, as follows:

![pic](https://leetcode.com/problems/wildcard-matching/Figures/44/if_match.png)

![pic](https://leetcode.com/problems/wildcard-matching/Figures/44/dpstar.png)

**Algorithm**

- Start from the table `D` filled with `False` everywhere but `D[0][0] = True`.
- Apply rules (1) and (2) in a loop and return `D[p_len][s_len]` as an answer.

![pic](https://leetcode.com/problems/wildcard-matching/Figures/44/fixed.png)

**Implementation**

```java
class Solution {
    public boolean isMatch(String s, String p) {
        int sLen = s.length(), pLen = p.length();

        // base cases
        if (p.equals(s)) {
            return true;
        }
    
        if (pLen > 0 && p.chars().allMatch(c -> c == '*')) {
            return true;
        }
    
        if (p.isEmpty() || s.isEmpty()) {
            return false;
        }

        // init all matrix except [0][0] element as False
        boolean[][] d = new boolean[pLen + 1][sLen + 1];
        d[0][0] = true;

        // DP compute
        for (int pIdx = 1; pIdx < pLen + 1; pIdx++) {
            // the current character in the pattern is '*'
            if (p.charAt(pIdx - 1) == '*') {
                int sIdx = 1;
                                 
                // d[p_idx - 1][s_idx - 1] is a string-pattern match
                // on the previous step, i.e. one character before.
                // Find the first idx in string with the previous math.
                while ((!d[pIdx - 1][sIdx - 1]) && (sIdx < sLen + 1)) {
                    sIdx++;
                }
    
                // If (string) matches (pattern),
                // when (string) matches (pattern)* as well
                d[pIdx][sIdx - 1] = d[pIdx - 1][sIdx - 1];
    
                // If (string) matches (pattern),
                // when (string)(whatever_characters) matches (pattern)* as well
                while (sIdx < sLen + 1) {
                    d[pIdx][sIdx++] = true;
                }
                          
            // the current character in the pattern is '?'
            } else if (p.charAt(pIdx - 1) == '?') {
                for (int sIdx = 1; sIdx < sLen + 1; sIdx++) {
                    d[pIdx][sIdx] = d[pIdx - 1][sIdx - 1];
                }
    
            // the current character in the pattern is not '*' or '?'
            } else {
                for (int sIdx = 1; sIdx < sLen + 1; sIdx++) {
                    // Match is possible if there is a previous match
                    // and current characters are the same
                    d[pIdx][sIdx] = d[pIdx - 1][sIdx - 1] &&
                    (p.charAt(pIdx - 1) == s.charAt(sIdx - 1));
                }
            }
        }
                                        
        return d[pLen][sLen];
    }
}
```

**Complexity Analysis**

- Time complexity: O(S \cdot P)*O*(*S*⋅*P*) where S*S* and P*P* are lengths of the input string and the pattern respectively.
- Space complexity: O(S \cdot P)*O*(*S*⋅*P*) to store the matrix.

---

#### Approach 3: Backtracking

**Intuition**

Complexity O(S \cdot P)*O*(*S*⋅*P*) is much better than O(S \cdot P \cdot (S + P))*O*(*S*⋅*P*⋅(*S*+*P*)), but still could be improved. There is no need to compute the entire matrix, i.e., to check all the possibilities for each star:

- Star matches zero characters.
- Star matches one character.
- Star matches two characters.

...

- Star matches all remaining characters.

Let's just pick up the first opportunity "matches zero characters" and proceed further. If this assumption would lead in "no match" situation, then *backtrack*: come back to the previous star, assume now that it matches one more character (one) and proceed again. Again "no match" situation? *Backtrack again*: come back to the previous star, and assume now that it matches one more character (two), etc.

![pic](https://leetcode.com/problems/wildcard-matching/Figures/44/backtrack.png)

**Algorithm**

Here is the algorithm.

- Let's use two pointers here: `s_idx` to iterate over the string, and `p_idx` to iterate over the pattern. While `s_idx < s_len`:
  - If there are still characters in the pattern (`p_idx < p_len`) and the characters under the pointers match (`p[p_idx] == s[s_idx]` or `p[p_idx] == '?'`), then move forward by increasing both pointers.
  - Otherwise, if there are still characters in the pattern (`p_idx < p_len`), and `p[p_idx] == '*'`, then first check "match zero characters" situation, i.e., increase only pattern pointer `p_idx++`. Write down for a possible backtrack the star position in `star_idx` variable, and the current string pointer in `s_tmp_idx` variable.
  - Else if there is "no match" situation: the pattern is used up `p_idx < p_len` or the characters under the pointers doesn't match.
    - If there was no stars in the pattern, i.e., no `star_idx`, return `False`.
    - If there was a star, then backtrack: set pattern pointer just after the last star `p_idx = star_idx + 1`, and string pointer `s_idx = s_tmp_idx + 1`, i.e., assume that this time the star matches *one more character*. Save the current string pointer for the possible backtrack `s_tmp_idx = s_idx`.
- Return `True` if all remaining characters in the pattern are stars.

**Implementation**

```java
class Solution {
    public boolean isMatch(String s, String p) {
        int sLen = s.length(), pLen = p.length();
        int sIdx = 0, pIdx = 0;
        int starIdx = -1, sTmpIdx = -1;

        while (sIdx < sLen) {
            // If the pattern caracter = string character
            // or pattern character = '?'
            if (pIdx < pLen && (p.charAt(pIdx) == '?' || p.charAt(pIdx) == s.charAt(sIdx))) {
                ++sIdx;
                ++pIdx;
    
            // If pattern character = '*'
            } else if (pIdx < pLen && p.charAt(pIdx) == '*') {
                // Check the situation
                // when '*' matches no characters
                starIdx = pIdx;
                sTmpIdx = sIdx;
                ++pIdx;
                          
            // If pattern character != string character
            // or pattern is used up
            // and there was no '*' character in pattern 
            } else if (starIdx == -1) {
                return false;
                          
            // If pattern character != string character
            // or pattern is used up
            // and there was '*' character in pattern before
            } else {
                // Backtrack: check the situation
                // when '*' matches one more character
                pIdx = starIdx + 1;
                sIdx = sTmpIdx + 1;
                sTmpIdx = sIdx;
            }
        }

        // The remaining characters in the pattern should all be '*' characters
        for (int i = pIdx; i < pLen; i++) {
            if (p.charAt(i) != '*') {
                return false;
            }
   
        }
        return true;
    }
}
```

**Complexity Analysis**

- Time complexity: O(\min(S, P))*O*(min(*S*,*P*)) for the best case and better than O(S \log P)*O*(*S*log*P*) for the average case, where S*S* and P*P* are lengths of the input string and the pattern correspondingly. Please refer to [this article](https://arxiv.org/pdf/1407.0950.pdf) for detailed proof. However, in the worst-case scenario, this algorithm requires O(S \cdot P)*O*(*S*⋅*P*) time.
- Space complexity: O(1)*O*(1) since it's a constant space solution.