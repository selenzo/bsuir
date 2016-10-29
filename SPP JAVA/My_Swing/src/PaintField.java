import javax.swing.*;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;
import java.util.ArrayList;


public class PaintField extends JPanel implements MouseListener,  MouseMotionListener, MouseWheelListener
{	
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
	
	final static float dash1[] = {7.0f};
    final static BasicStroke dashed = new BasicStroke(1.0f, BasicStroke.CAP_BUTT, BasicStroke.JOIN_MITER,
                        10.0f, dash1, 0.0f);	
	
public PaintField()
{	
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
};

	public void savePreviousImg()  
	{ 		
		state = new BufferedImage(PaintField.this.getWidth(), PaintField.this.getHeight(), BufferedImage.TYPE_INT_RGB);
		Graphics g = state.getGraphics();  
		g.drawImage(img, 0, 0, null);	
	}

	
	public void loadPreviousState()  
	{ 
		Graphics g = img.getGraphics();
		g.drawImage(state, 0, 0, PaintField.this);		
	}

	public void resizeField()  
	{ 
		 
		 BufferedImage copy = new BufferedImage(this.getWidth(), this.getHeight(), BufferedImage.TYPE_INT_RGB);
		 copy = this.img;
		 this.setPreferredSize(new Dimension (this.getWidth(),this.getHeight()));
		 this.img = new  BufferedImage(this.getWidth(), this.getHeight(), BufferedImage.TYPE_INT_RGB);
	     Graphics2D d2 = (Graphics2D) this.img.createGraphics();
	     d2.setColor(Color.white);
	     d2.fillRect(0, 0, this.getWidth(), this.getHeight());
	     d2.drawImage(copy, null, 0, 0);
	     this.loadPreviousState();
	     this.savePreviousImg();
	}
	
	
	protected void paintComponent(Graphics g) 
	{	
		if(img==null)
        {
            img = new  BufferedImage(this.getWidth(), this.getHeight(), BufferedImage.TYPE_INT_RGB);
            Graphics2D d2 = (Graphics2D) img.createGraphics();
            d2.setColor(Color.white);
            d2.fillRect(0, 0, PaintField.this.getWidth(), this.getHeight());

        }
		super.paintComponent(g); 
		g.drawImage(img, 0, 0,this);
	}
	
	public void clearPanel() 
	{
		Graphics g = img.getGraphics();
		g.setColor(this.getBackground());
		g.fillRect(0,0,this.getWidth(),this.getHeight());
		this.repaint();
		this.savePreviousImg();		
	}
	
	
	

	 public void resizeImage(int width, int height)
		{
		 	this.loadPreviousState();
		 	this.setSize(width, height);
		 	this.setPreferredSize(new Dimension (width, height));		    
		    Image resizing = img.getScaledInstance(width, height, BufferedImage.SCALE_DEFAULT);	
		    img = new  BufferedImage(width, height, BufferedImage.TYPE_INT_RGB);
			Graphics g = img.getGraphics();			
			g.drawImage(resizing, 0, 0,this);				
			this.repaint();				
		}
	 
	 

