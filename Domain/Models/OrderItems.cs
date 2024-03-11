namespace Domain.Models;

public class OrderItems
{

  public int OrderItemsId { get; set; }

    public int OrderId { get; set; }

    public int MenuId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
    



}
