using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySocial.API.Helpers;
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

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId)
                        .FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users =  _context.Users.Include(p => p.Photos);

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            //if 0 returns false else true where 0 means no chnages happened
            return await _context.SaveChangesAsync() > 0;
        }
    }
}