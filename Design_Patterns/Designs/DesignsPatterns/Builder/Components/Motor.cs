using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Components
{
    class Motor
    {
        private int power;

        public int Power { 
            get => power; 
            set => power = value; 
        }

        public Motor(int power)
        {
            this.power = power;
        }
    }
}
