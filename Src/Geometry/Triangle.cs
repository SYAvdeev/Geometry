using System;
using System.Numerics;

namespace Geometry
{
    public class Triangle : IAreaProvider
    {
        private readonly Vector3 _point1Coordinates;
        private readonly Vector3 _point2Coordinates;
        private readonly Vector3 _point3Coordinates;

        public Triangle(Vector3 point2Coordinates, Vector3 point3Coordinates, Vector3 point1Coordinates)
        {
            _point2Coordinates = point2Coordinates;
            _point3Coordinates = point3Coordinates;
            _point1Coordinates = point1Coordinates;
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