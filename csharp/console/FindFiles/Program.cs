using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace KbyteForumThread16198
{
  class Program
  {
    
    [DllImport("kernel32", CharSet = CharSet.Auto)]
    public static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

    [DllImport("kernel32", CharSet = CharSet.Auto)]
    public static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

    [DllImport("kernel32", CharSet = CharSet.Auto)]
    public static extern bool FindClose(IntPtr hFindFile);
    
    static void Main(string[] args)
    {
      // find first exe-file in directory
      WIN32_FIND_DATA fd;
      IntPtr h = FindFirstFile(@"C:\Windows\*.exe", out fd);
      Console.WriteLine("FindFirstFile: {0}", Encoding.Default.GetString(fd.cFileName));

      // find all exe-files with WinAPI
      WIN32_FIND_DATA fd2;

      while (FindNextFile(h, out fd2))
      {
        Console.WriteLine("FindNextFile: {0}", Encoding.Default.GetString(fd2.cFileName));
      }

      // recursive file search
      var startDir = new DirectoryInfo(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319");
      List<FileInfo> allFiles = new List<FileInfo>();

      GetFiles("*.exe", startDir, allFiles);

      // output files
      foreach (var file in allFiles)
      {
        Console.WriteLine(file.Name); // file.FullName
      }

      // compare files
      // сраниваем файлы
      if (CompareFiles(@"C:\Windows\System32\calc.exe", @"C:\Windows\System32\notepad.exe"))
      {
        Console.WriteLine("The files are identical!");
        // Console.WriteLine("Файлы одинаковые!");
      }

      Console.ReadKey();
    }

    /// <summary>
    /// Compares two files.
    /// </summary>
    private static bool CompareFiles(string filePath1, string filePath2)
    {
      var md5 = new MD5CryptoServiceProvider();

      byte[] file1Hash = md5.ComputeHash(File.Open(filePath1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
      byte[] file2Hash = md5.ComputeHash(File.Open(filePath2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

      string file1HashString = String.Join("", file1Hash.Select(b => b.ToString("x2")));
      string file2HashString = String.Join("", file2Hash.Select(b => b.ToString("x2")));

      return file1HashString.Equals(file2HashString);
    }

    /// <summary>
    /// Gets a list of all files.
    /// </summary>
    /// <param name="searchPattern">The search string to match against the names of files in <paramref name="currentDirectory"/>.</param>
    /// <param name="currentDirectory">Current directory.</param>
    /// <param name="allFiles">Search results.</param>
    private static void GetFiles(string searchPattern, DirectoryInfo currentDirectory, List<FileInfo> allFiles)
    {
      // get files
      // получаем и запоминаем все файлы в каталоге
      FileInfo[] files = currentDirectory.GetFiles(searchPattern);
      
      allFiles.AddRange(files);

      // get directories
      // получаем и перебираем вложенные каталоги
      DirectoryInfo[] childs = currentDirectory.GetDirectories();
      foreach (DirectoryInfo d in childs)
      {
        GetFiles(searchPattern, d, allFiles);
      }
    }

  }

}