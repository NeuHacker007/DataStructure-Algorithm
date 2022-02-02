## Solution

------

#### Overview

The solutions for this problem go by many names, such as Dynamic Programming, recursion with memoization, DFS, and backtracking *etc.* They all capture certain traits of the solutions.

In essence, all these solutions can all be categorized as variants of ***Dynamic Programming\*** (DP), as we will discuss in this article.

> As a reminder, with DP, we break the original problem down to several sub-problems *recursively* until the sub-problems are small enough to be solved directly. Then we combine the results of sub-problems to obtain the final solution for the original problem.

As one can see, the DP solutions are also the embodiment of the divide-and-conquer principle.

To come up a DP solution, the essential step is to **represent** the solution of the original problem with the results of its sub-problems. In general, there are two approaches to implement a DP solution, namely ***Top-Down\*** and ***Bottom-Up\***. We would explain in detail how to apply these two approaches to this problem in the following sections.



------

#### Approach 1: Top-Down Dynamic Programming

**Intuition**

Let us start with the top-down approach, which is more efficient compared to bottom-up approach in this case.

Given an input string \text{s} = \text{`catsanddog'}s=‘catsanddog’, we define the results of breaking it into words with the function \text{F(s)}F(s).

For any word (denoted as \text{w}w) in the dictionary, if it matches with a prefix of the input string, we then can *divide* the string into two parts: the word and the postfix, *i.e.* s = \text{w} + \text{postfix}*s*=w+postfix.

Consequently, the solution for the input string can be represented as follows:

\forall \text{w} \in \text{dict}, \quad s = \text{w} + \text{postfix} \implies \{ \text{w} + \text{F(postfix)} \} \subseteq \text{F(s)}∀w∈dict,*s*=w+postfix⟹{w+F(postfix)}⊆F(s)

*i.e.* we add the matched word to the solutions from the postfix.

For example, the word `cat` matches with a prefix of the string. As a result, we can divide the string into s = \text{`cat'} + \text{`sanddog'}*s*=‘cat’+‘sanddog’.

