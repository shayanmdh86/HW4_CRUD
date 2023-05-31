using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Service.Exception
{
    public class UserIsNotFundException : ApplicationException
    {
        public override string Message => "User is not fund!! ";
    }
}
