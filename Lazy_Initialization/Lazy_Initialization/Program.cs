using System;
namespace LazyInitialization { 
    class Program { 
        static void Main(string[] args) { 
            LazyObject lazyObject = new LazyObject();

            Console.WriteLine($"Объект инициализирован: {lazyObject.IsInitialized}"); 
            Console.WriteLine($"Значение свойства Value: {lazyObject.Value}"); 
            Console.WriteLine($"Объект инициализирован: {lazyObject.IsInitialized}");
            Console.ReadLine(); } 
    } 
    public class LazyObject { 
        private int _value; 
        private bool _isInitialized; 
        public int Value { get { if (!_isInitialized) { Initialize(); } return _value; } } 
        public bool IsInitialized { get { return _isInitialized; } } 
        private void Initialize() { 
            _value = 1; 
            _isInitialized = true; 
        } 
    } 
}