package com.magpie;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.geom.AffineTransform;

/**
 * Created by Antonio on 29.10.2016.
 */
public class Task4 extends JComponent {
    private int x = 200;
    private int y = 200;
    private int rad = 0;
    private boolean t = false;

    public Task4() {
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
            Graphics2D graphics2D = (Graphics2D) g;
            graphics2D.setRenderingHint ( RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON );
            AffineTransform affineTransform = graphics2D.getTransform();
            affineTransform.rotate(Math.toRadians(rad),x,x);
            graphics2D.transform(affineTransform);
            graphics2D.drawLine(x,y, x + 100, x + 100);

            t = false;
        }
    }
}
