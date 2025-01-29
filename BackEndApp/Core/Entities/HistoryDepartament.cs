using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEndApp.Core.Enums;

namespace BackEndApp.Core.Entities
{
    //история создания закрытия отделов
    public class HistoryDepartament
    {
        [Key]
        public int ID { get; set; }
        public TypeEventDepSub TypeEventDepSub { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime DateChangeHistory { get; set; }

        //relations
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }
       
    }
}
