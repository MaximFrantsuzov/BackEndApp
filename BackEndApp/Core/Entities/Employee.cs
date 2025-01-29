using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEndApp.Core.Enums;

namespace BackEndApp.Core.Entities
{
    //Отделения
    public class Employee
    {
        [Key]
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
        public bool isDismissal { get; set; }
        public int TitleJobId { get; set; }
        public JobTitle JobTitle { get; set; }
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }
        // relations
        public ICollection<WorkActivity> WorkActivities { get; set; }
        
    }
}
