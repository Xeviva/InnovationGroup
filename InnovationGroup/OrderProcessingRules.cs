namespace InnovationGroup
{
    public static class OrderProcessingRules
    {
        // These rules are here in a static class, but they could easily be stored in a database or file and
        // changes to rules in future would only require adding new rows here, the calculation process would not require any changes.
        public static List<OrderProcessingRule> Rules()
        {
            return new List<OrderProcessingRule>
            {
                 // Rules in Priority order
                 // Large repair orders for new customers should be closed
                 new OrderProcessingRule(OrderType.Repair, false, true, true, OrderStatus.Closed),
                 new OrderProcessingRule(OrderType.Repair, true, true, true, OrderStatus.Closed),
                 // Large rush hire orders should always be closed
                 new OrderProcessingRule(OrderType.Hire, true, true, true, OrderStatus.Closed),
                 new OrderProcessingRule(OrderType.Hire, true, false, true, OrderStatus.Closed),
                 // Large repair orders always require authorisation
                 new OrderProcessingRule(OrderType.Repair, false, false, true, OrderStatus.AuthorisationRequired),
                 new OrderProcessingRule(OrderType.Repair, true, false, true, OrderStatus.AuthorisationRequired),
                 // All rush orders for new customers always require authorisation
                 new OrderProcessingRule(OrderType.Hire, true, true, false, OrderStatus.AuthorisationRequired),
                 new OrderProcessingRule(OrderType.Repair, true, true, false, OrderStatus.AuthorisationRequired),
                 // All other orders should be confirmed
                 new OrderProcessingRule(OrderType.Hire, false, false, false, OrderStatus.Confirmed),
                 new OrderProcessingRule(OrderType.Hire, false, true, true, OrderStatus.Confirmed),
                 new OrderProcessingRule(OrderType.Hire, false, false, true, OrderStatus.Confirmed),
                 new OrderProcessingRule(OrderType.Hire, false, true, false, OrderStatus.Confirmed),
                 new OrderProcessingRule(OrderType.Repair, true, false, false, OrderStatus.Confirmed),
                 new OrderProcessingRule(OrderType.Repair, false, true, false, OrderStatus.Confirmed),
                 new OrderProcessingRule(OrderType.Hire, true, false, false, OrderStatus.Confirmed),
                 new OrderProcessingRule(OrderType.Repair, false, false, false, OrderStatus.Confirmed),
            };
        }
    }
}
