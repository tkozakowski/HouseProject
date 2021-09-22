using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Materials")]
    public class Material: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public decimal? PriceItem { get; set; }
        public string PurchasePlace { get; set; }
        public string Photo { get; set; }


        public int? LoanTrancheId { get; set; }
        public virtual LoanTranche LoanTranche { get; set; }

        public int ExecutionId { get; set; }
        public virtual Execution Execution { get; set; }

        public int? PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
