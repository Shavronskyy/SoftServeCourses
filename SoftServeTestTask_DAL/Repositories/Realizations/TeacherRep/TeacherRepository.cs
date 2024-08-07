using SoftServeTestTask_DAL.Database;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.TeacherRep;
using SoftServeTestTask_DAL.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_DAL.Repositories.Realizations.TeacherRep
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(CoursesDbContext _db) : base(_db)
        {

        }
    }
}
