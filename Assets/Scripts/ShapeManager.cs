using UnityEngine;

namespace Dan
{
    public class ShapeManager : MonoBehaviour
    {
        private Shape[] _shapes =
        {
            new Square(1f),
            new Circle(1f),
            new Triangle(1f, 1f, 1f)
        };

        private void Start()
        {
            foreach (var shape in _shapes)
            {
                Debug.Log($"{shape.GetType().Name} has an area of {shape.GetArea()} " +
                          $"and a perimeter of {shape.GetPerimeter()}");
            }
        }
    }
}