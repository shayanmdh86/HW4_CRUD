using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.Service.Exception
{
    public class MobileNotCorrectException : ApplicationException
    {
        public override string Message => "Your Mobile is not correct !!";
    }
}
