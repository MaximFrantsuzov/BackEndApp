using BackEndApp.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndApp.Core.Dtos.Employee
{
    //dto Получение данных о сотруднике(ах)
    public class GetEmployeeDto
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
        public string DepartamentName { get; set; }
        public int JobTotleId { get; set; }
        public string JobTitleName { get; set; }
    }
}
