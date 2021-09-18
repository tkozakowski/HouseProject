using Domain.Common;

namespace Domain.Entities
{
    public class WorkStage: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
