using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_grade_management_system.Models
{
    internal class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private static int StudentsCounter = 1;
        public int StudentId { get; init; }
        public Dictionary<string, double> Grades { get; private set; }
        public Student(string FirstName, string LastName, Dictionary<string, double> Grades)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            StudentId = StudentsCounter++;
            this.Grades = Grades;
        }
        public void AddGrade(string subject, double grade)
        {
            Grades[subject] = grade;
        }
        public double CalculateAverageGrade()
        {
            if (Grades.Count == 0)
                return 0.0;
            double total = 0.0;
            foreach (var grade in Grades.Values)
                total += grade;
            return total / Grades.Count;
        }
        public void DisplayStudentInformation()
        {
            Console.WriteLine($"Student ID : {StudentId}");
            Console.WriteLine($"Name : {FirstName} {LastName}");
            Console.WriteLine("Grades : ");
            foreach (var subject in Grades)
                Console.WriteLine($"{subject.Key} : {subject.Value}");
            Console.WriteLine("======================================================");
        }
        public string GetStudentName()
        {
            return ($"{FirstName} {LastName}");
        }
    }
}