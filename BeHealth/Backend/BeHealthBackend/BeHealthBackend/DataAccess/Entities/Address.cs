namespace BeHealthBackend.DataAccess.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
