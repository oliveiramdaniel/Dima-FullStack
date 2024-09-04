namespace Core.Requests.Orders;

public class PayOrderRequest : Request
{
    //public string OrderNumber { get; set; } = string.Empty;
    public long Id { get; set; }

    public string ExternalReference { get; set; } = string.Empty;
}