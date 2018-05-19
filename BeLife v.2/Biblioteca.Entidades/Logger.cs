using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//permite acceder a los archivos del sistema
namespace Biblioteca
{
    public class Logger
    {
        public static void Mensaje(string msg)
        {
            msg =DateTime.Now + " | " + msg + Environment.NewLine;
            File.AppendAllText("D:\\Log.txt", msg);
        }
    }
}