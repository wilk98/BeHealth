namespace BeHealthBackend.DataAccess.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public DateTime Created { get; set; }
        public string? Medicament { get; set; }
        public int? Quantity { get; set; }
        public string? Code { get; set; }
    }
}
