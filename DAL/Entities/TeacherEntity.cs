using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class TeacherEntity
    {
        [ForeignKey("UserEntity")]
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string EducationDegree { get; set; }
        public virtual UserEntity UserEntity { get; set; }
        public IList<TeacherSubjectEntity> TeacherSubjects { get; set; }
        public IList<IndScheduleRequestTeacherEntity> TeacherIndScheduleRequests { get; set; }
    }
}
