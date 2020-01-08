package app;
public class Array implements IArray {
    private int[] data;
    private int capacity;
    private int size;

 
    public Array(int capacity) {
        this.data = new int[capacity];
        this.size = 0;
    }
    publiic Array() {
        this(20);
    }

    public int getSize() {
        return this.size;
    }

    public int getCapacity() {
        return this.capacity;
    }

    public boolean isEmpty() {
        return this.size == 0;
    }
   
}