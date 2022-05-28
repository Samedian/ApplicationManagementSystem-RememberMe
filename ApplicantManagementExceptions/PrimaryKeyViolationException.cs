using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantManagemenSystemtExceptions
{
    public class PrimaryKeyViolationException :Exception
    {
        public PrimaryKeyViolationException(string message):base(message)
        {

        }
    }
}
