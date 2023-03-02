// Пример консольного приложения до применения принципов DRY, KISS, YAGNI, SOLID 
//using System;
//namespace ConsoleApplication
//{
//    class Program
//    {
//        static void Main(string[] args) { 
//            Console.WriteLine("Введите свое имя: "); 
//            string name = Console.ReadLine(); 
//            Console.WriteLine("Введите свой возраст: "); 
//            int age = int.Parse(Console.ReadLine()); 
//            Console.WriteLine("Введите место работы: "); 
//            string job = Console.ReadLine(); 
//            Console.WriteLine("Введите свое место жительства: "); 
//            string city = Console.ReadLine(); 
//            Console.WriteLine("Ваше имя: {0}", name); 
//            Console.WriteLine("Ваш возраст: {0}", age); 
//            Console.WriteLine("Ваше место работы: {0}", job); 
//            Console.WriteLine("Ваше место жительства: {0}", city); }
//    }
//} 
// Пример консольного приложения после применения принципов DRY, KISS, YAGNI, SOLID
using System;
namespace ConsoleApplication
{
    // Применение принципа SOLID: применение принципа единственной ответственности
    public class User
    { 
        public string Name { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        // Применение принципа KISS: упрощение и сокращение кода
        static void Main(string[] args)
        {
            User user = GetUserData(); 
            PrintUserData(user);
        }
        // Применение принципа DRY: избегание дублирования кода
        private static User GetUserData()
        {
            User user = new User();
            Console.WriteLine("Введите свое имя: ");
            user.Name = Console.ReadLine();
            Console.WriteLine("Введите свой возраст: ");
            user.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите свое место работы: ");
            user.Job = Console.ReadLine();
            Console.WriteLine("Введите свое место жительства: ");
            user.City = Console.ReadLine(); 
            return user;
        }
        // Применение принципа YAGNI: избегание излишней функциональности
        private static void PrintUserData(User user)
        {
            Console.WriteLine("Ваше имя: {0}", user.Name);
            Console.WriteLine("Ваш возраст: {0}", user.Age);
            Console.WriteLine("Ваше место работы: {0}", user.Job);
            Console.WriteLine("Ваше место жительства: {0}", user.City);
        }
    }
}    
        