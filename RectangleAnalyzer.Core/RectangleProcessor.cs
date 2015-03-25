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

        public RectanglesAnalysis GetAnalysis()
        {
            var RectanglesAnalysis = new RectanglesAnalysis();
            return new RectanglesAnalysis
            {
                EquivalencyAnalysis = Equivalence(),
                IntersectionAnalysis = Intersection(),
                ContainmentAnalysis = Containment(),
                AdjacencyAnalysis = Adjacency(),
                CongruenceAnalysis = Congruence(),
                SimilarityAnalysis = Similarity()
            };
        }

        public EquivalencyAnalysis Equivalence()
        {
            var analysis = new EquivalencyAnalysis
            {
                EquivalencyPresent = false,
                Message = "Rectangles are not equivalent"
            };

            if (rectangle1 == rectangle2)
            {
                analysis.EquivalencyPresent = true;
                analysis.Message = "Rectangles are equivalent";
            }
            return analysis;

        }

        public IntersectionAnalysis Intersection()
        {
            var analysis = new IntersectionAnalysis
            {
                IntersectionPresent = false,
                Message = "Rectangles do not intersect"
            };

            if (rectangle1.IntersectsWith(rectangle2))
            {
                var intersection = RectangleF.Intersect(rectangle1, rectangle2);

                if (rectangle1 != intersection && rectangle2 != intersection)
                {
                    analysis.IntersectionPresent = true;
                    var builder = new StringBuilder();
                    builder.AppendFormat("Rectangles intersect within an area defined as: (X:{0}, Y:{1}, Width:{2}, Height:{3})", intersection.X, intersection.Y, intersection.Width, intersection.Height);

                    var points = GetIntersectionPoints(intersection);
                    analysis.IntersectionPoints = points;
                    var pointsresult = String.Join(",", points.Select(p => String.Format("(X:{0}, Y:{1})", p.X, p.Y)));
                    builder.AppendFormat(". Intersection Points: {0}", pointsresult);

                    analysis.Message = builder.ToString();
                }

            }
            return analysis;

        }

        private List<PointF> GetIntersectionPoints(RectangleF intersection)
        {
            var points = new List<PointF>();
            var topLeft = intersection.Location;
            var topRight = new PointF(intersection.Right, intersection.Top);
            var bottomLeft = new PointF(intersection.X, intersection.Bottom);
            var bottomRight = new PointF(intersection.Right, intersection.Bottom);

            if ((topLeft.X == rectangle1.Left && topLeft.Y == rectangle2.Top) || (topLeft.X == rectangle2.Left && topLeft.Y == rectangle1.Top))
            {
                points.Add(topLeft);
            }
            if ((topRight.X == rectangle1.Right && topRight.Y == rectangle2.Top) || (topRight.X == rectangle2.Right && topRight.Y == rectangle1.Top))
            {
                points.Add(topRight);
            }
            if ((bottomLeft.X == rectangle1.Left && bottomLeft.Y == rectangle2.Bottom) || (bottomLeft.X == rectangle2.Left && bottomLeft.Y == rectangle1.Bottom))
            {
                points.Add(bottomLeft);
            }
            if ((bottomRight.X == rectangle2.Right && bottomRight.Y == rectangle1.Bottom) || (bottomRight.X == rectangle1.Right && bottomRight.Y == rectangle2.Bottom))
            {
                points.Add(bottomRight);
            }

            return points;
        }

        public ContainmentAnalysis Containment()
        {
            var containmentAnalysis = new ContainmentAnalysis
            {
                ContainmentPresent = false,
                Message = "Rectangles are not contained within each other"
            };

            if (rectangle1.Contains(rectangle2))
            {
                containmentAnalysis.ContainmentPresent = true;
                containmentAnalysis.Rectangle1ContainsRectangle2 = true;
                containmentAnalysis.Message = "Rectangle 1 contains Rectangle 2";
            }
            else if (rectangle2.Contains(rectangle1))
            {
                containmentAnalysis.ContainmentPresent = true;
                containmentAnalysis.Rectangle1ContainsRectangle2 = false;
                containmentAnalysis.Message = "Rectangle 2 contains Rectangle 1";
            }
            return containmentAnalysis;
        }

        public AdjacencyAnalysis Adjacency()
        {
            var adjacencyAnalysis = new AdjacencyAnalysis();
            adjacencyAnalysis.AdjacencyPresent = false;
            adjacencyAnalysis.Message = "Rectangles are not adjacent to each other";
            if (rectangle1.Right == rectangle2.Left || rectangle2.Right == rectangle1.Left || rectangle1.Top == rectangle2.Bottom || rectangle2.Top == rectangle1.Bottom)
            {
                var intersection = RectangleF.Intersect(rectangle1, rectangle2);
                if (!(intersection.Width == 0 && intersection.Height == 0))
                {
                    adjacencyAnalysis.AdjacencyPresent = true;
                    adjacencyAnalysis.Message = "Rectangles are adjacent to each other";
                }
            }
            return adjacencyAnalysis;
        }

        public CongruenceAnalysis Congruence()
        {
            var congruenceAnalysis = new CongruenceAnalysis()
            {
                CongruencePresent = false,
                Message = "Rectangles are not congruent"
            };
            if ((rectangle1.Height == rectangle2.Height && rectangle1.Width == rectangle2.Width) || (rectangle1.Height == rectangle2.Width && rectangle1.Width == rectangle2.Height))
            {
                congruenceAnalysis.CongruencePresent = true;
                congruenceAnalysis.Message = "Rectangles are congruent";
            }

            return congruenceAnalysis;
        }

        public SimilarityAnalysis Similarity()
        {
            var similarityAnalysis = new SimilarityAnalysis
            {
                SimilarityPresent = false,
                Message = "Rectangles are not similar"
            };
            if ((rectangle1.Width / rectangle1.Height == rectangle2.Width / rectangle2.Height) || (rectangle1.Width / rectangle1.Height == rectangle2.Height / rectangle2.Width))
            {
                similarityAnalysis.SimilarityPresent = true;
                similarityAnalysis.Message = "Rectangles are similar";
            }
            return similarityAnalysis;
        }
    }
}
