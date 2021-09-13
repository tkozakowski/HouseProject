using HouseProject.Domain.Enum;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HouseProject.Domain.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public DateTime? SendAt { get; set; }
        public string SendBy { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public Payment? Payment { get; set; }
        public decimal Cost { get; set; }

        public string PostId { get; set; }
        public virtual Post Post { get; set; }

        public ICollection<Attachment> Attachments { get; set; }

    }
}
