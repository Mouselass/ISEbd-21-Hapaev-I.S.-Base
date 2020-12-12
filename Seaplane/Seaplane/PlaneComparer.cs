using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seaplane
{
    class PlaneComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {            
            if (x is WaterPlane && y is WaterPlane)
            {
                return ComparerWaterPlane((WaterPlane)x, (WaterPlane)y);
            }
            if (x is WaterPlane && y is Plane)
            {
                return -1;
            }
            if (x is Plane && y is WaterPlane)
            {
                return 1;
            }
            if (x is Plane && y is Plane)
            {
                return ComparerPlane((Plane)x, (Plane)y);
            }
            return 0;
        }

        private int ComparerPlane(Plane x, Plane y)
        {
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }

        private int ComparerWaterPlane(WaterPlane x, WaterPlane y)
        {
            var res = ComparerPlane(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if (x.Star != y.Star)
            {
                return x.Star.CompareTo(y.Star);
            }
            if (x.Wing != y.Wing)
            {
                return x.Wing.CompareTo(y.Wing);
            }
            if (x.Floater != y.Floater)
            {
                return x.Floater.CompareTo(y.Floater);
            }
            return 0;
        }
    }
}