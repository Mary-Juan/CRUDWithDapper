using CRUDWithDapper.Models;
using System.ComponentModel;

namespace CRUDWithDapper.DTOs
{
    public class BranchDTO : BaseEntity
    {

        [DisplayName("نام شعبه")]
        public string Name { get; set; }

        public string Code { get; set; }

        public string TelephoneNumber { get; set; }

        public string Address { get; set; }

        public string BankName { get; set; }
    }
}
