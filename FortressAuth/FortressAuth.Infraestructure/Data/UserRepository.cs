using FortressAuth.Domain.Entity;
using FortressAuth.Domain.Interfaces;
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
    }
}
