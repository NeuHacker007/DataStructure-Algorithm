package app;
public class Array implements IArray {
    private int[] data;
    private int capacity;
    private int size;

 
    public Array(int capacity) {
        this.data = new int[capacity];
        this.size = 0;
    }
    
    public Array() {
        this(20);
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
        if (size == capacity) {
            throw new IllegalArgumentException("Add Failed! Array is full");
        }
        data[size] = e;
        size++;
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

    public int remove(int index) {
        return 0;
    }
   
}