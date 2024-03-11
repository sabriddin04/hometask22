namespace Domain.Models;

public class Orders
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public decimal TotalAmount { get; set; }

    public bool StatusOrders { get; set; }


}
