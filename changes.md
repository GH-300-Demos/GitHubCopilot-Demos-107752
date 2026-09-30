# Changes

- `ShoppingCart.ApplyDiscount` calculates percentage coupons from the subtotal while continuing to subtract flat coupons directly and clamp discounted totals at zero.
- The shopping cart demo now labels its corrected total accurately.
- Added runnable xUnit regression tests for percentage and flat coupons, including discounts that exceed the subtotal.
- Updated the C# demo instructions with the corrected behavior and commands to run the demo and tests.
