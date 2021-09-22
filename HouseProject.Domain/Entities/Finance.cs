using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Finances")]
    public class Finance : AuditableEntity
    {
        public int Id { get; set; }
        public decimal? Savings { get; set; }
        public decimal? CashExpenses { get; set; }
        public decimal? CreditExpenses { get; set; }
        public decimal? Difference { get; set; }

        public int LoanTrancheId { get; set; }
        public virtual LoanTranche LoanTranche { get; set; }
    }
}
