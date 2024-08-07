using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Entities.Account;
using SoftServeTestTask_DAL.Repositories.Interfaces.BaseRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_DAL.Repositories.Interfaces.AccountRep
{
    public interface IAccountRepository : IRepositoryBase<ApplicationUser>
    {
        Task<ApplicationUser> GetUserByUserName(string name);
        Task<ApplicationUser> GetUserByEmail(string email);
    }
}
