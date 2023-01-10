using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class SubjectRepository : Repository<SubjectEntity>, ISubjectRepository
    {
        public SubjectRepository(AppDBContext context) : base(context)
        {

        }
    }
}
