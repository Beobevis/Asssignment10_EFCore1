using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntitySample.Data.Entities;
[Table("Student")]
public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string? FirstName { get; set; }
    [Required, MaxLength(50)]
    public string? LastName { get; set; }
    [MaxLength(30)]
    public string? City { get; set; }
    [NotMapped]
    public string? State { get; set; }

    //public virtual Group group{get;set;}
}