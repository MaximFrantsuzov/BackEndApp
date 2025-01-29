using BackEndApp.Core.Enums;

namespace BackEndApp.Core.Dtos.HistorySubdivision
{
    public class CreateHistorySubdidvisionDto
    {
        public TypeEventDepSub TypeEventDepSub { get; set; }
        DateTime DateChangeHistory { get; set; }
        public int SubdivisionId { get; set; }
        public string SubdivisionName { get; set; }
    }
}
