using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delaunay_Triangulation
{
    class Circle
    {
        private RealPoint center;
        private float radius;

        Circle()
        {
            radius = 0.0f;
        }

        public Circle(RealPoint center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public RealPoint Center
        {
            get
            {
                return center;
            }
        }

        public float Radius
        {
            get
            {
                return radius;
            }
        }

        public void SetCircle(RealPoint center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public bool inside(RealPoint p)
        {
            if (center.distanceSq(p) < (radius * radius))
                return true;
            else
                return false;
        }

        public void circumCircle(RealPoint p1, RealPoint p2, RealPoint p3)
        {
            float centerPoint;

            centerPoint = Vector.crossProduct(p1, p2, p3);

            if (centerPoint != 0.0)
            {
                float p1Sq, p2Sq, p3Sq;
                float num, den;
                float cx, cy;

                p1Sq = p1.X * p1.X + p1.Y * p1.Y;
                p2Sq = p2.X * p2.X + p2.Y * p2.Y;
                p3Sq = p3.X * p3.X + p3.Y * p3.Y;
                num = p1Sq * (p2.Y - p3.Y) + p2Sq * (p3.Y - p1.Y) + p3Sq * (p1.Y - p2.Y);
                cx = num / (2.0f * centerPoint);
                num = p1Sq * (p3.X - p2.X) + p2Sq * (p1.X - p3.X) + p3Sq * (p2.X - p1.X);
                cy = num / (2.0f * centerPoint);


                center = new RealPoint(cx, cy);
            }
            radius = center.distance(p1);

        }
    }
}
