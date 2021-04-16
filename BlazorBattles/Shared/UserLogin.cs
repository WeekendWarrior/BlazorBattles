using System.ComponentModel.DataAnnotations;

namespace BlazorBattles.Shared
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Please enter a Username.")]
        public string Username { get; set; }

        [Required] 
        public string Password { get; set; }
    }
}
