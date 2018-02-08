using System;
using System.ComponentModel.DataAnnotations;

namespace Helper.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]        
        [StringLength(16, MinimumLength=4, ErrorMessage="Hasło musi mieć od 4 do 16 znaków.")]
        public string  Password { get; set; }     
        [Required]
        public string  Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        public DateTime Utworzony { get; set; }
        public DateTime OstatniaAktywnosc { get; set; }     
        [Required]
        [StringLength(60)]
        public string InstytucjaNazwa { get; set; }
        [Required]
        [StringLength(16)]        
        public string InstytucjaSymbol { get; set; }
        [Required]
        [StringLength(32)]
        public string InstytucjaRodzaj { get; set; }        
        public UserForRegisterDto()
        {
            Utworzony = DateTime.Now;
            OstatniaAktywnosc = DateTime.Now;
        }         
    }
}