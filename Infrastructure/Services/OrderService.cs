namespace Infrastructure.Services;

using Domain.Models;
using Infrastructure.DapperContext;
using Dapper;
public class OrderService
{
    private readonly DapperContext context;

    public OrderService()
    {
        context = new DapperContext();
    }

    public async Task AddOrder(Orders order)
    {
        var sql = "insert into Orders (CustomerId,TotalAmount,StatusOrders) values(@CustomerId,@TotalAmount,@StatusOrders)";

        await context.Connection().ExecuteAsync(sql, order);

    }

    public async Task DeleteOrder(int orderId)
    {
        var sql = "delete from Orders where OrderId=@orderId";

        await context.Connection().ExecuteAsync(sql, new { OrderId = orderId });
    }

    public async Task UpdateOrder(Orders order)
    {
        var sql = "update Orders set CustomerId=@CustomerId,TotalAmount=@TotalAmount,StatusOrders=@StatusOrders where OrderId=@orderId ";

        await context.Connection().ExecuteAsync(sql, order);
    }

    public async Task<List<Orders>> GetOrders()
    {
        var sql = "select * from Orders";

        var list = await context.Connection().QueryAsync<Orders>(sql);

        return list.ToList();
    }


      public async Task<OrderMenus> GetOrderWithMenus(int orderId)
    {

        var sql = @"select * from Orders where OrderId=@OrderId;

                   select Orders.OrderId,Orders.CustomerId,Orders.TotalAmount,orders.StatusOrders
                   
                    from Orders 
                   
                   join OrderItems on OrderItems.OrderId=Orders.OrderId
                   
                   where CustomerId=@customersId";

        OrderMenus odin = new OrderMenus();


        using (var multiple = await context.Connection().QueryMultipleAsync(sql, new { OrderId = orderId }))
        {
           odin.Order = await multiple.ReadFirstAsync<Orders>();

            var list = await multiple.ReadAsync<Menu>();

             odin.Menus = list.ToList();

        }

        return odin;
    }






}
