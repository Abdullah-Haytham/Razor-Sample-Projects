﻿using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class DepartmentModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public List<CourseModel> Courses { get; set; } = [];
        public List<StudentModel> Students { get; set; } = [];
    }
}
