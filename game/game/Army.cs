using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Army
    {
        public string Name { get; set; }
        public int Wins { get; set; } = 0;
        public int Price { get; set; }
        public List<Unit> List { get; set; }
        public List<Unit> InitialList { get; set; }
        Army(string name, List<int> amounts)
        {
            Name = name;
            List<Unit> units = new List<Unit>() { new LightInfantry(), new HeavyInfantry(), new Knight(),
                new LightInfantry(new Archer()), new HeavyInfantry(new Archer()), new Knight(new Archer()),
                new LightInfantry(new Healer()), new HeavyInfantry(new Healer()), new Knight(new Healer()),};
            List = units.Select((u, i) => u * amounts[i]).SelectMany(x => x).ToList();
            InitialList = List.Select(n => new Unit(n.UnitDescriptionId, n.UnitName, n.Type, n.Attack, n.Defence, n.HitPoints, n.SpecialAbilityType,
                n.SpecialAbilityStrength, n.SpecialAbilityRange)).ToList();
            Price = List.Sum(n => n.UnitPrice);
        }

        public static Army CreateUserArmy()
        {
            List<int> amounts = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToList();
            return new Army("Пользователь", amounts);
        }

        public static Army CreateRandomArmy()
        {
            List<int>[] options =
            {
                new List<int> { 1, 1, 0, 0, 2, 0, 0, 0, 0 },
                new List<int> { 0, 2, 0, 1, 1, 0, 0, 0, 0 },
                new List<int> { 0, 1, 0, 1, 0, 1, 0, 0, 0 },
                new List<int> { 0, 0, 1, 1, 1, 0, 0, 0, 0 },
                new List<int> { 1, 0, 0, 0, 1, 1, 0, 0, 0 },
                new List<int> { 1, 1, 0, 0, 0, 0, 0, 2, 0 },
                new List<int> { 0, 2, 0, 0, 0, 0, 1, 1, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                new List<int> { 0, 0, 1, 0, 0, 0, 1, 1, 0 },
                new List<int> { 1, 0, 0, 0, 0, 0, 0, 1, 1 }
            };
            int n = new Random().Next(0, 9);
            List<int> amounts = options[n];

            return new Army("Компьютер", amounts);
        }
    }
}
