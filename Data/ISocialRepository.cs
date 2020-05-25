using System.Collections.Generic;
using System.Threading.Tasks;
using CommunitySocial.API.Models;

namespace CommunitySocial.API.Data
{
    public interface ISocialRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
         Task<Photo> GetPhoto(int id);
         
    }
}