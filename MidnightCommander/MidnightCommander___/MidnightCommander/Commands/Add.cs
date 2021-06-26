using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.Commands
{
    public class Add
    {
        public Component Window { get; set; }

        public Add(Component window)
        {
            this.Window = window;
        }
        public void CreateFolder(string newfolder, string path)
        {            
            string pathString = path + @"\" + newfolder;
            System.IO.Directory.CreateDirectory(pathString);
        }
        public void CreateFile(string newfile, string path)
        {
            string pathString = path + @"\" + newfile;
            System.IO.File.Create(pathString).Close();
        }
    }
}
