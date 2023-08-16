using System.ComponentModel;

namespace DapperCRUD.Models
{
    public class Address : BaseEntity
    {
        [DisplayName("شهر")]
        public string City { get; set; }
        [DisplayName("خیابان")]
        public string Street { get; set; }
        [DisplayName("کوچه")]
        public string Alley { get; set; }
        [DisplayName("کد پستی")]
        public string PostalCode { get; set; }
        public int CustomerId { get; set; }

    }
}
