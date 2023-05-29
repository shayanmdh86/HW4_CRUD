using DocumentFormat.OpenXml.Office2013.Excel;
using HW4.Entity;
using HW4.Menu;
using HW4.Service;

namespace HW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService user = new UserService();
           
            int operation =Convert.ToInt32(Console.ReadLine());

            if (operation == 1)
            {
                Console.Clear();
                Console.WriteLine("Please insert your name: ");
                string inputName=Console.ReadLine();
                Console.WriteLine("Please insert your your phonenumber: ");
                string inputMobile=Console.ReadLine();
                Console.WriteLine("Please insert your birthdate: ");
                DateTime inputBirth=Convert.ToDateTime(Console.ReadLine());
                user.CreateUser(inputName, inputMobile, inputBirth);
                Console.ReadKey();

            }

        }
    }
}