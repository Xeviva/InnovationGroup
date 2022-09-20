using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InnovationGroup
{
    public class OrderProcessingRule
    {
        public OrderProcessingRule(OrderType type, bool isRush, bool isNewCustomer, bool isLarge, OrderStatus processedStatus)
        {
            Type = type;
            IsRushOrder = isRush;
            IsLargeOrder = isLarge;
            IsNewCustomer = isNewCustomer;
            ProcessStatus = processedStatus;
        }

        public OrderType Type { get; set; }
        public bool IsRushOrder { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsLargeOrder { get; set; }
        public OrderStatus ProcessStatus { get; set; }
    }
}
