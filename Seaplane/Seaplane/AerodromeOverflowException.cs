using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaplane
{
    public class AerodromeOverflowException : Exception
    {
        public AerodromeOverflowException() : base("На аэродроме нет свободных мест")
        { }
    }
}
