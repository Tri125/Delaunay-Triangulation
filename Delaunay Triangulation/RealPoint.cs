using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delaunay_Triangulation
{
    class RealPoint
    {
        private float x, y;

        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }


        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public RealPoint()
        {
            x = y = 0.0f;
        }

        public RealPoint(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public RealPoint(RealPoint p)
        {
            x = p.x;
            y = p.y;
        }


        public float distance(RealPoint p)
        {
            return (float)Math.Sqrt(distanceSq(p));
        }

        public float distanceSq(RealPoint p)
        {
            float dx, dy;

            dx = p.x - x;
            dy = p.y - y;

            return (float)(dx * dx + dy * dy);
        }


        public override string ToString()
        {
            return "RealPoint: " + "X " + x + "Y " + y;
        }

    }
}
