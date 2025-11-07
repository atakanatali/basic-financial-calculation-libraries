using System;

namespace FinancialCalculations.Analytics;

/// <summary>
/// Provides simple and compound interest calculations.
/// </summary>
public static class InterestCalculator
{
    /// <summary>
    /// Calculates the future value using simple interest.
    /// </summary>
    /// <param name="principal">The initial amount invested or borrowed.</param>
    /// <param name="annualRate">The annual interest rate as a decimal.</param>
    /// <param name="years">The number of years.</param>
    /// <returns>The future value under simple interest.</returns>
    public static decimal CalculateSimpleInterest(decimal principal, decimal annualRate, decimal years)
    {
        ValidateInputs(principal, annualRate, years);
        return principal * (1 + annualRate * years);
    }

    /// <summary>
    /// Calculates the future value using compound interest.
    /// </summary>
    /// <param name="principal">The initial amount invested or borrowed.</param>
    /// <param name="annualRate">The annual interest rate as a decimal.</param>
    /// <param name="years">The number of years.</param>
    /// <param name="compoundingPeriodsPerYear">The number of compounding periods per year.</param>
    /// <returns>The future value under compound interest.</returns>
    public static decimal CalculateCompoundInterest(decimal principal, decimal annualRate, decimal years, int compoundingPeriodsPerYear)
    {
        ValidateInputs(principal, annualRate, years);

        if (compoundingPeriodsPerYear <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(compoundingPeriodsPerYear), compoundingPeriodsPerYear, "Compounding periods must be greater than zero.");
        }

        var periods = compoundingPeriodsPerYear * years;
        var periodicRate = annualRate / compoundingPeriodsPerYear;
        return principal * (decimal)Math.Pow((double)(1 + periodicRate), (double)periods);
    }

    private static void ValidateInputs(decimal principal, decimal annualRate, decimal years)
    {
        if (principal < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(principal), principal, "Principal must be non-negative.");
        }

        if (annualRate < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(annualRate), annualRate, "Interest rate must be non-negative.");
        }

        if (years < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(years), years, "Years must be non-negative.");
        }
    }
}
