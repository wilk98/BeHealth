using System.ComponentModel.DataAnnotations.Schema;
namespace BeHealthBackend.DataAccess.Entities;

public class Certificate
{
    public int Id { get; set; }
    public virtual Doctor Doctor { get; set; }
    public string Filename { get; set; } = null!;
}