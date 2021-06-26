using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.Components
{
    public class HelpText : Component
    {       
        public string Text { get; set; }                

        public override void Draw(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(this.Text);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {
           
        }

        public override void Reload(string path)
        {
            throw new NotImplementedException();
        }
    }
}
