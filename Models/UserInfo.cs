using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExprementProject.Models
{
    public class UserInfo
    {

        public UserInfo() {
            Id = 0;
            Name = "";
            Email = "";
            Password = "";
            Contact = "";
            Address = "";
            Message = "";

        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        [NotMapped]
        public string Message { get; set; }
        
        








    }
}
