package com.magpie;

import java.awt.*;
import java.awt.event.*;
import java.awt.geom.*;
import java.util.Random;
import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;


public class Main {

    public static int x = 100;
    public static int y = 200;
    public static boolean dxd = false;
    public static boolean dyd = true;

    private static void createAndShowGUI() {
        //Create and set up the window.
        JFrame jFrame = new JFrame("task2");
//        jFrame.setPreferredSize(new Dimension(500,500));
//        jFrame.setMaximumSize(new Dimension(500,500));
//        jFrame.setMinimumSize(new Dimension(500,500));
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
//    jFrame.setBounds(100,100,300,300);

        MyFrame myFrame = new MyFrame();
        JButton jButton = new JButton();
        jButton.setText("sad");
        jButton.setSize(100,90);
        jButton.setLocation(239,150);
        JButton jButton2 = new JButton();
        jButton2.setText("sad");
        jButton2.setSize(50,50);
        jButton2.setLocation(299,200);
//        GridBagLayout layout=new GridBagLayout();
//        jFrame.setLayout(BorderLayout.CENTER);
        jFrame.setLayout(null);
        jFrame.add(jButton2);
        jFrame.add(myFrame);
        jFrame.add(jButton);

        jFrame.setResizable(false);

        jFrame.setSize(700,500);
//        jFrame.setBounds(0,0,500,500);
//        jFrame.pack();
    }

    public static void main(String[] args) {

        javax.swing.SwingUtilities.invokeLater(new Runnable() {
            public void run() {
                task7();
            }
        });
    }

    public static void task13() {
        JFrame jFrame = new JFrame("task12");
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        Task13 task13 = new Task13();
        jFrame.setLayout(null);
        jFrame.add(task13);

        jFrame.setResizable(false);
        jFrame.setSize(500,500);
    }

    public static void task12() {
        JFrame jFrame = new JFrame("task12");
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        Task12 task12 = new Task12();
        jFrame.setLayout(null);
        jFrame.add(task12);

        jFrame.setResizable(false);
        jFrame.setSize(500,500);
    }

    public static void task11() {
        JFrame jFrame = new JFrame("task11");
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        Task11 task11 = new Task11();
        jFrame.setLayout(null);
        jFrame.add(task11);

        jFrame.setResizable(false);
        jFrame.setSize(500,500);
    }


    public static void task10() {
        JFrame jFrame = new JFrame("task10");
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        Task10 task10 = new Task10();
        jFrame.setLayout(null);
        jFrame.add(task10);

        jFrame.setResizable(false);
        jFrame.setSize(500,500);
    }

