using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class TeacherSubjectEntity
    {
        public string TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }

        public string SubjectId { get; set; }
        public SubjectEntity Subject { get; set; }
    }
}
