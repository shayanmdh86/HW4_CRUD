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
            bool run = true;
            while (run)
            {
                Menu.RunMenu();
                int theOperation = Convert.ToInt32(Console.ReadLine());
                if (theOperation == 1)
                {
                    Console.WriteLine("name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Mobiale:");
                    string mobile = Console.ReadLine();
                    if (mobile == null || mobile.Length != 11)
                    {
                        Console.WriteLine("mobile is not correct<<");

                    }
                    else
                    {
                        Console.WriteLine("bith: ");
                        string berth = Console.ReadLine();
                        DateTime birthDate;
                        bool test = DateTime.TryParse(berth, out birthDate);
                        if (birthDate >= DateTime.Now || !test)
                        {
                            Console.WriteLine("Your Birthdate is notcorrect!!");
                        }
                        else
                        {
                            user.CreateUser(name, mobile, birthDate);
                            Console.WriteLine("User created successfully");
                            Console.ReadKey();
                            Console.WriteLine("Press Q to exit, otherwise you continue ");
                            char Key = Convert.ToChar(Console.ReadLine());
                            if (Key == 'Q')
                            {
                                run = false;
                            }
                        }
                    }
                }
                else if (theOperation == 2) 
                {
                    user.ReadUser();  

                    Console.WriteLine("Select the user id to update: ");
                    int inputId = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("Please enter new name: ");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Please enter new mobile: ");
                    string newMobile = Console.ReadLine();

                    user.UpdateUser(inputId, newName, newMobile);
                    Console.WriteLine("User update successfully");
                    Console.ReadKey();

                } 
            }
        }
    }
}