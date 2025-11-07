using System;

namespace FinancialCalculations.Analytics;

/// <summary>
/// Provides utilities for evaluating profit and loss metrics.
/// </summary>
public static class ProfitAndLossCalculator
{
    /// <summary>
    /// Calculates the profit or loss based on entry and exit prices.
    /// </summary>
    /// <param name="entryPrice">The entry price per unit.</param>
    /// <param name="exitPrice">The exit price per unit.</param>
    /// <param name="quantity">The number of units traded.</param>
    /// <returns>The profit or loss amount.</returns>
    public static decimal CalculatePnL(decimal entryPrice, decimal exitPrice, decimal quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be non-negative.");
        }

        return (exitPrice - entryPrice) * quantity;
    }

    /// <summary>
    /// Calculates the break-even price needed to cover transaction costs.
    /// </summary>
    /// <param name="entryPrice">The entry price per unit.</param>
    /// <param name="totalCosts">Total trading costs such as fees and commissions.</param>
    /// <param name="quantity">The traded quantity.</param>
    /// <returns>The break-even exit price.</returns>
    public static decimal CalculateBreakEvenPrice(decimal entryPrice, decimal totalCosts, decimal quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than zero.");
        }

        return entryPrice + totalCosts / quantity;
    }

    /// <summary>
    /// Calculates the return on investment for a trade.
    /// </summary>
    /// <param name="pnl">The profit or loss realised.</param>
    /// <param name="investedCapital">The amount of capital invested.</param>
    /// <returns>The return on investment as a decimal.</returns>
    public static decimal CalculateReturn(decimal pnl, decimal investedCapital)
    {
        if (investedCapital == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(investedCapital), investedCapital, "Invested capital must not be zero.");
        }

        return pnl / investedCapital;
    }
}
