using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Helper.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime Utworzony { get; set; }
        public DateTime OstatniaAktywnosc { get; set; }
        public string InstytucjaNazwa { get; set; }
        public string InstytucjaSymbol { get; set; }
        public string InstytucjaRodzaj { get; set; }
        public ICollection<Jednostka> Jednostki { get; set; }
        public User()
        {
            Jednostki = new Collection<Jednostka>();
        }

    }
}