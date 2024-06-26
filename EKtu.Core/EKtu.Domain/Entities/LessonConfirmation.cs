﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKtu.Domain.Entities
{
    public class LessonConfirmation:BaseEntity
    {
        public Lesson Lesson{ get; set; }
        public Student Student{ get; set; }
        public int StudentId{ get; set; }
        public int LessonId{ get; set; }
        public ExamNote ExamNote{ get; set; }
    }
}
