namespace InnovationGroup.Tests
{
    public class CalculateOrderStatusServiceTests
    {
        [Theory]
        [InlineData(OrderType.Hire, true, true, true, OrderStatus.Closed)]
        [InlineData(OrderType.Hire, true, true, false, OrderStatus.AuthorisationRequired)]
        [InlineData(OrderType.Hire, true, false, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Hire, false, false, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Hire, false, true, true, OrderStatus.Confirmed)]
        [InlineData(OrderType.Hire, false, false, true, OrderStatus.Confirmed)]
        [InlineData(OrderType.Hire, false, true, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Hire, true, false, true, OrderStatus.Closed)]
        [InlineData(OrderType.Repair, true, true, true, OrderStatus.Closed)]
        [InlineData(OrderType.Repair, true, true, false, OrderStatus.AuthorisationRequired)]
        [InlineData(OrderType.Repair, true, false, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Repair, false, false, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Repair, false, true, true, OrderStatus.Closed)]
        [InlineData(OrderType.Repair, false, false, true, OrderStatus.AuthorisationRequired)]
        [InlineData(OrderType.Repair, false, true, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Repair, true, false, true, OrderStatus.AuthorisationRequired)]
        public void CalculateOrderStatus_Works(OrderType type, bool isRush, bool isNew, bool isLarge, OrderStatus status)
        {
            var service = new CalculateOrderStatusService();

            var actual = service.CalculateOrderStatus(type, isRush, isNew, isLarge);

            Assert.Equal(status, actual);
        }

        [Theory]
        [InlineData(OrderType.Hire, true, true, true, OrderStatus.Closed)]
        [InlineData(OrderType.Hire, true, true, false, OrderStatus.AuthorisationRequired)]
        [InlineData(OrderType.Hire, true, false, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Hire, false, false, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Hire, false, true, true, OrderStatus.Confirmed)]
        [InlineData(OrderType.Hire, false, false, true, OrderStatus.Confirmed)]
        [InlineData(OrderType.Hire, false, true, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Hire, true, false, true, OrderStatus.Closed)]
        [InlineData(OrderType.Repair, true, true, true, OrderStatus.Closed)]
        [InlineData(OrderType.Repair, true, true, false, OrderStatus.AuthorisationRequired)]
        [InlineData(OrderType.Repair, true, false, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Repair, false, false, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Repair, false, true, true, OrderStatus.Closed)]
        [InlineData(OrderType.Repair, false, false, true, OrderStatus.AuthorisationRequired)]
        [InlineData(OrderType.Repair, false, true, false, OrderStatus.Confirmed)]
        [InlineData(OrderType.Repair, true, false, true, OrderStatus.AuthorisationRequired)]
        public void GetStatusForOrder_Works(OrderType type, bool isRush, bool isNewCustomer, bool isLarge, OrderStatus status)
        {
            var actual = CalculateOrderStatusService.GetStatusForOrder(type, isRush, isNewCustomer, isLarge);

            Assert.Equal(status, actual);
        }
    }
}