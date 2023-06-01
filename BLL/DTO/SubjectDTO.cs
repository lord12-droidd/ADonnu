using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class SubjectDTO
    {
        public string Name { get; set; }
        public IList<StudentDTO> Students { get; set; }
        public IList<TeacherDTO> Teachers { get; set; }
    }
}
