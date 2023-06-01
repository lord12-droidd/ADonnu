using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class IndScheduleRequestEntity
    {
        [ForeignKey("StudentEntity")]
        [Key]
        public string Id { get; set; }
        public string AzureAccessPath { get; set; }
        public virtual StudentEntity StudentEntity { get; set; }
        public IList<IndScheduleRequestTeacherEntity> IndScheduleRequestTeachers { get; set; }
    }
}
