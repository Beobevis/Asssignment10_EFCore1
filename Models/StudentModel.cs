using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EntitySample.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

    }
    public class StudentEditModel : StudentCreateModel{ 
        public int Id { get; set; }
    }
    public class StudentCreateModel
    {

        [Required, MaxLength(50)]
        public string? FirstName { get; set; }
        [Required, MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(30)]
        public string? City { get; set; }
        
        public string? State { get; set; }
    }

}
