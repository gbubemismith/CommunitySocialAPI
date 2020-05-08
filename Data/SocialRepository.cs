using System.Collections.Generic;
using System.Threading.Tasks;
using CommunitySocial.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunitySocial.API.Data
{
    public class SocialRepository : ISocialRepository
    {
        private readonly DataContext _context;

        public SocialRepository(DataContext context)
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

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            //if 0 returns false else true where 0 means no chnages happened
            return await _context.SaveChangesAsync() > 0;
        }
    }
}