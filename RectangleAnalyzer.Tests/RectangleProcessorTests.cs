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
                Assert.AreEqual(5, result.Count());
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
                Assert.AreEqual("Rectangles are equivalent", result.Single());
            }


        }
        [TestClass]
        public class TheIntersecttionMethod
        {
            [TestMethod]
            public void ReturnsIntersectionForOverlappingRectangles()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 10, 10);
                RectangleF rec2 = new RectangleF(9, 9, 10, 10);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Intersection();
                //Assert
                Assert.AreEqual("Rectangles intersect within an area defined as: (X:9, Y:9, Width:1, Height:1)", result);
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
                Assert.AreEqual("Rectangles do not intersect", result);
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
                Assert.AreEqual("Rectangles do not intersect", result);
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
                Assert.AreEqual("Rectangle 2 contains Rectangle 1", result);
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
                Assert.AreEqual("Rectangle 1 contains Rectangle 2", result);
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
                Assert.AreEqual("Rectangle 2 contains Rectangle 1", result);
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
                Assert.AreEqual("Rectangles are not contained within each other", result);
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
                Assert.AreEqual("Rectangles are adjacent to each other", result);
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
                Assert.AreEqual("Rectangles are adjacent to each other", result);
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
                Assert.AreEqual("Rectangles are adjacent to each other", result);
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
                Assert.AreEqual("Rectangles are adjacent to each other", result);
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
                Assert.AreEqual("Rectangles are adjacent to each other", result);
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
                Assert.AreEqual("Rectangles are adjacent to each other", result);
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
                Assert.AreEqual("Rectangles are adjacent to each other", result);
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
                Assert.AreEqual("Rectangles are not adjacent to each other", result);
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
                Assert.AreEqual("Rectangles are not adjacent to each other", result);
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
                Assert.AreEqual("Rectangles are not adjacent to each other", result);
            }
        }

        [TestClass]
        public class TheCongruencyMethod
        {
            [TestMethod]
            public void ReturnsNoCongruencyForNonCongruentRectangles()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 2, 2);
                RectangleF rec2 = new RectangleF(0, 2, 2, 3);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Congruency();

                //Assert
                Assert.AreEqual("Rectangles are not congruent", result);
            }

            [TestMethod]
            public void ReturnsCongruencyForCongruentRectanglesWithMatchingWidthAndHeight()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 2, 4);
                RectangleF rec2 = new RectangleF(0, 0, 2, 4);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Congruency();

                //Assert
                Assert.AreEqual("Rectangles are congruent", result);
            }

            [TestMethod]
            public void ReturnsCongruencyForCongruentRectanglesWithOppositeWidthAndHeight()
            {
                //Arrange
                RectangleF rec1 = new RectangleF(0, 0, 4, 2);
                RectangleF rec2 = new RectangleF(0, 0, 2, 4);
                var processor = new RectangleProcessor(rec1, rec2);

                //Act
                var result = processor.Congruency();

                //Assert
                Assert.AreEqual("Rectangles are congruent", result);
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
                Assert.AreEqual("Rectangles are not similar", result);
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
                Assert.AreEqual("Rectangles are similar", result);
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
                Assert.AreEqual("Rectangles are similar", result);
            }
        }
    }
}
