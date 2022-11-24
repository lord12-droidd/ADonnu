using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADonnu.Models
{
    public class StudentModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public string Group { get; set; }
        public string Faculty { get; set; }
        public string EducationForm { get; set; }
        public string FinancingForm { get; set; }
        public string EducationDegree { get; set; }
    }
}
