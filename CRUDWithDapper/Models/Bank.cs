namespace CRUDWithDapper.Models
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
    }
}
