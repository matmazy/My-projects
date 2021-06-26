using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MidnightCommander.Commands
{
    class Copy
    {
        public Component Window { get; set; }
        int Level = 0;
        public Copy(Component window)
        {
            this.Window = window;
        }
        public void Run(string sourDir, string destDir)
        {
            Level++;
            DirectoryInfo dir = new DirectoryInfo(sourDir);
            bool subDirs = true;

            DirectoryInfo[] dirs = dir.GetDirectories();

            if (Level == 1)
            {
                string s = sourDir;
                int i = s.LastIndexOf(@"\");
                s = s.Substring(i);
                destDir = destDir + s;
            }

            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }


            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = destDir + @"\" + file.Name;
                file.CopyTo(temppath, false);
            }


            if (subDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = destDir + "\\" + subdir.Name;
                    Run(subdir.FullName, temppath);
                    Level--;
                }

            }
        }
    }
}
