using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Service
{
    public interface IUserServise
    {
        public void Create(string name, string mobile, string birthDate);
    }
}
