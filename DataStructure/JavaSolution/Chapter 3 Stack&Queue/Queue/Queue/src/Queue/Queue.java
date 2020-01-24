package Queue;

public class Queue {
    public static void main(String[] args) throws Exception {
        ArrayQueue<Integer> queue = new ArrayQueue<Integer>();

        for (int i = 0; i < 10; i ++) {
            queue.enqueue(i);
        }
        System.out.println(queue);

        System.out.println(queue.dequeue());
        System.out.println(queue);

    }
}