﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EKtu.Repository.Dtos
{
    public class StudentChooseLessonCacheDto
    {
        public LessonCacheDto LessonCacheDtos{ get; set; }
    }
}
