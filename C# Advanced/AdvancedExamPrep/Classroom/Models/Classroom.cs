using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject.Models
{
    public class Classroom
    {
        private ICollection<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>(Capacity);
        }
        public int Count { get; set; }
        public int Capacity { get; set; }

        public string RegisterStudent(Student student)
        {
            if (Capacity > Count)
            {
                students.Add(student);

                Count++;

                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return $"No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (students.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                students.Remove(students.First(x => x.FirstName == firstName && x.LastName == lastName));

                Count--;

                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            if (students.Any(x => x.Subject == subject))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}")
                    .AppendLine("Students:");
                foreach (var student in students.Where(x => x.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().Trim();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
