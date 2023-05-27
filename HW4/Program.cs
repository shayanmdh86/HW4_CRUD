using HW4.Service;

namespace HW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService user = new UserService();
            string name = Console.ReadLine();
            string Mobile = Console.ReadLine();
            string brth = Console.ReadLine();
            user.Create(name, Mobile,brth);
            Console.ReadLine();
        }
    }
}