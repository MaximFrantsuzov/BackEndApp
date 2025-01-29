using System.ComponentModel.DataAnnotations;

namespace BackEndApp.Core.Entities
{
    //Отделения
    public class Subdivision
    {
        [Key]
        public int Id { get; set; }
        public string NameSubdivision { get; set; }
        public bool IsDeleted { get; set; }
        //Relations
        public ICollection<Departament> Departaments { get; set; }
        public ICollection<HistorySubdivision> HistorySubdivisions { get; set; }
       

     
    }
}
