using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Collections;

/// <summary>
/// FIO의 요약 설명입니다.
/// </summary>
namespace RFC
{
    public class myReverserClass : IComparer
    {
        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(y, x));
        }
    }
   

    public class FIO : IComparer
    {
        public FIO()
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //
        }
        public int Compare(object x, object y)
        {
            FileSystemInfo fs1 = (FileSystemInfo)x;
            FileSystemInfo fs2 = (FileSystemInfo)y;
            return fs1.LastWriteTime.CompareTo(fs2.LastWriteTime);
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
        public static string FileSystemList(string _root, string _path, string _refreshPath)
        {
            StringBuilder sb = new StringBuilder(1024);
            DirectoryInfo dif = new DirectoryInfo(_root);
            sb.Append("[");
            FileSystemInfo[] arrdi = dif.GetFileSystemInfos();
            FIO at = new FIO();
            Array.Sort(arrdi, at);
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
                    sb.Append(string.Format("{0}/{1}", _path, arrdi[i].Name));
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
    }
}
