using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MIAnalyzer
{
    class FolderIndexer
    {
        public enum ScanResult { Scanned, NotScanned }
        List<DirectoryInfo> FolderList;
        public ScanResult ScanSubFolder(DirectoryInfo folder)
        {
            foreach(var f in FolderList )
            {
                if (f.Name == folder.Name)
                    return ScanResult.Scanned;
            }
            return ScanResult.NotScanned;
        }
        public void LoadScannedSubFolders(List<DirectoryInfo> list)
        {
            this.FolderList = list;
        }
    }
}
