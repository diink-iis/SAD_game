using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public interface IUnit
    {
        int UnitDescriptionId { get; }
        string UnitName { get; }
        string Name { get; }
        Type Type { get; }
        int Attack { get; }
        int Defence { get; }
        int MaxHP { get; }
        int HitPoints { get; set; }
        int UnitPrice { get; }
        void TakeDamage(int attack, int price, out int damage);
    }
}
