using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert
{
    internal class Goblin : Enemy
    {
        public Goblin() : base(3)
        { }

        public override int attack()
        {
            Console.WriteLine("Body Slam");
            return 2;
        }



        public override string getName()
        {
            return "Goblin";
        }


    }
}
