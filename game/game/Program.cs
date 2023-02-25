using System.Text.Json;

namespace ConsoleApp
{
    public class Army
    {
        const int totalPrice = 100;
        const double actualPrice = totalPrice / 4;
        public string Name { get; set; }
        public int Wins { get; set; }
        public int WinsTotal { get; set; }
        public List<Unit> List { get; set; }

        public Army(string name)
        {
            Name = name;
            Wins = 0;
            WinsTotal = 0;
            List = new List<Unit>() { new LightInfantry(actualPrice), new HeavyInfantry(actualPrice), new Knight(actualPrice), new LightInfantry(actualPrice) };
        }

    }

    public class Unit
    {
        public int UnitDescriptionId { get; set; }
        public string UnitName { get; set; }
        public double Attack { get; set; }
        public double Defense { get; set; }
        public double HitPoints { get; set; }

        public Unit(int UnitId, string Name, double hpCoeff, double attackCoeff, double defenceCoeff, double price)
        {
            UnitDescriptionId = UnitId;
            UnitName = Name;
            double coeff = price / (attackCoeff + defenceCoeff + hpCoeff);
            Attack = Math.Floor(attackCoeff * coeff);
            Defense = Math.Floor(defenceCoeff * coeff);
            HitPoints = Math.Floor(hpCoeff * coeff);

        }

        public void TakeDamage(Unit enemy)
        {
            double damage = enemy.Attack - this.Defense;
            if (damage <= 0)
            {
                Console.WriteLine("весь удар поглощен защитой");
            }
            else
            {
                Console.WriteLine($"минус {damage} здоровья");
            }
        }

        public string Stats()
        {
            return $"Атака: {this.Attack} Защита: {this.Defense} Здоровье: {this.HitPoints}";
        }
    }

    public class War
    {
        public War(Army army1, Army army2)
        {
            Army[] armies = new Army[] { army1, army2 };

            Console.WriteLine("Начало войны");
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Начало {i + 1} боя");
                Fight(armies[i % 2], armies[(i + 1) % 2]);
                Console.WriteLine("Конец боя");
                Console.WriteLine();
            }

            if (army1.WinsTotal > army2.WinsTotal)
            {
                Console.Write($"Победила армия {army1.Name}");
            }
            else if (army1.WinsTotal < army2.WinsTotal)
            {
                Console.Write($"Победила армия {army2.Name}");
            }
            else
            {
                Console.WriteLine("Ничья");
            }

            Console.WriteLine("Конец войны");
        }
        public void Fight(Army afirst, Army asecond)
        {
            int turns = 0;
            while (true)
            {
                if (afirst.List.Count == 0 || asecond.List.Count == 0 || turns == 10)
                {
                    break;
                }

                int ufirstpos = new Random().Next(1, afirst.List.Count);
                int usecondpos = new Random().Next(1, asecond.List.Count);

                Start(afirst, ufirstpos, asecond, usecondpos);
                Turn(afirst, ufirstpos, asecond, usecondpos);
                turns++;
            }
            End(afirst, asecond);


        }
        public void Start(Army afirst, int ufpos, Army asecond, int uspos)
        {
            Console.WriteLine("Столкновение юнитов с характеристиками: ");
            Console.WriteLine("1. " + afirst.List[ufpos].Stats());
            Console.WriteLine("2. " + asecond.List[uspos].Stats());
            Console.WriteLine();
        }
        public void Turn(Army afirst, int ufpos, Army asecond, int uspos)
        {
            Unit ufirst = afirst.List[ufpos];
            Unit usecond = asecond.List[uspos];

            Console.WriteLine("Начало хода");
            Console.Write("Первый юнит атакует: ");
            usecond.TakeDamage(ufirst);

            if (usecond.HitPoints > 0)
            {
                Console.Write("Второй юнит атакует: ");
                ufirst.TakeDamage(usecond);
            }
            else
            {
                Console.WriteLine("Второй юнит мертв");
                afirst.Wins++;
                asecond.List.Remove(usecond);
            }
            Console.WriteLine("Конец хода");
            Console.WriteLine();
        }

        public void End(Army afirst, Army asecond)
        {
            if (afirst.Wins > asecond.Wins)
            {
                Console.WriteLine($"В этом бою победила армия {afirst.Name}");
                afirst.WinsTotal++;
            }
            else
            {
                Console.WriteLine($"В этом бою победила армия {asecond.Name}");
                asecond.WinsTotal++;
            }
        }
    }

    public class LightInfantry : Unit
    {
        new const int UnitDescriptionId = 1;
        new const string UnitName = "Infantry";
        const double att = 1;
        const double def = 1;
        const double hp = 2.25;
        public LightInfantry(double price) : base(UnitDescriptionId, UnitName, att, def, hp, price)
        {
        }
    }

    public class HeavyInfantry : Unit
    {
        new const int UnitDescriptionId = 2;
        new const string UnitName = "Heavy Infantry";
        const double hp = 0.75;
        const double att = 1.5;
        const double def = 2;
        public HeavyInfantry(double price) : base(UnitDescriptionId, UnitName, att, def, hp, price)
        {
        }

    }

    public class Knight : Unit
    {
        new const int UnitDescriptionId = 3;
        new const string UnitName = "Knight";
        const double att = 1.75;
        const double def = 0.5;
        const double hp = 2;
        public Knight(double price) : base(UnitDescriptionId, UnitName, att, def, hp, price)
        {
        }

    }
    class GetJsonFields
    {
        public string? TeamName { get; set; }
        public List<Unit>? UnitDiscriptions { get; set; }
        public List<int>? Units { get; set; }
        public void createJsonFile(GetJsonFields jsonString)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(jsonString, options);
            File.WriteAllText("WhyNot.json", json);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var army1 = new Army("Белая роза");
            List<int> id = new();
            //var army2 = new Army("Алая роза");
            //new War(army1, army2);
            for (int i = 0; i < army1.List.Count; i++)
            {
                id.Add(army1.List[i].UnitDescriptionId);
            }

            var jsonFile = new GetJsonFields
            {
                TeamName = "WhyNot?",
                UnitDiscriptions = army1.List,
                Units = id
            };
            jsonFile.createJsonFile(jsonFile);

        }
    }
}