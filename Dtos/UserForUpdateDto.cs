using System.ComponentModel.DataAnnotations;

namespace Helper.API.Dtos
{
    public class UserForUpdateDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        [StringLength(120)]
        public string InstytucjaNazwa { get; set; }
        [Required]
        [StringLength(16)]
        public string InstytucjaSymbol { get; set; }
        [Required]
        [StringLength(32)]
        public string InstytucjaRodzaj { get; set; }         
    }
}