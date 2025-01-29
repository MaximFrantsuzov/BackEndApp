using BackEndApp.Core.Enums;

namespace BackEndApp.Core.Dtos.HistoryDepartament
{
    public class GetHistoryDepartamentDto
    {
        public int ID { get; set; }
        public TypeEventDepSub TypeEventDepSub { get; set; }
        public DateTime DateChangeHistory { get; set; }

        //relations
        public int DepartamentId { get; set; }
        public string NameDepartament {  get; set; }    
    }
}
