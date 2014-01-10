using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delaunay_Triangulation
{
    //Real mathematical vector object
    class Vector
    {
        private float u, v;

        public Vector()
        {
            u = v = 0.0f;
        }

        public Vector(RealPoint p1, RealPoint p2)
        {
            u = p2.X - p1.X;
            v = p2.Y - p1.Y;
        }

        public Vector(float u, float v)
        {
            this.u = u;
            this.v = v;
        }

        public float dotProduct(Vector v)
        {
            return u * v.u + this.v * v.v;
        }

        public static float dotProduct(RealPoint p1, RealPoint p2, RealPoint p3)
        {
            float u1, v1, u2, v2;

            u1 = p2.X - p1.X;
            v1 = p2.Y - p1.Y;
            u2 = p3.X - p1.X;
            v2 = p3.Y - p1.Y;

            return u1 * u2 + v1 * v2;
        }


        public float crossProduct(Vector v) { return u * v.v - this.v * v.u; }


        public static float crossProduct(RealPoint p1, RealPoint p2, RealPoint p3)
        {
            float u1, v1, u2, v2;

            u1 = p2.X - p1.X;
            v1 = p2.Y - p1.Y;
            u2 = p3.X - p1.X;
            v2 = p3.Y - p1.Y;

            return u1 * v2 - v1 * u2;
        }

        public void setRealPoints(RealPoint p1, RealPoint p2)
        {
            u = p2.X - p1.X;
            v = p2.Y - p1.Y;
        }
    }
}
