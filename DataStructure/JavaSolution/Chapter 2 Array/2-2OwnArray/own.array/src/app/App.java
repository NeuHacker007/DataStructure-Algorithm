package app;

public class App {
    public static void main(String[] args) throws Exception {
        Array arr = new Array(20);
        for (int i = 0; i < 10; i++) {
            arr.addLast(i);
        }
        System.out.println(arr);
        arr.add(3, 5);
        System.out.println(arr);
        arr.remove(0);
        System.out.println(arr);
        System.out.println(arr.contains(0));
        System.out.println(arr.contains(3));
        arr.remove(9);
        System.out.println(arr);
        
    }
}