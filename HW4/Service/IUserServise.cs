using HW4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Service
{
    public interface IUserServise
    {

        void CreateUser(string fullName, string phone, DateTime dateOfBirth);
        List<User> ReadUser();
        void UpdateUser(int id, string newName, string newPhone);
       // void DeleteUser(int id);
    }
}
 