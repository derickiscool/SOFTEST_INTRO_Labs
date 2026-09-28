using System.Globalization;
using SOFTEST_INTRO_Calculator;

var calculator = new Calculator();

Console.WriteLine("Calculator Operations: ");
Console.WriteLine("a=add, s=subtract, m=multiply, d=divide");
Console.WriteLine("Operation : ");
string op = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

Console.Write("First Number: ");
string first = Console.ReadLine() ?? "";

Console.Write("Second Number: ");
string second = Console.ReadLine() ?? "";

bool firstOk = double.TryParse(first, NumberStyles.Float, CultureInfo.InvariantCulture, out double a);
bool secondOk = double.TryParse(second, NumberStyles.Float, CultureInfo.InvariantCulture, out double b);

if (!firstOk || !secondOk || !double.IsFinite(a) || !double.IsFinite(b))
{
    Console.WriteLine("Enter finite numbers; use . for decimals");
    return;
}

try
{
    double result = calculator.DoOperation(a, b, op);
    string text = result.ToString(CultureInfo.InvariantCulture);
    Console.WriteLine("Result: " + text);

}
catch (ArgumentException error)
{
    Console.WriteLine(error.Message);
}
