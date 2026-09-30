using IssueToPr;
using Xunit;

namespace IssueToPr.Tests;

public class ShoppingCartTests
{
    [Theory]
    [InlineData(true, 135)]
    [InlineData(false, 140)]
    public void Coupon_discounts_subtotal_by_its_type(bool isPercentage, int expectedTotal)
    {
        var cart = new ShoppingCart();
        cart.AddItem("Mechanical Keyboard", 120m, 1);
        cart.AddItem("USB-C Cable", 15m, 2);
        cart.ApplyCoupon(new Coupon("SAVE10", 10m, isPercentage));

        Assert.Equal(150m, cart.GetSubtotal());
        Assert.Equal((decimal)expectedTotal, cart.GetTotal());
    }

    [Theory]
    [InlineData(true, 200)]
    [InlineData(false, 200)]
    public void Discount_cannot_make_total_negative(bool isPercentage, int value)
    {
        var cart = new ShoppingCart();
        cart.AddItem("USB-C Cable", 15m, 2);
        cart.ApplyCoupon(new Coupon("BIG", value, isPercentage));

        Assert.Equal(0m, cart.GetTotal());
    }
}
