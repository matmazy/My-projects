using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander
{
    public class Item
    {
        public string Value { get; set; }

        public int Width { get; set; }        

        public void Draw()
        {
            Console.Write(this.Value);
        }
    }
}
