using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert
{
    abstract class Enemy
    {
        protected int hp;
        public Enemy(int hp)
        {
            this.hp = hp;
        }
        public abstract int attack();
        public abstract string getName();
        public bool isAlive()
        {
            return hp > 0;
        }

        public void receiveDamage(int dmg)
        {
            hp -= dmg;
            if (hp < 0)
                hp = 0;
        }
        public void displayInfo()
        {
            Console.WriteLine(getName() + ": Health: " + hp);
        }

        public int getHealth()
        {
            return hp;
        }
    }
}
