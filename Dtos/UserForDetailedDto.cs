using System;
using System.Collections.Generic;

namespace Helper.API.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime Utworzony { get; set; }
        public DateTime OstatniaAktywnosc { get; set; }     
        public string InstytucjaNazwa { get; set; }
        public string InstytucjaSymbol { get; set; }
        public string InstytucjaRodzaj { get; set; }         
        public ICollection<JednostkaForDetailedDto> Jednostki { get; set; }
    }
}