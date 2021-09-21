using Domain.Common;
using Domain.Enum;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class LoanTranche: AuditableEntity
    {
        public int Id { get; set; }
        public LoanTrancheStage Stage { get; set; }
        public decimal Amount { get; set; }

        public ICollection<Materials> Materials { get; set; }
    }
}
