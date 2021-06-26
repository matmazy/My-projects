using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander.Components
{
    public class HelpWindow : Component
    {
        public List<HelpText> Row = new List<HelpText>();


        public HelpWindow()
        {
            HelpText f1 = new HelpText();
            f1.Text = "Vytvořit Složku  F1";
            this.Row.Add(f1);

            HelpText f2 = new HelpText();
            f2.Text = "Odstranit Složku  F2";
            this.Row.Add(f2);

            HelpText f3 = new HelpText();
            f3.Text = "Vytvořit soubor  F3";
            this.Row.Add(f3);

            HelpText f4 = new HelpText();
            f4.Text = "Odstranit soubor  F4";
            this.Row.Add(f4);

            HelpText f5 = new HelpText();
            f5.Text = "Kopírovat soubor  F5";
            this.Row.Add(f5);
        }

        public override void Draw(int x, int y)
        {           
            Console.SetCursorPosition(x, y);

            foreach (HelpText item in Row)
            {
                item.Draw(x, y);
                x += 30;
                Console.Write(" ");
            }
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
