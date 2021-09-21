using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WorkStage: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Execution> Executions { get; set; }
    }
}
