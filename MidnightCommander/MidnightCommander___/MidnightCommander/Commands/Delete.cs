using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.Commands
{
    public class Delete
    {
        public Component Window { get; set; }

        public Delete(Component window)
        {
            this.Window = window;
        }
        public void DeleteFolder(string ToDelete)
        {
            Directory.Delete(ToDelete, true);
        }

        public void DeleteFile(string ToDelete)
        {
            File.Delete(ToDelete);
        }
    }
}
