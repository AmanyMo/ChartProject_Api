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
           //var n=  customers.GroupBy(c => c.Service).Select(s=>s.Count(s=>s.Service));
            var retCustomers= customers.Skip(0).Take(60);
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
                return Ok(customers.Take(40));
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
                return Ok(customers.Take(50));
            }
            else
                return NoContent();
        }


        [HttpGet("countperservice")]
        public async Task<ActionResult<int>> GetCustomerCountPerService(string service)
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
        [HttpGet("getperyear")]
        public async Task<ActionResult<int>> GetCustomerCountPeryear(int year)
        {
            IEnumerable<TechnicalDataOrange> customersCount = await _customer.GetCustomersCountPerYear(year);
            if (customersCount.Count() > 0)
            {
              var GroupCustomerPerYear=  customersCount.GroupBy(c => c.ContractDate.Value.Month).Select(c=>
                new
                {
                   month= c.Key,
                   count=c.Count()
                }).ToArray();
                if (GroupCustomerPerYear.Length>0)
                {
                    return Ok(GroupCustomerPerYear);
                }
            }
                return NoContent();
        }

        [HttpGet("countpereachservice")]
        public async Task<ActionResult<TechnicalDataOrange>> GetCustomerCountPerEachService()
        {
            IEnumerable<TechnicalDataOrange> customersGroup = await _customer.GetAllCustomers();
            var groupCustomers = customersGroup.GroupBy((c)=>c.Service)
                .Select(a=> new
                {
                    serviceName=a.Key,
                    count=a.Count()
                }).ToArray();
            if (groupCustomers.Length > 0)
            {
                return Ok(groupCustomers);
            }
            else
                return NoContent();
        }

    }
}
