using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Strategy
{
    public class AutoStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy un auto.");
        }
    }
}
