package com.magpie;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;
import java.awt.geom.AffineTransform;
import java.util.Random;

/**
 * Created by Antonio on 29.10.2016.
 */
public class Task10 extends JComponent {
    private int x = 0;
    private int y = 0;
    private int rad = 0;
    public int dx = 2;
    private boolean t = false;
    Random random = new Random();
    Label label = new Label();


    public Task10() {
        Timer timer = new Timer(30, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                t = true;
                repaint();
//                System.out.println(getBounds());
            }
        });

        JComboBox jComboBox = new JComboBox();
        jComboBox.addItem("Verdana");
        jComboBox.addItem("Courier New");
        jComboBox.addItem("Arial");
        jComboBox.setLocation(300,20);
        jComboBox.setSize(100, 20);
        jComboBox.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                label.Cnahge(jComboBox.getSelectedItem().toString());
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
            label.setLocation(x, y);
            Graphics2D graphics2D = (Graphics2D) g;
            graphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
            t = false;
        }
    }

    public class Label extends JLabel {

        public void Cnahge(String font) {
            String str = "";
            String tmp = getText().toString();
            for (int i = 0; i < tmp.length(); i++) {
                if(random.nextInt() % 2 == 0) {
                    str += tmp.substring(i,i+1).toUpperCase();
                } else {
                    str += tmp.substring(i,i +1).toLowerCase();
                }
                System.out.println(tmp);
            }
            setText(str);
            setFont(new Font(font,Font.TRUETYPE_FONT, 20));
            final Dimension size = getPreferredSize();
            setSize(size.width, size.width);
        }

        public Label() {
            setText("privet medved");
            setFont(new Font("Verdana",Font.TRUETYPE_FONT, 20));
            final Dimension size = getPreferredSize();
            setSize(size.width, size.width);
        }

        @Override
        public void paintComponent(Graphics g) {
            Graphics2D graphics2D = (Graphics2D) g;
            AffineTransform aT = graphics2D.getTransform();

            graphics2D.rotate(Math.toRadians(45),getWidth() / 2,getWidth() / 2);
            super.paintComponent(g);

            graphics2D.setTransform(aT);
        }
    }

}

