namespace BeHealthBackend.DataAccess.Entities;
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Doctor? Doctor { get; set; }
    public virtual Patient? Patient { get; set; }
}