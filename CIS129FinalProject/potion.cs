using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert
{
    abstract class Potion
    {
        PotionType type;
        int value;
        bool used;
        public PotionType Type { get { return type; } }
        public bool Used { get { return used; } }
        public int Value { get { return (used) ? 0 : value; } }

        public Potion(PotionType type, int value)
        {
            this.type = type;
            this.value = value;
            used = false;
        }

        public int usePotion()
        {
            if (used)
                return 0;
            used = true;
            return value;
        }
    }

    enum PotionType
    {
        HEALTH, MAGICKA
    }
}
