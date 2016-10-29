package com.magpie;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/**
 * Created by Antonio on 29.10.2016.
 */
public class Task12 extends JComponent {
    private int x = 200;
    private int y = 200;
    private int rad = 200;
    private double drad = 0;
    private boolean t = false;
    private float[] fractions = { 0f, 1f };
    private Color[] colors = new Color[]{ new Color ( 200, 200, 200 ), new Color ( 0, 0, 0 ) };

    public Task12() {
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
            drad += 0.1;

            Graphics2D graphics2D = (Graphics2D) g;
            graphics2D.setRenderingHint ( RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON );
            int tempX = (int)(200 + 175*Math.cos(drad));
            int tempY = (int)(y + 35*Math.sin(drad));

            if(((int)(drad / 3.14) % 2) == 0) {
                graphics2D.setPaint(new RadialGradientPaint ( x + rad / 6 , y - rad / 6, rad / 2, fractions, colors ));
                graphics2D.fillOval(x - rad/2, y - rad / 2, rad, rad);
                graphics2D.setColor(Color.blue);
                graphics2D.fillRect(tempX, tempY, 10, 10);
            } else {
                graphics2D.setColor(Color.blue);
                graphics2D.fillRect(tempX, tempY, 10, 10);

                graphics2D.setPaint(new RadialGradientPaint ( x + rad / 6 , y - rad / 6, rad / 2, fractions, colors ));
                graphics2D.fillOval(x - rad/2, y - rad / 2, rad, rad);

            }
            t = false;
        }




    }
}
