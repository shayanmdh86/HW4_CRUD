using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Service
{
    public static class Menu
    {
        public static void RunMenu()
        {
            Console.WriteLine("What do you want to do? \n1-CreateUser\n2-UpdateUser\n3-DeleteUser\n" +
                "4-ReadUser");
        }
    }
}
