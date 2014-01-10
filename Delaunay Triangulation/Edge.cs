using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delaunay_Triangulation
{
    class Edge
    {
        private int start, end;
        private int leftFace, rightFace;

        public Edge()
        {
            start = end = 0;
        }

        public Edge(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public int LeftFace
        {
            get
            {
                return leftFace;
            }

            set
            {
                leftFace = value;
            }
        }

        public int RightFace
        {
            get
            {
                return rightFace;
            }

            set
            {
                rightFace = value;
            }
        }

        public int Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }

        public int End
        {
            get
            {
                return end;
            }

            set
            {
                end = value;
            }
        }



        public override string ToString()
        {
            return "Edge: " + "Start " + start + "End " + end;
        }

    }
}
