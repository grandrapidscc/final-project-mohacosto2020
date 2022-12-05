using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert
{
    internal class Wizert
    {
        int hp;
        int mp;
        public int Hp { get; set; }
        public int Mp { get; set; }

        public Wizert()
        {
            hp = 100;
            mp = 200;
        }

        public bool Heal()
        {
            if (mp >= 5)
            {
                mp -= 5;
                hp += 3;
                Console.WriteLine("The Wizert casts a spell to heal his wounds.");
                return true;
            }
            Console.WriteLine("You do not have enough MP");
            return false;
        }

        public int FireBall()
        {
            if (mp >= 3)
            {
                Console.WriteLine("The Wizert casts a fireball that burns the enemy");
                mp -= 3;
                return 5;
            }
            Console.WriteLine("You do not have enough MP");
            return 0;
        }

        public void displayInfo()
        {
            Console.WriteLine("Wizert Status: HP: " + hp + " MP: " + mp);
        }

        internal bool isAlive()
        {
            return hp > 0;
        }

        internal void takeDamage(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;
        }
    }
}
