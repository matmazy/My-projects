using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander
{
    public abstract class Component
    {
        public abstract void Draw(int x, int y);
        public abstract void HandleKey(ConsoleKeyInfo info);

        public abstract void Reload(string path);
        

        public string Path { get; set; } = @"";
        public bool Active { get; set; } = false;
    }
}
