namespace BeHealthBackend.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime VisiDate { get; set; }
    }
}
