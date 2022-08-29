using System;

namespace Dan
{
    public class Triangle : Shape
    {
        private float _side1;
        private float _side2;
        private float _side3;
        
        public Triangle(float side1, float side2, float side3)
        {
            _side1 = side1;
            _side2 = side2;
            _side3 = side3;
        }
        
        public override float GetPerimeter()
        {
            return _side1 + _side2 + _side3;
        }

        public override float GetArea()
        {
            var s = GetPerimeter() / 2;
            return (float) Math.Sqrt(s * (s - _side1) * (s - _side2) * (s - _side3));
        }
    }
}