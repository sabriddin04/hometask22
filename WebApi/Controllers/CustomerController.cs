using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
namespace WebApi.Controllers;


[Controller]
[Route("[controller]")]
public class CustomerController : ControllerBase
{

    private readonly CustomerService customerService;

    public CustomerController()
    {
        customerService = new CustomerService();
    }


    [HttpDelete("delete-Customer")]

    public async Task DeleteCustomer(int customersId)
    {
        await customerService.DeleteCustomer(customersId);
    }


    [HttpGet("GEt-Customer")]


    public async Task<List<Customers>> GetCustomers()
    {
        return await customerService.GetCustomers();
    }


   [HttpPost("add-Customer")]
   
    public async Task AddCustomer(Customers customer)
    {
      
      await customerService.AddCustomer(customer);

    }

    [HttpPut("Update-Customer")]

     public async Task UpdateCustomer(Customers customer)
    {
        await customerService.UpdateCustomer(customer);

    }

  
    [HttpGet("GEt-Customer-with-orders")]
     public async Task<CustomerOrders> GetCustomerWithOrders(int customersId)
    {
       return await customerService.GetCustomerWithOrders(customersId);
    }



}
