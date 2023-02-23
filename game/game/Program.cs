using System;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace ConsoleApp
{
    public class Army
    {
        const int total_price = 100;
        const int LightAttack = 10;
        const int LightDefense = 10;
        const int LightHP = 5;
        const int HeavyAttack = 10;
        const int HeavyDefense = 15;
        const int HeavyHP = 10;
        const int KnightAttack = 30;
        const int KnightDefense = 30;
        const int KnightHP = 40;
        public List<Unit> list;
        public Army()
        {
            list = new List<Unit>();
            var CurrentPrice = total_price;
            Random rnd = new();
            while (CurrentPrice > 0)
            {
                var type = rnd.Next(1, 4);
                Unit unit;
                int RemainPrice;
                switch (type)
                {

                    case 1:
                        unit = new LightInfantry(LightAttack, LightDefense, LightHP, CurrentPrice, out RemainPrice);
                        break;
                    case 2:
                        unit = new HeavyInfantry(HeavyAttack, HeavyDefense, HeavyHP, CurrentPrice, out RemainPrice);
                        break;
                    default:
                        unit = new Knight(KnightAttack, KnightDefense, KnightHP, CurrentPrice, out RemainPrice);
                        break;

                }
                CurrentPrice = RemainPrice;
                list.Add(unit);
            }
        }
    }
    public class Unit
    {
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public Unit(int hp, int attack, int defense, int CurrentPrice, out int RemainPrice)
        {
            Random rnd = new();
            HP = rnd.Next(1, Math.Min(hp, CurrentPrice));
            CurrentPrice -= HP;
            Attack = rnd.Next(1, Math.Min(attack, CurrentPrice == 0?attack:CurrentPrice));
            CurrentPrice -= Attack;
            Defense = rnd.Next(1, Math.Min(defense, CurrentPrice == 0?defense : CurrentPrice));
            CurrentPrice -= Defense;
            RemainPrice = CurrentPrice;
        }

    }

    public class Fight
    {


    }

    public class LightInfantry : Unit
    {
        public LightInfantry(int hp, int attack, int defense, int CurrentPrice, out int RemainPrice) : base(hp, attack, defense, CurrentPrice, out RemainPrice)
        {
        }


    }

    public class HeavyInfantry : Unit
    {
        public HeavyInfantry(int hp, int attack, int defense, int CurrentPrice, out int RemainPrice) : base(hp, attack, defense, CurrentPrice, out RemainPrice)
        {
        }

    }

    public class Knight : Unit
    {
        public Knight(int hp, int attack, int defense, int CurrentPrice, out int RemainPrice) : base(hp, attack, defense, CurrentPrice, out RemainPrice)
        {
        }

    }
    
class Program
    {
        static void Main(string[] args)
        {
            var army = new Army();

        }
    }
}