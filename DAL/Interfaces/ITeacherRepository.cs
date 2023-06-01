﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITeacherRepository
    {
        Task<TeacherEntity> GetTeacherByIdAsync(string id);
    }
}
