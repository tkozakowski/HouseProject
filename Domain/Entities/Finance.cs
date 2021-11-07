using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Finance")]
    public class Finance : AuditableEntity
    {
        public int Id { get; set; }
        public decimal? ProjectsCost { get; set; }
        public decimal? PreparationsCost { get; set; }
        public decimal? DocumentsCost { get; set; }
        public decimal? ExecutionsCost { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Preparation> Preparations { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Execution> Executions { get; set; }
    }
}
