using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADonnu.Models
{
    public class IndScheduleRequestModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Course { get; set; }
        public string Group { get; set; }
        public string Faculty { get; set; }
        public string EducationForm { get; set; }
        public string FinancingForm { get; set; }
        public string EducationDegree { get; set; }
        public string Reason { get; set; }
        public string EndDate { get; set; }
        public string StartDate { get; set; }
        public string Phone { get; set; }
        public string Speciality { get; set; }
        public string Adds { get; set; }
        public string Signature { get; set; }
        public IList<TeacherSubjectModel> SubjectsForm { get; set; }
        public IList<string> Files { get; set; }
    }

    public class TeacherSubjectModel
    {
        public string CombinedTeacherName { get; set; }
        public string SubjectName { get; set; }
        public string Email { get; set; }
    }

}
