package com.magpie;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.geom.AffineTransform;
import java.lang.reflect.Field;
import java.util.Random;

/**
 * Created by Antonio on 29.10.2016.
 */
public class Task11 extends JComponent {
    private int x = 0;
    private int y = 0;
    private int rad = 0;
    public int dx = 2;
    private boolean t = false;
    Random random = new Random();
    Label label = new Label();


    public Task11() {
        Timer timer = new Timer(30, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                t = true;
                repaint();
//                System.out.println(getBounds());
            }
        });

        JComboBox jComboBox = new JComboBox();
        jComboBox.addItem("BLUE");
        jComboBox.addItem("RED");
        jComboBox.addItem("WHITE");
        jComboBox.setLocation(300,20);
        jComboBox.setSize(100, 20);
        jComboBox.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                label.Cnahge(jComboBox.getSelectedIndex());
                System.out.print(jComboBox.getSelectedItem());
            }
        });

        add(label);
        add(jComboBox);

        timer.start();
        setSize(500, 500);
    }

    @Override
    public void paintComponent(Graphics g) {
        if (t) {
            rad += 1;

            dx = x > 350 ? -dx : x < 10 ? Math.abs(dx) : dx;
            x += dx;
            y += dx;
            label.setLocation(x, 200);
            Graphics2D graphics2D = (Graphics2D) g;
            graphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
            t = false;
        }
    }

    public class Label extends JLabel {

        public void Cnahge(int color) {

            Color[] colors = {Color.BLUE, Color.red, Color.white};

            setForeground(colors[color]);
            final Dimension size = getPreferredSize();
            setSize(size.width, size.width);
        }

        public Label() {
            setText("privet medved");
//            setOpaque(true);
            setForeground(Color.BLUE);
            setFont(new Font("Verdana",Font.TRUETYPE_FONT, 20));
            final Dimension size = getPreferredSize();
            setSize(size.width, size.width);
        }

        @Override
        public void paintComponent(Graphics g) {
//            Graphics2D graphics2D = (Graphics2D) g;
//            AffineTransform aT = graphics2D.getTransform();

//            graphics2D.rotate(Math.toRadians(45),getWidth() / 2,getWidth() / 2);
            super.paintComponent(g);

//            graphics2D.setTransform(aT);
        }
    }
}
