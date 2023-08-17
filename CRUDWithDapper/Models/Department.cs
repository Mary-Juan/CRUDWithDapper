namespace CRUDWithDapper.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
    }
}
