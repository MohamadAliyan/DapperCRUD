namespace DapperCRUD.Models
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Alley { get; set; }
        public string PostalCode { get; set; }
        public int CustomerId { get; set; }

    }
}
