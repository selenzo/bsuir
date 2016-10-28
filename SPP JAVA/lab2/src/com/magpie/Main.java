package com.magpie;

import java.awt.*;
import java.awt.event.*;
import java.awt.geom.*;
import java.util.Random;
import javax.swing.*;
import javax.swing.border.Border;


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
                createAndShowGUI();
            }
        });

//
//        Timer timer = new Timer(40, new ActionListener() {
//            @Override
//            public void actionPerformed(ActionEvent e) {
//                jFrame.repaint();
//            }
//        });
//        timer.start();
//
//
////        jFrame.setSize(500, 500);
//
//        int dx = 2, dy = 2;
//        int rad = 90;
////        Graphics2D g = (Graphics2D)jFrame.getRootPane().getGraphics();
////        Shape bigCircle = new Ellipse2D.Double(x, y,  rad, rad);
////        g.draw(bigCircle);
//
//
//
////        jFrame.getRootPane().setBorder(BorderFactory.createMatteBorder(4, 4, 4, 4, Color.RED));
//
//        Timer timer2 = new Timer(40, new ActionListener() {
//            @Override
//            public void actionPerformed(ActionEvent e) {
////                SwingUtilities.updateComponentTreeUI(jFrame);
//
////                jFrame.repaint();
//                Graphics2D graphics2D = (Graphics2D)jFrame.getGraphics();
//                jFrame.update(graphics2D);
//
//                if (dxd) {
//                    if(500 > x + rad + 10) {
//                        x +=5;
//                    } else {
//                        System.out.println(x);
//                        dxd = false;
//                    }
//                } else {
//                    if(0 < x - 10) {
//                        x -=5;
//                    } else {
//                        System.out.println(x);
//                        dxd = true;
//                    }
//                }
//                if (dyd) {
//                    if(500 > y + rad + 10) {
//                        y +=5;
//                    } else {
//                        System.out.println(y);
//                        dyd = false;
//                    }
//                } else {
//                    if(0 < y - 30) {
//                        y -=5;
//                    } else {
//                        System.out.println(y);
//                        dyd = true;
//                    }
//                }
//
//                Shape bigCircle = new Ellipse2D.Double(x, y,  rad, rad);
//                graphics2D.draw(bigCircle);
//
//            }
//        });
        //timer.start();


    }
    /*
    * JFrame fr=new JFrame("Вращение треугольника вокруг своего центра тяжести");
        fr.setPreferredSize( new Dimension(300,300));
        final JPanel pan= new JPanel();
        fr.add(pan);
        fr.setVisible(true);
        fr.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        fr.pack();
        Timer tm= new Timer(500, new ActionListener(){
            int i=0;
            @Override
            public void actionPerformed(ActionEvent arg0) {
                Graphics2D gr=(Graphics2D)pan.getRootPane().getGraphics();
                pan.update(gr);
                GeneralPath path=new GeneralPath();
                path.append(new Polygon(new int []{60,-80,50},new int[]{-60,-50,40},3),true);
                int x=(60-80+50)/3,y=(-60-50+40)/3;
                gr.translate(150, 150);
                AffineTransform tranforms = AffineTransform.getRotateInstance((i++)*0.07, x, y);
                gr.transform(tranforms);
                gr.draw(path);
            }});
        tm.start();
    *
    * */

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