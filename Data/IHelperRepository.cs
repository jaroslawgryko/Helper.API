using System.Collections.Generic;
using System.Threading.Tasks;
using Helper.API.Helpers;
using Helper.API.Models;

namespace Helper.API.Data
{
    public interface IHelperRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(int id);         
    }
}