using BackEndApp.Core.Enums;

namespace BackEndApp.Core.Dtos.HistoryDepartament
{
    public class CreateHistoryDepartamentDto
    {
        public TypeEventDepSub TypeEventDepSub { get; set; }
        DateTime DateChangeHistory { get; set; }
        public int DepartamentId { get; set; }
      
    }
}
