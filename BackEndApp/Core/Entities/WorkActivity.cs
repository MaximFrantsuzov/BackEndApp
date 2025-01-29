using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEndApp.Core.Enums;

namespace BackEndApp.Core.Entities
{
    //Трудовая деятельность (приём,перевод,уволнение)
    public class WorkActivity
    {
        [Key]
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime Date_Event { get; set; }
        public TypeEventEmployee TypeEventEmployee { get; set; }
        ////relations
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }

    }
}
