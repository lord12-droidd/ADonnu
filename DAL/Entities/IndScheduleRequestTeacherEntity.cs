using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class IndScheduleRequestTeacherEntity
    {
        public string IndScheduleRequestId { get; set; }
        public IndScheduleRequestEntity IndScheduleRequest { get; set; }

        public string TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public int TeacherPosition { get; set; }
        
    }
}
