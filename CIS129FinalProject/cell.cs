using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert
{
    internal class Cell
    {
        string description;
        public string Description { get { return description; } set { description = value; } }
        Potion potion;
        Enemy enemy;
        public Potion Potion { get { return potion; } set { potion = value; } }
        public bool HasPotion { get { return potion != null && !potion.Used; } }
        public Enemy Enemy { get { return enemy; } set { enemy = value; } }
        public bool HasEnemy { get { return enemy != null && enemy.isAlive(); } }

        public Cell(Potion potion, Enemy enemy)
        {
            Potion = potion;
            Enemy = enemy;
        }

        public Cell(string description) : this(null, null)
        {
            this.description = description;
        }

        public Cell(Enemy enemy) : this(null, enemy)
        {
        }

        public void displayInfo()
        {
            Console.WriteLine(description);
            if (HasEnemy)
            {
                Console.WriteLine("You have encountered an enemy:" + enemy.getName() + " HP: " + enemy.getHealth());
            }
            else if (HasPotion)
            {
                Console.WriteLine("You have picked up a potion");
            }
        }
    }
}
