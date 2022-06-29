namespace ChartProject_Api.Data
{
    public class DbModel:DbContext
    {
        public DbModel(DbContextOptions<DbModel> options):base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Customer> Technical_Data_Orange { set; get; }
    }
}
