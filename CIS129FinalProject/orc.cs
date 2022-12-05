using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert
{
    internal class Orc : Enemy
    {
        public Orc() : base(5)
        { }

        public override int attack()
        {
            Console.WriteLine("Cleave");
            return 3;
        }

        public override string getName()
        {
            return "Orc";
        }

    }
}
