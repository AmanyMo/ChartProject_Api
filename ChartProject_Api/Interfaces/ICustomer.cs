namespace ChartProject_Api.Interfaces
{
    public interface ICustomer
    {
        public Task<IEnumerable<TechnicalDataOrange>> GetAllCustomers();
        public Task<IEnumerable<TechnicalDataOrange>> GetAllCustomersExpired();
        public Task<IEnumerable<TechnicalDataOrange>> GetAllCustomersWillExpired();
        public Task<int> GetCustomersCountByService(string serviceType);
        public Task<int> GetCustomersCountPerMonthPerYear(int month,int year);


    }
}
