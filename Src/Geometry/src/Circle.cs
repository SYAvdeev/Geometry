using System;
using System.Numerics;

namespace Geometry
{
    public class Circle : IAreaProvider
    {
        private readonly Vector2 _centerCoordinates;
        private readonly float _radius;

        public Circle(Vector2 centerCoordinates, float radius)
        {
            _centerCoordinates = centerCoordinates;
            _radius = radius;
        }

        public float GetArea() => (float)Math.PI * _radius * _radius;
    }
}