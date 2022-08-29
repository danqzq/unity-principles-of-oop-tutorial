namespace Dan
{
    public class Square : Shape
    {
        private float _side;
        
        public Square(float side)
        {
            _side = side;
        }

        public override float GetPerimeter()
        {
            return _side * 4;
        }

        public override float GetArea()
        {
            return _side * _side;
        }
    }
}