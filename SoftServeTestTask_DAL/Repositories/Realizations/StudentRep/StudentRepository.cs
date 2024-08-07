using SoftServeTestTask_DAL.Database;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.StudentRep;
using SoftServeTestTask_DAL.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_DAL.Repositories.Realizations.StudentRep
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(CoursesDbContext _db) : base(_db)
        {

        }
    }
}
