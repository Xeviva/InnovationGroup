namespace InnovationGroup
{
    public class CalculateOrderStatusService
    {
        // Using the test run as a guide, I can tell that doing it this way takes 3ms to run all test cases
        [Obsolete("This way takes longer")]
        public OrderStatus CalculateOrderStatus(OrderType orderType, bool isRushOrder, bool isNewCustomer, bool isLargeOrder)
        {
            if(orderType == OrderType.Repair && isLargeOrder && isNewCustomer)
            {
                return OrderStatus.Closed;
            }

            if(isLargeOrder && isRushOrder && orderType == OrderType.Hire)
            {
                return OrderStatus.Closed;
            }

            if(isLargeOrder && orderType == OrderType.Repair)
            {
                return OrderStatus.AuthorisationRequired;
            }

            if(isRushOrder && isNewCustomer)
            {
                return OrderStatus.AuthorisationRequired;
            }

            return OrderStatus.Confirmed;
        }

        // Using the test run as a guide, I can tell that doing it this way takes < 1ms to run all test cases
        public static OrderStatus GetStatusForOrder(OrderType type, bool isRushOrder, bool isNewCustomer, bool isLargeOrder)
        {
            List<OrderProcessingRule> rules = OrderProcessingRules.Rules();

            OrderProcessingRule? rule = rules.FirstOrDefault(x => x.Type == type
                                                && x.IsRushOrder == isRushOrder
                                                && x.IsNewCustomer == isNewCustomer
                                                && x.IsLargeOrder == isLargeOrder);

            return rule?.ProcessStatus ?? OrderStatus.Confirmed;
        }
    }
}
