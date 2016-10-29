
import java.io.File;
import javax.swing.filechooser.FileFilter;


public class PNGFileFilter extends FileFilter
{

	
	
	public boolean accept(File file)
	{
		if (file.getName().endsWith(".png")) return true;
		if (file.isDirectory()) return true;
		return false;		
	}


	public String getDescription() 
	{	
		return null;
	}

}
