package com.magpie;
import java.util.Random;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public static void Task5() {
        String[] names = {"ivan", "petr", "vasya"};
        int[] times = {20, 30, 10};
        int temp = 0;
        for (int i = 0; i < times.length; i++) {
            temp = (times[temp] > times[i] ? i : temp);
        }
        System.out.print("победитель: " + names[temp] + " время " + String.valueOf(times[temp]));
    }

    public static void Task4() {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();
        char ch = (char) (65 + random.nextInt(24));
        boolean answer = false;
        while(!answer) {
            System.out.println( "input char from A to Z");
            char temp = scanner.next().charAt(0);
            answer = (ch == temp);
            System.out.println( (ch < temp ? "too high" : ch > temp ? "too low" : "right") );
        }
    }

    public static void Task3() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("введите интервал");
        float interval = scanner.nextFloat();
        System.out.print("расстояние = " + String.valueOf(1100 * interval) + " футов");
    }

    public static void Task2() {
        String str = "Привет бяка";
        System.out.println(str);
        str = str.replace("бяка", "вырезан с цензурой");
        System.out.println(str);
    }

    public static void Task1() {
        Random rnd = new Random(System.currentTimeMillis());
        Scanner keyboard = new Scanner(System.in);
        float[] arr = new float[10];

        for (int i = 0; i < arr.length; i++) {
            arr[i] = rnd.nextInt(arr.length);
        }

        for (int i = 0; i < arr.length; i++) {
            System.out.print(String.valueOf(arr[i])+ " ");
        }

        System.out.println("номер элемента который увеличить");
        int tempI = keyboard.nextInt();
        tempI--;
        if (tempI > arr.length || tempI < 0) {
            System.out.print("неверный номер");
            return;
        }
        arr[tempI] *= 1.1;

        for (int i = 0; i < arr.length; i++) {
            System.out.print(String.valueOf(arr[i])+ " ");
        }
    }
}
