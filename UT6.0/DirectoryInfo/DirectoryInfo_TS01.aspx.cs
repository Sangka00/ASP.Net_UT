using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Text;

public partial class DirectoryInfo_DirectoryInfo_TS01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn1_Click(object sender, EventArgs e)
    {
        // Directory 존재 확인
        DirectoryInfo di = new DirectoryInfo("z:\\temp\\");
        if (di.Exists) { Response.Write("Y"); }
        else { Response.Write("N"); }
    }



    protected void Btn2_Click(object sender, EventArgs e)
    {
        // Directory 생성
        string path = "z:\\sangkaTemp";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        
    }

    protected void Btn3_Click(object sender, EventArgs e)
    {
        // Directory Size
        string path = "z:\\sangkaTemp";
        Response.Write(DirectorySize(path, true));
    }
    /// <summary>  
    /// 디렉토리 사이즈(Byte)  
    /// KByte : / 1024  
    /// MByte : / ( 1024 * 1024 )  
    /// </summary>  
    /// <param name="dInfo">디렉토리</param>  
    /// <param name="includeSubDir">서브디렉토리포함유무</param>  
    /// <returns>사이즈(Byte)</returns>
    private long DirectorySize(string path, bool includeSubDir)
    {
        DirectoryInfo dInfo = new DirectoryInfo(path);
        long totalSize = dInfo.EnumerateFiles().Sum(file => file.Length);

        return DirectorySize(dInfo, includeSubDir);
    }

    
    public long DirectorySize(DirectoryInfo dInfo, bool includeSubDir)
    {
        long totalSize = dInfo.EnumerateFiles().Sum(file => file.Length);
        if (includeSubDir) totalSize += dInfo.EnumerateDirectories().Sum(dir => DirectorySize(dir, true));
        return totalSize;
    }

    protected void Btn4_Click(object sender, EventArgs e)
    {
        // Directory Copy
        CopyDirectory("z:\\temp", "z:\\atemp");
    }
    /// <summary>  
    /// 디렉토리 Copy  
    /// </summary>  
    /// <param name="sourcePath">원본 디렉토리 경로</param>  
    /// <param name="destinationPath">생성 디렉토리 경로</param>  
    public void CopyDirectory(string sourcePath, string destinationPath)
    {
        DirectoryInfo source = new DirectoryInfo(sourcePath);
        DirectoryInfo destination = new DirectoryInfo(destinationPath);
        CopyDirectory(source, destination);
    }
    /// <summary>  
    /// 디렉토리 Copy  
    /// </summary>  
    /// <param name="source">원본 디렉토리</param>  
    /// <param name="destination">생성 디렉토리</param>  
    public void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
    {
        CreateDirectory(destination);

        // Copy all files.  
        FileInfo[] files = source.GetFiles();
        foreach (FileInfo file in files)
        {
            file.CopyTo(Path.Combine(destination.FullName, file.Name));
        }

        // Process subdirectories.  
        DirectoryInfo[] dirs = source.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            // Get destination directory.  
            string destinationDir = Path.Combine(destination.FullName, dir.Name);
            CopyDirectory(dir, new DirectoryInfo(destinationDir)); // Call CopyDirectory() recursively.  
        }
    }
    public void CreateDirectory(DirectoryInfo dInfo)
    {
        if (!dInfo.Exists) dInfo.Create();
    }
    protected void Btn5_Click(object sender, EventArgs e)
    {
        //Diretory Sort : array.Reverse , array.Sort
        Response.Write(FileSystemList("Z:\\00.DAT", string.Empty, "aaa"));
    }
    protected string FileSystemList(string _root, string _path, string _refreshPath)
    {
        StringBuilder sb = new StringBuilder(1024);
        sb.Append("[");
        DirectoryInfo dif = new DirectoryInfo(_root);
        FileSystemInfo[] arrdi = dif.GetFileSystemInfos();
        Array.Reverse(arrdi);
        // Array.Sort(arrdi);


        string[] arrEP = _refreshPath.Split('/');
        int dataCount = 0;
        for (int i = 0; i < arrdi.Length; i++)
        {
            if (ExcludeList(arrdi[i].Name))
            {
                string Flag = arrdi[i].GetType().FullName == "System.IO.DirectoryInfo" ? "folder" : "file";
                if (dataCount != 0) sb.Append(@",");
                sb.Append(@"{""text"":""");
                sb.Append(arrdi[i].Name);
                sb.Append(@""",""classes"":""");
                sb.Append(Flag);
                sb.Append(@""",");
                sb.Append(@"""size"":""");
                if (Flag != "folder")
                {
                    FileInfo fi = (FileInfo)arrdi[i];
                    sb.Append(fi.Length);
                }
                sb.Append(@""",""date"":""");
                sb.Append(arrdi[i].LastWriteTime);
                sb.Append(@""",""id"":""");
                sb.Append(string.Format("{0}/{1}", "Z:\\00.DAT", arrdi[i].Name));
                sb.Append(@""",""hasChildren"":");
                int ChildrenCount = 0;
                if (Flag == "folder")
                {
                    DirectoryInfo dd = (DirectoryInfo)arrdi[i];
                    ChildrenCount = dd.GetDirectories().Length + dd.GetFiles().Length;
                }
                sb.Append(ChildrenCount > 0 ? "true" : "false");
                if (arrEP.Length > 1 && arrEP[1] == arrdi[i].Name)
                {
                    sb.Append(@",""expanded"":true");
                    sb.Append(@",""children"":");
                    sb.Append(FileSystemList(Path.Combine(dif.FullName, arrdi[i].Name), string.Format("{0}/{1}", _path, arrdi[i].Name), _refreshPath.Remove(0, arrdi[i].Name.Length + 1)));
                }
                else
                {
                    sb.Append(@",""expanded"":false");
                }
                sb.Append("}");
                dataCount++;


            }

        }
        sb.Append("]");
        return sb.ToString();
    }

    protected static bool ExcludeList(string _name)//제외 항목
    {
        bool result = true;
        switch (_name.ToUpper())
        {
            case "WEB.CONFIG": result = false; break;
            case "ASPNET_CLIENT": result = false; break;
            default: result = true; break;
        }
        return result;
    }

    protected void btn10_Click(object sender, EventArgs e)
    {
        FileInfo fi = new FileInfo("z:\\temp_12\\web.config");
        if (fi.Exists) { Response.Write("Y"); }
        else { Response.Write("N"); }
    }

    protected void Btn6_Click(object sender, EventArgs e)
    {
        DirectoryInfo di = new DirectoryInfo("/");
        Response.Write(Directory.GetCurrentDirectory().ToString());
    }
}