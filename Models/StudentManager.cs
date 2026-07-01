using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_grade_management_system.Models
{
    internal class StudentManager
    {
        private List<Student> students;
        public StudentManager()
        {
            students = new List<Student>();
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public void DisplayAllStudents()
        {
            foreach (var student in students)
                student.DisplayStudentInformation();
            Console.WriteLine();
        }
        public Student? GetStudentByID(int studentId)
        {
            return students.FirstOrDefault(s => s.StudentId == studentId);
        }
    }
}