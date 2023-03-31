namespace BeHealthBackend.DTOs.RecipeDtoFolder
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Patient { get; set; }
        public int PatientId { get; init; }
        public long Date { get; set; }
        public string Medicament { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
    }
}
