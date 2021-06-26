using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MidnightCommander
{
    public class TableWindow : Component
    {
        private FileService service = new FileService();

        private Table table;
        
        public override void Draw(int x,int y)
        {            
            this.table.Draw(x, y);
        }

        public override void HandleKey(ConsoleKeyInfo info)
        {
            this.table.HandleKey(info);
        }      

        public override void Reload(string path)
        {
            this.table = null;

            FileContent data = this.service.FileLoad(path);
            this.table = new Table(data.Header.ToArray());

            foreach (string[] item in data.Data)
            {
                this.table.Add(item);
            }
        }
    }
}
