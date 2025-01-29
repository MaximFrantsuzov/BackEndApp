namespace BackEndApp.Core.Dtos.Departament
{
    public class UpdateDepartamentDto
    {
        public int Id { get; set; }
        public string NameDepartament { get; set; }

        public int SubdivisionId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
