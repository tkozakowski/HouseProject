using HouseProject.Domain.Enum;
using System;

namespace HouseProject.Domain.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Stage Stage { get; set; }
        public string Recipient { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public Payment Payment { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        
        public int? SendTypeId { get; set; }
        public SendType SendType { get; set; }

        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

    }
}
