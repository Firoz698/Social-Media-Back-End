
using System.ComponentModel.DataAnnotations;

namespace ExprementProject.Models
{
    public class FileTabel
    {
        public FileTabel()
        {
            Id = 0;
            Image = null;
        }
        [Key]
        public int Id { get; set; } 
        public byte[]? Image { get; set; }
    }
}
