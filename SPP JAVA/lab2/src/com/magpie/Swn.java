package com.magpie;

/**
 * Created by Antonio on 29.10.2016.
 */

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.filechooser.FileFilter;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;
import java.util.ArrayList;

public class Swn {
    String fileName;

    public Swn() {

        JPanel cB = new JPanel();
        final JFileChooser files = new JFileChooser();
        files.setFileFilter(new PNGFileFilter());
        Toolkit toolkit = Toolkit.getDefaultToolkit();
        Image image16 = toolkit.getImage("cleaner16.png");
        final Cursor c16 = toolkit.createCustomCursor(image16, new Point(10, 10), "Cleaner");
        Image image = toolkit.getImage("cleaner32.png");
        final Cursor c32 = toolkit.createCustomCursor(image, new Point(4, 4), "Cleaner");
        final JFrame frame = new JFrame("Graphic Editor");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);
        frame.setLayout(new BorderLayout());
        ImageIcon penc = new ImageIcon("Pencil.png");
        ImageIcon clean = new ImageIcon("Erase.png");
        ImageIcon squar = new ImageIcon("square.png");
        ImageIcon lin = new ImageIcon("Line.png");
        ImageIcon ellipsimg = new ImageIcon("Ellips.png");
        Box leftBox = Box.createVerticalBox();
        JPanel tools = new JPanel();
        JPanel up = new JPanel();
        JPanel down = new JPanel();
        JPanel status = new JPanel();
        final JComboBox sizeOfEraser = new JComboBox();
        final PaintField drawing = new PaintField();
        final JScrollPane scrollDrawing = new JScrollPane(drawing);
        scrollDrawing.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
        scrollDrawing.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
        final JLabel lb = new JLabel("Tool:");
        JLabel lb1 = new JLabel("Color:");
        final JLabel choosedTool = new JLabel("None.");
        final JLabel choosedColor = new JLabel("             ");
        choosedColor.setOpaque(true);
        choosedColor.setBorder(BorderFactory.createLoweredBevelBorder());
        choosedColor.setBackground(Color.BLACK);
        JButton load = new JButton("     Load        ");
        JButton cut = new JButton("   Cut Rect   ");
        JButton copy = new JButton("  Copy Rect ");
        JButton paste = new JButton("     Paste      ");
        JButton save = new JButton(" Save as...   ");
        JButton clear = new JButton("     Clear       ");
        JButton cutShape = new JButton("Copy Shape");
        //JButton viewColorChooser = new  JButton("   Set color  ");
        final JToggleButton pencil = new JToggleButton(penc);
        final JToggleButton line = new JToggleButton(lin);
        final JToggleButton square = new JToggleButton(squar);
        final JToggleButton ellips = new JToggleButton(ellipsimg);
        final JToggleButton cleaner = new JToggleButton(clean);
        sizeOfEraser.addItem("16px sqare");
        sizeOfEraser.addItem("32px sqare");
        //viewColorChooser.setBackground(Color.WHITE);
        cleaner.setBackground(Color.WHITE);
        pencil.setBackground(Color.WHITE);
        clear.setBackground(Color.WHITE);
        line.setBackground(Color.WHITE);
        square.setBackground(Color.WHITE);
        cut.setBackground(Color.WHITE);
        save.setBackground(Color.WHITE);
        load.setBackground(Color.WHITE);
        copy.setBackground(Color.WHITE);
        paste.setBackground(Color.WHITE);
        ellips.setBackground(Color.WHITE);
        cutShape.setBackground(Color.WHITE);
        cB.add(sizeOfEraser);
        leftBox.add(load);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(save);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(clear);
        leftBox.add(Box.createVerticalStrut(5));
        //leftBox.add(viewColorChooser);
        //leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(copy);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(cut);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(cutShape);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(paste);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(pencil);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(line);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(square);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(ellips);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(cleaner);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(cB);
        leftBox.add(Box.createVerticalStrut(5));
        leftBox.add(Box.createVerticalGlue());
        tools.add(leftBox);
        status.add(lb);
        status.add(choosedTool);
        status.add(lb1);
        status.add(choosedColor);
        frame.add(tools, BorderLayout.WEST);
        frame.add(up, BorderLayout.EAST);
        frame.add(scrollDrawing, BorderLayout.CENTER);
        //frame.add(drawing, BorderLayout.CENTER);
        frame.add(status, BorderLayout.NORTH);
        frame.add(down, BorderLayout.SOUTH);
        frame.pack();
        frame.setSize(800, 700);

