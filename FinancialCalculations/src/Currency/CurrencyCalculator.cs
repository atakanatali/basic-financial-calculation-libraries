using System;

namespace FinancialCalculations.Currency;

/// <summary>
/// Provides helper methods for working with currency exchange rates and conversions.
/// </summary>
public static class CurrencyCalculator
{
    /// <summary>
    /// Converts an <paramref name="amount"/> from one currency into another using the supplied
    /// market convention rates. Rates must be expressed as the price of one unit of the currency
    /// in terms of a common quote currency (for example USD).
    /// </summary>
    /// <param name="amount">The amount denominated in the <paramref name="fromRate"/> currency.</param>
    /// <param name="fromRate">The rate of the source currency against the quote currency.</param>
    /// <param name="toRate">The rate of the target currency against the quote currency.</param>
    /// <returns>The converted amount in the target currency.</returns>
    public static decimal Convert(decimal amount, decimal fromRate, decimal toRate)
    {
        ValidateRate(fromRate, nameof(fromRate));
        ValidateRate(toRate, nameof(toRate));

        return amount * (toRate / fromRate);
    }

    /// <summary>
    /// Calculates the cross rate between two currency pairs. For example, if you have EUR/USD and
    /// USD/TRY rates, this method returns EUR/TRY.
    /// </summary>
    /// <param name="baseToQuoteRate">The rate of the base currency versus the intermediate quote currency.</param>
    /// <param name="quoteToTargetRate">The rate of the intermediate quote currency versus the target currency.</param>
    /// <returns>The cross rate between the base and target currencies.</returns>
    public static decimal CalculateCrossRate(decimal baseToQuoteRate, decimal quoteToTargetRate)
    {
        ValidateRate(baseToQuoteRate, nameof(baseToQuoteRate));
        ValidateRate(quoteToTargetRate, nameof(quoteToTargetRate));

        return baseToQuoteRate * quoteToTargetRate;
    }

    /// <summary>
    /// Calculates the converted amount using a cross rate. This is useful when the original amount
    /// needs to be converted through an intermediate currency.
    /// </summary>
    /// <param name="amount">The amount to convert.</param>
    /// <param name="baseToQuoteRate">The rate of the base currency versus the intermediate quote currency.</param>
    /// <param name="quoteToTargetRate">The rate of the intermediate quote currency versus the target currency.</param>
    /// <returns>The converted amount in the target currency.</returns>
    public static decimal CrossConvert(decimal amount, decimal baseToQuoteRate, decimal quoteToTargetRate)
    {
        var crossRate = CalculateCrossRate(baseToQuoteRate, quoteToTargetRate);
        return amount * crossRate;
    }

    /// <summary>
    /// Calculates the percentage change between two rates.
    /// </summary>
    /// <param name="previousRate">The previous rate.</param>
    /// <param name="currentRate">The current rate.</param>
    /// <returns>The percentage change expressed as a decimal (e.g. 0.05 equals a 5% increase).</returns>
    public static decimal CalculateRateChange(decimal previousRate, decimal currentRate)
    {
        ValidateRate(previousRate, nameof(previousRate));
        ValidateRate(currentRate, nameof(currentRate));

        return (currentRate - previousRate) / previousRate;
    }

    private static void ValidateRate(decimal rate, string parameterName)
    {
        if (rate <= 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, rate, "Rates must be greater than zero.");
        }
    }
}
