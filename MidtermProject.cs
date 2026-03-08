using System;
using System.IO;
using System.Collections.Generic;

namespace MidtermProject
{
    public enum MenuOption
    {
        A = 1,
        B,
        C,
        D,
        E

    }

    public class Student
    {
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Course { get; set; }
        public int Year { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Grade { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            List<Student> students = new List<Student>();

            while (running)
            {
                Console.WriteLine("\n+++++++++++++++++++++++++++++\n" +
                                  "|         MAIN MENU         |\n" +
                                  "+++++++++++++++++++++++++++++\n" +
                                  "|1. Register Student        |\n" +
                                  "|2. Enroll Student Subjects |\n" +
                                  "|3. Enter Grades            |\n" +
                                  "|4. Show Grade by Student   |\n" +
                                  "|5. Exit                    |\n" +
                                  "+++++++++++++++++++++++++++++\n" +
                                  "Enter Choice (A/B/C/D/E):");

                string input = Console.ReadLine().ToUpper();
                Console.WriteLine("Invalid choice");


                if (!Enum.TryParse(input, out MenuOption choice))
                {
                    Console.Clear();
                }

                switch (choice)
                {
                    case MenuOption.A:
                        Console.Clear();
                        Console.WriteLine("Registering Student...");
                        RegisterStudent register = new RegisterStudent();
                        register.Execute(students);
                        break;
                    case MenuOption.B:
                        Console.Clear();
                        Console.WriteLine("Enrolling Student to Subjects...");
                        EnrollStudent enroll = new EnrollStudent();
                        enroll.Execute(students);
                        break;
                    case MenuOption.C:
                        Console.Clear();
                        Console.WriteLine("Entering Grades to Student...");
                        GradeStudent grade = new GradeStudent();
                        grade.Execute(students);
                        break;
                    case MenuOption.D:
                        Console.Clear();
                        Console.WriteLine("Showing Grade by Students...");
                        ShowGradeStudent show = new ShowGradeStudent();
                        show.Execute(students);
                        break;
                    case MenuOption.E:
                        Console.Clear();
                        Console.WriteLine("Thank you for using the program...");
                        running = false;
                        break;
                }
            }
        }
    }

    public class RegisterStudent
    {
        public void Execute(List<Student> students)
        {
            Console.Clear();
            bool running = true;
            Student student = new Student();

            while (running)
            {
                Console.WriteLine("Enter Student's First Name:");
                string firstName = Console.ReadLine();

                student.FirstName = firstName;

                Console.WriteLine("Enter Student's Middle Initial:");
                string middleInitial = Console.ReadLine();

                student.MiddleInitial = middleInitial;

                Console.WriteLine("Enter Student's Last Name:");
                string lastName = Console.ReadLine();

                student.LastName = lastName;

                DateTime birthDate;

                Console.WriteLine("Enter Student's Date of Birth (yyyy-MM-dd):");

                while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null,
                       System.Globalization.DateTimeStyles.None, out birthDate)
                       || birthDate > DateTime.Now)
                {
                    Console.WriteLine("Invalid date. Please enter a valid date in format yyyy-MM-dd:");
                }

                student.BirthDate = birthDate.ToString("yyyy-MM-dd");

                int age = DateTime.Now.Year - birthDate.Year;
                if (DateTime.Now < birthDate.AddYears(age))
                {
                    age--;
                }

                Console.WriteLine("Enter Student's Address:");
                string address = Console.ReadLine();

                student.Address = address;

                bool inputting = true;
                int contactNumber;
                while (inputting)
                {
                    Console.WriteLine("Enter Students Contact Number:");
                    string number = Console.ReadLine();
                    if (!int.TryParse(number, out contactNumber) && contactNumber < 1 && contactNumber > 12)
                    {
                        Console.WriteLine("Invalid. please enter contact number");
                    }
                    else
                    {
                        student.ContactNumber = contactNumber.ToString();
                        inputting = false;
                    }
                }

                students.Add(student);

                running = false;
            }

            string path = "Names.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (Student s in students)
                {
                    writer.WriteLine("Student First Name: " + s.FirstName);
                    writer.WriteLine("Student Middle Initial: " + s.MiddleInitial);
                    writer.WriteLine("Student Last Name: " + s.LastName);
                    writer.WriteLine("Student Birthdate: " + s.BirthDate);
                    writer.WriteLine("Student Age: " + s.Age);
                    writer.WriteLine("Student Address: " + s.Address);
                    writer.WriteLine("Student Contact Number: " + s.ContactNumber);
                    writer.WriteLine("++++++++++++++++++++++++++++++++++++++++++\n");
                }
            }
        }
    }


    public class EnrollStudent
    {
        public void Execute(List<Student> students)
        {
            Console.Clear();

            Console.Clear();

            string path = "Names.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("No registered students found.");
                return;
            }

            List<string> studentNames = new List<string>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Student First Name:"))
                    {
                        string name = line.Replace("Student First Name:", "").Trim();
                        studentNames.Add(name);
                    }
                }
            }

            if (studentNames.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("Registered Students:");

            for (int i = 0; i < studentNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {studentNames[i]}");
            }

            Console.WriteLine("Select student number:");
            int choice = int.Parse(Console.ReadLine());

            string selectedStudent = studentNames[choice - 1];

            Console.WriteLine("Enter Subject 1:");
            string subject1 = Console.ReadLine();

            Console.WriteLine("Enter Subject 2:");
            string subject2 = Console.ReadLine();

            Console.WriteLine("Enter Subject 3:");
            string subject3 = Console.ReadLine();

            string newPath = "StudentNames.txt";

            using (StreamWriter writer = new StreamWriter(newPath, true))
            {
                writer.WriteLine("Student: " + selectedStudent);
                writer.WriteLine("Subject1: " + subject1);
                writer.WriteLine("Subject2: " + subject2);
                writer.WriteLine("Subject3: " + subject3);
                writer.WriteLine("----------------------");
            }

            Console.WriteLine("Subjects successfully enrolled.");
        }
    }

    public class GradeStudent
    {
        public void Execute(List<Student> students)
        {
            Console.Clear();

            string path = "StudentNames.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("No enrolled students found.");
                return;
            }

            List<string> studentEntries = new List<string>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Student:"))
                    {
                        studentEntries.Add(line);
                    }
                }
            }

            for (int i = 0; i < studentEntries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {studentEntries[i]}");
            }

            Console.WriteLine("Select student to grade:");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter grade for Subject 1:");
            int g1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter grade for Subject 2:");
            int g2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter grade for Subject 3:");
            int g3 = int.Parse(Console.ReadLine());

            string result1 = (g1 >= 75) ? "Passed" : "Failed";
            string result2 = (g2 >= 75) ? "Passed" : "Failed";
            string result3 = (g3 >= 75) ? "Passed" : "Failed";

            using (StreamWriter writer = new StreamWriter("StudentGrades.txt", true))
            {
                writer.WriteLine(studentEntries[choice - 1]);
                writer.WriteLine("Subject1 Grade: " + g1 + " - " + result1);
                writer.WriteLine("Subject2 Grade: " + g2 + " - " + result2);
                writer.WriteLine("Subject3 Grade: " + g3 + " - " + result3);
                writer.WriteLine("------------------------");
            }

            Console.WriteLine("Grades successfully recorded.");

        }
    }

    public class ShowGradeStudent
    {
        public void Execute(List<Student> students)
        {
            Console.Clear();

            string path = "StudentGrades.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("No grades recorded.");
                Console.ReadKey();
                return;
            }

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }    
}