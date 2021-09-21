using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Execution : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? EstimatedCost { get; set; }
        public decimal? CostPayed { get; set; }
        public decimal? Account { get; set; }
        public decimal? LaborCost { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }



        public int WorkStageID { get; set; }
        public virtual WorkStage WorkStage { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}
