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

        void CreateUser(string name, string mobile, DateTime birthdate);
        List<User> ReadUser();
        void UpdateUser(int id, string name, string mobile);
        void DeleteUser(int id);
    }
}
 