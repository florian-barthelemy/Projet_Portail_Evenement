using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_project.Exceptions
{
    public class ListEmptyException : Exception
    {
        public ListEmptyException()
        {
        }

        public ListEmptyException(string message) : base(message)
        {
        }

    }
}
