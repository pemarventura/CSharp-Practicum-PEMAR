
using Application.Entities;

namespace Practicum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = DependencyResolver.CreateServer();

            while (true)
            {
                Console.WriteLine("Type the desired list of dishes: ");
                var order = Console.ReadLine();
                string output = server.TakeOrder(order);
                Console.WriteLine(output);
            }
        }
    }
}