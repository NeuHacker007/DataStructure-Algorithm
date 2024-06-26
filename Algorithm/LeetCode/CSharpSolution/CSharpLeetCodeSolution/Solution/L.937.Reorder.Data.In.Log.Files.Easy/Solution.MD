## Solution

------

#### Overview

First of all, let us put aside the debate whether this problem is an easy or medium one. The problem is a good exercise to practice the technique of **custom sort** in different languages.

> The idea of custom sort is that we don't have to rewrite a sorting algorithm every time we have a different ***sorting criteria*** among the elements.

Each language provides certain interface that allows us to **customize** the sorting criteria of the sorting functions, so that we can reuse the implementation of sorting in different scenarios.

In this article, we will present two ways to specify the sorting order, namely by **comparator** and by **sorting key**.

------

#### Approach 1: Comparator

**Intuition**

Given a list of elements [e_1, e_2, e_3][*e*1,*e*2,*e*3], regardless of the content of the elements, the first way to specify the *order* among the elements is to define the **pairwise** << (*"less than"*) **relationship** globally.

For instance, for the above example, we could define the **relationships** as e_3 < e_2, \space e_2 < e_1*e*3<*e*2, *e*2<*e*1. Then if we are asked to sort the list in the *ascending* order, the result would be [e_3, e_2, e_1][*e*3,*e*2,*e*1].

**Note:** normally we should define all pairwise relationships among all elements, but due to the transitive property, we omit certain relationships that can be deduced from others, *e.g.* (e_3 < e_2, e_2 < e_1) \to (e_1 < e_3)(*e*3<*e*2,*e*2<*e*1)→(*e*1<*e*3)

If we ever change the *order*, *e.g.* e_1 < e_3, \space e_3 < e_2*e*1<*e*3, *e*3<*e*2, the final *sorted* result would be changed accordingly, *i.e.* [e_1, e_3, e_2][*e*1,*e*3,*e*2].

**Algorithm**

The above pairwise *"less than"* relationship is also known as **comparator** in Java, which is a function object that helps the sorting functions to determine the orders among a collection of elements.

We show the [definition of the comparator](https://docs.oracle.com/javase/8/docs/api/java/util/Comparator.html) interface as follows:

```java
int compare(T o1, T o2) {
    if (o1 < o2)
        return -1;
    else if (o1 == o2)
        return 0;
    else // o1 > o2
        return 1;
}
```

> As we discussed before, once we define the pairwise relationship among the elements in a collection, the **total order** of the collection is then fixed.

Now, what we need to do is to define our own proper **comparator** according to the description of the problem. We can translate the problem into the following rules:

- 1). The *letter-logs* should be prioritized above all *digit-logs*.
- 2). Among the *letter-logs*, we should further sort them firstly based on their **contents**, and then on their **identifiers** if the contents are identical.
- 3). Among the *digit-logs*, they should remain in the same order as they are in the collection.

One can then go ahead and implement the comparator based on the above rules. Here is an example.

```java	
class Solution {
    public String[] reorderLogFiles(String[] logs) {

        Comparator<String> myComp = new Comparator<String>() {
            @Override
            public int compare(String log1, String log2) {
                // split each log into two parts: <identifier, content>
                String[] split1 = log1.split(" ", 2);
                String[] split2 = log2.split(" ", 2);

                boolean isDigit1 = Character.isDigit(split1[1].charAt(0));
                boolean isDigit2 = Character.isDigit(split2[1].charAt(0));

                // case 1). both logs are letter-logs
                if (!isDigit1 && !isDigit2) {
                    // first compare the content
                    int cmp = split1[1].compareTo(split2[1]);
                    if (cmp != 0)
                        return cmp;
                    // logs of same content, compare the identifiers
                    return split1[0].compareTo(split2[0]);
                }

                // case 2). one of logs is digit-log
                if (!isDigit1 && isDigit2)
                    // the letter-log comes before digit-logs
                    return -1;
                else if (isDigit1 && !isDigit2)
                    return 1;
                else
                    // case 3). both logs are digit-log
                    return 0;
            }
        };

        Arrays.sort(logs, myComp);
        return logs;
    }
}
```

**Stable Sort**

One might notice that in the above implementation one can find the logic that corresponds each of the rules, except the **Rule (3)**.

Indeed, we did not do anything explicitly to ensure the order imposed by the Rule (3).

