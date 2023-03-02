using System;

namespace SingletonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Singleton s1 = Singleton.Instance;

            Console.WriteLine("Object: {0}", s1.GetHashCode());

            Singleton s2 = Singleton.Instance;

            Console.WriteLine("Object: {0}", s2.GetHashCode());

            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            Console.ReadKey();
        }
    }

    public sealed class Singleton
    {
        private static Singleton? instance = null;
        private static readonly object padlock = new object();

        Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
}