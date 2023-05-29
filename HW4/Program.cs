using DocumentFormat.OpenXml.Office2013.Excel;
using HW4.Entity;
using HW4.Service;

namespace HW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService user = new UserService();
            Console.WriteLine("Hello, what operation do you want to do?:\n1-Creat User \n2-Update User \n" +
                "3-Delete User \n4-Reed User List ");

            int operation =Convert.ToInt32(Console.ReadLine());

            if (operation == 1)
            {
                Console.Clear();
                Console.WriteLine("Please insert your name: ");
                string inputName=Console.ReadLine();
                string inputMobile=Console.ReadLine();
                DateTime inputBirth=Convert.ToDateTime(Console.ReadLine());
                user.CreateUser(inputName, inputMobile, inputBirth);

            }

        }
    }
}