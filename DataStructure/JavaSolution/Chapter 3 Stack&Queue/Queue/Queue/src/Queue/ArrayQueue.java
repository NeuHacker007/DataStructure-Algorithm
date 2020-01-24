package Queue;

public class ArrayQueue<E> implements IQueue<E> {
    
    private Array<E> array;

    public ArrayQueue(int capacity) {
        array = new Array<E>(capacity);
    }

    public ArrayQueue() {
        this(20);
    }
    
    public int getSize() {
        return array.getSize();
    }
    public void enqueue(E e) {
        array.addLast(e);
    }
    public E dequeue() {
       return array.removeFirst();
    }
    public boolean isEmpty() {
        return array.isEmpty();
    }
    public E getFront() {
        return array.getFirst();
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Size: %d, Capacity: %d\n", array.getSize(), array.getCapacity()));
        sb.append("Top [");
        for (int i = 0; i < array.getSize(); i++) {
            sb.append(array.get(i));
            if (i != array.getSize() - 1) {
                sb.append(", ");
            }
        }
        sb.append("] Tail");

        return sb.toString();
    }
}