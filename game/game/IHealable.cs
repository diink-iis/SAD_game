using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public interface IHealable
    {
        public static void GainHealth(int hpower, Unit unit)
        {
            unit.HitPoints = Math.Min(unit.MaxHP, unit.HitPoints + hpower);
        }
    }
}
