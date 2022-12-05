using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert
{
    internal class HealthPotion : Potion
    {
        public HealthPotion() : base(PotionType.HEALTH, 10)
        {
        }
    }
}
