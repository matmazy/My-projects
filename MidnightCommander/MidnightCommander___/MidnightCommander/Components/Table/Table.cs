using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MidnightCommander.Commands;


namespace MidnightCommander
{
    public class Table : Component 
    {
        public int selected { get; set; } = 1;
        public int Width { get; set; } = Console.WindowWidth / 2;

        Row header = new Row();
        
        public List<Row> Data = new List<Row>();
        public List<Row> FinalData = new List<Row>();
       
        public Table(params string [] headers)
        {            
           
            foreach (string item in headers)
            {
                this.header.Add(new Item() { Value = item });
            }
        }

        public void CreateNewData()
        {
            if (this.selected < 22)
            {
                for (int i = 0; i < 23; i++)
                {
                    FinalData.Add(this.Data[0 + i]);
                }
            }
            else
            {
                for (int i = 0; i < 23; i++)
                {
                    FinalData.Add(this.Data[this.selected + i - 22]);
                }
            }
        }


        public void Add(params string[] values)
        {
            if (values.Length != this.header.Count)
                throw new ArgumentOutOfRangeException("Neshoduje se počet sloupečků");

            Row row = new Row();

            foreach (string item in values)
            {
                row.Add(new Item() { Value = item });
            }
            this.Data.Add(row);            
        }

        public void FirstLine()
        {
            Console.WriteLine("┌" + "────" + App.Window.Path.PadRight(Width - 6, '─') + "┐");
        }

        public void DrawLine()
        {
            Console.Write("├");
            for (int i = 0; i < this.Width - 2; i++)                // ├ │ ┤ └ ┘
            {
                Console.Write("─");
            }
            Console.WriteLine("┤");
        }
        public void LastLine()
        {
            Console.Write("└");
            for (int i = 0; i < this.Width - 2; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");
        }


        public override void HandleKey(ConsoleKeyInfo info)
        {            
            if (info.Key == ConsoleKey.DownArrow && this.selected < this.Data.Count - 1)
            {
                this.selected++;
            }
                
            else if (info.Key == ConsoleKey.UpArrow && this.selected > 1)
            {
                this.selected--;                
            }
                
            else if (info.Key == ConsoleKey.Enter)             
            {
                if (App.Window.Active == true)
                {
                    App.Window.Path += Data[selected].items[0].Value;
                    App.Window.Reload(App.Window.Path);
                }
                else if (App.SecWindow.Active == true)
                {
                    App.SecWindow.Path += Data[selected].items[0].Value;
                    App.SecWindow.Reload(App.SecWindow.Path);
                }
            }

            else if (info.Key == ConsoleKey.Backspace)
            {
                foreach (Component item in App.Windows)
                {
                    if (!item.Active)
                        continue;

                    char[] ways = item.Path.ToArray();

                    if (ways.Length <= 3)
                        item.Path = "";
                    else
                    {
                        string way = item.Path;
                        int last = way.LastIndexOf(@"\");
                        way = way.Substring(0, last);
                        item.Path = way;
                    }
                    item.Reload(item.Path);
                }                
            }
            //pridani slozky
            else if (info.Key == ConsoleKey.F1)
            {
                foreach (Component component in App.Windows)
                {
                    if (!component.Active)
                        continue;

                    Add addcmd = new Add(component);
                    addcmd.CreateFolder("Nová Složka", component.Path);
                    component.Reload(component.Path);
                }
            }
            //smazani slozky
            else if (info.Key == ConsoleKey.F2)
            {
                foreach (Component component in App.Windows)
                {
                    if (component.Active)
                    {
                        Delete dellcmd = new Delete(component);
                        string ToDelete = component.Path + this.Data[selected].items[0].Value;
                        dellcmd.DeleteFolder(ToDelete);
                        component.Reload(component.Path);
                    }
                }
            }
            //novy soubor .txt
            else if(info.Key == ConsoleKey.F3)
            {
                foreach (Component component in App.Windows)
                {
                    if (!component.Active)
                        continue;

                    Add addfil = new Add(component);
                    addfil.CreateFile("NovyTextak.txt", component.Path);
                    component.Reload(component.Path);
                }
            }
            //odstraneni souboru
            else if(info.Key == ConsoleKey.F4)
            {
                foreach (Component component in App.Windows)
                {
                    if(component.Active == true)
                    {
                        Delete dellFil = new Delete(component);
                        string toDelete = component.Path + @"\" + this.Data[selected].items[0].Value;
                        dellFil.DeleteFile(toDelete);
                        component.Reload(component.Path);
                    }                    
                }
            }
            //kopírování
            else if(info.Key == ConsoleKey.F5)
            {
                foreach (Component component in App.Windows)
                {
                    if (component.Active)
                    {
                        Copy copycmd = new Copy(component);
                        string secPath = "";
                        foreach (Component item in App.Windows)
                        {
                            if (!item.Active)
                                secPath = item.Path;                            
                        }
                        copycmd.Run(component.Path + this.Data[selected].items[0].Value,secPath);
                    }                   
                }
            }
        }

        public override void Draw(int x, int y)
        {
            CreateNewData();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(x, y);
            this.FirstLine();
            y++;
            
            Console.SetCursorPosition(x, y);
            this.header.Draw();            
            Console.WriteLine();
            y++;

            Console.SetCursorPosition(x, y);            
            this.DrawLine();
            y++;

            Console.SetCursorPosition(x, y);
            
            int index = 0;
            foreach (Row item in this.FinalData)
            {                
                if (index == this.selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (this.selected >= 22 && index == 22)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                item.Draw();
                Console.SetCursorPosition(x, y);

                Console.BackgroundColor = ConsoleColor.Blue;
                index++;                
                y++;
            }            
            this.LastLine();
            FinalData.Clear();
        }

        public override void Reload(string path)
        {
            throw new NotImplementedException();
        }
    }
}
