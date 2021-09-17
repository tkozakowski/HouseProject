using HouseProject.Domain.Common;
using System.Collections.Generic;

namespace HouseProject.Domain.Entities
{
    public class Post: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
