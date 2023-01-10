using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class StudentEntity
    {
        [ForeignKey("UserEntity")]
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Course { get; set; }
        public string Group { get; set; }
        public string Faculty { get; set; }
        public string EducationForm { get; set; }
        public string FinancingForm { get; set; }
        public string EducationDegree { get; set; }
        public virtual UserEntity UserEntity { get; set; }
    }
}
