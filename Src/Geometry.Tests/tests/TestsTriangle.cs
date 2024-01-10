using System;
using System.Numerics;
using Geometry.Exceptions;
using Xunit;

namespace Geometry.Tests
{
    public class TestsTriangle
    {
        [Fact]
        public void TestTriangleZeroArea()
        {
            IAreaProvider triangle = new Triangle(
                new Vector2(0f, 0f),
                new Vector2(0f, 0f),
                new Vector2(0f, 0f));
            Assert.True(triangle.GetArea() == 0f);
        }
        
        [Fact]
        public void TestTriangleHalfArea()
        {
            IAreaProvider triangle = new Triangle(
                new Vector2(0f, 0f),
                new Vector2(0f, 1f),
                new Vector2(1f, 0f));
            Assert.True(Math.Abs(triangle.GetArea() - 0.5f) < Constants.FloatTolerance);
        }
        
        [Fact]
        public void TestTriangleRightAngled()
        {
            Triangle triangle = new Triangle(
                new Vector2(0f, 0f),
                new Vector2(0f, 1f),
                new Vector2(1f, 0f));
            Assert.True(triangle.IsRightAngled);
        }
        
        [Fact]
        public void TestTriangleSidesRightAngled()
        {
            Triangle triangle = new Triangle(1f, 1f, (float)Math.Sqrt(2f));
            Assert.True(triangle.IsRightAngled);
        }
        
        [Fact]
        public void TestTriangleSidesHalfArea()
        {
            Triangle triangle = new Triangle(1f, 1f, (float)Math.Sqrt(2f));
            Assert.True(Math.Abs(triangle.GetArea() - 0.5f) < Constants.FloatTolerance);
        }
        
        [Fact]
        public void TestTriangleSidesExceptions()
        {
            void CreateWrongTriangle()
            {
                Triangle triangle = new Triangle(1f, 1f, 10f);
            }

            Assert.Throws<TriangleConstructorException>(CreateWrongTriangle);
        }
    }
}