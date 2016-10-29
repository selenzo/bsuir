import javax.imageio.ImageIO;
import javax.swing.*;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
public class Swn 
{
	String fileName;
	
	public Swn()
	{
		

		JPanel cB = new JPanel();	
		final JFileChooser files = new JFileChooser();
		files.setFileFilter( new PNGFileFilter());			
		Toolkit toolkit = Toolkit.getDefaultToolkit();
		Image image16 = toolkit.getImage("cleaner16.png");
		final Cursor c16 = toolkit.createCustomCursor(image16 , new Point(10,10), "Cleaner");	
		Image image = toolkit.getImage("cleaner32.png");
		final Cursor c32 = toolkit.createCustomCursor(image , new Point(4,4), "Cleaner");
		final JFrame frame = new JFrame  ("Graphic Editor");	
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true);
		frame.setLayout(new BorderLayout());
		ImageIcon penc =  new ImageIcon("Pencil.png");
		ImageIcon clean=  new ImageIcon("Erase.png");
		ImageIcon squar =  new ImageIcon("square.png");
		ImageIcon lin =  new ImageIcon("Line.png");	
		ImageIcon ellipsimg =  new ImageIcon("Ellips.png");			
		Box leftBox = Box.createVerticalBox();		
		JPanel tools = new JPanel();
		JPanel up = new JPanel();
		JPanel down = new JPanel();
		JPanel status = new JPanel();
		final JComboBox sizeOfEraser = new JComboBox();
		final PaintField drawing = new PaintField ();		
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
		JButton load = new  JButton("     Load        ");
		JButton cut = new  JButton("   Cut Rect   ");
		JButton copy = new  JButton("  Copy Rect ");
		JButton paste = new  JButton("     Paste      ");
		JButton save = new  JButton(" Save as...   ");
		JButton clear = new  JButton("     Clear       ");
		JButton cutShape = new  JButton("Copy Shape");
		//JButton viewColorChooser = new  JButton("   Set color  ");			
		final JToggleButton pencil = new JToggleButton (penc);
		final JToggleButton line = new JToggleButton (lin);
		final JToggleButton square = new JToggleButton (squar);
		final JToggleButton ellips = new JToggleButton (ellipsimg);
		final JToggleButton cleaner = new JToggleButton (clean);		
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
		
		frame.addComponentListener(new  ComponentAdapter() {
			public void componentResized(java.awt.event.ComponentEvent evt)
			{	
				 drawing.resizeField();				
			}
		});
		

		
		pencil.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  le)  
			{ 
				choosedTool.setText("Pencil.");	
				line.setSelected(false);
				square.setSelected(false);
				cleaner.setSelected(false);	
				ellips.setSelected(false);
				drawing.kindOfDraving = KindOfDraving.PENCIL;	
				drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
			}
		});

		line.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  le)  
			{ 
				choosedTool.setText("Line.");	
				pencil.setSelected(false);
				square.setSelected(false);
				cleaner.setSelected(false);
				ellips.setSelected(false);
				drawing.kindOfDraving = KindOfDraving.LINE;	
				drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));				
			}
		});
		
		square.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  le)  
			{ 
				choosedTool.setText("Sqare.");	
				line.setSelected(false);
				pencil.setSelected(false);
				cleaner.setSelected(false);	
				ellips.setSelected(false);
				drawing.kindOfDraving = KindOfDraving.SQARE;				
				drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
				
			}
		});
		
		ellips.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  le)  
			{
				choosedTool.setText("Ellips.");	
				line.setSelected(false);
				pencil.setSelected(false);
				cleaner.setSelected(false);	
				square.setSelected(false);	
				drawing.kindOfDraving = KindOfDraving.ELLIPS;				
				drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
				
			}
		});
		
		cleaner.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  le)  
			{ 
				choosedTool.setText("Cleaner.");	
				line.setSelected(false);
				ellips.setSelected(false);
				pencil.setSelected(false);
				square.setSelected(false);	
				if(sizeOfEraser.getSelectedItem() == "16px sqare")
				{	
					drawing.eraserH = 12;				
					drawing.setCursor (c16);
				}
				if(sizeOfEraser.getSelectedItem() == "32px sqare")
				{	
					drawing.eraserH = 24;
					drawing.setCursor (c32);
				}
				drawing.kindOfDraving = KindOfDraving.ERASER;
				
			}
		});
		
		sizeOfEraser.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  e)  
			{ 
				if(cleaner.isSelected() == true)
				{
					if(sizeOfEraser.getSelectedItem() == "16px sqare")
					{
						drawing.setCursor (c16);
						drawing.eraserH = 12;
					}
					if(sizeOfEraser.getSelectedItem() == "32px sqare")
					{
						drawing.setCursor (c32);
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
		choosedColor.addMouseListener(new MouseAdapter()   {   

	        public void mouseClicked(MouseEvent e)   
	        {   
	        	drawing.clr = JColorChooser.showDialog(frame, "Choose the color", Color.BLACK);
				choosedColor.setBackground(drawing.clr);
	        }   
	});
	
		
		
		
		clear.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  qw)  
			{ 
				drawing.clearPanel();				
			}
		});
		
		copy.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  qw)  
			{
				choosedTool.setText("Coping.");
				drawing.kindOfDraving = KindOfDraving.COPY;	
				drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));	
				
			}
		});
		
		
		cut.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  qw)  
			{
				choosedTool.setText("Cutting.");	
				drawing.kindOfDraving = KindOfDraving.CUT;	
				drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));	
			}
		});
		
		cutShape.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  qw)  
			{
				choosedTool.setText("Copping shape.");
				drawing.kindOfDraving = KindOfDraving.SHAPE;	
				drawing.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));	
			}
		});
		
		paste.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  qw)  
			{ 
				drawing.kindOfDraving = KindOfDraving.PASTE;
				drawing.setCursor(Cursor.getPredefinedCursor(Cursor.CROSSHAIR_CURSOR));	
			}
		});
		
		load.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  qw)  
			{ 				
				
				int result = files.showOpenDialog(null);
				if(result == JFileChooser.APPROVE_OPTION)
                {
                  try
                  {
                       fileName = files.getSelectedFile().getAbsolutePath();
                       File iF= new  File(fileName);                    
                       drawing.img = ImageIO.read(iF);                                  
                       drawing.setSize(drawing.img.getWidth(), drawing.img.getWidth());
                       drawing.repaint();
                  } 
                  catch (FileNotFoundException ex) 
                  {
                        JOptionPane.showMessageDialog(frame, "������ ����� �� ����������");
                  } 
                  catch (IOException ex) 
                  {
                        JOptionPane.showMessageDialog(frame, "���������� �����-������");
                  }
                  drawing.savePreviousImg();
                }
			}
		});	
		

		save.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent  qw)  
			{ 
				
				
				 try
				 {           
	                  // if(fileName==null)
	                  // {	                      
	                	   int result = files.showSaveDialog(null);
	                       if(result==JFileChooser.APPROVE_OPTION)
	                       {
	                           fileName = files.getSelectedFile().getAbsolutePath();
	                       }
	                       //  }       
	                   
	                        ImageIO.write(drawing.img, "png", new  File(fileName + ".png"));
	                  
	                  
	               }
	               catch(IOException ex)
	               {
	                  JOptionPane.showMessageDialog(frame, "������ �����-������");
	               } 
					
			}
		});	
		
	        
	

	}	
	
	
	public static void main(String[] args) 
	{
		SwingUtilities.invokeLater(new Runnable(){
			public void run()
			{
				new Swn();
			}
	});
	}
	}


