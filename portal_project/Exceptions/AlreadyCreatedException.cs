using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Exceptions
{
    public class AlreadyCreatedException : Exception
    {
        public AlreadyCreatedException()
        {
        }

        public AlreadyCreatedException(string message) : base(message)
        {
        }

    }
}
