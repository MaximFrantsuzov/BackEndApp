using BackEndApp.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApp.Core.Entities
{
    //История создания и закрытия отделений
    public class HistorySubdivision
    {
        [Key]
        public int Id { get; set; }
        public TypeEventDepSub TypeEventDepSub { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName ="date")]
        public DateTime DateChangeHistory { get; set; }

        //Relations
        public int SubdivisionId { get; set; }
        public Subdivision Subdivision { get; set; }
       
    }
}
