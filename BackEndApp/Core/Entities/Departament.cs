using System.ComponentModel.DataAnnotations;

namespace BackEndApp.Core.Entities
{   
    //Отдел
    public class Departament
    {
        [Key]
        public int Id { get; set; }
        public string NameDepartament { get; set; }
        public bool IsDeleted { get; set; }
        //relations
        public int SubdivisionId {  get; set; }
        public Subdivision Subdivision { get; set; }
        public ICollection<WorkActivity> WorkActivities { get; set; }
        public ICollection<HistoryDepartament> HistoryDepartaments { get; set; }
        public ICollection<Employee> Employees { get; set; }
  

    }
}
