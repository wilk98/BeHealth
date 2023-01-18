namespace BeHealthBackend.Entities
{
    public abstract class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
        public DateTime Created { get; }
        public virtual List<Visit> Visits { get; set; } = new List<Visit>();
    }
}
