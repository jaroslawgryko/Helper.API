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
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(userParams.InstytucjaRodzaj) && userParams.InstytucjaRodzaj != "all" )
            {
                users = users.Where(u => u.InstytucjaRodzaj == userParams.InstytucjaRodzaj);
            }

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }        

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(j => j.Jednostki).FirstOrDefaultAsync(u => u.Id == id);
            
            return user;
        }          
    }
}