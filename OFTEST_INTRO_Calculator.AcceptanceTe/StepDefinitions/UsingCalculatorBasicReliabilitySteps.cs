using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _context;

    public UsingCalculatorBasicReliabilitySteps(CalculatorContext context)
    {
        _context = context;
    }

    [When("I calculate Musa current intensity with lambda0 {double}, v0 {double}, and tau {double}")]
    public void WhenICalculateMusaCurrentIntensity(double lambda0, double v0, double tau)
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result = _context.Calculator.BasicMusaCurrentIntensity(lambda0, v0, tau);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            _context.Error = ex;
        }
    }

    [When("I calculate Musa cumulative failures with lambda0 {double}, v0 {double}, and tau {double}")]
    public void WhenICalculateMusaCumulativeFailures(double lambda0, double v0, double tau)
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result = _context.Calculator.BasicMusaCumulativeFailures(lambda0, v0, tau);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            _context.Error = ex;
        }
    }
}