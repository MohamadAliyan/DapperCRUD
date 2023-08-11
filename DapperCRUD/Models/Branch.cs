using System.ComponentModel;

namespace DapperCRUD.Models
{
    public class Branch: BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public int   BankId { get; set; }
    }
    public class BranchDto:BaseEntity
    {
        [DisplayName("نام شعبه")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string BankName { get; set; }
    }
}
