// See https://aka.ms/new-console-template for more information
using InnovationGroup;

Console.WriteLine("Hello, Please enter order details:");

try
{
    Console.WriteLine("Order Type (Hire or Repair): ");
    bool validStatus = Enum.TryParse(Console.ReadLine(), out OrderType type);
    if(!validStatus)
    {
        throw new Exception("Invalid status");
    }

    Console.WriteLine("is this a rush order (true/false): ");
    string isRush = Console.ReadLine() ?? "";
    bool isRushOrder = Convert.ToBoolean(isRush);

    Console.WriteLine("is this a new customer (true/false): ");
    string newCustomer = Console.ReadLine() ?? "";
    bool isNewCustomer = Convert.ToBoolean(newCustomer);

    Console.WriteLine("is this a large order (true/false): ");
    string isLarge = Console.ReadLine() ?? "";
    bool isLargeOrder = Convert.ToBoolean(isLarge);

    var newOrderStatus = CalculateOrderStatusService.GetStatusForOrder(type, isRushOrder, isNewCustomer, isLargeOrder);
    Console.WriteLine($"The order status is: {newOrderStatus}");
}
catch(Exception)
{
    Console.WriteLine("Invalid order entry");
}

