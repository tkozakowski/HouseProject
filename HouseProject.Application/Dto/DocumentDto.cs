using System;

namespace HouseProject.Application.Dto
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public decimal Cost { get; set; }
        public DateTime? ReceivedAt { get; set; }
    }
}
