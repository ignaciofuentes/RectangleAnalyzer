using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RectangleAnalyzer.Core
{
    public class RectangleProcessor
    {
        private RectangleF rectangle1;
        private RectangleF rectangle2;

        public RectangleProcessor(RectangleF rectangle1, RectangleF rectangle2)
        {
            this.rectangle1 = rectangle1;
            this.rectangle2 = rectangle2;
        }


        public IEnumerable<string> GetAnalysis()
        {
            if (rectangle1 == rectangle2)
            {
                yield return "Rectangles are equivalent";
            }
            else
            {
                yield return Intersection();
                yield return Containment();
                yield return Adjacency();
            }
        }

        public string Intersection()
        {
            if (rectangle1.IntersectsWith(rectangle2))
            {
                var intersection = RectangleF.Intersect(rectangle1, rectangle2);
                if (rectangle1 != intersection && rectangle2 != intersection)
                {
                    return String.Format("Rectangles intersect within an area defined as: (X:{0}, Y:{1}, Width:{2}, Height:{3})", intersection.X, intersection.Y, intersection.Width, intersection.Height);
                }
            }
            return "Rectangles do not intersect";

        }

        public string Containment()
        {
            if (rectangle1.Contains(rectangle2))
            {
                return "Rectangle 1 contains Rectangle 2";
            }
            else if (rectangle2.Contains(rectangle1))
            {
                return "Rectangle 2 contains Rectangle 1";
            }
            else return "Rectangles are not contained within each other";
        }




        public string Adjacency()
        {
            if (rectangle1.Right == rectangle2.Left || rectangle2.Right == rectangle1.Left || rectangle1.Top == rectangle2.Bottom || rectangle2.Top == rectangle1.Bottom)
            {
                var i = RectangleF.Intersect(rectangle1, rectangle2);
                if (!(i.Width == 0 && i.Height == 0))
                    return "Rectangles are adjacent to each other";
            }
            return "Rectangles are not adjacent to each other";
        }

    }
}
