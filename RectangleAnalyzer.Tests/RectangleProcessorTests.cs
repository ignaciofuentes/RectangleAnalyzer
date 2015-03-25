using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RectangleAnalyzer.Core;
using System.Drawing;
using System.Linq;

namespace RectangleAnalyzer.Tests
{
    [TestClass]
    public class RectangleProcessorTests
    {
        [TestClass]
        public class TheGetAnalysisMethod
        {

            [TestMethod]
            public void ReturnsFiveOutcomesForDifferentValueRectangles()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 1, 10, 10);
                RectangleF rec2 = new RectangleF(0, 0, 10, 10);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.GetAnalysis();
                //Assert
                Assert.AreEqual(5, result.GetSummary().Count());
            }
            [TestMethod]
            public void ReturnsOnlyEquivalencyForEqualValueRectangles()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 10, 10);
                RectangleF rec2 = new RectangleF(0, 0, 10, 10);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.GetAnalysis();
                //Assert
                Assert.AreEqual("Rectangles are equivalent", result.GetSummary().Single());
            }
        }
        [TestClass]
        public class TheIntersecttionMethod
        {
            private IntersectionAnalysis SetUp(float x1, float y1, float width1, float height1, float x2, float y2, float width2, float height2)
            {
                //Arrange
                RectangleF rec1 = new RectangleF(x1, y1, width1, height1);
                RectangleF rec2 = new RectangleF(x2, y2, width2, height2);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Intersection();

                return result;
                //Assert
                //Assert.IsTrue(result.IntersectionPresent);

            }


            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheTopLeft()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 3, 1, 2, 2);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(4, 3)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(5, 2)));
            }
            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheMidLeft()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 3, 4, 2, 2);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(4, 4)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(4, 6)));
            }

            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheBottomLeft()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 3, 7, 2, 2);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(4, 7)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(5, 8)));
            }

            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheMidBottom()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 6, 7, 2, 2);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(6, 8)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(8, 8)));
            }

            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheBottomRight()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 9, 7, 2, 2);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(10, 7)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(9, 8)));
            }

            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheMidRight()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 9, 4, 2, 2);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(10, 4)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(10, 6)));
            }

            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheTopRight()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 9, 1, 2, 2);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(9, 2)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(10, 3)));
            }

            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheMidTop()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 6, 1, 2, 2);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(6, 2)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(8,2)));
            }

            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheWholeLeft()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 3, 1, 2, 10);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(5, 2)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(5, 8)));
            }

            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheWholeMiddle()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 6, 1, 1, 10);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(6, 2)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(7, 2)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(6, 8)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(7, 8)));
            }

            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangleOnTheWholeRight()
            {
                //Arrange And Act
                var result = SetUp(4, 2, 6, 6, 9, 1, 2, 10);
                //Assert
                Assert.IsTrue(result.IntersectionPresent);
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(9, 2)));
                Assert.IsTrue(result.IntersectionPoints.Contains(new PointF(9, 8)));
            }

            [TestMethod]
            public void ReturnsNoIntersectionForNonOverlappingRectangles()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 10, 10);
                RectangleF rec2 = new RectangleF(11, 0, 10, 10);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Intersection();

                //Assert
                Assert.IsFalse(result.IntersectionPresent);
            }

            [TestMethod]
            public void ReturnsNoIntersectionForFullyContainedRectangles()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(1, 1, 1, 1);
                RectangleF rec2 = new RectangleF(0, 0, 10, 10);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Intersection();

                //Assert
                Assert.IsFalse(result.IntersectionPresent);
            }
        }
        [TestClass]
        public class TheContainmentMethod
        {

            [TestMethod]
            public void ReturnsContainmentForRectangle1ContainedWithinRectangle2()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(1, 1, 1, 1);
                RectangleF rec2 = new RectangleF(0, 0, 10, 10);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Containment();

                //Assert
                Assert.IsTrue(result.ContainmentPresent);
                Assert.IsFalse(result.Rectangle1ContainsRectangle2);
            }

            [TestMethod]
            public void ReturnsContainmentForRectangle2ContainedWithinRectangle1()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 10, 10);
                RectangleF rec2 = new RectangleF(1, 1, 1, 1);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Containment();

                //Assert
                Assert.IsTrue(result.ContainmentPresent);
                Assert.IsTrue(result.Rectangle1ContainsRectangle2);
            }

            [TestMethod]
            public void ReturnsContainmentForRectangle1ContainedAndSharingSideWithRectangle2()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 1, 1);
                RectangleF rec2 = new RectangleF(0, 0, 10, 10);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Containment();

                //Assert

                Assert.IsTrue(result.ContainmentPresent);
                Assert.IsFalse(result.Rectangle1ContainsRectangle2);
            }



            [TestMethod]
            public void ReturnsNoContainmentForRectanglesNotContainedWithinEachOther()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 10, 10);
                RectangleF rec2 = new RectangleF(1, 0, 10, 10);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Containment();

                //Assert
                Assert.IsFalse(result.ContainmentPresent);
            }

        }
        [TestClass]
        public class TheAdjacencyMethod
        {
            [TestMethod]
            public void ReturnsAdjacencyForRectanglesAdjacentWithPartialSegmentOnTheSide()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(4, 2, 3, 3);
                RectangleF rec2 = new RectangleF(7, 3, 1, 1);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Adjacency();

                //Assert
                Assert.IsTrue(result.AdjacencyPresent);
            }
            [TestMethod]
            public void ReturnsAdjacencyForInvertedRectanglesAdjacentWithPartialSegmentOnTheSide()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(7, 3, 1, 1);
                RectangleF rec2 = new RectangleF(4, 2, 3, 3);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Adjacency();

                //Assert
                Assert.IsTrue(result.AdjacencyPresent);
            }

            [TestMethod]
            public void ReturnsAdjacencyForRectanglesAdjacentWithWholeSegmentOnTheSide()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(4, 2, 3, 3);
                RectangleF rec2 = new RectangleF(7, 2, 3, 3);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Adjacency();

                //Assert
                Assert.IsTrue(result.AdjacencyPresent);
            }

            [TestMethod]
            public void ReturnsAdjacencyForInvertedRectanglesAdjacentWithWholeSegmentOnTheSide()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(7, 2, 3, 3);
                RectangleF rec2 = new RectangleF(4, 2, 3, 3);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Adjacency();

                //Assert
                Assert.IsTrue(result.AdjacencyPresent);
            }

            [TestMethod]
            public void ReturnsAdjacencyForRectanglesAdjacentWithPartialSegmentOnTheTop()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(4, 2, 3, 3);
                RectangleF rec2 = new RectangleF(5, 1, 1, 1);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Adjacency();

                //Assert
                Assert.IsTrue(result.AdjacencyPresent);
            }

            [TestMethod]
            public void ReturnsAdjacencyForInvertedRectanglesAdjacentWithPartialSegmentOnTheTop()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(5, 1, 1, 1);
                RectangleF rec2 = new RectangleF(4, 2, 3, 3);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Adjacency();

                //Assert
                Assert.IsTrue(result.AdjacencyPresent);
            }
            [TestMethod]
            public void ReturnsAdjacencyForRectanglesAdjacentWithWholeSegmentOnTheTop()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(4, 0, 3, 2);
                RectangleF rec2 = new RectangleF(4, 2, 3, 3);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Adjacency();

                //Assert
                Assert.IsTrue(result.AdjacencyPresent);
            }


            [TestMethod]
            public void ReturnsNoAdjacencyForRectanglesThatShareSideEdgeButNotTopEdge()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(1, 0, 1, 1);
                RectangleF rec2 = new RectangleF(0, 99, 1, 1);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Adjacency();

                //Assert
                Assert.IsFalse(result.AdjacencyPresent);
            }


            [TestMethod]
            public void ReturnsNoAdjacencyForRectanglesNotAdjacentToEachOther()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(2, 0, 2, 2);
                RectangleF rec2 = new RectangleF(0, 3, 2, 2);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Adjacency();

                //Assert
                Assert.IsFalse(result.AdjacencyPresent);
            }
            [TestMethod]
            public void ReturnsNoAdjacencyForInvertedRectanglesNotAdjacentToEachOther()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 3, 2, 2);
                RectangleF rec2 = new RectangleF(2, 0, 2, 2);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Adjacency();

                //Assert
                Assert.IsFalse(result.AdjacencyPresent);
            }
        }

        [TestClass]
        public class TheCongruenceMethod
        {
            [TestMethod]
            public void ReturnsNoCongruencyForNonCongruentRectangles()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 2, 2);
                RectangleF rec2 = new RectangleF(0, 2, 2, 3);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Congruence();

                //Assert
                Assert.IsFalse(result.CongruencePresent);
            }

            [TestMethod]
            public void ReturnsCongruencyForCongruentRectanglesWithMatchingWidthAndHeight()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 2, 4);
                RectangleF rec2 = new RectangleF(0, 0, 2, 4);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Congruence();

                //Assert
                Assert.IsTrue(result.CongruencePresent);
            }

            [TestMethod]
            public void ReturnsCongruencyForCongruentRectanglesWithOppositeWidthAndHeight()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 4, 2);
                RectangleF rec2 = new RectangleF(0, 0, 2, 4);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Congruence();

                //Assert
                Assert.IsTrue(result.CongruencePresent);
            }
        }

        [TestClass]
        public class TheSimilarityMethod
        {
            [TestMethod]
            public void ReturnsNoSimilarityForNonSimilarRectangles()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 2, 2);
                RectangleF rec2 = new RectangleF(0, 2, 2, 3);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Similarity();

                //Assert
                Assert.IsFalse(result.SimilarityPresent);
            }

            [TestMethod]
            public void ReturnsSimilarityForRectanglesWithEqualMatchingRatioOnWidthAndHeight()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 2, 4);
                RectangleF rec2 = new RectangleF(0, 0, 4, 8);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Similarity();

                //Assert
                Assert.IsTrue(result.SimilarityPresent);
            }

            [TestMethod]
            public void ReturnsSimilarityForRectanglesWithEqualOppositeRatioOnWidthAndHeight()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 2, 4);
                RectangleF rec2 = new RectangleF(0, 0, 8, 4);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Similarity();

                //Assert
                Assert.IsTrue(result.SimilarityPresent);
            }
        }
    }
}
