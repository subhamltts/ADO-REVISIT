﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityADODTO
{
    public class CourseDTO
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public int Duration{ get; set; }
        public string Owner { get; set; }
        public string AssessmentMode { get; set; }

    }
}
