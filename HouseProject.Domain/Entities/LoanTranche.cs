namespace HouseProject.Domain.Entities
{
    public class LoanTranche
    {
        public int Id { get; set; }
        public string Stage { get; set; }
        public decimal Amount { get; set; }
    }
}
