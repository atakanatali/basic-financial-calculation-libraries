using System;

namespace FinancialCalculations.Fees;

/// <summary>
/// Calculates transaction fees and related metrics for trading and payments.
/// </summary>
public static class FeeCalculator
{
    /// <summary>
    /// Calculates the fee charged on a transaction based on a proportional rate.
    /// </summary>
    /// <param name="notional">The notional amount of the transaction.</param>
    /// <param name="feeRate">The fee rate expressed as a decimal (e.g. 0.0025 equals 0.25%).</param>
    /// <param name="minimumFee">Optional minimum fee floor applied when the proportional fee is lower.</param>
    /// <param name="maximumFee">Optional maximum fee cap applied when the proportional fee is higher.</param>
    /// <returns>The fee amount respecting the provided boundaries.</returns>
    public static decimal CalculateFee(decimal notional, decimal feeRate, decimal minimumFee = 0m, decimal? maximumFee = null)
    {
        if (notional < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(notional), notional, "Notional must be non-negative.");
        }

        if (feeRate < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(feeRate), feeRate, "Fee rate must be non-negative.");
        }

        if (minimumFee < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(minimumFee), minimumFee, "Minimum fee must be non-negative.");
        }

        if (maximumFee is < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumFee), maximumFee, "Maximum fee must be non-negative when provided.");
        }

        var proportionalFee = notional * feeRate;
        var fee = Math.Max(proportionalFee, minimumFee);

        if (maximumFee.HasValue)
        {
            fee = Math.Min(fee, maximumFee.Value);
        }

        return fee;
    }

    /// <summary>
    /// Calculates the net proceeds after subtracting fees from the notional amount.
    /// </summary>
    /// <param name="notional">The notional amount of the transaction.</param>
    /// <param name="feeAmount">The fee amount to deduct.</param>
    /// <returns>The net amount after fees.</returns>
    public static decimal CalculateNetProceeds(decimal notional, decimal feeAmount)
    {
        if (feeAmount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(feeAmount), feeAmount, "Fee amount must be non-negative.");
        }

        return notional - feeAmount;
    }

    /// <summary>
    /// Calculates the effective fee rate resulting from a fee amount applied to a notional.
    /// </summary>
    /// <param name="feeAmount">The fee amount applied.</param>
    /// <param name="notional">The transaction notional.</param>
    /// <returns>The effective fee rate as a decimal.</returns>
    public static decimal CalculateEffectiveFeeRate(decimal feeAmount, decimal notional)
    {
        if (notional <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(notional), notional, "Notional must be greater than zero.");
        }

        if (feeAmount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(feeAmount), feeAmount, "Fee amount must be non-negative.");
        }

        return feeAmount / notional;
    }
}
