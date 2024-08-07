using Microsoft.EntityFrameworkCore;
using SoftServeTestTask_DAL.Database;
using SoftServeTestTask_DAL.Entities.Account;
using SoftServeTestTask_DAL.Repositories.Interfaces.AccountRep;
using SoftServeTestTask_DAL.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_DAL.Repositories.Realizations.Account
{
    public class AccountRepository : RepositoryBase<ApplicationUser>, IAccountRepository
    {
        public AccountRepository(CoursesDbContext db) : base(db)
        {
        }

        public async Task<ApplicationUser> GetUserByUserName(string name)
        {
            return await _db.Set<ApplicationUser>().FirstAsync(x => x.UserName == name);
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _db.Set<ApplicationUser>().FirstAsync(x => x.Email == email);
        }
    }
}
