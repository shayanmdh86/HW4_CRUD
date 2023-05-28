using HW4.Service;

namespace HW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
           
            UserService user = new UserService();
            //string name = Console.ReadLine();
            //string Mobile = Console.ReadLine();
            //var brth =Convert.ToDateTime(Console.ReadLine());
            //user.Create(name, Mobile, brth);
            user.ReadUser();
            Console.ReadLine();
        }
    }
}