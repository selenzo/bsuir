package com.magpie;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/**
 * Created by Antonio on 29.10.2016.
 */
public class Task13 extends JComponent {
    private int x = 200;
    private int sec = 0;
    private int min = 0;
    private int hour = 0;
    private int y = 200;
    private int rad = 200;
    private double drad = 0;
    private boolean t = false;

    public Task13() {
        Timer timer = new Timer(30, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                t = true;
                repaint();
//                System.out.println(getBounds());
            }
        });

        JButton jButton1 = new JButton();
        jButton1.setText("+1 min");
        jButton1.setSize(80,20);
        jButton1.setLocation(100,10);
        jButton1.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                min++;
                if (min == 60) {
                    min = 0;
                    hour++;
                }
                if (hour == 12) {
                    hour = 0;
                }
            }
        });

        JButton jButton2 = new JButton();
        jButton2.setText("+1 hour");
        jButton2.setSize(80,20);
        jButton2.setLocation(190,10);
        jButton2.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                hour++;
                if (hour == 12) {
                    hour = 0;
                }
            }
        });

        add(jButton1);
        add(jButton2);

        timer.start();
        setSize(500, 500);
    }

    @Override
    public void paintComponent(Graphics g) {
        if (t) {
            sec += 1;
            if (sec == 60) {
                sec = 0;
                min++;
            }
            if (min == 60) {
                min = 0;
                hour++;
            }
            if (hour == 12) {
                hour = 0;
            }


            Graphics2D graphics2D = (Graphics2D) g;
            graphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
//            double tempXa = sec *6 * 3.14 / 180;
//            double tempYa = sec *6 * 3.14 / 180;
            int tempX = (int) (y + (x / 2) * Math.cos((sec - 15) * 6 * 3.14 / 180));
            int tempY = (int) (x + (y / 2) * Math.sin((sec - 15) * 6 * 3.14 / 180));
            graphics2D.drawLine(x, y, tempX, tempY);

            tempX = (int) (x + (x / 2.5) * Math.cos((min - 15) * 6 * 3.14 / 180));
            tempY = (int) (y + (y / 2.5) * Math.sin((min - 15) * 6 * 3.14 / 180));
            graphics2D.drawLine(x, y, tempX, tempY);

            tempX = (int) (x + (x / 4) * Math.cos((hour - 3) * 30 * 3.14 / 180));
            tempY = (int) (y + (y / 4) * Math.sin((hour - 3) * 30 * 3.14 / 180));
            graphics2D.drawLine(x, y, tempX, tempY);

            for (int i = 0; i < 12; i++) {
                tempX = (int) (x + (x / 1.5) * Math.cos((i - 3) * 30 * 3.14 / 180));
                tempY = (int) (y + (y / 1.5) * Math.sin((i - 3) * 30 * 3.14 / 180));
                graphics2D.drawOval(tempX, tempY, 6,6);
            }

            t = false;
        }


    }
}
