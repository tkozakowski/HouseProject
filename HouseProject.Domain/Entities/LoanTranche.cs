using Domain.Common;
using Domain.Enum;

namespace Domain.Entities
{
    public class LoanTranche: AuditableEntity
    {
        public int Id { get; set; }
        public LoanTrancheStage Stage { get; set; }
        public decimal Amount { get; set; }
    }
}
