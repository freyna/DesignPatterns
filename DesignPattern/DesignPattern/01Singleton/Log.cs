using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._01Singleton
{
    public class Log
    {
        // Se crea la instancia en tiempo de ejecución
        private readonly static Log instance = new Log();
        private string path = "log.txt";
        // Obtenemos nuestra instancia.
        public static Log Instance
        {
            get
            {
                return instance;
            }
        }

        // Creamos un constructor privado para evitar poder crear otra instancia de la clase
        private Log()
        {

        }

        public async Task Save(string message)
        {
            await File.AppendAllTextAsync(path, message + Environment.NewLine);
        }


    }
}
