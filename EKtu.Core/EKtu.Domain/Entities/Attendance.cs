﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKtu.Domain.Entities
{
    public class Attendance:BaseEntity
    {
        public StudentChooseLesson StudentChooseLesson { get; set; }
        public int StudentChooseLessonId{ get; set; }
        public bool IsPresent { get; set; }

    }
}