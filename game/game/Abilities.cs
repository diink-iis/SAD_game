using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Archer : ISpecialAbility, IHealable
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
        // метод из интерфейса лечилки
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
        public static void DoAction()
        {
            // здесь нужен метод, как он хилит
        }
        // метод из интерфейса лечилки
    }
}