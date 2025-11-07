# Basic Financial Calculation Libraries

This repository contains a .NET (net7.0) class library that groups together frequently used
financial calculations. The project is prepared to be packed as a NuGet package named
`BasicFinancialCalculations` so it can be distributed and consumed by other .NET solutions.

## Features

The library currently provides the following capabilities:

- **Currency calculations** – spot conversions, cross-rate calculations, and rate change analytics.
- **Fee calculations** – proportional fees with configurable minimum and maximum boundaries plus net proceeds helpers.
- **Volume sizing** – utilities for sizing trades based on notional limits and price information.
- **Interest calculations** – simple and compound interest formulas for savings or borrowing.
- **Loan analytics** – amortised payment and outstanding balance calculations.
- **Profit &amp; loss metrics** – break-even, profit/loss, and return on investment helpers.

The code is organised by concern within the `FinancialCalculations` project directory.

## Getting Started

Reference the library from another project by adding the project or NuGet package.

```bash
# From a solution directory
dotnet add reference ../FinancialCalculations/FinancialCalculations.csproj
```

After referencing the project you can import the namespaces that you need:

```csharp
using FinancialCalculations.Currency;
using FinancialCalculations.Fees;
using FinancialCalculations.Trading;
```

Each namespace exposes static calculator classes with well documented methods and validation.

## Building the NuGet Package

The project is configured with `GeneratePackageOnBuild` so building in `Release` mode
produces the NuGet package automatically:

```bash
# Build with Release configuration to create the .nupkg file
DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1 dotnet build FinancialCalculations/FinancialCalculations.csproj -c Release
```

The resulting package will be available under `FinancialCalculations/bin/Release/`.

## License

This project is distributed under the MIT License. See [LICENSE](LICENSE) for details.
