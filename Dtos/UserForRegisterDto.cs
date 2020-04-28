using System.ComponentModel.DataAnnotations;

namespace CommunitySocial.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required] 
        [StringLength(8, MinimumLength = 3, ErrorMessage = "You must specify password between 3 and 8 characters")]
        public string Password { get; set; }

    }
}