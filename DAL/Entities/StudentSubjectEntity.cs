using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class StudentSubjectEntity
    {
        public string StudentId { get; set; }
        public StudentEntity Student { get; set; }

        public string SubjectId { get; set; }
        public SubjectEntity Subject { get; set; }
    }
}
