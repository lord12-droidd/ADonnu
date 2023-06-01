using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class SubjectEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<StudentSubjectEntity> StudentSubjects { get; set; }
        public IList<TeacherSubjectEntity> TeacherSubjects { get; set; }

    }
}
