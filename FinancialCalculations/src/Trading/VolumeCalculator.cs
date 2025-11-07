using System;

namespace FinancialCalculations.Trading;

/// <summary>
/// Provides position sizing utilities based on limits and leverage constraints.
/// </summary>
public static class VolumeCalculator
{
    /// <summary>
    /// Calculates the maximum tradable volume given a notional limit and unit price.
    /// </summary>
    /// <param name="limit">The maximum allowed notional exposure.</param>
    /// <param name="unitPrice">The price per unit of the instrument.</param>
    /// <returns>The maximum number of units that can be traded without breaching the limit.</returns>
    public static decimal CalculateMaxVolume(decimal limit, decimal unitPrice)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit must be non-negative.");
        }

        if (unitPrice <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(unitPrice), unitPrice, "Unit price must be greater than zero.");
        }

        return Math.Floor(limit / unitPrice);
    }

    /// <summary>
    /// Calculates the notional exposure created by trading a certain volume at a given price.
    /// </summary>
    /// <param name="volume">The number of units traded.</param>
    /// <param name="unitPrice">The price per unit.</param>
    /// <returns>The notional exposure.</returns>
    public static decimal CalculateExposure(decimal volume, decimal unitPrice)
    {
        if (volume < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(volume), volume, "Volume must be non-negative.");
        }

        if (unitPrice < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(unitPrice), unitPrice, "Unit price must be non-negative.");
        }

        return volume * unitPrice;
    }

    /// <summary>
    /// Calculates the volume that must be traded in order to reach a target exposure.
    /// </summary>
    /// <param name="targetExposure">The desired notional exposure.</param>
    /// <param name="unitPrice">The price per unit of the instrument.</param>
    /// <returns>The volume that achieves the target exposure.</returns>
    public static decimal CalculateRequiredVolume(decimal targetExposure, decimal unitPrice)
    {
        if (targetExposure < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(targetExposure), targetExposure, "Target exposure must be non-negative.");
        }

        if (unitPrice <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(unitPrice), unitPrice, "Unit price must be greater than zero.");
        }

        return targetExposure / unitPrice;
    }
}
