package com.magpie;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.geom.AffineTransform;

/**
 * Created by Antonio on 29.10.2016.
 */
public class Task5 extends JComponent {
    private int x = 100;
    private int y = 200;
    private int rad = 0;
    private int dx = 2;
    private boolean t = false;

    public Task5() {
        Timer timer = new Timer(30, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                t = true;
                repaint();
//                System.out.println(getBounds());
            }
        });
        timer.start();
        setSize(500,500);
    }

    @Override
    public void paintComponent(Graphics g) {
        if(t) {
            rad +=1;
            dx = x > 300 ? -dx : x < 100 ? Math.abs(dx) : dx;
            x += dx;
            y += dx;

            Graphics2D graphics2D = (Graphics2D) g;
            graphics2D.setRenderingHint ( RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON );
//            graphics2D.drawLine(100,200, 300, 200);

            graphics2D.drawOval(x, y, 1, 1);
            AffineTransform affineTransform = graphics2D.getTransform();
            affineTransform.rotate(Math.toRadians(rad),x,y);
            graphics2D.transform(affineTransform);
            graphics2D.drawLine(x - 10,y - 50, x - 10, y + 50);

            t = false;
        }
    }
}
