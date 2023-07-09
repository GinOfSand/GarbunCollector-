using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbunCollector_
{
    internal class ListWork:IDisposable
    {
        private const char Separator = '\n';

        public List<string> ToDos { get; set; }

        public ListWork()
        {
            if (File.Exists("todos.txt")==true)
            {
                FileStream fs = new FileStream("todos.txt",FileMode.Open);
            }
            else
            {
               File.Create("todos.txt");
               FileStream fs = new FileStream("todos.txt", FileMode.Open);
               byte[] buffer = new byte[1024];
               fs.Read(buffer, 0, buffer.Length);
               string st = buffer.ToString();
               fs.Close();
               
                ToDos = st.Split(Convert.ToChar(Separator)).ToList();
               
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
