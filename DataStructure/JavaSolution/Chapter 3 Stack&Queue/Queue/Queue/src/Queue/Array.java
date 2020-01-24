package Queue;

public class Array<E> {
    private E[] data;
    private int size;

    public Array(int capacity) {
        data = (E[]) new Object[capacity];
        size = 0;
    }

    public Array() {
        this(20);
    }
    public int getSize() {
        return size;
    }

    public int getCapacity() {
        return data.length;
    }

    public void set(int index, E e) {
        if (index < 0 || index > size) {
            throw new IllegalArgumentException("Set failed! Index is valid!");
        }
        data[index] = e;
    }
    
    public E get (int index) {
        if (index < 0 || index >= size) {
            throw new IllegalArgumentException("Set failed! Index is valid!");
        }
        return data[index];
    }

    public E getFirst() {
        return get(0);
    }

    public E getLast() {
        return get(size - 1);
    }

    public void addLast(E e) {
        add(size, e);
    }

    public void addFirst(E e) {
        add(0, e);
    }

    public void add(int index, E e) {
        if (size == data.length) {
           // throw new IllegalArgumentException("Add Failed. Array is full!");
           this.resize(2 * data.length);
        }
        if (index < 0 || index > size) {
            throw new IllegalArgumentException("Add Failed. Index is invalid");
        }

        for (int i = size - 1; i >= index; i--) {
            data[i + 1] = data[i];
        }
        data[index] = e;
        size++;

    }
    public E removeFirst() {
       return remove(0);
    }
    public E removeLast() {
       return  remove(size - 1);
    }
    public E remove(int index) {
        if (index < 0 || index >= size) {
            throw new IllegalArgumentException("Remove Failed! invalid index");
        }
        E result = data[index];

        for (int i = index + 1; i < size; i++) {
            data[i - 1] = data[i];
        }
        if (size == data.length / 4 && data.length / 2 != 0) {
            this.resize(data.length / 2);
        }
        size--;
        return result;
    }

    public boolean contains(E e) {
        for (int i = 0; i < size; i++) {
            if(data[i] == e) {
                return true;
            }
        }
        return false;
    }

    public int findIndex(E e) {
        for (int i = 0; i < size; i++) {
            if(data[i] == e) {
                return i;
            }
        }
        return -1; 
    }

    public boolean isEmpty() {
        return size == 0;
    }

    public boolean isFull() {
        return size == data.length;
    }

    private void resize(int newCapacity){
        E[] newData = (E[]) new Object[newCanewCapacity];
        for (int i = 0; i < size; i++) {
            newData[i] = data[i];
        }
        data = newData;
    }
}