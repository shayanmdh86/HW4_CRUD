using DocumentFormat.OpenXml.Office2013.Excel;
using HW4.Entity;
using HW4.Service;
using System.Reflection;
using HW4.Service.Exception;

namespace HW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService user = new UserService();
            bool run = true;
            string Key;
            while (run)
            {
                Menu.RunMenu();
                int theOperation = Convert.ToInt32(Console.ReadLine());
                if (theOperation == 1)
                {
                    try
                    {
                        Console.WriteLine("name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Mobiale:");
                        string mobile = Console.ReadLine();
                        if (mobile == null || mobile.Length != 11)
                        {
                            throw new MobileNotCorrectException();

                        }
                        else
                        {
                            Console.WriteLine("bith: ");
                            string berth = Console.ReadLine();
                            DateTime birthDate;
                            bool test = DateTime.TryParse(berth, out birthDate);
                            if (birthDate >= DateTime.Now || !test)
                            {
                                throw new BirthDateException();
                            }
                            else
                            {
                                user.CreateUser(name, mobile, birthDate);
                                Console.WriteLine("User created successfully");

                            }

                            Console.WriteLine("Press Q to exit, press C to continue ");
                            Key = Console.ReadLine();
                            while (Key != "Q" && Key != "C")
                            {
                                Console.WriteLine("Press Q to exit, press C to continue ");
                                Key = Console.ReadLine();

                            }
                            if (Key == "Q")
                                run = false;

                            else if (Key == "C")
                            {
                                run = true;
                               Console.Clear();
                            }

                        }
                    }
                    catch (MobileNotCorrectException e)
                    {
                        Console.WriteLine($"Exception: {e}");
                    }
                    catch (BirthDateException e)
                    {
                        Console.WriteLine($"Exception{e}");
                    }
                }
                
                else if (theOperation == 2) 
                {
                    try
                    {
                        var list = user.ReadUser();
                        foreach (var users in list)
                        {
                            Console.WriteLine($"ID = {users.Id} - Name = {users.Name} - PhoneNumber = {users.Mobile} " +
                                $"-  BirthDate = {users.BirthDate.ToString("yyyy-MM-dd")} - UserCreationTime = {users.CreateDate}");
                        }

                        Console.WriteLine("Select the user id to update: ");
                        int inputId = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();

                        Console.WriteLine("Please enter new name: ");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Please enter new mobile: ");
                        string newMobile = Console.ReadLine();
                        if (newMobile == null || newMobile.Length != 11)
                        {
                            throw new MobileNotCorrectException();

                        }
                        else
                        {
                            user.UpdateUser(inputId, newName, newMobile);
                            Console.WriteLine("User update successfully");
                        }

                        Console.WriteLine("Press Q to exit, press C to continue ");
                        Key = Console.ReadLine();
                        while (Key != "Q" && Key != "C")
                        {
                            Console.WriteLine("Press Q to exit, press C to continue ");
                            Key = Console.ReadLine();

                        }
                        if (Key == "Q")
                            run = false;

                        else if (Key == "C")
                            run = true;
                    }
                    catch(MobileNotCorrectException e)
                    {
                        Console.WriteLine($"Exception : {e}");
                    }
                }
                else if (theOperation==3)
                {
                    var list = user.ReadUser();
                    foreach (var users in list)
                    {
                        Console.WriteLine($"ID = {users.Id} - Name = {users.Name} - PhoneNumber = {users.Mobile} " +
                            $"-  BirthDate = {users.BirthDate.ToString("yyyy-MM-dd")} - UserCreationTime = {users.CreateDate}");
                    }
                    Console.WriteLine("Select the user id to Delete: ");
                    int inputId = Convert.ToInt32(Console.ReadLine());
                    user.DeleteUser(inputId);
                    Console.WriteLine("User delete successfully");
                    Console.WriteLine("Press Q to exit, press C to continue ");
                    Key = Console.ReadLine();
                    while (Key != "Q" && Key != "C")
                    {
                        Console.WriteLine("Press Q to exit, press C to continue ");
                        Key = Console.ReadLine();

                    }
                    if (Key == "Q")
                        run = false;

                    else if (Key == "C")
                        run = true;


                }
                else if (theOperation==4)
                {
                    var list = user.ReadUser();
                    foreach (var users in list)
                    {
                        Console.WriteLine($"ID = {users.Id} - Name = {users.Name} - PhoneNumber = {users.Mobile} " +
                            $"-  BirthDate = {users.BirthDate.ToString("yyyy-MM-dd")} - UserCreationTime = {users.CreateDate}");
                    }

                    Console.WriteLine("Press Q to exit, press C to continue ");
                    Key = Console.ReadLine();
                    while (Key != "Q" && Key != "C") 
                    {
                        Console.WriteLine("Press Q to exit, press C to continue ");
                        Key = Console.ReadLine();
                    
                    }
                    if (Key == "Q")
                        run = false;

                    else if (Key == "C")
                        run = true;

                }
            }
        }
    }
}