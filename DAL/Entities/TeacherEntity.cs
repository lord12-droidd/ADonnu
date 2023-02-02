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
        public virtual UserEntity UserEntity { get; set; }
    }
}
