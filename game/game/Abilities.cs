using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Archer : ISpecialAbility
    {
        public string UnitName { get; } = "Archer";
        public int SpecialAbilityType { get; } = 1;
        public int SpecialAbilityStrength { get; } = 3;
        public int SpecialAbilityRange { get; } = 3;
        public void DoAction(int pos, Army my, Army enemy)
        {
        }
        public static void DoAction(int pos, Unit me, int price, Army enemy)
        {
            int barrier = Math.Min(me.SpecialAbilityRange - pos, enemy.List.Count);
            if (barrier < 1)
            {
                Console.WriteLine($"не хватило дальности");
                return;
            }
            for (int i = 0; i < barrier; i++)
            {
                if (enemy.List[i].HitPoints > 0)
                {
                    enemy.List[i].TakeDamage(me.SpecialAbilityStrength, price, out int damage);
                    Console.WriteLine($"юнит {enemy.List[i].Name} лишился {damage} здоровья");
                    return;
                }
            }
            Console.WriteLine($"все оппоненты в пределах досягаемости оказались мертвы");
        }
    }

    public class Healer : ISpecialAbility
    {
        public string UnitName { get; } = "Healer";
        public int SpecialAbilityType { get; } = 2;
        public int SpecialAbilityStrength { get; } = 4;
        public int SpecialAbilityRange { get; } = 2;
        public void DoAction(int pos, Army my, Army enemy)
        {
        }
        public static void DoAction(int pos, Unit me, Army my)
        {
            int barrier1 = Math.Max(pos - me.SpecialAbilityRange, 0);
            int barrier2 = Math.Min(pos + me.SpecialAbilityRange, my.List.Count - 1);
            for (int i = barrier1; i <= barrier2; i++)
            {
                var u = my.List[i];
                bool check = typeof(IHealable).IsAssignableFrom(u.Type);
                if (check && u.HitPoints > 0 && u.HitPoints < u.MaxHP)
                {
                    IHealable.GainHealth(me.SpecialAbilityStrength, u);
                    Console.WriteLine($"юнит {u.Name} излечился до {u.HitPoints} здоровья");
                    return;
                }
            }
            Console.WriteLine($"все дружеские юниты в пределах досягаемости либо мертвы, либо здоровы");
        }
    }
}