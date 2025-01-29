using BackEndApp.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndApp.Core.Dtos.Employee
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HomeAdress { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string NumberPhone { get; set; }
        public LevelEducation LevelEducation { get; set; }
        public int DepartamentId { get; set; }
        public int JobTitleId { get; set; }
    }
}
