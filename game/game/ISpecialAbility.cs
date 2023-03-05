using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public interface ISpecialAbility
    {
        string UnitName { get; }
        int SpecialAbilityType { get; }
        int SpecialAbilityStrength { get; }
        int SpecialAbilityRange { get; }
        void DoAction(int pos, Army one, Army other);
    }
}
