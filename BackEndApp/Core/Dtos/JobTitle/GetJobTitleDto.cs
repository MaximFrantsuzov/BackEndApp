using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndApp.Core.Dtos.JobTitle
{
    public class GetJobTitleDto
    {
        public int Id { get; set; }
        public string NameJobTitle { get; set; }
        [Required]
        [Column(TypeName = "numeric")]
      
        public Decimal Salary { get; set; }
    }
}
