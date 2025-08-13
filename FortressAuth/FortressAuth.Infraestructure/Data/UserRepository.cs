using FortressAuth.Domain.Entity;
using FortressAuth.Domain.Interfaces;
using FortressAuth.Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;

namespace FortressAuth.Infraestructure.Data
{
    public class UserRepository : IUserRepository
    {
        public SqlServerDbContext _sqlServerDbContext { get; set; }
        public UserRepository(SqlServerDbContext sqlServerDbContext)
        {
            this._sqlServerDbContext = sqlServerDbContext;
        }
        public Task AddUserAsync(User user)
        {
            _sqlServerDbContext.Users.AddAsync(user);

            return _sqlServerDbContext.SaveChangesAsync();
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            return _sqlServerDbContext.Users.FirstOrDefaultAsync<User>(user => user.Email == email);
        }

        public Task<List<User>> GetAllUsersAsync(UserFilter userFilter)
        {
            IQueryable<User> query = _sqlServerDbContext.Users;

            if (userFilter.Id.HasValue)
            {
                query = query.Where(user => user.Id == userFilter.Id.Value);
            }

            if (!string.IsNullOrEmpty(userFilter.Name))
            {
                query = query.Where(user => user.Name.ToUpper() == userFilter.Name.ToUpper());
            }

            if (!string.IsNullOrEmpty(userFilter.Email))
            {
                query = query.Where(user => user.Email.ToUpper() == userFilter.Email.ToUpper());
            }

            if (userFilter.DhInclusionGreaterThan.HasValue)
            {
                query = query.Where(user => user.DhInclusion >= userFilter.DhInclusionGreaterThan.Value);
            }

            if (userFilter.DhInclusionLessThan.HasValue)
            {
                query = query.Where(user => user.DhInclusion <= userFilter.DhInclusionLessThan.Value);
            }

            if (userFilter.DhChangeGreaterThan.HasValue)
            {
                query = query.Where(user => user.DhChange >= userFilter.DhChangeGreaterThan.Value);
            }

            if (userFilter.DhChangeLessThan.HasValue)
            {
                query = query.Where(user => user.DhChange <= userFilter.DhChangeLessThan.Value);
            }

            return query.ToListAsync();
        }
    }
}
