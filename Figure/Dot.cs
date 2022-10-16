using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dots
{
    internal class Dot
    {
        private double x;
        private double y;
        private double z;

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public double Z { get { return z; } set { z = value; } }

        public Dot(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }

        public void Show()
        {
            Console.WriteLine($"({X},{Y},{Z})");
        }


        public double Dist0()
        {
            return Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public static double Distance_between(Dot a, Dot b)
        {
            return Math.Sqrt(Math.Pow((a.x - b.x), 2) + Math.Pow((a.y - b.y), 2) + Math.Pow((a.z - b.z), 2));
        }

        public static Dot operator +(Dot a, Dot b)
        {
            Dot c = new(a.x + b.x, a.y + b.y, a.z + b.z);
            return c;
        }

        public static double Scalar(Dot a, Dot b)
        {
            return (a.x * b.x + a.y * b.y + a.z * b.z);
        }

        public static Dot operator *(Dot a, Dot b)
        {
            Dot c = new((a.y * b.z - a.z * b.y), (a.x * b.z - a.z * b.x), (a.x * b.y - a.y * b.x));
            return c;
        }





    }
}