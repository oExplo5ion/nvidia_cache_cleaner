using System;
using System.IO;
using System.Windows.Input;

namespace NVIDIA_Cleaner
{
    public static class Paths
    {
        // System folders
        public static string SystemPath
        {
            get
            {
                return Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            }
        }

        public static string AppData
        {
            get
            {
                string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Directory.GetParent(roaming).FullName;
            }
        }


        // Cache folders
        public static string NVCache
        {
            get
            {
                string programData = Path.Combine(SystemPath, "ProgramData");
                string nvidiaCorporation = Path.Combine(programData, "NVIDIA Corporation");
                return Path.Combine(nvidiaCorporation, "NV_Cache");
            }
        }

        public static string DCache
        {
            get
            {
                string local = Path.Combine(AppData, "Local");
                string dCache = Path.Combine(local, "D3DSCache");
                return dCache;
            }
        }

        public static string GlCache
        {
            get 
            {
                string local = Path.Combine(AppData, "Local");
                string nvidia = Path.Combine(local, "NVIDIA");
                return Path.Combine(nvidia, "GLCache");
            }
        }

        public static string Temp
        {
            get
            {
                string local = Path.Combine(AppData, "Local");
                return Path.Combine(local, "Temp");
            }
        }
    }
}
