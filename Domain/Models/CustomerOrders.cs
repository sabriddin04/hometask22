namespace Domain.Models;

public class CustomerOrders
{
    public Customers? Customer { get; set; }

    public List<Orders>? Orders { get; set; }

}
