using System;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace ConsoleApp
{
    public class Army
    {
        const int totalPrice = 100;
        const double actualPrice = totalPrice / 3;
        public List<Unit> list;
        public Tuple<Tuple<double, double, double>, Tuple<double, double, double>, Tuple<double, double, double>> createArmy()
        {
            Tuple<double, double, double> ligthInfUnit = new LightInfantry().calculateUnit(actualPrice);
            Tuple<double, double, double> heavyInfUnit = new HeavyInfantry().calculateUnit(actualPrice);
            Tuple<double, double, double> knightUnit = new Knight().calculateUnit(actualPrice);
            return Tuple.Create(ligthInfUnit, heavyInfUnit, knightUnit);
        }
        
    }
    public class Unit
    {
        public double calculateCoeff(double attackWeight, double defenceWieght, double hpWeight, double sumPrice)
        {
            return sumPrice / (attackWeight + defenceWieght + hpWeight);
        }
        double calculateHP(double HP, double coeff)
        {
            return HP * coeff;
        }
        double calculateAttack(double attack, double coeff)
        {
            return attack * coeff;
        }
        double calculateDefence(double defence, double coeff)
        {
            return defence * coeff;
        }
        public Tuple<double, double, double> calculateMetrics(double hpCoeff, double attackCoeff, double defenceCoeff, double price)
        {
            double coeff = calculateCoeff(hpCoeff, attackCoeff, defenceCoeff, price);
            double hp = calculateHP(hpCoeff, coeff);
            double attack = calculateAttack(attackCoeff, coeff);
            double defence = calculateDefence(defenceCoeff, coeff);
            return Tuple.Create(hp, attack, defence);
        }


    }

    public class Fight
    {
    }

    public class LightInfantry : Unit
    {
        const double attackParam = 1;
        const double defenseParam = 1;
        const double hpParam = 2.25;
        public Tuple<double, double, double> calculateUnit(double RemainPrice)
        {
            Tuple<double, double, double> coeff = calculateMetrics(attackParam, defenseParam, hpParam, RemainPrice);
            return coeff;
        }
    }

    public class HeavyInfantry : Unit
    {
        const double hpParam = 0.75;
        const double attackParam = 1.5;
        const double defenseParam = 2;
        public Tuple<double, double, double> calculateUnit(double RemainPrice)
        {
            Tuple<double, double, double> coeff = calculateMetrics(attackParam, defenseParam, hpParam, RemainPrice);
            return coeff;
        }
    }

    public class Knight : Unit
    {
        const double attackParam = 1.75;
        const double defenseParam = 0.5;
        const double hpParam = 2;
        public Tuple<double, double, double>  calculateUnit(double RemainPrice)
        {
            Tuple<double, double, double> coeff = calculateMetrics(attackParam, defenseParam, hpParam, RemainPrice);
            return coeff;
        }

    }
    
class Program
    {
        static void Main(string[] args)
        {
            //var army = new Army();
            var test = new Knight();
            var test2 = new Army();
            Console.WriteLine(test.calculateCoeff(0.75, 1.5, 2, 33.3));
            Console.WriteLine(test.calculateUnit(33.3));
            Console.WriteLine(test2.createArmy());
        }
    }
}