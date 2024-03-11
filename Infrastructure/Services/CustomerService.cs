namespace Infrastructure.Services;

using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
public class CustomerService
{

    private readonly DapperContext context;

    public CustomerService()
    {
        context = new DapperContext();
    }

    public async Task AddCustomer(Customers customer)
    {
        var sql = "insert into Customers (CustomerName,Address) values(@CustomerName,Address)";

        await context.Connection().ExecuteAsync(sql, customer);

    }

    public async Task DeleteCustomer(int customersId)
    {
        var sql = "delete from Customers where CustomersId=@customersId";

        await context.Connection().ExecuteAsync(sql, new { CustomersId = customersId });
    }

    public async Task UpdateCustomer(Customers customer)
    {
        var sql = "update Customers set CustomerName=@CustomerName,Address=@Address where CustomersId=@customersId ";

        await context.Connection().ExecuteAsync(sql, customer);
    }

    public async Task<List<Customers>> GetCustomers()
    {
        var sql = "select * from Customers";

        var list = await context.Connection().QueryAsync<Customers>(sql);

        return list.ToList();
    }

    public async Task<CustomerOrders> GetCustomerWithOrders(int customersId)
    {

        var sql = @"select * from Customers where CustomersId=@customersId;

                   select * from Orders where CustomerId=@customersId";

        CustomerOrders odin = new CustomerOrders();


        using (var multiple = await context.Connection().QueryMultipleAsync(sql, new { CustomersId = customersId }))
        {
           odin.Customer = await multiple.ReadFirstAsync<Customers>();

            var list = await multiple.ReadAsync<Orders>();

             odin.Orders = list.ToList();

        }

        return odin;
    }
}
