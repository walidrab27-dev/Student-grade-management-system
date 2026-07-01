using System.ComponentModel.Design;
using System.Numerics;
using Student_grade_management_system.Models;
namespace Student_grade_management_system;

class Program
{
    public static void Menu()
    {
        var studentManager = new StudentManager();
        string? choice;
        while (true)
        {
            Console.WriteLine("\n--- Student Grade Management System ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Assign Grades");
            Console.WriteLine("3. Calculate Average Grade");
            Console.WriteLine("4. Display Student Information");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string? firstName, lastName;
                    do
                    {
                        Console.WriteLine("Enter student first name : ");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter student last name : ");
                        lastName = Console.ReadLine();
                    } while (String.IsNullOrEmpty(firstName) || String.IsNullOrWhiteSpace(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrWhiteSpace(lastName));
                    var newStudent = new Student(firstName, lastName, new Dictionary<string, double>());
                    studentManager.AddStudent(newStudent);
                    Console.WriteLine($"Student added successfully! Generated ID is: {newStudent.StudentId}");
                    break;
                case "2":
                    Console.WriteLine("Enter student ID : ");
                    if (int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        var student = studentManager.GetStudentByID(studentId);
                        if (student != null)
                        {
                            string? subject;
                            do
                            {
                                Console.WriteLine("Enter Subject : ");
                                subject = Console.ReadLine();
                                Console.WriteLine("Enter Grade : ");
                            } while (String.IsNullOrEmpty(subject) || String.IsNullOrWhiteSpace(subject));

                            if (double.TryParse(Console.ReadLine(), out double grade) && (grade >= 0 && grade <= 100))
                            {
                                student.AddGrade(subject, grade);
                                Console.WriteLine("Grade assigned successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid grade input.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID input.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter student ID : ");
                    if (int.TryParse(Console.ReadLine(), out int avgStudentID))
                    {
                        var student = studentManager.GetStudentByID(avgStudentID);
                        if (student != null)
                        {
                            string name = student.GetStudentName();
                            double averageGrade = student.CalculateAverageGrade();
                            Console.WriteLine($"Average Grade for {name}: {averageGrade:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID input.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter student ID : ");
                    if (int.TryParse(Console.ReadLine(), out int infoStudentId))
                    {
                        var student = studentManager.GetStudentByID(infoStudentId);
                        if (student != null)
                        {
                            student.DisplayStudentInformation();
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID input.");
                    }
                    break;
                case "5":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static void Main(string[] args)
    {
        Menu();
    }
}
