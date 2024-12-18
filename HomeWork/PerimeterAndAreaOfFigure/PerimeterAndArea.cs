using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.PerimeterAndAreaOfFigure
{

    public abstract class Shape
    {

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

        public virtual void Display()
        {
            Console.WriteLine($"Площадь: {CalculateArea()} Периметр: {CalculatePerimeter()}");
        }

    }
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public override double CalculateArea()
        {
            return Width * Height;
        }
        public override double CalculatePerimeter()
        {
            return 2 * (Height + Width);
        }
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
    public class Triangle : Shape
    {
        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
        public double ThirdSide { get; set; }

        public Triangle (double firstSide, double secondSide, double thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }
        public override double CalculateArea()
        {
            double HalfPerimeter = CalculatePerimeter() / 2;
            return Math.Sqrt (HalfPerimeter * (HalfPerimeter - FirstSide) *
                                              (HalfPerimeter - SecondSide) *
                                              (HalfPerimeter - ThirdSide));
        }
        public override double CalculatePerimeter()
        {
            return FirstSide + SecondSide + ThirdSide;
        }
    }
    class PerimeterAndArea
    {
        public static void PerimeterArea()
        {
            Shape rectangle = new Rectangle(7, 10);
            Shape circle = new Circle(7);
            Shape triangle = new Triangle(7, 10, 16);
            rectangle.Display();
            circle.Display();
            triangle.Display();
        }
    }
}
