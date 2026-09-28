using System;
using System.Collections.Generic;
using System.Text;

namespace SOFTEST_INTRO_Calculator
{
    public class Calculator
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a , double b) => a - b;

        public double Multiply(double  a, double b) => a * b;

        //Starter version : complete the zero-divisor rule in section 5
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Divisor cannot be zero");

            }
            return a / b;
        }
        public double DoOperation(double a, double b, string op)
        {
            return op switch
            {
                "a" => Add(a, b),
                "s" => Subtract(a, b),
                "m" => Multiply(a, b),
                "d" => Divide(a, b),
                _ => throw new ArgumentException("Unknown operation.")
            };
        }

        public long Factorial(int n)
        {
            if (n < 0 || n > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Input must be between 0 and 20.");
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public double TriangleArea(double height, double width)
        {
            if (height < 0 || width < 0)
            {
                throw new ArgumentOutOfRangeException("Dimensions cannot be negative.");
            }
            return 0.5 * height * width;
        }

        public double CircleArea(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius cannot be negative.");
            }
            return Math.PI * radius * radius;
        }

        public long UnknownFunctionA(int n, int r)
        {
            if (r < 0 || n < r || n > 20)
            {
                throw new ArgumentOutOfRangeException("Inputs must satisfy 0 <= r <= n <= 20.");
            }

            return Factorial(n) / Factorial(n - r);
        }

        public long UnknownFunctionB(int n, int r)
        {
            if (r < 0 || n < r || n > 20)
            {
                throw new ArgumentOutOfRangeException("Inputs must satisfy 0 <= r <= n <= 20.");
            }

            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }
        public double CalculateMtbf(double operatingTime, int failures)
        {
            if (operatingTime <= 0 || failures <= 0)
            {
                throw new ArgumentOutOfRangeException("Operating time and failures must be positive.");
            }

            return operatingTime / failures;
        }

        public double CalculateAvailability(double mtbf, double mttr)
        {
            if (mtbf < 0 || mttr < 0 || (mtbf + mttr) <= 0)
            {
                throw new ArgumentOutOfRangeException("MTBF and MTTR cannot be negative, and denominator must be positive.");
            }

            return mtbf / (mtbf + mttr);
        }

        public double BasicMusaCurrentIntensity(double lambda0, double v0, double tau)
        {
            if (lambda0 <= 0 || v0 <= 0 || tau < 0)
            {
                throw new ArgumentOutOfRangeException("Inputs must satisfy lambda0 > 0, v0 > 0, and tau >= 0.");
            }

            return lambda0 * Math.Exp(-lambda0 * tau / v0);
        }

        public double BasicMusaCumulativeFailures(double lambda0, double v0, double tau)
        {
            if (lambda0 <= 0 || v0 <= 0 || tau < 0)
            {
                throw new ArgumentOutOfRangeException("Inputs must satisfy lambda0 > 0, v0 > 0, and tau >= 0.");
            }

            return v0 * (1 - Math.Exp(-lambda0 * tau / v0));
        }

    }
}
