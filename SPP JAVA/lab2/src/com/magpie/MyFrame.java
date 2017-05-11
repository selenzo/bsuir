package com.magpie;

import javax.swing.*;
import javax.swing.border.Border;
import java.awt.*;
import java.awt.event.*;
import java.awt.geom.Ellipse2D;

/**
 * Created by Antonio on 28.10.2016.
 */
public class MyFrame extends JComponent {

    public static int x = 200;
    public static int y = 200;
    public static boolean dxd = false;
    public static boolean dyd = true;
    private boolean t = false;

    public MyFrame() {

        Timer timer = new Timer(30, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                t = true;
                repaint();
            }
        });
        timer.start();
        setSize(500,500);
        setBounds(0,0,500,500);

//        setBorder();
    }


    @Override
    public void paintComponent(Graphics g) {

        if(t) {
            int dx = 2, dy = 2, rad = 60;

            if (dxd) {
                if(500 > x + rad + 10) {
                    x +=2;
                } else {
                    System.out.println(x);
                    dxd = false;
                }
            } else {
                if(0 < x ) {
                    x -=2;
                } else {
                    System.out.println(x);
                    dxd = true;
                }
            }
            if (dyd) {
                if(500 > y + rad +30) {
                    y +=2;
                } else {
                    System.out.println(y);
                    dyd = false;
                }
            } else {
                if(0 < y ) {
                    y -=2;
                } else {
                    System.out.println(y);
                    dyd = true;
                }
            }

            g.drawOval(x, y,  rad, rad);
            t = false;
        }
    }
}
