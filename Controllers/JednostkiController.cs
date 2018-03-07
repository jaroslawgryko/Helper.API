using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.API.Data;
using Helper.API.Dtos;
using Helper.API.Helpers;
using Helper.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helper.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    public class JednostkiController : Controller
    {
        private readonly IHelperRepository _repo;
        private readonly IMapper _mapper;
        public JednostkiController(IHelperRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Register(int userId, [FromBody]JednostkaForRegisterDto jednostkaForRegisterDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();      

            var parent = await _repo.GetJednostkaUser(userId, jednostkaForRegisterDto.ParentId);
            if (parent == null)
                return BadRequest("Nie znaleziono jednostki nadrzędnej");

            var jednostka = _mapper.Map<Jednostka>(jednostkaForRegisterDto);      
            jednostka.DataModyfikacji = DateTime.Now;
            jednostka.Parent = parent;
            jednostka.UserId = userId;
            jednostka.IsMain = false;

            _repo.Add(jednostka);

            var jednostkaToReturn = _mapper.Map<JednostkaForListDto>(jednostka);
            jednostkaToReturn.Id = jednostka.Id;

            if(await _repo.SaveAll())
            {
                return CreatedAtRoute("GetJednostka", new { id = jednostka.Id }, jednostkaToReturn );
            }

            throw new System.Exception("Dodanie jednostki nie powiodło się");
        }

        [HttpGet("{id}", Name = "GetJednostka")]
        public async Task<IActionResult> GetJednostka(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var jednostkaFromRepo = await _repo.GetJednostkaUser(userId, id);

            if (jednostkaFromRepo == null)
                return NotFound();
            
            var jednostkaForReturn = _mapper.Map<Jednostka, JednostkaForDetailedDto>(jednostkaFromRepo);

            return Ok(jednostkaForReturn);
        }


        [HttpGet]
        public async Task<IActionResult> GetJednostkiUser(int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var jednostkiFromRepo = await _repo.GetJednostkiUser(userId);
            if (jednostkiFromRepo == null)
                return NotFound();

            var jednostkiForReturn = _mapper.Map<IEnumerable<JednostkaForTreeDto>>(jednostkiFromRepo);

            return Ok(jednostkiForReturn);

        }
    }
}