namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public Course()
        {
            StudentsEnrolled = new HashSet<StudentCourse>();
            Resources = new HashSet<Resource>();
            HomeworkSubmissions = new HashSet<Homework>();
        }

        public int CourseId { get; set; }

        public string Description { get; set; }

        public DateTime EndDate { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public ICollection<StudentCourse> StudentsEnrolled { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
