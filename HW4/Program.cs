using HW4.Entity;
using HW4.Service;

namespace HW4
{
    internal class Program
    {
        static void Main(string[] args)
        {


            UserService user = new UserService();
            string name = Console.ReadLine();
            string MOBILE = Console.ReadLine();
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            user.CreateUser(name,MOBILE,date);

        }
    }
}