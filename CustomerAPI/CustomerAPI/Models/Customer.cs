namespace CustomerAPI
{
    public class Customer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime created { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
