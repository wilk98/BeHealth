namespace BeHealthBackend.Entities
{
    public class Patient : Person
    {
        public Guid Id { get; set; }
        public int Pesel { get; set; }
        public virtual List<Visit> Visits { get; set; } = new List<Visit>();
    }
}