        frame.addComponentListener(new ComponentAdapter() {
            public void componentResized(java.awt.event.ComponentEvent evt) {
                drawing.resizeField();
            }
        });


        pencil.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent le) {
                choosedTool.setText("Pencil.");
                line.setSelected(false);
                square.setSelected(false);
                cleaner.setSelected(false);
                ellips.setSelected(false);
                drawing.kindOfDraving = KindOfDraving.PENCIL;
                drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
            }
        });

        line.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent le) {
                choosedTool.setText("Line.");
                pencil.setSelected(false);
                square.setSelected(false);
                cleaner.setSelected(false);
                ellips.setSelected(false);
                drawing.kindOfDraving = KindOfDraving.LINE;
                drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
            }
        });

        square.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent le) {
                choosedTool.setText("Sqare.");
                line.setSelected(false);
                pencil.setSelected(false);
                cleaner.setSelected(false);
                ellips.setSelected(false);
                drawing.kindOfDraving = KindOfDraving.SQARE;
                drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));

            }
        });

        ellips.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent le) {
                choosedTool.setText("Ellips.");
                line.setSelected(false);
                pencil.setSelected(false);
                cleaner.setSelected(false);
                square.setSelected(false);
                drawing.kindOfDraving = KindOfDraving.ELLIPS;
                drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));

            }
        });

        cleaner.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent le) {
                choosedTool.setText("Cleaner.");
                line.setSelected(false);
                ellips.setSelected(false);
                pencil.setSelected(false);
                square.setSelected(false);
                if (sizeOfEraser.getSelectedItem() == "16px sqare") {
                    drawing.eraserH = 12;
                    drawing.setCursor(c16);
                }
                if (sizeOfEraser.getSelectedItem() == "32px sqare") {
                    drawing.eraserH = 24;
                    drawing.setCursor(c32);
                }
                drawing.kindOfDraving = KindOfDraving.ERASER;

            }
        });

        sizeOfEraser.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                if (cleaner.isSelected() == true) {
                    if (sizeOfEraser.getSelectedItem() == "16px sqare") {
                        drawing.setCursor(c16);
                        drawing.eraserH = 12;
                    }
                    if (sizeOfEraser.getSelectedItem() == "32px sqare") {
                        drawing.setCursor(c32);
                        drawing.eraserH = 24;
                    }

                }
            }
        });


	/*	viewColorChooser.addActionListener(new ActionListener()
        {
			public void actionPerformed(ActionEvent  qw)
			{
				drawing.clr = JColorChooser.showDialog(frame, "Choose the color", Color.BLACK);
				choosedColor.setBackground(drawing.clr);
			}
		});*/
        choosedColor.addMouseListener(new MouseAdapter() {

            public void mouseClicked(MouseEvent e) {
                drawing.clr = JColorChooser.showDialog(frame, "Choose the color", Color.BLACK);
                choosedColor.setBackground(drawing.clr);
            }
        });


        clear.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent qw) {
                drawing.clearPanel();
            }
        });

        copy.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent qw) {
                choosedTool.setText("Coping.");
                drawing.kindOfDraving = KindOfDraving.COPY;
                drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));

            }
        });


        cut.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent qw) {
                choosedTool.setText("Cutting.");
                drawing.kindOfDraving = KindOfDraving.CUT;
                drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
            }
        });

        cutShape.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent qw) {
                choosedTool.setText("Copping shape.");
                drawing.kindOfDraving = KindOfDraving.SHAPE;
                drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
            }
        });

        paste.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent qw) {
                drawing.kindOfDraving = KindOfDraving.PASTE;
                drawing.setCursor(Cursor.getPredefinedCursor(Cursor.CROSSHAIR_CURSOR));
            }
        });

        load.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent qw) {

                int result = files.showOpenDialog(null);
                if (result == JFileChooser.APPROVE_OPTION) {
                    try {
                        fileName = files.getSelectedFile().getAbsolutePath();
                        File iF = new File(fileName);
                        drawing.img = ImageIO.read(iF);
                        drawing.setSize(drawing.img.getWidth(), drawing.img.getWidth());
                        drawing.repaint();
                    } catch (FileNotFoundException ex) {
                        JOptionPane.showMessageDialog(frame, "пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ");
                    } catch (IOException ex) {
                        JOptionPane.showMessageDialog(frame, "пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ-пїЅпїЅпїЅпїЅпїЅпїЅ");
                    }
                    drawing.savePreviousImg();
                }
            }
        });


        save.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent qw) {


                try {
                    // if(fileName==null)
                    // {
                    int result = files.showSaveDialog(null);
                    if (result == JFileChooser.APPROVE_OPTION) {
                        fileName = files.getSelectedFile().getAbsolutePath();
                    }
                    //  }

                    ImageIO.write(drawing.img, "png", new File(fileName + ".png"));


                } catch (IOException ex) {
                    JOptionPane.showMessageDialog(frame, "пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ-пїЅпїЅпїЅпїЅпїЅпїЅ");
                }

            }
        });


    }


    public class PNGFileFilter extends FileFilter {


        public boolean accept(File file) {
            if (file.getName().endsWith(".png")) return true;
            if (file.isDirectory()) return true;
            return false;
        }


        public String getDescription() {
            return null;
        }

    }


    public class PaintField extends JPanel implements MouseListener, MouseMotionListener, MouseWheelListener {
        boolean[] stateOfSize;

        int z_width = 0;
        int z_height = 0;
        int xn, xf, yn, yf, eraserH;
        ArrayList<Integer> polX, polY;
        int[] polCopyX;
        int[] polCopyY;
        boolean polBorderDraw;
        int copyPolX, copyPolY;
        Color clr;
        BufferedImage img, copyShape, state, pasteWithBorder;
        KindOfDraving kindOfDraving;
        Image cropimg;
        int zoom = 0;

        final  float dash1[] = {7.0f};
        final  BasicStroke dashed = new BasicStroke(1.0f, BasicStroke.CAP_BUTT, BasicStroke.JOIN_MITER,
                10.0f, dash1, 0.0f);

        public PaintField() {
            polX = new ArrayList<Integer>();
            polY = new ArrayList<Integer>();
            clr = Color.BLACK;
            addMouseListener(this);
            addMouseMotionListener(this);
            this.addMouseWheelListener(this);
            this.setOpaque(true);
            this.setBorder(BorderFactory.createLoweredBevelBorder());
            this.setBackground(Color.WHITE);
            stateOfSize = new boolean[3];
            stateOfSize[0] = false;
            stateOfSize[1] = true;
            stateOfSize[2] = false;
            kindOfDraving = KindOfDraving.NONE;
        }

        ;

        public void savePreviousImg() {
            state = new BufferedImage(PaintField.this.getWidth(), PaintField.this.getHeight(), BufferedImage.TYPE_INT_RGB);
            Graphics g = state.getGraphics();
            g.drawImage(img, 0, 0, null);
        }


        public void loadPreviousState() {
            Graphics g = img.getGraphics();
            g.drawImage(state, 0, 0, PaintField.this);
        }

        public void resizeField() {

            BufferedImage copy = new BufferedImage(this.getWidth(), this.getHeight(), BufferedImage.TYPE_INT_RGB);
            copy = this.img;
            this.setPreferredSize(new Dimension(this.getWidth(), this.getHeight()));
            this.img = new BufferedImage(this.getWidth(), this.getHeight(), BufferedImage.TYPE_INT_RGB);
            Graphics2D d2 = (Graphics2D) this.img.createGraphics();
            d2.setColor(Color.white);
            d2.fillRect(0, 0, this.getWidth(), this.getHeight());
            d2.drawImage(copy, null, 0, 0);
            this.loadPreviousState();
            this.savePreviousImg();
        }


        protected void paintComponent(Graphics g) {
            if (img == null) {
                img = new BufferedImage(this.getWidth(), this.getHeight(), BufferedImage.TYPE_INT_RGB);
                Graphics2D d2 = (Graphics2D) img.createGraphics();
                d2.setColor(Color.white);
                d2.fillRect(0, 0, PaintField.this.getWidth(), this.getHeight());

            }
            super.paintComponent(g);
            g.drawImage(img, 0, 0, this);
        }

        public void clearPanel() {
            Graphics g = img.getGraphics();
            g.setColor(this.getBackground());
            g.fillRect(0, 0, this.getWidth(), this.getHeight());
            this.repaint();
            this.savePreviousImg();
        }


        public void resizeImage(int width, int height) {
            this.loadPreviousState();
            this.setSize(width, height);
            this.setPreferredSize(new Dimension(width, height));
            Image resizing = img.getScaledInstance(width, height, BufferedImage.SCALE_DEFAULT);
            img = new BufferedImage(width, height, BufferedImage.TYPE_INT_RGB);
            Graphics g = img.getGraphics();
            g.drawImage(resizing, 0, 0, this);
            this.repaint();
        }


        public void copyPart(int x1, int y1, int h, int w) {
            polX.add(x1);
            polY.add(y1);
            polX.add(x1 + h);
            polY.add(y1);
            polX.add(x1 + h);
            polY.add(y1 + w);
            polX.add(x1);
            polY.add(y1 + w);
            copyDefaultShape();
        }

        public void cutPart(int x1, int y1, int h, int w) {
            this.loadPreviousState();
            copyPart(x1, y1, h, w);
            this.loadPreviousState();
            Polygon mys = new Polygon();
            for (int i = 0; i < polCopyX.length; i++) {
                mys.addPoint(polCopyX[i], polCopyY[i]);
            }
            Graphics g1 = img.getGraphics();
            g1.fillPolygon(mys);
            this.savePreviousImg();
        }

        public void mousePressed(MouseEvent em) {
            if (state == null) this.savePreviousImg();
            xn = em.getX();
            yn = em.getY();
        }

        public void copyDefaultShape() {
            copyShape = new BufferedImage(PaintField.this.getWidth(), PaintField.this.getHeight(), BufferedImage.TYPE_INT_RGB);
            Graphics g = copyShape.getGraphics();
            g.drawImage(img, 0, 0, null);

            polCopyX = new int[polX.size()];
            polCopyY = new int[polY.size()];

            for (int i = 0; i < polX.size(); i++) {
                polCopyX[i] = polX.get(i);
                polCopyY[i] = polY.get(i);
            }
            Polygon mys = new Polygon(polCopyX, polCopyY, polCopyX.length);
            Graphics g1 = img.getGraphics();
            g1.setColor(Color.BLUE);
            ((Graphics2D) g1).setStroke(dashed);
            g1.drawPolygon(mys);

            copyPolX = mys.getBounds().x;
            copyPolY = mys.getBounds().y;

            polX.clear();
            polY.clear();
        }

        public void pasteDefaulShape(int x, int y) {

            int dx, dy;
            dx = x - copyPolX;
            dy = y - copyPolY;

            Polygon mys = new Polygon();
            for (int i = 0; i < polCopyX.length; i++) {
                mys.addPoint(polCopyX[i] + dx, polCopyY[i] + dy);
            }

            Graphics g1 = img.getGraphics();
            g1.setClip(mys);
            g1.drawImage(copyShape, dx, dy, PaintField.this);
            //g1 = img.getGraphics();
            if (polBorderDraw) {
                g1.setClip(0, 0, img.getWidth(), img.getHeight());
                g1.setColor(Color.BLUE);
                ((Graphics2D) g1).setStroke(dashed);
                g1.drawPolygon(mys);
            }
            this.repaint();
        }


        public void mouseDragged(MouseEvent em) {

            Graphics g = img.getGraphics();
            g.setColor(this.clr);
            if (kindOfDraving != KindOfDraving.SHAPE) this.loadPreviousState();
            switch (kindOfDraving) {

                case PENCIL:
                    g.drawLine(xn, yn, em.getX(), em.getY());
                    this.repaint();
                    xn = em.getX();
                    yn = em.getY();
                    this.savePreviousImg();
                    break;
                case LINE:
                    Graphics k = img.getGraphics();
                    k.setColor(this.clr);
                    xf = em.getX();
                    yf = em.getY();
                    k.drawLine(xn, yn, xf, yf);
                    break;
                case SQARE:
                    xf = em.getX();
                    yf = em.getY();
                    g.drawRect(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf - xn), Math.abs(yf - yn));
                    break;
                case ERASER:
                    xf = em.getX();
                    yf = em.getY();
                    g.setColor(Color.white);
                    g.fillRect(xf, yf, this.eraserH, this.eraserH);
                    this.savePreviousImg();
                    break;
                case COPY:
                    Graphics2D g2 = (Graphics2D) g;
                    g2.setStroke(dashed);
                    g2.setColor(Color.BLUE);
                    xf = em.getX();
                    yf = em.getY();
                    g2.drawRect(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf - xn), Math.abs(yf - yn));
                    break;
                case PASTE:
                    xf = em.getX();
                    yf = em.getY();
                    polBorderDraw = true;
                    this.pasteDefaulShape(xf, yf);
                    break;
                case ELLIPS:
                    xf = em.getX();
                    yf = em.getY();
                    g.drawOval(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf - xn), Math.abs(yf - yn));
                    break;
                case CUT:
                    Graphics2D g22 = (Graphics2D) g;
                    g22.setStroke(dashed);
                    g22.setColor(Color.BLACK);
                    xf = em.getX();
                    yf = em.getY();
                    g22.drawRect(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf - xn), Math.abs(yf - yn));
                    break;
                case SHAPE:
                    polX.add(em.getX());
                    polY.add(em.getY());
                    g.setColor(Color.BLUE);
                    g.drawLine(xn, yn, em.getX(), em.getY());
                    this.repaint();
                    xn = em.getX();
                    yn = em.getY();
                    break;
                case NONE:
                    break;
            }
            this.repaint();
        }

        public void mouseMoved(MouseEvent em) {


        }


        public void mouseClicked(MouseEvent em) {
            this.loadPreviousState();
            Graphics g = img.getGraphics();
            if (kindOfDraving == KindOfDraving.ERASER) {
                xf = em.getX();
                yf = em.getY();
                g.setColor(Color.white);
                g.fillRect(xf, yf, this.eraserH, this.eraserH);
                this.savePreviousImg();
                this.repaint();
            }
        }


        public void mouseEntered(MouseEvent em) {


        }


        public void mouseExited(MouseEvent em) {


        }

        public void mouseReleased(MouseEvent em) {
            this.loadPreviousState();
            xf = em.getX();
            yf = em.getY();
            Graphics g = img.getGraphics();
            g.setColor(this.clr);
            switch (kindOfDraving) {
                case LINE:
                    g.drawLine(xn, yn, xf, yf);
                    this.savePreviousImg();
                    break;
                case SQARE:
                    g.fillRect(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf - xn), Math.abs(yf - yn));
                    this.savePreviousImg();
                    break;
                case COPY:
                    Graphics2D g2 = (Graphics2D) g;
                    g2.setStroke(dashed);
                    g2.setColor(Color.BLACK);
                    this.copyPart(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xn - xf), Math.abs(yn - yf));
                    break;
                case PASTE:
                    xf = em.getX();
                    yf = em.getY();
                    polBorderDraw = false;
                    this.pasteDefaulShape(xf, yf);
                    this.savePreviousImg();
                    break;
                case ELLIPS:
                    g.drawOval(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf - xn), Math.abs(yf - yn));
                    this.savePreviousImg();
                    break;
                case CUT:
                    Graphics2D g22 = (Graphics2D) g;
                    g22.setStroke(dashed);
                    g22.setColor(Color.BLUE);
                    this.cutPart(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xn - xf), Math.abs(yn - yf));
                    g22.drawRect(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf - xn), Math.abs(yf - yn));
                    break;
                case SHAPE:
                    this.savePreviousImg();
                    copyDefaultShape();
                    break;
                case NONE:
                    break;
            }

            this.repaint();
        }


        public void mouseWheelMoved(MouseWheelEvent me) {
            if (z_width == 0)
                z_width = this.getWidth();
            if (z_height == 0)
                z_height = this.getHeight();


            if (me.getWheelRotation() > 0) {
                if (stateOfSize[1]) {
                    this.resizeImage(2 * z_width, 2 * z_height);
                    stateOfSize[1] = false;
                    stateOfSize[2] = true;
                } else if (stateOfSize[0]) {
                    this.resizeImage(z_width, z_height);
                    this.resizeImage(z_width, z_height);
                    stateOfSize[0] = false;
                    stateOfSize[1] = true;
                }
            }

            if (me.getWheelRotation() < 0) {
                if (stateOfSize[2]) {
                    this.resizeImage(z_width, z_height);
                    this.resizeImage(z_width, z_height);
                    stateOfSize[2] = false;
                    stateOfSize[1] = true;
                } else if (stateOfSize[1]) {
                    this.resizeImage((int) (z_width / 2), (int) (z_height / 2));
                    stateOfSize[1] = false;
                    stateOfSize[0] = true;
                }
            }
        }


    }
    enum KindOfDraving  {PENCIL, LINE, SQARE, ELLIPS, ERASER, COPY, CUT, PASTE, SHAPE, NONE}

}


