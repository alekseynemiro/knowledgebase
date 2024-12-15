using System.Runtime.InteropServices;

namespace KbyteForumThread16198
{

  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  struct WIN32_FIND_DATA
  {

    public uint dwFileAttributes;

    public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;

    public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;

    public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;

    public uint nFileSizeHigh;

    public uint nFileSizeLow;

    public uint dwReserved0;

    public uint dwReserved1;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
    public byte[] cFileName;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
    public byte[] cAlternateFileName;

  }

}