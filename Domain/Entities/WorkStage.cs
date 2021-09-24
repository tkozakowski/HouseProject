using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("WorkStages")]
    public class WorkStage: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Execution> Executions { get; set; }
    }
}
