namespace BackEndApp.Core.Dtos.Departament
{
    public class GetDepartamentDto
    {
        public int Id { get; set; }
        public string NameDepartament { get; set; }

        public int SubdivisionId { get; set; }
        public string SubdivisionName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
