using System;
using System.Collections.Generic;

namespace ObjectPool
{
    public class User { 
        public string Name { get; set; } 
        public string Email { get; set; } 
    } 
    public class UserPool {
        private List<User> users; 
        public UserPool() { 
            users = new List<User>(); 
        } 
        public User GetUser() { 
            if (users.Count() == 0) return null; 
            User user = users[0]; 
            users.RemoveAt(0); 
            return user; } 
        public void ReturnUser(User user) { 
            users.Add(user); 
        }
    } 
    class Program { 
        static void Main(string[] args) { 
            UserPool userPool = new UserPool(); 
            userPool.ReturnUser(new User { Name = "Sonya", Email = "Sonya@rea.ru" });
            userPool.ReturnUser(new User { Name = "Diana", Email = "Diana@rea.ru" }); 
            User user = userPool.GetUser(); 
            Console.WriteLine("Name: {0}, Email: {1}", user.Name, user.Email); 
            userPool.ReturnUser(user); 
            Console.ReadKey(); 
        } 
    } 
}
