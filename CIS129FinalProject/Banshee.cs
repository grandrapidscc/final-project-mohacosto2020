using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert
{
    internal class Banshee : Enemy
    {

        public Banshee() : base(8)
        { }

        public override int attack()
        {
            Console.WriteLine("Screech");
            return 5;
        }

        public override string getName()
        {
            return "Banshee";
        }

    }
}
