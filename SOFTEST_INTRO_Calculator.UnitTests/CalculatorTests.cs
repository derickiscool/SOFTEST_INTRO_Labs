using SOFTEST_INTRO_Calculator;
using NUnit.Framework;

namespace SOFTEST_INTRO_Calculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator = null;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();

        }

        [Test]
       public void Add_TwoPositiveNumbers_ReturnsSum()
        {
            //Arrange: the calculator is created in setup
            //Act
            double result = _calculator.Add(10, 20);
            Assert.That(result, Is.EqualTo(30));

        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 5, 5)]
        [TestCase(-3, 8, 5)]
        [TestCase(0.1, 0.2, 0.3)]
        public void Add_RepresentativeInputs_ReturnsSum(double a, double b, double expected)
        {
            double result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }


        [TestCase(10,4,6)]
        [TestCase(5,0,5)]
        [TestCase(0,5, -5)]
        [TestCase(-5, -3, -2)]
        public void Subtract_RepresentativeInputs_ReturnsDifference(double a, double b, double expected)
        {
            double result = _calculator.Subtract(a, b);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [TestCase(3, 4, 12)]
        [TestCase(5, 0, 0)]
        [TestCase(-3, 4, -12)]
        [TestCase(-2, -3, 6)]
        public void Multiply_RepresentativeInputs_ReturnsProduct(double a, double b, double expected)
        {
            double result = _calculator.Multiply(a, b);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [TestCase(1, 2, 0.5)]
        [TestCase(0, 15, 0)]
        [TestCase(15, -3, -5)]
        public void Divide_ValidInputs_ReturnsQuotient(double a, double b, double expected)
        {
            double result = _calculator.Divide(a, b);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [TestCase(15, 0)]
        [TestCase(0, 0)]
        public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
        {
            Assert.That(() => _calculator.Divide(a, b),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Factorial_Zero_ReturnsOne()
        {
            long result = _calculator.Factorial(0);
            Assert.That(result, Is.EqualTo(1L));
        }

        [TestCase(1, 1L)]
        [TestCase(5, 120L)]
        [TestCase(20, 2432902008176640000L)]
        public void Factorial_ValidInputs_ReturnsFactorial(int n, long expected)
        {
            long result = _calculator.Factorial(n);
            Assert.That(result, Is.EqualTo(expected));
        }


        [TestCase(-1)]
        [TestCase(21)]
        public void Factorial_OutOfRangeInputs_ThrowsArgumentOutOfRangeException(int n)
        {
            Assert.That(() => _calculator.Factorial(n),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        

        [TestCase(3, 4, 6.0)]
        [TestCase(0, 5, 0.0)]
        [TestCase(5, 0, 0.0)]
        public void TriangleArea_ValidInputs_ReturnsArea(double height, double width, double expected)
        {
            double result = _calculator.TriangleArea(height, width);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [TestCase(-1, 5)]
        [TestCase(5, -1)]
        public void TriangleArea_NegativeInputs_ThrowsArgumentOutOfRangeException(double height, double width)
        {
            Assert.That(() => _calculator.TriangleArea(height, width),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }


        [TestCase(0, 0.0)]
        [TestCase(1, Math.PI)]
        [TestCase(2, Math.PI * 4)]
        public void CircleArea_ValidRadius_ReturnsArea(double radius, double expected)
        {
            double result = _calculator.CircleArea(radius);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [TestCase(-1)]
        public void CircleArea_NegativeRadius_ThrowsArgumentOutOfRangeException(double radius)
        {
            Assert.That(() => _calculator.CircleArea(radius),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(5, 5, 120L)]
        [TestCase(5, 4, 120L)]
        [TestCase(5, 3, 60L)]
        [TestCase(5, 0, 1L)]
        [TestCase(0, 0, 1L)]
        public void UnknownFunctionA_ValidInputs_ReturnsExpectedResult(int n, int r, long expected)
        {
            long result = _calculator.UnknownFunctionA(n, r);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(5, 5, 1L)]
        [TestCase(5, 4, 5L)]
        [TestCase(5, 3, 10L)]
        [TestCase(5, 0, 1L)]
        [TestCase(0, 0, 1L)]
        public void UnknownFunctionB_ValidInputs_ReturnsExpectedResult(int n, int r, long expected)
        {
            long result = _calculator.UnknownFunctionB(n, r);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(-4, 5)] // n < 0
        [TestCase(4, 5)]  // r > n
        public void UnknownFunctions_TableExceptions_ThrowArgumentOutOfRangeException(int n, int r)
        {
            Assert.That(() => _calculator.UnknownFunctionA(n, r),
                Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => _calculator.UnknownFunctionB(n, r),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        [TestCase(1000, 10, 100.0)]
        [TestCase(450, 3, 150.0)]
        public void CalculateMtbf_ValidInputs_ReturnsMtbf(double operatingTime, int failures, double expected)
        {
            double result = _calculator.CalculateMtbf(operatingTime, failures);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [TestCase(0, 5)]   // non-positive operating time
        [TestCase(-10, 5)] // negative operating time
        [TestCase(100, 0)]  // zero failures
        [TestCase(100, -1)] // negative failures
        public void CalculateMtbf_InvalidInputs_ThrowsArgumentOutOfRangeException(double operatingTime, int failures)
        {
            Assert.That(() => _calculator.CalculateMtbf(operatingTime, failures),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(90, 10, 0.9)]
        [TestCase(0, 10, 0.0)]
        [TestCase(100, 0, 1.0)]
        public void CalculateAvailability_ValidInputs_ReturnsAvailability(double mtbf, double mttr, double expected)
        {
            double result = _calculator.CalculateAvailability(mtbf, mttr);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }

        [TestCase(-1, 10)] // negative MTBF
        [TestCase(10, -1)] // negative MTTR
        [TestCase(0, 0)]   // denominator is zero
        public void CalculateAvailability_InvalidInputs_ThrowsArgumentOutOfRangeException(double mtbf, double mttr)
        {
            Assert.That(() => _calculator.CalculateAvailability(mtbf, mttr),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        [TestCase(10.0, 100.0, 0.0, 10.0)]
        [TestCase(10.0, 100.0, 10.0, 3.67879441)]
        public void BasicMusaFailureIntensity_ValidInputs_ReturnsExpectedValue(
    double lambda0, double v0, double tau, double expected)
        {
            double result = _calculator.BasicMusaCurrentIntensity(lambda0, v0, tau);
            Assert.That(result, Is.EqualTo(expected).Within(1e-6));
        }

        [TestCase(10.0, 100.0, 0.0, 0.0)]
        [TestCase(10.0, 100.0, 10.0, 63.21205588)]
        public void BasicMusaCumulativeFailures_ValidInputs_ReturnsExpectedValue(
            double lambda0, double v0, double tau, double expected)
        {
            double result = _calculator.BasicMusaCumulativeFailures(lambda0, v0, tau);
            Assert.That(result, Is.EqualTo(expected).Within(1e-6));
        }

        [TestCase(0.0, 100.0, 10.0)]  // lambda0 <= 0
        [TestCase(-5.0, 100.0, 10.0)] // lambda0 < 0
        [TestCase(10.0, 0.0, 10.0)]   // v0 <= 0
        [TestCase(10.0, -10.0, 10.0)] // v0 < 0
        [TestCase(10.0, 100.0, -1.0)] // tau < 0
        public void BasicMusa_InvalidInputs_ThrowArgumentOutOfRangeException(
            double lambda0, double v0, double tau)
        {
            Assert.That(() => _calculator.BasicMusaCurrentIntensity(lambda0, v0, tau),
                Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => _calculator.BasicMusaCumulativeFailures(lambda0, v0, tau),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

    }
}
