using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }        

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(j => j.Jednostki).FirstOrDefaultAsync(u => u.Id == id);
            
            return user;
        }          
    }
}