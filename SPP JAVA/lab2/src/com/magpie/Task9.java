package com.magpie;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.geom.AffineTransform;

/**
 * Created by Antonio on 29.10.2016.
 */
public class Task9 extends JComponent {
    public double w = 0.1;
    private double x = 0;
    private double y = 0;
    private double rad = 0;
    public double dx = 0;
    public boolean start = false;
    private boolean t = false;
    private Timer timer = new Timer(100, new ActionListener() {
        @Override
        public void actionPerformed(ActionEvent e) {
            t = true;
            repaint();
//                System.out.println(getBounds());
        }
    });

    public void SetDx(int temp) {
        if (dx != 0) {

            dx += dx > 0 ? temp : -temp;
        } else {
            dx += temp > 0 ? temp : 0;

        }
        System.out.println(dx);
    }

    public void StartStop(boolean value) {
        if(value != start) {
            if (value) {
                timer.start();
                start = true;
            } else {
                timer.stop();
                start = false;
            }
        }

    }

    public Task9() {
        setSize(500, 500);
    }

    @Override
    public void paintComponent(Graphics g) {
        if (t) {
            rad += 0.5;
            dx += 0.2;
            dx = dx > 500 ? 0 : dx;
//            dx = x > 300 ? -dx : x < 100 ? Math.abs(dx) : dx;
            x = ((1 + Math.cos(w * rad)) / 2) + dx;
//            System.out.println(x);
//            x++;
            y = Math.sin(x) * 100 + 300;

//            x += dx;

            Graphics2D graphics2D = (Graphics2D) g;
            graphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
            graphics2D.drawLine(0,300, 500, 300);

            graphics2D.drawOval((int)x, (int)y, 2, 2);
//            AffineTransform affineTransform = graphics2D.getTransform();
//            affineTransform.rotate(Math.toRadians(rad),x,y);
//            graphics2D.transform(affineTransform);
//            graphics2D.drawPolygon(xPoints,yPoints,4);
//            graphics2D.drawLine(x - 10,y - 50, x - 10, y + 50);

            t = false;
        }
    }
}
