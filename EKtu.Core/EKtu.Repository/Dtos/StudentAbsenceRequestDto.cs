﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKtu.Repository.Dtos
{
    public class StudentAbsenceRequestDto
    {
        public int UserId { get; set; }
        public int LessonId { get; set; }
    }
}
