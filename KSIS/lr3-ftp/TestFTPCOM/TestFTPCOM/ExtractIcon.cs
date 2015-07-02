using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/// <summary>
/// Summary description for ExtractIcon.
/// </summary>
public class ExtractIcon
{
    [DllImport("Shell32.dll")]
    private static extern IntPtr SHGetFileInfo
        (
        string pszPath,
        uint dwFileAttributes,
        out SHFILEINFO psfi,
        uint cbfileInfo,
        SHGFI uFlags
        );

    [DllImport("comctl32.dll")]
    private static extern int ImageList_GetImageCount(
        IntPtr himl
        );

    [DllImport("comctl32.dll")]
    private static extern IntPtr ImageList_GetIcon(
        IntPtr himl,
        int i,
        uint flags
        );

    [StructLayout(LayoutKind.Sequential)]
    private struct SHFILEINFO
    {
        public SHFILEINFO(bool b)
        {
            hIcon = IntPtr.Zero; iIcon = 0; dwAttributes = 0; szDisplayName = ""; szTypeName = "";
        }

        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;

        [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
        public string szDisplayName;

        [MarshalAs(UnmanagedType.LPStr, SizeConst = 80)]
        public string szTypeName;
    };

    private ExtractIcon()
    {
    }

    private enum SHGFI
    {
        SHGFI_ICON = 0x000000100,     // get icon
        SHGFI_DISPLAYNAME = 0x000000200,     // get display name
        SHGFI_TYPENAME = 0x000000400,     // get type name
        SHGFI_ATTRIBUTES = 0x000000800,     // get attributes
        SHGFI_ICONLOCATION = 0x000001000,     // get icon location
        SHGFI_EXETYPE = 0x000002000,     // return exe type
        SHGFI_SYSICONINDEX = 0x000004000,     // get system icon index
        SHGFI_LINKOVERLAY = 0x000008000,     // put a link overlay on icon
        SHGFI_SELECTED = 0x000010000,     // show icon in selected state
        SHGFI_ATTR_SPECIFIED = 0x000020000,     // get only specified attributes
        SHGFI_LARGEICON = 0x000000000,     // get large icon
        SHGFI_SMALLICON = 0x000000001,     // get small icon
        SHGFI_OPENICON = 0x000000002,     // get open icon
        SHGFI_SHELLICONSIZE = 0x000000004,     // get shell size icon
        SHGFI_PIDL = 0x000000008,     // pszPath is a pidl
        SHGFI_USEFILEATTRIBUTES = 0x000000010     // use passed dwFileAttribute
    }

    private enum SHIL
    {
        SHIL_LARGE = 0,   // normally 32x32
        SHIL_SMALL = 1,  // normally 16x16
        SHIL_EXTRALARGE = 2,
        SHIL_SYSSMALL = 3   // like SHIL_SMALL, but tracks system small icon metric correctly
    }

    /// <summary>
    /// Get the associated Icon for a file or application, this method always returns
    /// an icon.  If the strPath is invalid or there is no idonc the default icon is returned
    /// </summary>
    /// <param name="strPath">full path to the file</param>
    /// <param name="bSmall">if true, the 16x16 icon is returned otherwise the 32x32</param>
    /// <returns></returns>
    public static Icon GetIcon(string strPath, bool bSmall)
    {
        SHFILEINFO info = new SHFILEINFO(true);
        int cbFileInfo = Marshal.SizeOf(info);
        SHGFI flags;
        if (bSmall)
            flags = SHGFI.SHGFI_ICON | SHGFI.SHGFI_SMALLICON;
        else
            flags = SHGFI.SHGFI_ICON | SHGFI.SHGFI_SMALLICON | SHGFI.SHGFI_USEFILEATTRIBUTES;

        SHGetFileInfo(strPath, 256, out info, (uint)cbFileInfo, flags);
        return Icon.FromHandle(info.hIcon);
    }

    public static int GetIconIndex(string strPath, ImageList imgList)
    {
        SHFILEINFO info = new SHFILEINFO(true);
        int cbFileInfo = Marshal.SizeOf(info);
        SHGFI flags;
        IntPtr hIcon;

        flags = SHGFI.SHGFI_SYSICONINDEX | SHGFI.SHGFI_SMALLICON;

        IntPtr ret = SHGetFileInfo("c:\\", 256, out info, (uint)cbFileInfo, flags);
        int nbIcon = ImageList_GetImageCount(ret);

        for (int i = 0; i < nbIcon; i++)
        {
            hIcon = ImageList_GetIcon(ret, i, 0);
            imgList.Images.Add(Icon.FromHandle(hIcon));
        }

        return info.iIcon;
    }
}