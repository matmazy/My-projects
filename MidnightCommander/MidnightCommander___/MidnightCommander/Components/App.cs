using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidnightCommander.Components;


namespace MidnightCommander
{
    public static class App
    {
        public static Component Window;
        public static Component SecWindow;
        public static Component Helprow;


        //public static Component Disc;

        public static List<Component> Windows = new List<Component>();

        


        public static void Run()
        {           
            //Console.BackgroundColor = ConsoleColor.Blue;
            Window = new TableWindow();
            SecWindow = new TableWindow();
            Helprow = new HelpWindow();            
            App.Window.Reload(App.Window.Path);
            App.SecWindow.Reload(App.SecWindow.Path);
            
            App.Window.Active = true;            
            Windows.Add(App.Window);
            Windows.Add(App.SecWindow);
        }


        public static void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            App.Window.Draw(0,0);
            App.SecWindow.Draw(57, 0);
            App.Helprow.Draw(0, 28);            
        }

        public static void HandleKey(ConsoleKeyInfo info)
        {
            if(info.Key == ConsoleKey.Tab)
            {
                if (App.Window.Active == true)
                {
                    App.Window.Active = false;
                    App.SecWindow.Active = true;
                }
                else
                {
                    App.Window.Active = true;
                    App.SecWindow.Active = false;
                }
            }
            else
            {
                foreach (Component item in Windows)
                {
                    if(item.Active == true)
                    {
                        item.HandleKey(info);
                    }
                }
            }
        }
    }
}