For the postfix of `sanddog`, we could obtain the results by recursively applying our function, *i.e.* \text{F(`sanddog')} = \{ \text{`sand dog'} \}F(‘sanddog’)={‘sand dog’}. By adding the prefix word to the solutions of the postfix, we then obtain one of the solutions for the original string, *i.e.* \text{`cat sand dog'} \in \text{F(s)}‘cat sand dog’∈F(s).

> The above approach can be considered as a ***top-down\*** DP. The reason lies in the part that we adopt the *laissez-faire* strategy, *i.e.* we simply take a first step, while assuming the subsequent steps will figure out on their owns.

In our case, we first find a match to a prefix of the string, while assuming that we would eventually obtain the results for the corresponding postfix.

In the following graph, we illustrate how the top-down approach works with a concrete example, *i.e.* with the input string as `s="catsanddogo"` and the word dictionary as `wordDict=["cat", "cats", "and", "sand", "dog", "do", "go"]`.

![DFS](https://leetcode.com/problems/word-break-ii/Figures/140/140_DFS.png)

Each node in the graph represents a postfix of the input string. In particular, we have some nodes with an empty string, which indicates the end of the input string. Each edge indicates the reduction from one postfix to another. The label on top of each edge indicates the word that is used to trigger the reduction.

As one might notice, the above graph is a **tree** data structure. From **top** to **bottom**, we reduce the input string down to its postfixes recursively until the string becomes empty.

> Each path that starts with the root node (input string) and ends with a leaf node of an empty string represents a sequence of words that the input string can be broke down into, as we highlighted in the graph.

**Algorithm**

Following the above intuition, it seems intuitive to implement the solution with recursion.

We define a recursive function called `_wordBreak_topdown(s)` which generates the results for the input string. Here are a few steps to implement our recursive function.

- First of all, as the ***base case*** of the recursion, when the input string is empty, the recursion would terminate. Note that we return a list of empty list as the result, rather than just an empty list.
- As the main body of the function, we run an iteration over all the prefixes of the input string. If the corresponding prefix happens to match a word in the dictionary, we then invoke recursively the function on the postfix.
- At the end of the iteration, we keep the results in the hashmap named `memo` with each valid postfix string as its key and the list of words that compose the prefix of as the value. For instance, for the postfix `dogo`, its corresponding entry in the hashmap would be `memo["dogo"] = ["do", "go"]`.
- Finally, as the result, we return the entry of `memo` with the input string as the key. (The string itself is a postfix of the string itself.)

```java
class Solution {
    protected Set<String> wordSet;
    protected HashMap<String, List<List<String>>> memo;

    public List<String> wordBreak(String s, List<String> wordDict) {
        wordSet = new HashSet<>();
        for (String word : wordDict) {
            wordSet.add(word);
        }
        memo = new HashMap<String, List<List<String>>>();

        _wordBreak_topdown(s);

        // chain up words together
        List<String> ret = new ArrayList<String>();
        for (List<String> words : memo.get(s)) {
            StringBuffer sentence = new StringBuffer();
            for (String word : words) {
                sentence.insert(0, word);
                sentence.insert(0, " ");
            }
            ret.add(sentence.toString().strip());
        }

        return ret;
    }

    protected List<List<String>> _wordBreak_topdown(String s) {
        if (s.equals("")) {
            List<List<String>> solutions = new ArrayList<List<String>>();
            solutions.add(new ArrayList<String>());
            return solutions;
        }

        if (memo.containsKey(s)) {
            return memo.get(s);
        } else {
            List<List<String>> solutions = new ArrayList<List<String>>();
            memo.put(s, solutions);
        }

        for (int endIndex = 1; endIndex <= s.length(); ++endIndex) {
            String word = s.substring(0, endIndex);
            if (wordSet.contains(word)) {
                List<List<String>> subsentences = _wordBreak_topdown(s.substring(endIndex));
                for (List<String> subsentence : subsentences) {
                    List<String> newSentence = new ArrayList<String>(subsentence);
                    newSentence.add(word);
                    memo.get(s).add(newSentence);
                }
            }
        }
        return memo.get(s);
    }
}
```

**Optimization**

The execution of the recursion would unfold as a tree as we shown before.

As one might notice, there are some duplicate nodes in the tree, *e.g.* the node with the postfix `dogo`, which is due to the fact that there are several ways to reduce the input string down to the same postfix.

Therefore, it would be natural to reuse the results that we've calculated for certain postfix, rather than re-calculating them at each occasion. Together with recursion, this optimization technique is also called ***memoization\***.

Another essential characteristic about DP solutions is that we reuse the results of intermediate solutions. Without this optimization, *i.e.* if we do not reuse the intermediate solutions, our top-down approach could not be fully qualified as the DP solution.

![DP with memoization](https://leetcode.com/problems/word-break-ii/Figures/140/140_dp_memoization.png)

On the other hand, as revealed by the execution graph, we can consider our top-down approach as *backtracking* or DFS (Depth-First Search) traversal over the tree / graph alike data structure. Here is how we formulate the approaches.

- **Backtracking**: given an input string, we *explore* all the possibilities to break it down to words. At certain step, if we cannot move forwards, we would *backtrack* to the previous step and try another alternative.
- **DFS traversal**: we can reformulate the problem as finding all the paths from the root to the leaf nodes in a tree consisting of postfixes. Therefore, by traversing the tree in the manner of DFS as we did, we could achieve the goal easily.

**Complexity Analysis**

Let N*N* be the length of the input string and W*W* be the number of words in the dictionary.

- Time Complexity: \mathcal{O}(N ^ 2 + 2^N + W)O(*N*2+2*N*+*W*)

  - In the execution graph shown before, we might visit certain nodes multiple times, but we visit each edge once and only once. Therefore, the time complexity of the algorithm is proportional to the number of **edges**, which depends on the construction of the input string and the word dictionary.
  - In the worst case, there could be N*N* valid postfixes, *i.e.* each prefix of the input string is a valid word. For example, it is one of the worst cases with the input string as `s=aaa` and the word dictionary as `wordDict=["a", "aa", "aaa"]`.

  ![worst case](https://leetcode.com/problems/word-break-ii/Figures/140/140_worst_case_example.png)

  - For a postfix of length i*i*, it could make at most i*i* invocation of the recursive function, *i.e.* a node with the prefix of length i*i* would have at most i*i* outgoing edges. Since we have N*N* prefixes, in total, we could have \sum_{i=1}^{N}{i} = \frac{(1 + N)\cdot N}{2}∑*i*=1*N**i*=2(1+*N*)⋅*N* edges in th execution graph.
  - In addition, at each visit of the edge, we need to iterate through the number of solutions that bring back by the edge. In the above worst case, each postfix of length i*i* would have 2^{i-1}2*i*−1 number of solutions, *i.e.* each edge brings back 2^{i-1}2*i*−1 number of solution from the target postfix. Therefore, in total, we need \mathcal{O}(\sum_{i=1}^{N}{2^{i-1}}) = \mathcal{O}(2^N)O(∑*i*=1*N*2*i*−1)=O(2*N*) iterations to construct the final solutions.
  - At the beginning of the algorithm, we construct a set out of the dictionary, which takes \mathcal{O}(W)O(*W*) time.
  - In total, the overall time complexity of the algorithm is \mathcal{O}(N ^ 2 + 2^N + W)O(*N*2+2*N*+*W*).

- Space Complexity: \mathcal{O}(2 ^ {N} \cdot N + W)O(2*N*⋅*N*+*W*)

  - In the worst case, it could be possible to insert a break between every adjacent characters in the string. Therefore, there could be 2 ^ {N-1}2*N*−1 possible combinations to break the input string into words. Each combination would consist of N*N* characters from the input string. As a result, in total we would need \mathcal{O}(2 ^ {N-1} \cdot N)O(2*N*−1⋅*N*) space to hold the values in the hashmap. In addition, we would have N*N* entries for the keys, which could amount to \mathcal{O}(N ^ 2)O(*N*2) space.

  - We use a set to keep all the words from the dictionary, which we assume to be \mathcal{O}(W)O(*W*) space.

  - It is worth mentioning that the recursion would incur additional space consumption on the function call stack. But since they would not dominate the other space overhead, we can omit them here.

  - In total, the overall space complexity of the algorithm is \mathcal{O}(2 ^ {N-1} \cdot N + N ^ 2 + W) = \mathcal{O}(2 ^ {N} \cdot N + W)O(2*N*−1⋅*N*+*N*2+*W*)=O(2*N*⋅*N*+*W*).

    

------

#### Approach 2: Bottom-Up Dynamic Programming

**Intuition**

> As opposed to the top-down approach, the ***bottom-up\*** dynamic programming *progressively* builds up the solutions for the sub-problems upfront, rather than delaying them to the end.

We will demonstrate the difference between the two approaches with a concrete example later.

Following the same definition in the top-down approach, given an input string \text{s}s, *e.g.* \text{s} = \text{`catsanddog'}s=‘catsanddog’, we define the results of breaking it into words with the function \text{F(s)}F(s).

For any word (denoted as \text{w}w) in the dictionary, if it matches with a postfix of the input string, we then can *divide* the string into two parts: the prefix and the word, *i.e.* s = \text{prefix} + \text{w}*s*=prefix+w.

Consequently, the solution for the input string can be represented as follows:

\forall \text{w} \in \text{dict}, \quad s = \text{prefix} + \text{w} \implies \{ \text{F(prefix)} + \text{w} \} \subseteq \text{F(s)}∀w∈dict,*s*=prefix+w⟹{F(prefix)+w}⊆F(s)

*i.e.* we add the matched word to the solutions from the prefix.

We start from an empty prefix (*i.e.* the bottom case), to progressively extend the solutions to a larger prefix. Eventually, the extended prefix would grow to be the original string.

In the following graph, we demonstrate how the bottom-up approach works for the same example in the top-down approach, *i.e.* with the input string as `s="catsanddogo"` and the word dictionary as `wordDict=["cat", "cats", "and", "sand", "dog", "do", "go"]`.

![DP table](https://leetcode.com/problems/word-break-ii/Figures/140/140_dp_value_table.png)

As one can see from the above graph, by appending words to the prefixes, we obtain the solutions for the larger strings. At the end, we calculate the solutions for all possible prefixes, which includes the solutions for the original string, since the string itself is a prefix of the string.

**Algorithm**

To implement the bottom-up DP approach, we often use an array to keep track of all the intermediate solutions. The problem is no exception.

We define an array called `dp`. Each element in the array (`dp[i]`) would be used to hold the solutions for the corresponding prefix `s[0:i]`.

For example, for the prefix of `s[0:3] = "cat"`, the value for the element of `dp[3]` would be `["cat"]`, as we indicated in the previous graph.

> The goal of the algorithm boils down to calculating each element in the `dp` array. And the desired result would be the last element in the array, *i.e.* `dp[len(s)]`, which corresponds to the results for the entire string.

Here are a few steps on how to calculate the values for the `dp` array:

- First of all, we create an empty `dp` array to hold all the intermediate solutions.
- We then iterate through all prefixes of the input string, from the bottom case (empty string) to the entire string.
- For each prefix, we enumerate all possible combinations to see if we could reuse the solutions from the previous prefixes.

```java
class Solution {
    protected Set<String> wordSet;

    private void updateCharSet(String s, HashSet<Character> charSet) {
        for (int i = 0; i < s.length(); ++i)
            charSet.add(s.charAt(i));
    }

    public List<String> wordBreak(String s, List<String> wordDict) {
        HashSet<Character> stringCharSet = new HashSet<Character>();
        updateCharSet(s, stringCharSet);

        HashSet<Character> wordCharSet = new HashSet<Character>();
        wordSet = new HashSet<>();
        for (String word : wordDict) {
            wordSet.add(word);
            updateCharSet(word, wordCharSet);
        }

        // quick check on the sets of characters
        if (!wordCharSet.containsAll(stringCharSet))
            return new ArrayList();

        ArrayList<ArrayList<String>> dp = new ArrayList<ArrayList<String>>(s.length() + 1);
        for (int i = 0; i < s.length() + 1; ++i) {
            ArrayList<String> emptyList = new ArrayList<String>();
            dp.add(emptyList);
        }
        dp.get(0).add("");

        for (int endIndex = 1; endIndex < s.length() + 1; ++endIndex) {
            ArrayList<String> sublist = new ArrayList<String>();

            // fill up the values in the dp array.
            for (int startIndex = 0; startIndex < endIndex; ++startIndex) {
                String word = s.substring(startIndex, endIndex);
                if (wordSet.contains(word))
                    for (String subsentence : dp.get(startIndex))
                        sublist.add((subsentence + " " + word).strip());
            }
            dp.set(endIndex, sublist);
        }

        return dp.get(s.length());
    }
}
```

**Note:** since this is not the most efficient algorithm, as we will see in the analysis later, we added an additional check at the beginning of the algorithm, to see if the input string contains some characters that do not appear in any of the words in the dictionary. If this is the case, then we are sure that the input string cannot be broken down into words, which can save us from running the algorithm.

With this check, we could by pass some tricky test cases, not ending up with the TLE (Time Limit Exceeded) error.

We mentioned previously that we could consider the top-down DP approach as the DFS (Depth-First Traversal) over the structure of graph.

> Similarly, we could consider the bottom-up DP approach as the BFS ***(Breadth-First Search)\*** over the same graph structure, as shown in the following graph.

![BFS with DP table](https://leetcode.com/problems/word-break-ii/Figures/140/140_BFS_with_table.png)

Rather than going in depth, the bottom-up DP approach explores the breadth first. It is not the best strategy in the case, since not every branch would lead to a potential solution, yet with BFS we have to keep all the intermediate solutions regardless of whether they would lead to a final solution or not. While in DFS, no intermediate solution is kept until it leads to a final solution. This is the main reason why DFS (top-down approach) is a much more efficient algorithm for this problem, compared to BFS (bottom-down approach).

**Keep Breaks Not Words**

One of the drawbacks of the above bottom-up implementation is that we keep the intermediate solutions in the form of strings, *e.g.* `dp[7] = ['cat sand', 'cats and']`.

It is rather costly to do so. The rationale is twofold: 1). we have to keep many copies of string in the memory. 2). we have to iterate through the string to make a new copy, which is time-consuming.

One of the optimizations that we can do is that rather than keeping the words (strings), we simply keep the **positions** to insert the breaks into the original string. For the same example of `dp[7]`, we can store the values as `dp[7] = [[3, 7], [4, 7]]`, which we could interpret as follows:

- For the solution of `[3, 7]`, by inserting a break respectively at the indices of 3 and 7 in the original string, we could obtain a list of words, *i.e.* `"cat sand"`.
- Similarly, the solution of `[4, 7]` corresponds to the list of words `"cats and"`.

With this optimization, we then can convert the previous dp array to the following: ![BFS with breaks](https://leetcode.com/problems/word-break-ii/Figures/140/140_BFS_with_breaks.png) As one can see, not only do we save the space to store the intermediate solutions, but also the time to calculate them.

```java
class Solution {
    protected Set<String> wordSet;

    private void updateCharSet(String s, HashSet<Character> charSet) {
        for (int i = 0; i < s.length(); ++i)
            charSet.add(s.charAt(i));
    }

    public List<String> wordBreak(String s, List<String> wordDict) {
        HashSet<Character> stringCharSet = new HashSet<Character>();
        updateCharSet(s, stringCharSet);

        HashSet<Character> wordCharSet = new HashSet<Character>();
        wordSet = new HashSet<>();
        for (String word : wordDict) {
            wordSet.add(word);
            updateCharSet(word, wordCharSet);
        }

        // quick check on the sets of characters
        if (!wordCharSet.containsAll(stringCharSet))
            return new ArrayList();

        ArrayList<ArrayList<ArrayList<Integer>>> dp =
                new ArrayList<ArrayList<ArrayList<Integer>>>(s.length() + 1);
        for (int i = 0; i < s.length() + 1; ++i) {
            ArrayList<ArrayList<Integer>> emptyList = new ArrayList<ArrayList<Integer>>();
            dp.add(emptyList);
        }
        ArrayList<Integer> start = new ArrayList<Integer>();
        start.add(0);
        dp.get(0).add(start);

        for (int endIndex = 1; endIndex < s.length() + 1; ++endIndex) {
            ArrayList<ArrayList<Integer>> stops = new ArrayList<ArrayList<Integer>>();

            // fill up the values in the dp array.
            for (int startIndex = 0; startIndex < endIndex; ++startIndex) {
                String word = s.substring(startIndex, endIndex);
                if (wordSet.contains(word)) {
                    for (List<Integer> subsentence : dp.get(startIndex)) {
                        ArrayList<Integer> copy = new ArrayList(subsentence);
                        copy.add(endIndex);
                        stops.add(copy);
                    }
                }
            }
            dp.set(endIndex, stops);
        }

        // reconstruct the words list from the positions of breaks/stops
        ArrayList<String> ret = new ArrayList<String>();
        for (List<Integer> stops : dp.get(s.length())) {
            StringBuffer sentence = new StringBuffer();
            for (int i = 0; i < stops.size() - 1; ++i) {
                sentence.append(s.substring(stops.get(i), stops.get(i + 1)) + " ");
            }
            ret.add(sentence.toString().strip());
        }

        return ret;
    }
}
```

**Recursive Encoding**

Although we save quite some efforts by storing just the breaks rather than the words themselves, still we were **repeating** the solutions of small prefixes in the solutions for the larger prefixes.

> To avoid this repetition, we could simply refer to the previous solutions with their indices in the dp array, rather than copying them.

With the above *recursive encoding* schema, we could further reduce the dp array into the following:

![BFS with recursive encoding](https://leetcode.com/problems/word-break-ii/Figures/140/140_BFS_recursive_encoding.png)

As shown in the above graph, each element in the encoding is a two-element tuple as `[previous_dp_index, word_end_index]`. First of all, the two indices define the scope of the word to be added. In addition, the first index (*i.e.* `previous_dp_index`) indicates the previous dp entry that we should *recursively* look into, in order to add the words that compose the prefix.

With this schema, we could further save some space and time to calculate the intermediate solutions.

One caveat though is that it is slightly more complex to decode the final solutions from the encoded results.

```java
class Solution {
    protected Set<String> wordSet;
    protected ArrayList<ArrayList<ArrayList<Integer>>> dp;

    protected String inputString;
    protected ArrayList<String> result;

    private void updateCharSet(String s, HashSet<Character> charSet) {
        for (int i = 0; i < s.length(); ++i)
            charSet.add(s.charAt(i));
    }

    public List<String> wordBreak(String s, List<String> wordDict) {
        HashSet<Character> stringCharSet = new HashSet<Character>();
        updateCharSet(s, stringCharSet);

        HashSet<Character> wordCharSet = new HashSet<Character>();
        wordSet = new HashSet<>();
        for (String word : wordDict) {
            wordSet.add(word);
            updateCharSet(word, wordCharSet);
        }

        // quick check on the sets of characters
        if (!wordCharSet.containsAll(stringCharSet))
            return new ArrayList();

        inputString = s;
        dp = new ArrayList<ArrayList<ArrayList<Integer>>>(s.length() + 1);
        for (int i = 0; i < s.length() + 1; ++i) {
            ArrayList<ArrayList<Integer>> emptyList = new ArrayList<ArrayList<Integer>>();
            dp.add(emptyList);
        }
        ArrayList<Integer> start = new ArrayList<Integer>();
        start.add(0);
        dp.get(0).add(start);

        for (int endIndex = 1; endIndex < s.length() + 1; ++endIndex) {
            ArrayList<ArrayList<Integer>> stops = new ArrayList<ArrayList<Integer>>();

            // fill up the values in the dp array.
            for (int startIndex = 0; startIndex < endIndex; ++startIndex) {
                String word = s.substring(startIndex, endIndex);
                if (wordSet.contains(word)) {
                    ArrayList<Integer> newStop = new ArrayList();
                    newStop.add(startIndex);
                    newStop.add(endIndex);
                    stops.add(newStop);
                }
            }
            dp.set(endIndex, stops);
        }

        this.result = new ArrayList<String>();
        wordDFS("", s.length());
        return this.result;
    }

    protected void wordDFS(String sentence, Integer dpIndex) {
        if (dpIndex == 0) {
            result.add(sentence.strip());
            return;
        }

        for (List<Integer> wordIndex : dp.get(dpIndex)) {
            Integer start = wordIndex.get(0), end = wordIndex.get(1);
            String newSentence = inputString.substring(start, end) + " " + sentence;
            wordDFS(newSentence, start);
        }
    }
}
```

**Complexity Analysis**

Let N*N* be the length of the input string and W*W* be the number of words in the dictionary.

- Time Complexity: \mathcal{O}(N^2 + 2 ^ N + W)O(*N*2+2*N*+*W*)
  - As we discussed before, in the worst case, it could be possible to insert a break between every adjacent characters in the input string, *i.e.* each prefix of length k*k* would have 2 ^ {k-1}2*k*−1 number of solutions.
  - While we iterate over all prefixes of the input string, starting from the empty prefix, the number of solutions for each prefix would double at each step.
  - Assume that we adopt the most optimal recursive encoding for the solutions, we would need k*k* steps to build solutions for the prefix of length k*k*. In total, we would need \sum_{i=1}^{N}{i} = \frac{(N+1) \cdot N}{2}∑*i*=1*N**i*=2(*N*+1)⋅*N* steps to build all intermediate solutions.
  - However, at the end, we need to reconstruct the solutions from the encoding. In the worst case, we would have 2 ^ {N-1}2*N*−1 number of solutions. Thus it would take at least 2 ^ {N-1}2*N*−1 steps to reconstruct the solutions.
  - Similarly, it would take W*W* steps to build the word set from the dictionary.
  - In total, the overall time complexity for the bottom-up DP approach with the recursive encoding is \mathcal{O}(\frac{(N+1) \cdot N}{2} + 2 ^ {N-1} + W ) = \mathcal{O}(N^2 + 2 ^ N + W)O(2(*N*+1)⋅*N*+2*N*−1+*W*)=O(*N*2+2*N*+*W*).
- Space Complexity: \mathcal{O}(2^N \cdot N + N^2 + W)O(2*N*⋅*N*+*N*2+*W*)
  - As stated above, in the worst case, each prefix of length k*k* would have 2 ^ {k-1}2*k*−1 number of solutions. Therefore, in total, we would have \sum_{k=1}^{N}{2 ^ {k-1}} = 2^N∑*k*=1*N*2*k*−1=2*N* intermediate solutions. If we keep the solutions as words or breaks, we would need N*N* space for each solution. Thus, it amounts to 2^N \cdot N2*N*⋅*N* for the approaches that keep the intermediate solutions as words or breaks.
  - On the other hand, if we use the recursive encoding, each prefix of length k*k* would only need k*k* entries at most to keep its solutions. With the encoding, we would only need \sum_{k=1}^{N}{k} = \frac{(1+N) \cdot N}{2}∑*k*=1*N**k*=2(1+*N*)⋅*N* space to keep all intermediate solutions.
  - As always, we would need an additional W*W* space to hold the words in the dictionary.
  - In total, the space complexity of the algorithm is \mathcal{O}(2^N \cdot N + N^2 + W)O(2*N*⋅*N*+*N*2+*W*), if we adopt the recursive encoding schema.