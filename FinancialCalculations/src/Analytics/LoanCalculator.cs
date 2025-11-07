using System;

namespace FinancialCalculations.Analytics;

/// <summary>
/// Calculates loan repayment metrics using standard amortisation formulae.
/// </summary>
public static class LoanCalculator
{
    /// <summary>
    /// Calculates the periodic payment required to amortise a loan.
    /// </summary>
    /// <param name="principal">The initial principal amount.</param>
    /// <param name="annualRate">The annual interest rate as a decimal.</param>
    /// <param name="years">The loan term in years.</param>
    /// <param name="paymentsPerYear">The number of payments per year.</param>
    /// <returns>The constant payment amount per period.</returns>
    public static decimal CalculatePayment(decimal principal, decimal annualRate, int years, int paymentsPerYear)
    {
        if (principal <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(principal), principal, "Principal must be greater than zero.");
        }

        if (annualRate < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(annualRate), annualRate, "Interest rate must be non-negative.");
        }

        if (years <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(years), years, "Years must be greater than zero.");
        }

        if (paymentsPerYear <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(paymentsPerYear), paymentsPerYear, "Payments per year must be greater than zero.");
        }

        var totalPayments = years * paymentsPerYear;
        var periodicRate = annualRate / paymentsPerYear;

        if (periodicRate == 0)
        {
            return principal / totalPayments;
        }

        var factor = (decimal)Math.Pow(1 + (double)periodicRate, totalPayments);
        return principal * periodicRate * factor / (factor - 1);
    }

    /// <summary>
    /// Calculates the outstanding balance after a certain number of payments have been made.
    /// </summary>
    /// <param name="principal">The original principal.</param>
    /// <param name="annualRate">The annual interest rate as a decimal.</param>
    /// <param name="years">The loan term in years.</param>
    /// <param name="paymentsPerYear">The number of payments per year.</param>
    /// <param name="paymentsMade">The number of payments already made.</param>
    /// <returns>The remaining balance.</returns>
    public static decimal CalculateRemainingBalance(decimal principal, decimal annualRate, int years, int paymentsPerYear, int paymentsMade)
    {
        var payment = CalculatePayment(principal, annualRate, years, paymentsPerYear);
        var periodicRate = annualRate / paymentsPerYear;
        var totalPayments = years * paymentsPerYear;

        if (paymentsMade < 0 || paymentsMade > totalPayments)
        {
            throw new ArgumentOutOfRangeException(nameof(paymentsMade), paymentsMade, "Payments made must be between 0 and the total number of payments.");
        }

        if (periodicRate == 0)
        {
            return principal - payment * paymentsMade;
        }

        var factor = (decimal)Math.Pow(1 + (double)periodicRate, paymentsMade);
        return principal * (decimal)Math.Pow(1 + (double)periodicRate, paymentsMade) - payment * (factor - 1) / periodicRate;
    }
}
