using System.Collections.Generic;

namespace Domain.Entities
{
    public class Stage
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
