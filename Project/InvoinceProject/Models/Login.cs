using System.ComponentModel.DataAnnotations;

namespace InvoinceProject.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}
