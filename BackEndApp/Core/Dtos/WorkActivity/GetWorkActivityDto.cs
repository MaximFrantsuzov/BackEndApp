using BackEndApp.Core.Enums;

namespace BackEndApp.Core.Dtos.WorkActivity
{
    public class GetWorkActivityDto
    {
        public int Id { get; set; }
        public DateTime Date_Event { get; set; }
        public TypeEventEmployee TypeEventEmployee { get; set; }
        public int EmployeeId { get; set; }
        public string FIO {  get; set; }
        public int DepartamentId { get; set; }
        public string DepartamentName { get; set; }

    
    }
}