		 public void copyPart(int x1, int y1, int h, int w)
		{ 		
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
		 
		 public void cutPart(int x1, int y1, int h, int w)
			{	
			 	this.loadPreviousState();
			 	copyPart(x1, y1, h, w);			 	
			 	this.loadPreviousState();
			 	Polygon mys = new Polygon();
				for (int i = 0; i < polCopyX.length; i++) 				
				{
					mys.addPoint(polCopyX[i], polCopyY[i]);
				}
				Graphics g1 = img.getGraphics();
				g1.fillPolygon(mys);	
				this.savePreviousImg();
			}
	 
		 public void mousePressed(MouseEvent em) 
			{				 	
			 	if (state == null) this.savePreviousImg();
				xn = em.getX();
				yn = em.getY();				
			}
		 
		 public void copyDefaultShape() 
		 {
			copyShape = new BufferedImage(PaintField.this.getWidth(), PaintField.this.getHeight(), BufferedImage.TYPE_INT_RGB);
			Graphics g = copyShape.getGraphics(); 
			g.drawImage(img, 0, 0, null);			
			
			polCopyX = new int[polX.size()];
			polCopyY = new int[polY.size()];
			
			for (int i = 0; i < polX.size(); i++) 
			{
				polCopyX[i] = polX.get(i);
				polCopyY[i] = polY.get(i);
			}
			Polygon mys = new Polygon(polCopyX, polCopyY, polCopyX.length);
			Graphics g1 = img.getGraphics();
			g1.setColor(Color.BLUE);
			((Graphics2D)g1).setStroke(dashed);
			g1.drawPolygon(mys);
			
			copyPolX = mys.getBounds().x;
			copyPolY = mys.getBounds().y;
			
			polX.clear();
			polY.clear();
		 }
		 
		 public void pasteDefaulShape(int x, int y) 
		 {
			
			int dx, dy;
			dx = x - copyPolX;
			dy = y - copyPolY;
			
			Polygon mys = new Polygon();
			for (int i = 0; i < polCopyX.length; i++) 
			{
				mys.addPoint(polCopyX[i] + dx, polCopyY[i] + dy);
			}
			
			Graphics g1 = img.getGraphics();
			g1.setClip(mys);
			g1.drawImage(copyShape, dx, dy, PaintField.this);
			//g1 = img.getGraphics();
			if (polBorderDraw) 
			{
				g1.setClip(0, 0, img.getWidth(), img.getHeight());
				g1.setColor(Color.BLUE);
				((Graphics2D)g1).setStroke(dashed);
				g1.drawPolygon(mys);
			}
			this.repaint();	
		 }
		
		 

	public void mouseDragged(MouseEvent em) 
	{		
		
		Graphics g = img.getGraphics();       
	    g.setColor(this.clr);
	    if (kindOfDraving != KindOfDraving.SHAPE) this.loadPreviousState();
		switch (kindOfDraving)
			{
		
			case PENCIL:				
		        g.drawLine(xn, yn, em.getX(),em.getY());		       
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
				g.drawRect(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf-xn), Math.abs(yf-yn));						
				break;				
			case ERASER:
				xf = em.getX();
				yf = em.getY();
				g.setColor(Color.white);
				g.fillRect(xf, yf, this.eraserH, this.eraserH);
				this.savePreviousImg();						
				break;				
			case COPY:				
				Graphics2D g2 = (Graphics2D)g;
				g2.setStroke(dashed);
				g2.setColor(Color.BLUE);
				xf = em.getX();
				yf = em.getY();					
				g2.drawRect(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf-xn), Math.abs(yf-yn));							
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
				g.drawOval(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf-xn), Math.abs(yf-yn));								
				break;					
			case CUT:				
				Graphics2D g22 = (Graphics2D)g;
				g22.setStroke(dashed);
				g22.setColor(Color.BLACK);
				xf = em.getX();
				yf = em.getY();					
				g22.drawRect(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf-xn), Math.abs(yf-yn));							
				break;
			case SHAPE:					
				polX.add(em.getX());
				polY.add(em.getY());
				g.setColor(Color.BLUE);
				g.drawLine(xn, yn, em.getX(),em.getY());		       
		        this.repaint();
		        xn = em.getX();
				yn = em.getY();				
				break;			
			case NONE:				
				break;				
			}
			this.repaint();	
	}

	public void mouseMoved(MouseEvent em) 
	{			

		
	}

	
	public void mouseClicked(MouseEvent em) 
	{		
		this.loadPreviousState();
		Graphics g = img.getGraphics(); 		
		if (kindOfDraving == KindOfDraving.ERASER)
		{
			xf = em.getX();
			yf = em.getY();
			g.setColor(Color.white);
			g.fillRect(xf, yf, this.eraserH, this.eraserH);
			this.savePreviousImg();
			this.repaint();			
		}		
	}

	
	public void mouseEntered(MouseEvent em) 
	{	
		
		
	}

	
	public void mouseExited(MouseEvent em) 
	{
		
		
	}	

	public void mouseReleased(MouseEvent em) 
	{
		this.loadPreviousState();
		xf = em.getX();
		yf = em.getY();		
		Graphics g = img.getGraphics(); 
		g.setColor(this.clr);
		switch  (kindOfDraving)
		{			
			case LINE:				
		        g.drawLine(xn, yn, xf, yf);	
		        this.savePreviousImg();
				break;
			case SQARE:	
				g.fillRect(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf-xn), Math.abs(yf-yn));
				this.savePreviousImg();
				break;				
			case COPY:			
				Graphics2D g2 = (Graphics2D)g;
				g2.setStroke(dashed);
				g2.setColor(Color.BLACK);				
				this.copyPart(Math.min(xn , xf), Math.min(yn, yf), Math.abs(xn - xf), Math.abs(yn - yf));
		        break;		        
			case PASTE:	
				xf = em.getX();
				yf = em.getY();
				polBorderDraw = false;
				this.pasteDefaulShape(xf, yf);
				this.savePreviousImg();
		        break;		        
			case ELLIPS:	
				 g.drawOval(Math.min(xn, xf), Math.min(yn, yf), Math.abs(xf-xn), Math.abs(yf-yn));	
				 this.savePreviousImg();
		         break;		         
			case CUT:	
				Graphics2D g22 = (Graphics2D)g;
				g22.setStroke(dashed);
				g22.setColor(Color.BLUE);			
				this.cutPart(Math.min(xn , xf), Math.min(yn, yf), Math.abs(xn - xf), Math.abs(yn - yf));
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


	public void mouseWheelMoved(MouseWheelEvent me) 
	{  
		if (z_width == 0)
		z_width = this.getWidth();
		if (z_height == 0)
		z_height =  this.getHeight();		
		
		
			if(me.getWheelRotation() > 0)
			{
				if (stateOfSize[1]) 
				{
					this.resizeImage(2*z_width, 2*z_height);			
					stateOfSize[1] = false;
					stateOfSize[2] = true;
				}
				else 
					if (stateOfSize[0]) 
					{
						this.resizeImage(z_width, z_height);
						this.resizeImage(z_width, z_height); 
						stateOfSize[0] = false;
						stateOfSize[1] = true;
					}
			}	
			
			if(me.getWheelRotation() < 0)
			{
				if (stateOfSize[2])
				{
					this.resizeImage(z_width, z_height); 
					this.resizeImage(z_width, z_height); 
					stateOfSize[2] = false;
					stateOfSize[1] = true;
				} 
				else 
					if (stateOfSize[1])
					{
						this.resizeImage((int)(z_width / 2), (int)(z_height / 2)); 				 
						stateOfSize[1] = false;
						stateOfSize[0] = true;
					}
			}		
	}
	

}


