# Changes

## Coupon calculation

- `CSharp/14-issue-to-pr/ShoppingCart.cs`: `ApplyDiscount` now checks
  `Coupon.IsPercentage`. Percentage coupons subtract `subtotal × Value / 100`;
  flat coupons continue to subtract `Value` directly. The existing zero floor
  still prevents either type from producing a negative total.
- For the demo cart (keyboard €120 × 1 and cable €15 × 2), the subtotal is €150.
  `SAVE10` as a 10% coupon now subtracts €15 and totals **€135** instead of
  **€140**. A flat coupon worth €10 still totals **€140**.
- The demo's printed actual total and its source comments now reflect the fix.

## Regression coverage and instructions

- `CSharp/14-issue-to-pr/tests/ShoppingCartTests.cs` checks both coupon types
  against the €150 cart and checks that a 200% or €200 coupon on a €30 cart
  produces zero, not a negative total.
- `CSharp/14-issue-to-pr/tests/ShoppingCart.Tests.csproj` provides a .NET 8
  xUnit project that links the demo source, allowing the example and four test
  cases to run without a separate application project.
- `CSharp/README.md` now describes the corrected output and gives commands for
  running the demo and its tests.

From the repository root, verify with:

```bash
dotnet test CSharp/14-issue-to-pr/tests/ShoppingCart.Tests.csproj
dotnet run --project CSharp/14-issue-to-pr/tests/ShoppingCart.Tests.csproj
```
