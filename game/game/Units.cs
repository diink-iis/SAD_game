using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class LightInfantry : Unit, IHealable
    {
        new const int UnitDescriptionId = 1;
        new const string UnitName = "Infantry";
        new static readonly Type Type = typeof(LightInfantry);
        new const int Attack = 3;
        new const int Defence = 3;
        new const int MaxHP = 7;
        public LightInfantry() : base(UnitDescriptionId, UnitName, Type, Attack, Defence, MaxHP)
        {
        }
        public LightInfantry(ISpecialAbility spec) : base(UnitDescriptionId, spec.UnitName, Type, Attack, Defence, MaxHP, spec.SpecialAbilityType, spec.SpecialAbilityStrength, spec.SpecialAbilityRange)
        {
        }
    }

    public class HeavyInfantry : Unit, IHealable
    {
        new const int UnitDescriptionId = 2;
        new const string UnitName = "Heavy Infantry";
        new static readonly Type Type = typeof(HeavyInfantry);
        new const int Attack = 7;
        new const int Defence = 7;
        new const int MaxHP = 7;
        public HeavyInfantry() : base(UnitDescriptionId, UnitName, Type, Attack, Defence, MaxHP)
        {
        }
        public HeavyInfantry(ISpecialAbility spec) : base(UnitDescriptionId, spec.UnitName, Type, Attack, Defence, MaxHP, spec.SpecialAbilityType, spec.SpecialAbilityStrength, spec.SpecialAbilityRange)
        {
        }
    }

    public class Knight : Unit
    {
        new const int UnitDescriptionId = 3;
        new const string UnitName = "Knight";
        new static readonly Type Type = typeof(Knight);
        new const int Attack = 10;
        new const int Defence = 8;
        new const int MaxHP = 24;
        public Knight() : base(UnitDescriptionId, UnitName, Type, Attack, Defence, MaxHP)
        {
        }
        public Knight(ISpecialAbility spec) : base(UnitDescriptionId, spec.UnitName, Type, Attack, Defence, MaxHP, spec.SpecialAbilityType, spec.SpecialAbilityStrength, spec.SpecialAbilityRange)
        {
        }
    }
}
