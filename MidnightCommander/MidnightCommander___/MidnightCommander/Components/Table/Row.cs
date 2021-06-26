using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MidnightCommander
{
    public class Row 
    {
        public bool ActiveRow { get; set; }

        public int ConsoleHalfWidth { get; set; } = Console.WindowWidth / 2;

        public const string PATH = @"C:\";
        
        public List<Item> items = new List<Item>();
        
        DirectoryInfo dir = new DirectoryInfo(PATH);
       
        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Add(Item item)
        {            
            this.items.Add(item);
        }

        public  void Draw()
        {           
            int i = 0;            
            foreach (Item item in this.items)
            {
                Console.Write("│");

                if(i == 0)
                {
                    string tmp = "";
                    char[] chars = item.Value.ToCharArray();
                    if(chars.Length < 30)
                    {
                        Console.Write(item.Value.PadRight(30 - item.Width, ' '));
                    }
                    else
                    {
                        for (int x = 0; x < 29; x++)
                        {
                            tmp += chars[x];
                        }
                        Console.Write(tmp.PadRight(30 - item.Width, ' '));
                    }
                }
                else
                {
                    Console.Write(item.Value.PadRight(11 - item.Width,' '));
                }

                i++;
            }
            Console.Write("│");
        }

        
        
    }
}
