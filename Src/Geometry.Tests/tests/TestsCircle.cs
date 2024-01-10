using System;
using System.Numerics;
using Geometry.Exceptions;
using Xunit;

namespace Geometry.Tests
{
    public class TestsCircle
    {
        [Fact]
        public void TestCircleZeroArea()
        {
            IAreaProvider circleZeroArea = new Circle(new Vector2(0f, 0f), 0f);
            Assert.True(circleZeroArea.GetArea() == 0f);
        }
        
        [Fact]
        public void TestCircleSingleArea()
        {
            IAreaProvider circleSingleArea = new Circle(new Vector2(0f, 0f), 1f);
            Assert.True(Math.Abs(circleSingleArea.GetArea() - Math.PI) < Constants.FloatTolerance);
        }
        
        [Fact]
        public void TestCircleDoubleArea()
        {
            IAreaProvider circleSingleArea = new Circle(new Vector2(0f, 0f), 2f);
            Assert.True(Math.Abs(circleSingleArea.GetArea() - 4f * Math.PI) < Constants.FloatTolerance);
        }
        
        [Fact]
        public void TestCircleExceptions()
        {
            void CreateWrongCircle()
            {
                IAreaProvider circleWrong = new Circle(new Vector2(0f, 0f), -1f);
            }

            Assert.Throws<CircleConstructorException>(CreateWrongCircle);
        }
    }
}