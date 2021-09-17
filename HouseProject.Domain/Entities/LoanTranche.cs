using HouseProject.Domain.Common;
using HouseProject.Domain.Enum;

namespace HouseProject.Domain.Entities
{
    public class LoanTranche: AuditableEntity
    {
        public int Id { get; set; }
        public LoanTrancheStage Stage { get; set; }
        public decimal Amount { get; set; }
    }
}