The short answer is that the Rule (3) is ensured *implicitly* by an important property of sorting algorithms, called **[stability](https://en.wikipedia.org/wiki/Sorting_algorithm#Stability)**.

> It is stated as "stable sorting algorithms sort equal elements in the same order that they appear in the input."

Not all sort algorithms are *stable*, *e.g.* ***merge sort\*** is stable.

The `Arrays.sort()` interface that we used is stable, as one can find in the [specification](https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Arrays.html).

Therefore, the Rule (3) is implicitly respected thanks to the stability of the sorting algorithm that we used.

**Complexity Analysis**

Let N*N* be the number of logs in the list and M*M* be the maximum length of a single log.

- Time Complexity: \mathcal{O}(M \cdot N \cdot \log N)O(*M*⋅*N*⋅log*N*)
  - First of all, the time complexity of the `Arrays.sort()` is \mathcal{O}(N \cdot \log N)O(*N*⋅log*N*), as stated in the [API specification](https://docs.oracle.com/javase/8/docs/api/java/util/Arrays.html#sort-byte:A-), which is to say that the `compare()` function would be invoked \mathcal{O}(N \cdot \log N)O(*N*⋅log*N*) times.
  - For each invocation of the `compare()` function, it could take up to \mathcal{O}(M)O(*M*) time, since we compare the contents of the logs.
  - Therefore, the overall time complexity of the algorithm is \mathcal{O}(M \cdot N \cdot \log N)O(*M*⋅*N*⋅log*N*).
- Space Complexity: \mathcal{O}(M \cdot \log N)O(*M*⋅log*N*)
  - For each invocation of the `compare()` function, we would need up to \mathcal{O}(M)O(*M*) space to hold the parsed logs.
  - In addition, since the implementation of `Arrays.sort()` is based on quicksort algorithm whose space complexity is \mathcal{O}(\log n)O(log*n*), assuming that the space for each element is \mathcal{O}(1)O(1)). Since each log could be of \mathcal{O}(M)O(*M*) space, we would need \mathcal{O}(M \cdot \log N)O(*M*⋅log*N*) space to hold the intermediate values for sorting.
  - In total, the overall space complexity of the algorithm is \mathcal{O}(M + M \cdot \log N) = \mathcal{O}(M \cdot \log N)O(*M*+*M*⋅log*N*)=O(*M*⋅log*N*).

----

#### Approach 2: Sorting by Keys

**Intuition**

Rather than defining pairwise relationships among all elements in a collection, the order of the elements can also be defined with **sorting keys**.

To illustrate the idea, let us first define a `Student` object as follows, which has three properties: *name*, *grade*, *age*.

```python
class Student:
    def __init__(self, name, grade, age):
        self.name = name
        self.grade = grade
        self.age = age

student_objects = [
    Student('john', 'A', 15),
    Student('jane', 'B', 12),
    Student('dave', 'B', 10),
]
```

Now, if we are asked to sort the list of students by *age* in ascending order, we could simply use the `age` property of each student as the sorting key, as follows:

```python
>>> sorted(student_objects, key=lambda student: student.age)
[('dave', 'B', 10), ('jane', 'B', 12), ('john', 'A', 15)]
```

> Furthermore, the key could be a tuple of multiple keys, *i.e.* `tuple(key_1, key_2, ... key_n)`.

If two elements have the same value on `key_1`, the comparison will carry on for the following keys, *i.e.* `key_2 ... key_n`.

As a result, if we are asked to sort the students first by the *grade*, then by the *age*, we can simply return the compound key `(stduent.grade, student.age)`, as follows:

```python
>>> sorted(student_objects, key=lambda student: (student.grade, student.age))
[('john', 'A', 15), ('dave', 'B', 10), ('jane', 'B', 12)]
```

**Algorithm**

Given the above intuition, it should be clear that all we need is to *translate* the rules we defined before into a tuple of keys.

As a reminder, here are a list of the rules that we defined before, concerning the order of logs:

- 1). The *letter-logs* should be prioritized above all *digit-logs*.
- 2). Among the *letter-logs*, we should further sort them based on firstly on their **contents**, and then on their **identifiers** if the contents are identical.
- 3). Among the *digit-logs*, they should remain in the same order as they are in the collection.

To ensure the above order, we could define a tuple of 3 keys, `(key_1, key_2, key_3)`, as follows:

- `key_1`: this key serves as a indicator for the type of logs. For the *letter-logs*, we could assign its `key_1` with `0`, and for the *digit-logs*, we assign its `key_1` with `1`. As we can see, thanks to the assigned values, the *letter-logs* would take the priority above the *digit-logs*.
- `key_2`: for this key, we use the ***content\*** of the *letter-logs* as its value, so that among the *letter-logs*, they would be further ordered based on their content, as required in the Rule (2).
- `key_3`: similarly with the `key_2`, this key serves to further order the *letter-logs*. We will use the ***identifier\*** of the *letter-logs* as its value, so that for the *letter-logs* with the same content, we could further sort the logs based on its identifier, as required in the Rule (2).

**Note:** for the *digit-logs*, we don't need the `key_2` and `key_3`. We can simply assign the `None` value to these two keys. As a result, the key value for all the *digit-logs* would be `(1, None, None)`.

Finally, thanks to the **stability** of sorting algorithms, the elements with the same key value would remain the same order as in the original input. Therefore, the Rule (3) is ensured.



```python
class Solution:
    def reorderLogFiles(self, logs: List[str]) -> List[str]:

        def get_key(log):
            _id, rest = log.split(" ", maxsplit=1)
            return (0, rest, _id) if rest[0].isalpha() else (1, )

        return sorted(logs, key=get_key)
```

**Complexity Analysis**

Let N*N* be the number of logs in the list and M*M* be the maximum length of a single log.

- Time Complexity: \mathcal{O}(M \cdot N \cdot \log N)O(*M*⋅*N*⋅log*N*)
  - The `sorted()` in Python is implemented with the [Timsort](https://en.wikipedia.org/wiki/Timsort) algorithm whose time complexity is \mathcal{O}(N \cdot \log N)O(*N*⋅log*N*).
  - Since the keys of the elements are basically the logs itself, the comparison between two keys can take up to \mathcal{O}(M)O(*M*) time.
  - Therefore, the overall time complexity of the algorithm is \mathcal{O}(M \cdot N \cdot \log N)O(*M*⋅*N*⋅log*N*).
- Space Complexity: \mathcal{O}(M \cdot N)O(*M*⋅*N*)
  - First, we need \mathcal{O}(M \cdot N)O(*M*⋅*N*) space to keep the keys for the log.
  - In addition, the worst space complexity of the [Timsort](https://en.wikipedia.org/wiki/Timsort) algorithm is \mathcal{O}(N)O(*N*), assuming that the space for each element is \mathcal{O}(1)O(1). Hence we would need \mathcal{O}(M \cdot N)O(*M*⋅*N*) space to hold the intermediate values for sorting.
  - In total, the overall space complexity of the algorithm is \mathcal{O}(M \cdot N + M \cdot N) = \mathcal{O}(M \cdot N)O(*M*⋅*N*+*M*⋅*N*)=O(*M*⋅*N*).