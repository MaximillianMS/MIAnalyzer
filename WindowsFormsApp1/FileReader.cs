using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MIAnalyzer
{
    public static class FileReader
    {
        public static List<string> ReadFile(string path)
        {
            var res = new List<string>();
            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    while(!sr.EndOfStream)
                    {
                        res.Add(sr.ReadLine());
                    }
                }
            }
            return res;
        }
        public static List<DirectoryInfo> EnumerateSubFolders(string PathToFolders)
        {
            return Directory.EnumerateDirectories(PathToFolders).Select(i => new DirectoryInfo(i)).ToList();

        }
    }

}
