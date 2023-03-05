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
        new const int Attack = 3;
        new const int Defence = 3;
        public static readonly int MaxHP = 7;
        public LightInfantry() : base(UnitDescriptionId, UnitName, Attack, Defence, MaxHP)
        {
        }
        public LightInfantry(ISpecialAbility spec) : base(UnitDescriptionId, spec.UnitName, Attack, Defence, MaxHP, spec.SpecialAbilityType, spec.SpecialAbilityStrength, spec.SpecialAbilityRange)
        {
        }
        // метод из интерфейса реализовать
    }

    public class HeavyInfantry : Unit, IHealable
    {
        new const int UnitDescriptionId = 2;
        new const string UnitName = "Heavy Infantry";
        new const int Attack = 7;
        new const int Defence = 7;
        public static readonly int MaxHP = 7;
        public HeavyInfantry() : base(UnitDescriptionId, UnitName, Attack, Defence, MaxHP)
        {
        }
        public HeavyInfantry(ISpecialAbility spec) : base(UnitDescriptionId, spec.UnitName, Attack, Defence, MaxHP, spec.SpecialAbilityType, spec.SpecialAbilityStrength, spec.SpecialAbilityRange)
        {
        }
        // и тут тоже
    }

    public class Knight : Unit
    {
        new const int UnitDescriptionId = 3;
        new const string UnitName = "Knight";
        new const int Attack = 10;
        new const int Defence = 8;
        public static readonly int MaxHP = 24;
        public Knight() : base(UnitDescriptionId, UnitName, Attack, Defence, MaxHP)
        {
        }
        public Knight(ISpecialAbility spec) : base(UnitDescriptionId, spec.UnitName, Attack, Defence, MaxHP, spec.SpecialAbilityType, spec.SpecialAbilityStrength, spec.SpecialAbilityRange)
        {
        }
    }
}
