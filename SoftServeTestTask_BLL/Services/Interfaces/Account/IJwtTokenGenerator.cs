using SoftServeTestTask_DAL.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_BLL.Services.Interfaces.Account
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);

    }
}
