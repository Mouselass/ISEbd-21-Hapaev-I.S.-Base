using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaplane
{
    public class PlaneNotFoundException : Exception
    {
        public PlaneNotFoundException(int i) : base("Не найден самолет по месту " + i)
        { }
    }
}
