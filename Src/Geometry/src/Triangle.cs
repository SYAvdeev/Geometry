using System;
using System.Numerics;
using Geometry.Exceptions;

namespace Geometry
{
    public class Triangle : IAreaProvider
    {
        private readonly Vector2 _point1Coordinates;
        private readonly Vector2 _point2Coordinates;
        private readonly Vector2 _point3Coordinates;

        public bool IsRightAngled
        {
            get
            {
                Vector2 side1 = _point1Coordinates - _point2Coordinates;
                Vector2 side2 = _point2Coordinates - _point3Coordinates;
                Vector2 side3 = _point3Coordinates - _point1Coordinates;

                return Math.Abs(side1.LengthSquared() + side2.LengthSquared() - side3.LengthSquared()) <
                       Constants.FloatTolerance ||
                       Math.Abs(side2.LengthSquared() + side3.LengthSquared() - side1.LengthSquared()) <
                       Constants.FloatTolerance ||
                       Math.Abs(side3.LengthSquared() + side1.LengthSquared() - side2.LengthSquared()) <
                       Constants.FloatTolerance;
            }
        }

        public Triangle(Vector2 point2Coordinates, Vector2 point3Coordinates, Vector2 point1Coordinates)
        {
            _point1Coordinates = point1Coordinates;
            _point2Coordinates = point2Coordinates;
            _point3Coordinates = point3Coordinates;
        }

        public Triangle(float side1, float side2, float side3)
        {
            if (side1 < 0f || side2 < 0f || side3 < 0f)
            {
                throw new TriangleConstructorException("All sides must be greater than zero");
            }

            if (side1 + side2 < side3 || side2 + side3 < side1 || side3 + side1 < side2)
            {
                throw new TriangleConstructorException("Sum of any two sides must be greater than the third side");
            }

            _point1Coordinates = new Vector2(0f);
            _point2Coordinates = new Vector2(side1, 0f);

            float cosA = (side1 * side1 + side2 * side2 - side3 * side3) / (2f * side1 * side2);
            float sinA = (float)Math.Sqrt(1 - cosA * cosA);

            _point3Coordinates = new Vector2(side2 * cosA, side2 * sinA);
        }

        public float GetArea()
        {
            float x1 = _point1Coordinates.X;
            float x2 = _point2Coordinates.X;
            float x3 = _point3Coordinates.X;
            
            float y1 = _point1Coordinates.Y;
            float y2 = _point2Coordinates.Y;
            float y3 = _point3Coordinates.Y;

            return Math.Abs(x1*y2 + x2*y3 + x3*y1 - x2*y1 - x3*y1 - x1*y3) / 2f;
        }
    }
}