using NUnit.Framework;
using System;

[TestFixture]
public class TermDepositCalculatorTests
{
    private TermDepositService service;

    public TermDepositCalculatorTests()
    {
        service = new TermDepositService();
    }

    [TestCase(10000, 0.05, 5, "Monthly", 12834)]  // Adjusted for 5 years of monthly compounding
    [TestCase(10000, 0.05, 5, "Quarterly", 12820)]  // Adjusted for 5 years of quarterly compounding
    [TestCase(10000, 0.05, 5, "Annually", 12763)]  // Adjusted for 5 years of annual compounding
    [TestCase(10000, 0.011, 3, "At Maturity", 10330)]
    public void CalculateFinalAmount_VariousCompounding_ReturnsCorrectValue(double principal, double rate, int term, string frequency, double expected)
    {
        // Act
        double result = service.CalculateFinalAmount(principal, rate, term, frequency);

        // Assert
        Assert.That(result, Is.EqualTo(expected), $"Compounding {frequency} did not calculate correctly.");
    }
}