using System.ComponentModel.DataAnnotations;

namespace Helper.API.Dtos
{
    public class UserForRegisterDto
    {
       [Required]
       public string Username { get; set; }
       [Required]        
       [StringLength(16, MinimumLength=4, ErrorMessage="Długość hasła musi być między 4 a 16 znaków.")]
       public string  Password { get; set; }        
    }
}