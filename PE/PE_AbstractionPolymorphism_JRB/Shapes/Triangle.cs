using PE_AbstractionPolymorphism_JRB.Shapes;

namespace PE_AbstractionPolymorphism_JRB.Shapes
{
    /// <summary>
    /// Triangles are Shapes with 3 sides
    /// </summary>
    internal class Triangle : Shape
    {
        // Triangles can have a different base (length) and height (width)
        private double length;
        private double width;

        // Create a new triangle using the base constructor to save the type
        public Triangle(double length, double width) : base("triangle")
        {
            this.length = length;
            this.width = width;
        }

        // Implement CalculateArea correctly for a triangle
        public override double CalculateArea()
        {
            return 0.5 * length * width;
        }

        // Implement the Area property as well
        public override double Area
        {
            get
            {
                return 0.5 * length * width;
            }
        }
    }
}
