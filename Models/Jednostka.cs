using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helper.API.Models
{
    [Table("Jednostki")]
    public class Jednostka
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Symbol { get; set; }
        public string Opis { get; set; }
        public DateTime DataModyfikacji { get; set; }
        public bool IsMain { get; set; }
        public User User    { get; set;}
        public int UserId { get; set; }
    }
}