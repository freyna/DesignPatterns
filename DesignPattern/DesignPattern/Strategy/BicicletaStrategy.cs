using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Strategy
{
    public class BicicletaStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una bicicleta");
        }
    }
}
