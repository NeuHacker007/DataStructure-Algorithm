package Queue;
interface IQueue<E> {
    int getSize();
    void enqueue(E e);
    E dequeue();
    boolean isEmpty();
    E getFront();
}