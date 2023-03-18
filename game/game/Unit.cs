using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace game
{
    public class Unit : IUnit, ISpecialAbility
    {
        public int UnitDescriptionId { get; }
        public string UnitName { get; }
        [JsonIgnore]
        public string Name { get; }
        [JsonIgnore]
        public Type Type { get; }
        public int Attack { get; }
        public int Defence { get; }
        [JsonIgnore]
        public int MaxHP { get; }
        public int HitPoints { get; set; }
        [JsonIgnore]
        public int UnitPrice { get; }
        public int SpecialAbilityType { get; }
        public int SpecialAbilityStrength { get; }
        public int SpecialAbilityRange { get; }
        public Unit(int uid, string uname, Type type, int att, int def, int hp, int sat = 0, int sas = 0, int sar = 0)
        {
            UnitDescriptionId = uid;
            UnitName = uname;
            Name = new Random().NextInt64(1000, 1999).ToString();
            Type = type;
            Attack = att;
            Defence = def;
            HitPoints = MaxHP = hp;
            UnitPrice = att + def + hp;
            SpecialAbilityType = sat;
            SpecialAbilityStrength = sas;
            SpecialAbilityRange = sar;
            UnitPrice = att + def + hp + (sas + sar) * 2;
        }

        public void TakeDamage(int attack, int price, out int damage)
        {
            damage = (int)Math.Ceiling(attack * (price - this.Defence) / 100.0d);
            this.HitPoints -= damage;
        }

        public void DoAction(int pos, Army one, Army other)
        {
            if (this.SpecialAbilityType == 1)
            {
                Archer.DoAction(pos, one.List[pos], one.Price, other);
            }
            if (this.SpecialAbilityType == 2)
            {
                Healer.DoAction(pos, one.List[pos], one);
            }
        }
        public static List<Unit> operator *(Unit unit, int amount)
        {
            List<Unit> res = new List<Unit>();
            for (int i = 0; i < amount; i++)
            {
                res.Add(new Unit(unit.UnitDescriptionId, unit.UnitName, unit.Type, unit.Attack, unit.Defence, unit.HitPoints,
                    unit.SpecialAbilityType, unit.SpecialAbilityStrength, unit.SpecialAbilityRange));
            }
            return res;
        }
    }
}
