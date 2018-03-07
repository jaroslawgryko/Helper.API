using System;

namespace Helper.API.Dtos
{
    public class JednostkaForListDto
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Symbol { get; set; }
        public DateTime DataModyfikacji { get; set; }
        public JednostkaForListDto Parent { get; set; }
        public int? ParentId { get; set;}
    }
}