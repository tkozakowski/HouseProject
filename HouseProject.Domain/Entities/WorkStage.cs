using HouseProject.Domain.Common;

namespace HouseProject.Domain.Entities
{
    public class WorkStage: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
