# Overview
We're asked to implement the structure which provides the following operations in average \mathcal{O}(1)O(1) time:

1. Insert

2. Delete

3. GetRandom

First of all - why this weird combination? The structure looks quite theoretical, but it's widely used in popular statistical algorithms like Markov chain Monte Carlo and Metropolis–Hastings algorithm. These algorithms are for sampling from a probability distribution when it's difficult to compute the distribution itself.

Let's figure out how to implement such a structure. Starting from the Insert, we immediately have two good candidates with \mathcal{O}(1)O(1) average insert time:

Hashmap (or Hashset, the implementation is very similar): Java HashMap / Python dictionary

Array List: Java ArrayList / Python list

Let's consider them one by one.

### Hashmap provides Insert and Delete in average constant time, although has problems with GetRandom.

The idea of GetRandom is to choose a random index and then to retrieve an element with that index. There is no indexes in hashmap, and hence to get true random value, one has first to convert hashmap keys in a list, that would take linear time. The solution here is to build a list of keys aside and to use this list to compute GetRandom in constant time.

### Array List has indexes and could provide Insert and GetRandom in average constant time, though has problems with Delete.

To delete a value at arbitrary index takes linear time. The solution here is to always delete the last value:

Swap the element to delete with the last one.

Pop the last element out.

For that, one has to compute an index of each element in constant time, and hence needs a hashmap which stores element -> its index dictionary.

Both ways converge into the same combination of data structures:

Hashmap element -> its index.

Array List of elements.