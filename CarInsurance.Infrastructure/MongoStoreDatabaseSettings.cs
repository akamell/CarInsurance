namespace CarInsurance.Infrastructure
{
    public class MongoStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
