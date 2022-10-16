using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dots;

namespace _4dots
{
    internal class Figure
    {
        private Dot vert1;
        private Dot vert2;
        private Dot vert3;
        private Dot vert4;

        public Figure(Dot vert1, Dot vert2, Dot vert3, Dot vert4)
        {
            this.vert1 = vert1;
            this.vert2 = vert2;
            this.vert3 = vert3;
            this.vert4 = vert4;
        }

        public double area()
        {
            Dot Vec1 = new(vert1.X - vert3.X, vert1.Y - vert3.Y, vert1.Z - vert3.Z);
            Dot Vec2 = new(vert2.X - vert4.X, vert2.Y - vert4.Y, vert2.Z - vert4.Z);
            double phi = Math.Acos((Dot.Scalar(Vec1, Vec2)) / (Vec1.Dist0() * Vec2.Dist0()));
            return 0.5 * Vec1.Dist0() * Vec2.Dist0() * Math.Sin(phi);
        }

        public static double diagonal(Dot a, Dot b)
        {
            return Dot.Distance_between(a, b);
        }

        public Boolean isconvex()
        {   
            return false;
        }

        public String Structure()
        {
            Dot Vec1 = new(vert2.X - vert1.X, vert2.Y - vert1.Y, vert2.Z - vert1.Z);
            Dot Vec2 = new(vert3.X - vert2.X, vert3.Y - vert2.Y, vert3.Z - vert2.Z);
            Dot Vec3 = new(vert4.X - vert3.X, vert4.Y - vert3.Y, vert4.Z - vert3.Z);
            Dot Vec4 = new(vert1.X - vert4.X, vert1.Y - vert4.Y, vert1.Z - vert4.Z);
            double phi1 = (Math.Acos((Dot.Scalar(Vec4, Vec1)) / (Vec4.Dist0() * Vec1.Dist0()))) * 180 / Math.PI;
            double phi2 = (Math.Acos((Dot.Scalar(Vec1, Vec2)) / (Vec1.Dist0() * Vec2.Dist0()))) * 180 / Math.PI;
            double phi3 = (Math.Acos((Dot.Scalar(Vec2, Vec3)) / (Vec2.Dist0() * Vec3.Dist0()))) * 180 / Math.PI;
            double phi4 = (Math.Acos((Dot.Scalar(Vec3, Vec4)) / (Vec3.Dist0() * Vec4.Dist0()))) * 180 / Math.PI;

            if (phi1 * phi2 * phi3 * phi4 == Math.Pow(90, 4))
            {
                if (Vec1.Dist0() == Vec2.Dist0() && Vec2.Dist0() == Vec3.Dist0() && Vec3.Dist0() == Vec4.Dist0())
                    return "Square";
                else
                    return "Rectangle";
            }
            else
            {
                if (((Vec1.Y * Vec3.Z - Vec1.Z * Vec3.Y) - (Vec1.X * Vec3.Z - Vec1.Z * Vec3.X) + (Vec1.X * Vec3.Y - Vec1.Y * Vec3.X) == 0) & (((Vec2.Y * Vec4.Z - Vec2.Z * Vec4.Y) - (Vec2.X * Vec4.Z - Vec2.Z * Vec4.X) + (Vec2.X * Vec4.Y - Vec2.Y * Vec4.X) == 0)))
                {
                    if ((Vec1.Dist0() == Vec3.Dist0()) ^ (Vec1.Dist0() == Vec3.Dist0()))
                        return "Rhombus";
                    else
                        return "Parallelogram";
                }
                if (((Vec1.Y * Vec3.Z - Vec1.Z * Vec3.Y) - (Vec1.X * Vec3.Z - Vec1.Z * Vec3.X) + (Vec1.X * Vec3.Y - Vec1.Y * Vec3.X) == 0) & (Vec1.Dist0() != Vec3.Dist0()))
                    return "Trapeze";
                if (((Vec2.Y * Vec4.Z - Vec2.Z * Vec4.Y) - (Vec2.X * Vec4.Z - Vec2.Z * Vec4.X) + (Vec2.X * Vec4.Y - Vec2.Y * Vec4.X) == 0) & (Vec1.Dist0() != Vec3.Dist0()))
                    return "Trapeze";
            }
            return "None";
        }

        public Boolean Coplanar()
        {
            Dot Vec1 = new(vert3.X - vert1.X, vert3.Y - vert1.Y, vert3.Z - vert1.Z);
            Dot Vec2 = new(vert2.X - vert1.X, vert2.Y - vert1.Y, vert2.Z - vert1.Z);
            Dot Vec3 = new(vert4.X - vert1.X, vert4.Y - vert1.Y, vert4.Z - vert1.Z);

            double det = (Vec1.X * Vec2.Y * Vec3.Z) + (Vec1.Y * Vec2.Z * Vec3.X) + (Vec1.Z * Vec2.X * Vec3.Y) - (Vec1.Z * Vec2.Y * Vec3.X) - ( Vec1.Y * Vec2.X * Vec3.Z) - ( Vec1.X * Vec2.Z * Vec3.Y);
            if (det == 0)
            {
                return true;
            }
            return false;
        }

    }
}
