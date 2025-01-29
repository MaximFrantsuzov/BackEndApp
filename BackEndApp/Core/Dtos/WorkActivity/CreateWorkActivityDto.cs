using BackEndApp.Core.Enums;

namespace BackEndApp.Core.Dtos.WorkActivity
{
    public class CreateWorkActivityDto
    {
        public DateTime Date_Event { get; set; }
        public TypeEventEmployee TypeEventEmployee { get; set; }
        ////relations
        public int EmployeeId { get; set; }
        public int DepartamentId { get; set; }
    }
}
