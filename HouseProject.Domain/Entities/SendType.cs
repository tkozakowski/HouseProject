using System.Collections.Generic;

namespace HouseProject.Domain.Entities
{
    public class SendType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
