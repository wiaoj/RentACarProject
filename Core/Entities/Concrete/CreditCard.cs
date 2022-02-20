using Core.Entities.Abstract;

namespace Core.Entities.Concrete {
    public class CreditCard : IEntity {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public String FullName { get; set; }
        public String CardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int Cvv { get; set; }
    }
}