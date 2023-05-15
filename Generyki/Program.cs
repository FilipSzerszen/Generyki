using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Generyki
{
    class Program
    {
        public delegate void Display(string value);
        public delegate bool GenericPredicate<T>(T value);

        static int Count<T>(IEnumerable<T> elements, GenericPredicate<T> predicate)
        {
            int counter = 0;
            foreach (T element in elements)
            {
                if (predicate(element)) counter++;
            }
            return counter;
        }
        static void DisplayInt(IEnumerable<int> numbers, Display methodName)
        {
            foreach (var number in numbers) methodName(number.ToString());
        }
        
        static void Main(string[] args)
        {
            //predykaty
            Display display = Console.WriteLine;
            Display display2 = Console.Write;
            Display display3 = (string value) => Console.Write(value + " ");

            display("Test");
            var numbers = new int[] { 10, 30, 50 };
            DisplayInt(numbers, display);
            Console.WriteLine("\r\n");
            DisplayInt(numbers, display2);
            Console.WriteLine("\r\n");
            DisplayInt(numbers, display3);

            var count = Count(numbers, (int value)=>value>35);
            Console.WriteLine("\r\n"+count +"\r\n");

            var strings = new string[]{ "Generic", "Strings", "Test" };
            count = Count(strings, s => s.Length > 4);
            Console.WriteLine(count + "\r\n");

            //generyki
            var restaurants = new List<Restautrant>();
            var result = new PaginatedResult<Restautrant>();

            result.Results = restaurants;

            var users = new List<User>();
            //result.Results = users; //compile error

            //var stringRepository = new Repository<string>();
            //stringRepository.AddElement("some value");

            //var getElement = stringRepository.GetElement(0);

            var userRepository = new Repository<string, User>();
            userRepository.AddElement("Bill", new User() { Name = "Bill" });
            User bill = userRepository.GetElement("Bill");

            int[] intArray = new int[] { 1, 2, 5 };
            Utils.Swap(ref intArray[0], ref intArray[2]);
            //Console.WriteLine(string.Join(" ", intArray));


        }
    }
}
