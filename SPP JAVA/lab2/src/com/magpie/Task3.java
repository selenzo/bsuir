package com.magpie;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.Graphics2D.*;
/**
 * Created by Antonio on 29.10.2016.
 */
public class Task3 extends JComponent {
    private int x = 100;
    private int y = 100;
    private int rad = 100;
    private int drad = 2;
    private boolean t = false;
    private float[] fractions = { 0f, 1f };
    private Color[] colors = new Color[]{ new Color ( 200, 200, 200 ), new Color ( 0, 0, 0 ) };

    public Task3() {
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
            drad = (rad > 100 ? -drad : (rad < 5 ? Math.abs(drad) : drad));
            System.out.println(rad);
            rad +=drad;
//            g.drawOval(x - rad/2, y - rad/2,  rad, rad);

            Graphics2D graphics2D = (Graphics2D) g;
            graphics2D.setRenderingHint ( RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON );
//            graphics2D.setRenderingHint ( RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_SPEED );
//            graphics2D.setRenderingHint ( RenderingHints.KEY_COLOR_RENDERING, RenderingHints.VALUE_COLOR_RENDER_QUALITY );

            graphics2D.setPaint(new RadialGradientPaint ( x + rad / 6 , y - rad / 6, rad / 2, fractions, colors ));
            graphics2D.fillOval(x - rad/2, y - rad / 2, rad, rad);
//            graphics2D.fillRect ( 0, 0, 500, getHeight () );

//            g.fillOval(x - rad/2, y - rad/2,  rad, rad);
            t = false;
        }




    }
}
