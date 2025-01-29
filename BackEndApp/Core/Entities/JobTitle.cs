using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApp.Core.Entities
{
    //Должность
    public class JobTitle
    {
        [Key]
        public int Id { get; set; }
        public string NameJobTitle { get; set; }
        [Required]
        [Column(TypeName = "numeric")]
      
        public Decimal Salary {  get; set; }

        //relations
        public ICollection<Employee> Employees { get; set; }

    }
}
