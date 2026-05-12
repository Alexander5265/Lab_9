using System;

namespace TriangleWpfApp
{
    public class Triangle
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public double SideA
        {
            get { return sideA; }
        }

        public double SideB
        {
            get { return sideB; }
        }

        public double SideC
        {
            get { return sideC; }
        }

        public bool Exists()
        {
            return sideA + sideB > sideC &&
                   sideA + sideC > sideB &&
                   sideB + sideC > sideA;
        }

        public double Area()
        {
            if (!Exists())
            {
                return 0;
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;

            return Math.Sqrt(
                semiPerimeter *
                (semiPerimeter - sideA) *
                (semiPerimeter - sideB) *
                (semiPerimeter - sideC));
        }

        public static implicit operator double(Triangle triangle)
        {
            return triangle.sideA + triangle.sideB + triangle.sideC;
        }

        public static double operator -(Triangle triangle)
        {
            return triangle.Area();
        }

        public static bool operator >(Triangle triangle1, Triangle triangle2)
        {
            return triangle1.Area() > triangle2.Area();
        }

        public static bool operator <(Triangle triangle1, Triangle triangle2)
        {
            return triangle1.Area() < triangle2.Area();
        }

        public override string ToString()
        {
            return $"A = {sideA}, B = {sideB}, C = {sideC}";
        }
    }
}