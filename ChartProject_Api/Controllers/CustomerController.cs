using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartProject_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        //api/customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnicalDataOrange>>> GetAll()
        {
           IEnumerable<TechnicalDataOrange> customers =  await _customer.GetAllCustomers();
            var retCustomers= customers.Skip(0).Take(20);
            if (customers.Count()>0)
            {

                return Ok(retCustomers);
            }
            else
             return NoContent();
        }

        [HttpGet("expired")]
        public async Task<ActionResult<IEnumerable<TechnicalDataOrange>>> GetAllExpired()
        {
            var customers = await _customer.GetAllCustomersExpired();
            if (customers.Count()>0)
            {
                return Ok(customers.Take(20));
            }
            else
            return NoContent();
        }

        [HttpGet("willExpired")]
        public async Task<ActionResult<IEnumerable<TechnicalDataOrange>>> GetAllWillBeExpired()
        {
            var customers = await _customer.GetAllCustomersWillExpired();
            if (customers.Count() > 0)
            {
                return Ok(customers.Take(20));
            }
            else
                return NoContent();
        }


        [HttpGet("countperservice")]
        public async Task<ActionResult<int>> GetCustomerCount(string service)
        {
            var customersCount = await _customer.GetCustomersCountByService(service);
            if (customersCount > 0)
            {
                return Ok(customersCount);
            }
            else
                return NoContent();
        }
        [HttpGet("getperdate")]
        public async Task<ActionResult<int>> GetCustomerCountPerDate(int month, int year)
        {
            var customersCount = await _customer.GetCustomersCountPerMonthPerYear(month, year);
            if (customersCount > 0)
            {
                return Ok(customersCount);
            }
            else
                return NoContent();
        }

    }
}
