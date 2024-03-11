namespace WebApi.Controllers;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
[Controller]
[Route("[controller]")]
public class OrderController:ControllerBase
{

 private readonly OrderService orderService;

 public OrderController()
 {
    orderService=new OrderService();
 }

  
  
    [HttpDelete("delete-Order")]

    public async Task DeleteOrder(int orderId)
    {
        await orderService.DeleteOrder(orderId);
    }


    [HttpGet("GEt-Orders")]


    public async Task<List<Orders>> GetOrders()
    {
        return await orderService.GetOrders();
    }


   [HttpPost("add-Order")]
   
    public async Task AddOrder(Orders order)
    {
      
      await orderService.AddOrder(order);

    }

    [HttpPut("Update-Order")]

     public async Task UpdateCustomer(Orders order)
    {
        await orderService.UpdateOrder(order);

    }

  
    [HttpGet("GEt-Order-with-menus")]
    
      public async Task<OrderMenus> GetOrderWithMenus(int orderId)
    {
       return await orderService.GetOrderWithMenus(orderId);
    }

    

}
