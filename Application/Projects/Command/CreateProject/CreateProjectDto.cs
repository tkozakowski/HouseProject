using System;

namespace Application.Projects.Command.CreateProject
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string Supplier { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public int? PaymentTypeId { get; set; }

    }
}
