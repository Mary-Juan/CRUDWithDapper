namespace CRUDWithDapper.Models
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public int BankId { get; set; }
    }
}
