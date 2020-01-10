package app;
public class Array implements IArray {
    private int[] data;
    private int capacity;
    private int size;

 
    public Array(int capacity) {
        this.data = new int[capacity];
        this.capacity = capacity;
        this.size = 0;
    }
    
    public Array() {
        this(20);
    }

    public int get(int index) {
        if (index < 0 || index >= size) {
            throw new IllegalArgumentException("Get failed! index invalid");
        }
        return data[index];
    }

    public void set(int index, int e) {
        if (index < 0 || index >= size) {
            throw new IllegalArgumentException("Get failed! index invalid");
        }
        data[index] = e;
    }

    public boolean contains(int e) {
        for(int i = 0; i < size; i++) {
            if (data[i] == e) {
                return true;
            }
        }
        return false;
    }

    @Override
    public int getSize() {
        return this.size;
    }
    @Override
    public int getCapacity() {
        return this.capacity;
    }
    @Override
    public boolean isEmpty() {
        return this.size == 0;
    }

    @Override
    public void addLast(int e) {
        this.add(size, e);
    }
    @Override
    public void add(int index, int e) {
        if (size == capacity) {
            throw new IllegalArgumentException("Add failed! Array is full");
        }
        if (index < 0 || index > size) {
            throw new IllegalArgumentException("Add Failed! Invalid index");
        }
        for(int i = size - 1; i >= index; i--) {
            data[i + 1] = data[i]; 
        }
        data[index] = e;
        size++;
    }
    @Override
    public int remove(int index) {
        if (index < 0 || index >= size) {
            throw new IllegalArgumentException("Remove failed! Invalid index.");
        }

        int result = data[index];

        for (int i = index; i < size; i++) {
            data[i] = data[i + 1];
        }
        size--;
        return result;
    }
   
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Size: %d, Capacity: %d\n", size, capacity));
        sb.append('[');
        for (int i = 0; i < size; i++) {
            sb.append(data[i]);
            if (i != size - 1) {
                sb.append(", ");
            }
        }
        sb.append(']');

        return sb.toString();
    }
}