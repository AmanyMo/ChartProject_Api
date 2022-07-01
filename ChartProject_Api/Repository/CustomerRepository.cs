using ChartProject_Api.Interfaces;

namespace ChartProject_Api.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly CustomerContext _context;
        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TechnicalDataOrange>> GetAllCustomers()
        {
           // IQueryable<TechnicalDataOrange> v =  _context.TechnicalDataOranges;
           //var items= v.Skip(0).Take(20);
           // return (IEnumerable<TechnicalDataOrange>)items.ToListAsync();


          return await _context.TechnicalDataOranges.ToListAsync();
        }

        public async Task<IEnumerable<TechnicalDataOrange>> GetAllCustomersExpired()
        {
            return await _context.TechnicalDataOranges.Where(d=>d.ContractExpiryDate<DateTime.Now).ToListAsync();
        }

        public async Task<IEnumerable<TechnicalDataOrange>> GetAllCustomersWillExpired()
        {
            return await _context.TechnicalDataOranges
                .Where(d => d.ContractExpiryDate < (DateTime.Now.AddMonths(1)) 
                && d.ContractExpiryDate > DateTime.Now).ToListAsync();
        }

        public async Task<int> GetCustomersCountByService(string serviceType)
        {
            return await _context.TechnicalDataOranges.Where(s => s.Service == serviceType).CountAsync();
        }

        public async Task<int> GetCustomersCountPerMonthPerYear(int month, int year)
        {
            return await _context.TechnicalDataOranges
                .Where(s => 
                    s.ContractDate.Value.Month == month && s.ContractDate.Value.Year == year).CountAsync();

        }

        public async Task<IEnumerable<TechnicalDataOrange>> GetCustomersCountPerYear(int year)
        {
            var customers = await _context.TechnicalDataOranges.
                Where(c=> c.ContractDate.Value.Year==year).ToListAsync();
              return customers;
        }
    }
}