    public static void task9() {
        JFrame jFrame = new JFrame("task9");
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        Task9 task9 = new Task9();
        jFrame.setLayout(null);

        JLabel jLabel = new JLabel();
        jLabel.setText("w=");
        jLabel.setSize(20,10);
        jLabel.setLocation(10, 15);

        JButton jButton1 = new JButton();
        jButton1.setText("Start");
        jButton1.setSize(80,20);
        jButton1.setLocation(100,10);
        jButton1.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                task9.StartStop(true);
            }
        });

        JButton jButton2 = new JButton();
        jButton2.setText("Stop");
        jButton2.setSize(80,20);
        jButton2.setLocation(190,10);
        jButton2.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                task9.StartStop(false);
            }
        });

        SpinnerNumberModel spinnerNumberModel = new SpinnerNumberModel(0.1,0,10,0.1);
        JSpinner jSpinner = new JSpinner(spinnerNumberModel);
        jSpinner.setSize(60,20);
        jSpinner.setLocation(30,10);
        jSpinner.addChangeListener(new ChangeListener() {
            @Override
            public void stateChanged(ChangeEvent e) {
                 task9.w = (double)jSpinner.getValue();
                System.out.println(task9.w);
            }
        });



        jFrame.add(task9);
        jFrame.add(jLabel);
        jFrame.add(jSpinner);
        jFrame.add(jButton1);
        jFrame.add(jButton2);


        jFrame.setResizable(false);
        jFrame.setSize(500,500);
    }

    public static void task8() {
        JFrame jFrame = new JFrame("task5");
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        Task8 task8 = new Task8();
        JButton jButton1 = new JButton();
        jButton1.setText("+1");
        jButton1.setSize(80,30);
        jButton1.setLocation(350,30);
        jButton1.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                task8.SetDx(1);

            }
        });

        JButton jButton2 = new JButton();
        jButton2.setText("-1");
        jButton2.setSize(80,30);
        jButton2.setLocation(350,70);
        jButton2.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                task8.SetDx(-1);
            }
        });

        jFrame.setLayout(null);
        jFrame.add(task8);
        jFrame.add(jButton1);
        jFrame.add(jButton2);

        jFrame.setResizable(false);
        jFrame.setSize(500,500);
    }

    public static void task7() {
        new Swn();
//
//        JFrame jFrame = new JFrame("task7");
//        jFrame.setVisible(true);
//        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
//
//        Task7 task7 = new Task7();
//        jFrame.setLayout(null);
//        jFrame.add(task7);
//
//        jFrame.setResizable(false);
//        jFrame.setSize(500,500);
    }

    public static void task6() {
        JFrame jFrame = new JFrame("task5");
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        Task6 task6 = new Task6();
        jFrame.setLayout(null);
        jFrame.add(task6);

        jFrame.setResizable(false);
        jFrame.setSize(500,500);
    }

    public static void task5() {
        JFrame jFrame = new JFrame("task4");
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        Task5 task5 = new Task5();
        jFrame.setLayout(null);
        jFrame.add(task5);

        jFrame.setResizable(false);
        jFrame.setSize(500,500);
    }

    public static void task4() {
        JFrame jFrame = new JFrame("task3");
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        Task4 task4 = new Task4();
        jFrame.setLayout(null);
        jFrame.add(task4);

        jFrame.setResizable(false);
        jFrame.setSize(500,500);
    }

    public static void task3() {
        JFrame jFrame = new JFrame("task3");
//        jFrame.setPreferredSize(new Dimension(500,500));
//        jFrame.setMaximumSize(new Dimension(500,500));
//        jFrame.setMinimumSize(new Dimension(500,500));
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

//    jFrame.setBounds(100,100,300,300);
        Task3 task3 = new Task3();
//        GridBagLayout layout=new GridBagLayout();
//        jFrame.setLayout(BorderLayout.CENTER);
        jFrame.setLayout(null);
        jFrame.add(task3);

        jFrame.setResizable(false);

        jFrame.setSize(500,500);

    }


    public static void Task2() {
        JFrame jFrame = new JFrame("task2");
//        jFrame.setPreferredSize(new Dimension(500,500));
//        jFrame.setMaximumSize(new Dimension(500,500));
//        jFrame.setMinimumSize(new Dimension(500,500));
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

//    jFrame.setBounds(100,100,300,300);

        MyFrame myFrame = new MyFrame();
//        GridBagLayout layout=new GridBagLayout();
//        jFrame.setLayout(BorderLayout.CENTER);
        jFrame.setLayout(null);
        jFrame.add(myFrame);

        jFrame.setResizable(false);

        jFrame.setSize(500,500);
    }

    //Задать движение по экрану строк (одна за другой) из массива строк. Направление движения по апплету и значение каждой строки выбирается случайным образом.
    public static void Task1() {
        Random random = new Random();

        JFrame jFrame = new JFrame("task1");
        jFrame.setPreferredSize(new Dimension(500,500));
        jFrame.setVisible(true);
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JPanel jPanel = new JPanel();
        jPanel.setOpaque(true);
        jPanel.setBackground(Color.WHITE);
        jPanel.setLayout(null);

        String[] strings = {"привет медвед", "hello bear", "hail medved"};
        boolean[] direction = new boolean[strings.length];
        JLabel[] jLabels = new JLabel[strings.length];
        for (int i = 0; i < strings.length; i++) {
            direction[i] = random.nextBoolean();
            jLabels[i] = new JLabel();
            jLabels[i].setText(strings[i]);

            jLabels[i].setLocation(0, i * 60);
//            jLabels[i].setHorizontalTextPosition(JLabel.CENTER);

            jLabels[i].setSize(jLabels[i].getText().length() * 20, 50);
            jLabels[i].setFont(jLabels[i].getFont().deriveFont(Font.TRUETYPE_FONT, 40f));
            jPanel.add(jLabels[i]);


        }

//        jFrame.setSize(500,500);
//        jFrame.pack();
        jFrame.setContentPane(jPanel);
        jFrame.setSize(500, 500);

        Timer timer = new Timer(50, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                for (int i = 0; i < strings.length; i++) {
                    if(direction[i]) {
//                        System.out.println(jLabels[i].getX());

                        jLabels[i].setLocation( jLabels[i].getX() < 500 ? jLabels[i].getX() + 5 : -jLabels[i].getWidth(), jLabels[i].getY());
                    } else {
                        jLabels[i].setLocation( (jLabels[i].getX() + jLabels[i].getWidth() > 0) ? jLabels[i].getX() - 5 : 500, jLabels[i].getY());
                    }
                }
//                System.out.println(jFrame.getSize());
            }
        });
        timer.start();

//        jFrame.setLocationByPlatform(true);
//        jFrame.setMaximumSize(new Dimension(500,400));
//        jFrame.setResizable(false);

    }
}