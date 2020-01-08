package array;
public class Main {
    public static void main(String[] args) {
        int[] arr = new int[20];
        for (int i = 0; i < arr.length; i++) {
            arr[i] = i;
            System.out.println(i);
        }

        int[] scores = new int[]{11, 22, 33};
        for(int score: scores) {
            System.out.println(score);
        }
    }
}