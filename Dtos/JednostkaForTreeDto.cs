using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Helper.API.Dtos
{
    public class JednostkaForTreeDto
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Symbol { get; set; }
        public DateTime DataModyfikacji { get; set; }
        public JednostkaForListDto Parent { get; set; }
        public int? ParentId { get; set;}        
        public ICollection<JednostkaForListDto> Children { get; set; }
        public JednostkaForTreeDto()
        {
            Children = new Collection<JednostkaForListDto>();
        }             
    }
}