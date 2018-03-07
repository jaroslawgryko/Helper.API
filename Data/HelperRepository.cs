using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.API.Helpers;
using Helper.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Helper.API.Data
{
    public class HelperRepository : IHelperRepository
    {
        private readonly DataContext _context;
        public HelperRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
 
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }      

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;  // jeżeli jest więcej zmian niż 0
        }          

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.OrderByDescending(u => u.OstatniaAktywnosc).AsQueryable();

            if (!string.IsNullOrEmpty(userParams.InstytucjaRodzaj) && userParams.InstytucjaRodzaj != "all" && userParams.InstytucjaRodzaj != "undefined" )
            {
                users = users.Where(u => u.InstytucjaRodzaj == userParams.InstytucjaRodzaj);
            }

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "utworzony":
                        users = users.OrderByDescending(u => u.Utworzony);
                        break;
                    default:
                        users = users.OrderByDescending(u => u.OstatniaAktywnosc);
                        break;
                }
            }

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }        

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(j => j.Jednostki).FirstOrDefaultAsync(u => u.Id == id);
            
            return user;
        }          

        public async Task<Jednostka> GetJednostka(int id)
        {
            return await _context.Jednostki.FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<Jednostka> GetJednostkaUser(int userId, int id)
        {
            return await _context.Jednostki.FirstOrDefaultAsync(j => j.Id == id && j.UserId == userId);
        }

        public async Task<IEnumerable<Jednostka>> GetJednostkiUser(int userId)
        {
            var jednostki = await _context.Jednostki.Where(j => j.UserId == userId).ToListAsync();

            return jednostki;
        }
    }
}