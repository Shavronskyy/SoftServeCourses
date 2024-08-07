using SoftServeTestTask_DAL.Database;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.CourseRep;
using SoftServeTestTask_DAL.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_DAL.Repositories.Realizations.CourseRep
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(CoursesDbContext context) : base(context)
        {

        }
    }
}
