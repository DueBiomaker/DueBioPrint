using RepetierHost.extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RepetierHost.util
{
    public class FileUtils
    {
        public static string CreatePath(string basePath, params string[] subFolders)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("{0}", Clean(basePath));
            foreach(string folder in subFolders)
            {
                builder.AppendFormat("{0}{1}", Path.DirectorySeparatorChar, Clean(folder));
            }

            return builder.ToString();
        }

        private static string Clean(string subPath)
        {
            if (!subPath.IsNullOrEmpty() && subPath[0] == Path.DirectorySeparatorChar)
                subPath = subPath.Substring(1);
            if (!subPath.IsNullOrEmpty() && subPath[subPath.Length - 1] == Path.DirectorySeparatorChar)
                subPath = subPath.Substring(0, subPath.Length - 1);

            return subPath.Trim();
        }

        public static bool FilePathHasInvalidChars(string path)
        {

            return (!string.IsNullOrEmpty(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0);
        }
    }
}
