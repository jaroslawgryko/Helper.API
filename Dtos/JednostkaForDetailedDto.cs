using System;

namespace Helper.API.Dtos
{
    public class JednostkaForDetailedDto
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Symbol { get; set; }
        public string Opis { get; set; }
        public DateTime DataModyfikacji { get; set; }
        public bool IsMain { get; set; }        
    }
}