﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Executions")]
    public class Execution : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? EstimatedCost { get; set; }
        public decimal? CostPayed { get; set; }
        public decimal? LaborCost { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }


        public int WorkStageID { get; set; }
        public virtual WorkStage WorkStage { get; set; }

        public int? FinanceId { get; set; }
        public virtual Finance Finance { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}
