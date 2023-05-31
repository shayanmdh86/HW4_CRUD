using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Service.Exception
{
    public class BirthDateException : ApplicationException
    {
        public override string Message => "Your birth date is not correct!!";
    }
}
