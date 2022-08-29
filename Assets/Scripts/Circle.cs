namespace Dan
{
    public class Circle : Shape
    {
        private float _radius;

        public Circle(float radius)
        {
            _radius = radius;
        }
        
        public override float GetPerimeter()
        {
            return _radius * 2 * 3.14f;
        }

        public override float GetArea()
        {
            return _radius * _radius * 3.14f;
        }
    }
}