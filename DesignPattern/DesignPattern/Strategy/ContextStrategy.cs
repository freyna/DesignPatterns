using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Strategy
{
    public class ContextStrategy
    {
        private IStrategy strategy;

        public IStrategy Strategy
        {
            set => strategy = value;
        }

        public ContextStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void run()
        {
            strategy.Run();
        }
    }
}
