using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class War
    {
        const int fights = 4;
        Army afirst, asecond;
        public Army Winner { get; protected set; }
        public War(Army user, Army computer)
        {
            Army[] armies = new Army[] { user, computer };

            Console.WriteLine("Начало войны");
            Console.WriteLine();
            for (int i = 0; i < fights; i++)
            {
                afirst = armies[i % 2];
                asecond = armies[(i + 1) % 2];
                Fight();
                Console.WriteLine();
            }
            FindTotalWinner();
        }

        void ShowStats()
        {
            Console.WriteLine($"{afirst.Name} ({afirst.Price}) --- vs --- {asecond.Name} ({asecond.Price})");

            List<Unit> everyone = afirst.List.Reverse<Unit>().ToList().Concat(asecond.List).ToList();
            int columns = everyone.Count;
            int separator = afirst.List.Count;
            List<string> column = new List<string>() { "Имя", "Класс", "ХП", "Атака", "Защита", "Сила", "Радиус" };
            const int rows = 7;

            for (int i = 0; i < rows; i++)
            {
                Console.Write(column[i] + "\t");
                for (int j = 0; j < columns; j++)
                {
                    string nspace, wspace;
                    int length = everyone[j].UnitName.Length;
                    if (length < 8)
                    {
                        nspace = "\t";
                        wspace = "\t";
                    }
                    else
                    {
                        nspace = "\t";
                        wspace = "\t\t";
                    }

                    if (j == separator)
                    {
                        Console.Write("|");
                    }

                    switch (i)
                    {
                        case 0:
                            Console.Write(everyone[j].Name + wspace);
                            break;
                        case 1:
                            Console.Write(everyone[j].UnitName + nspace);
                            break;
                        case 2:
                            Console.Write(everyone[j].HitPoints + wspace);
                            break;
                        case 3:
                            Console.Write(everyone[j].Attack + wspace);
                            break;
                        case 4:
                            Console.Write(everyone[j].Defence + wspace);
                            break;
                        case 5:
                            Console.Write(everyone[j].SpecialAbilityStrength + wspace);
                            break;
                        case 6:
                            Console.Write(everyone[j].SpecialAbilityRange + wspace);
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        void ExchangeAttacks(int ufpos, int uspos)
        {
            Unit ufirst = afirst.List[ufpos];
            Unit usecond = asecond.List[uspos];

            usecond.TakeDamage(ufirst.Attack, afirst.Price, out int usdam);
            Console.WriteLine($"Юнит {ufirst.Name} атакует. Юнит {usecond.Name} теряет {usdam} здоровья");

            if (usecond.HitPoints > 0)
            {
                ufirst.TakeDamage(usecond.Attack, asecond.Price, out int ufdam);
                Console.WriteLine($"Юнит {usecond.Name} атакует. Юнит {ufirst.Name} теряет {ufdam} здоровья");
            }
        }

        void ActivateAbility(int pos, Army my, Army enemy)
        {
            if (my.List[pos].SpecialAbilityType == 0)
            {
                return;
            }
            else
            {
                Console.Write($"{my.List[pos].Name} активирует спец. возможность {my.List[pos].UnitName}: ");
                my.List[pos].DoAction(pos, my, enemy);
            }
        }

        void ExchangeSpecialAbilities()
        {
            int fcount = afirst.List.Count;
            int scount = asecond.List.Count;
            for (int i = 0; i < Math.Max(fcount, scount); i++)
            {
                if (i < fcount)
                {
                    ActivateAbility(i, afirst, asecond);
                }
                if (i < scount)
                {
                    ActivateAbility(i, asecond, afirst);
                }
            }
        }

        void RemoveDeadUnits()
        {
            afirst.List.Where((u) => u.HitPoints <= 0).ToList().ForEach( (u) => afirst.List.Remove(u) );
            asecond.List.Where((u) => u.HitPoints <= 0).ToList().ForEach( (u) => asecond.List.Remove(u) );
        }

        void Turn()
        {
            Console.WriteLine("Начало хода");
            ShowStats();
            ExchangeAttacks(0, 0);
            ExchangeSpecialAbilities();
            RemoveDeadUnits();
            Console.WriteLine("Конец хода");
            Console.WriteLine();
        }

        void FindWinner()
        {
            if (afirst.List.Count > asecond.List.Count)
            {
                Console.WriteLine($"В этом бою победила армия {afirst.Name}");
                afirst.Wins++;
            }
            else if (afirst.List.Count < asecond.List.Count)
            {
                Console.WriteLine($"В этом бою победила армия {asecond.Name}");
                asecond.Wins++;
            }
            else
            {
                Console.WriteLine("В этом бою ничья");
            }
        }

        void Fight()
        {
            Console.WriteLine($"НАЧАЛО БОЯ");
            Console.WriteLine();
            while (true)
            {
                if (afirst.List.Count == 0 || asecond.List.Count == 0)
                {
                    break;
                }
                Turn();
            }
            FindWinner();
        }

        void FindTotalWinner()
        {
            if (afirst.Wins > asecond.Wins)
            {
                Console.WriteLine($"Победила армия {afirst.Name}");
                Winner = afirst;
            }
            else if (afirst.Wins < asecond.Wins)
            {
                Console.WriteLine($"Победила армия {asecond.Name}");
                Winner = asecond;
            }
            else
            {
                Console.WriteLine("Ничья");
                Winner = new Army[] { afirst, asecond }[new Random().Next(0, 1)];
            }
        }
    }
}
