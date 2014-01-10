using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delaunay_Triangulation
{
    class Triangulation
    {
        private const int UNDEFINED = -1;
        private const int UNIVERSE = 0;

        private int nPoints;
        RealPoint[] points;
        private int nEdges;
        private int maxEdges;
        Edge[] edges;


        public Triangulation(int nPoints)
        {
            this.nPoints = nPoints;
            this.points = new RealPoint[nPoints];
            for (int i = 0; i < nPoints; i++)
            {
                points[i] = new RealPoint();
            }

            maxEdges = 3 * nPoints - 6; //max number of edges
            edges = new Edge[maxEdges];
            for (int i = 0; i < maxEdges; i++)
            {
                edges[i] = new Edge();
            }
            nEdges = 0;
        }

        public void setNPoints(int nPoints)
        {
            Edge[] tmpEdge = edges;
            int tmpMaxEdges = maxEdges;
            maxEdges = 3 * nPoints - 6; //Max number of edges.
            edges = new Edge[maxEdges];

            int minMaxEdges;
            if (tmpMaxEdges < maxEdges)
                minMaxEdges = tmpMaxEdges;
            else
                minMaxEdges = maxEdges;


            for (int i = 0; i < minMaxEdges; i++)
            {
                this.edges[i] = tmpEdge[i];
            }

            for (int i = minMaxEdges; i < maxEdges; i++)
                this.edges[i] = new Edge();

            RealPoint[] tmpPoint = points;
            points = new RealPoint[nPoints];

            int minPoints;
            if (nPoints < this.nPoints)
                minPoints = nPoints;
            else
                minPoints = this.nPoints;

            for (int i = 0; i < minPoints; i++)
                this.points[i] = tmpPoint[i];

            for (int i = minPoints; i < nPoints; i++)
                this.points[i] = new RealPoint();

            this.nPoints = nPoints;
        }

        public void copyPoints(Triangulation t)
        {
            int n;

            if (t.nPoints < nPoints)
                n = t.nPoints;
            else
                n = nPoints;
            for (int i = 0; i < n; i++)
            {
                points[i].X = t.points[i].X;
                points[i].Y = t.points[i].Y;
            }
            nEdges = 0;
        }

        void addTriangle(int start, int end, int u)
        {
            addEdge(start, end);
            addEdge(end, u);
            addEdge(u, start);
        }

        public int addEdge(int start, int end)
        {
            return addEdge(start, end, UNDEFINED, UNDEFINED);
        }

        public int addEdge(int start, int end, int leftface, int rightface)
        {
            int e;

            e = findEdge(start, end);
            if (e == UNDEFINED)
                if (start < end)
                {
                    edges[nEdges].Start = start;
                    edges[nEdges].End = end;
                    edges[nEdges].LeftFace = leftface;
                    edges[nEdges].RightFace = rightface;
                    return nEdges++;
                }
                else
                {
                    edges[nEdges].Start = end;
                    edges[nEdges].End = start;
                    edges[nEdges].LeftFace = rightface;
                    edges[nEdges].RightFace = leftface;
                    return nEdges++;
                }
            else
                return UNDEFINED;
        }

        public int findEdge(int start, int end)
        {
            bool edgeExists = false;
            int index = -1;

            for (int i = 0; i < nEdges; i++)
            {
                if (edges[i].Start == start && edges[i].End == end || edges[i].Start == end && edges[i].End == start)
                {
                    edgeExists = true;
                    index = i;
                    break;
                }
            }
            if (edgeExists)
            {
                return index;
            }
            else
                return UNDEFINED;
        }


        public void updateLeftFace(int eI, int start, int end, int f)
        {
            if (!((edges[eI].Start == start && edges[eI].End == end) ||
                  (edges[eI].Start == end && edges[eI].End == start)))
                Console.Out.WriteLine("updateLeftFace: adj. matrix and edge table mismatch");
            if (edges[eI].Start == start && edges[eI].LeftFace == Triangulation.UNDEFINED)
                edges[eI].LeftFace = f;
            else if (edges[eI].End == start && edges[eI].RightFace == Triangulation.UNDEFINED)
                edges[eI].RightFace = f;
            else
                Console.Out.WriteLine("updateLeftFace: attempt to overwrite edge info");
        }

        public void print()
        {
            printPoints();
            printEdges();
        }

        public void printPoints()
        {
            for (int i = 0; i < nPoints; i++)
                Console.Out.WriteLine(points[i].ToString());
        }

        public void printEdges()
        {
            for (int i = 0; i < nEdges; i++)
                Console.Out.WriteLine(edges[i].ToString());
        }

    }
}
