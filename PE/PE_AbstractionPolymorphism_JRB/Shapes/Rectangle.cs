using System;

namespace PE_AbstractionPolymorphism_JRB.Shapes
{
    /// <summary>
    /// Rectangles are Shapes with two sets of parallel sides
    /// </summary>
    internal class Rectangle : Shape
    {
        // Rectangles have separate lengths and widths
        private double length;
        private double width;

        // Create a new rectangle using the base constructor to save the type
        public Rectangle(double length, double width) : base("rectangle")
        {
            this.length = length;
            this.width = width;
        }

        // Implement CalculateArea correctly for a rectangle
        public override double CalculateArea()
        {
            return length * width;
        }

        // Implement the Area property as well
        public override double Area
        {
            get
            {
                return length * width;
            }
        }
    }
}
