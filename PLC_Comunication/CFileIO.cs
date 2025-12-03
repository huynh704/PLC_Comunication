using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class CFileIO
{
    public static bool WriteLog(string filePath, string content)
    {
        try
        {
            StreamWriter streamWriter = new StreamWriter(filePath, true, Encoding.UTF8);
            streamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " - " + content);
            streamWriter.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public static bool SaveTextFile(string filePath, string content)
    {
        try
        {
            StreamWriter streamWriter = new StreamWriter(filePath, true, Encoding.UTF8);
            streamWriter.WriteLine(content);
            streamWriter.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public static bool SaveTextFile(string filePath, string[] content)
    {
        try
        {
            StreamWriter streamWriter = new StreamWriter(filePath, true, Encoding.UTF8);
            streamWriter.WriteLine(content);
            streamWriter.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
