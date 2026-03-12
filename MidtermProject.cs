using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

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

    public enum Inputting
    {
        False = 0,
        True = 1
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

    public class EnrolledStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public int Year { get; set; }
        public List<string> Subjects { get; set; } = new List<string>();
    }

    public class Subject
    {
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
    }

    public static class SubjectList
    {
        public static List<Subject> Subjects = new List<Subject>()
    {
        new Subject { SubjectID="IT-101A", SubjectName="Introduction to Computing"},
        new Subject { SubjectID="IT-102A", SubjectName="Computer Programming"},
        new Subject { SubjectID="IT-103A", SubjectName="Introduction to Human Computer Interactions"},
        new Subject { SubjectID="MATH-105A", SubjectName="Discrete Mathematics"},
        new Subject { SubjectID="GEC-101A", SubjectName="Mathematics in the Modern World"},
        new Subject { SubjectID="GEC-102A", SubjectName="Philippine Popular Culture"},
        new Subject { SubjectID="PE-101A", SubjectName="Physical Education 1"},
        new Subject { SubjectID="THEO-101A", SubjectName="Introduction to Catholic Faith 1"},
        new Subject { SubjectID="COMP-102IT", SubjectName="Computer Applications"},
        new Subject { SubjectID="IT-104A", SubjectName="Computer Programming 2"},
        new Subject { SubjectID="IT-105A", SubjectName="Platform Technologies"},
        new Subject { SubjectID="IT-106A", SubjectName="IT Social and Professional Issues"},
        new Subject { SubjectID="GEC-103A", SubjectName="Understanding the Self"},
        new Subject { SubjectID="GEC-104A", SubjectName="Art Appreciation"},
        new Subject { SubjectID="RZL-101A", SubjectName="Life and Works of Rizal"},
        new Subject { SubjectID="PE-102A", SubjectName="Physical Education"},
        new Subject { SubjectID="THEO-102A", SubjectName="Scriptures, the Sacraments and Liturgy"}
    };
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            List<Student> students = new List<Student>();

            while (running)
            {
                Console.Clear();
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

            while (running)
            {
                Student student = new Student();

                bool validFirst = false;
                while (!validFirst)
                {
                    Console.WriteLine("Enter Student's First Name:");
                    string firstName = Console.ReadLine();

                    if (firstName.Length == 0)
                    {
                        Console.WriteLine("First name cannot be empty.");
                    }
                    else
                    {
                        bool lettersOnly = true;

                        for (int i = 0; i < firstName.Length; i++)
                        {
                            char c = firstName[i];

                            if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                            {
                                lettersOnly = false;
                            }
                        }

                        if (!lettersOnly)
                        {
                            Console.WriteLine("First name must contain letters only.");
                        }
                        else
                        {
                            student.FirstName = firstName;
                            validFirst = true;
                        }
                    }
                }

                bool inputting = true;
                while (inputting)
                {
                    Console.WriteLine("Enter Student's Middle Initial:");
                    string middleInitial = Console.ReadLine().ToUpper();

                    if (middleInitial.Length != 1)
                    {
                        Console.WriteLine("Please only enter One(1) Letter...");
                    }
                    else
                    {
                        char c = middleInitial[0];

                        if (!((c >= 'A' && c <= 'Z')))
                        {
                            Console.WriteLine("Middle initial must be a letter.");
                        }
                        else
                        {
                            student.MiddleInitial = middleInitial;
                            inputting = false;
                        }
                    }
                }

                bool validLast = false;
                while (!validLast)
                {
                    Console.WriteLine("Enter Student's Last Name:");
                    string lastName = Console.ReadLine();

                    if (lastName.Length == 0)
                    {
                        Console.WriteLine("Last name cannot be empty.");
                    }
                    else
                    {
                        bool lettersOnly = true;

                        for (int i = 0; i < lastName.Length; i++)
                        {
                            char c = lastName[i];

                            if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                            {
                                lettersOnly = false;
                            }
                        }

                        if (!lettersOnly)
                        {
                            Console.WriteLine("Last name must contain letters only.");
                        }
                        else
                        {
                            student.LastName = lastName;
                            validLast = true;
                        }
                    }
                }

                DateTime birthDate;
                Console.WriteLine("Enter Student's Date of Birth (yyyy-MM-dd):");

                while (!DateTime.TryParse(Console.ReadLine(), out birthDate) || birthDate > DateTime.Now)
                {
                    Console.WriteLine("Invalid date. Please try again:");
                }

                student.BirthDate = birthDate.ToString("yyyy-MM-dd");

                int age = DateTime.Now.Year - birthDate.Year;

                if (DateTime.Now < birthDate.AddYears(age))
                {
                    age--;
                }

                student.Age = age;

                Console.WriteLine("Enter Student's Address:");
                student.Address = Console.ReadLine();

                bool inputtingContactNumber = true;

                while (inputtingContactNumber)
                {
                    Console.WriteLine("Enter Student's Contact Number:");
                    string number = Console.ReadLine();

                    if (number.Length == 0)
                    {
                        Console.WriteLine("Contact number cannot be empty.");
                    }
                    else
                    {
                        bool digitsOnly = true;

                        for (int i = 0; i < number.Length; i++)
                        {
                            char c = number[i];

                            if (!(c >= '0' && c <= '9'))
                            {
                                digitsOnly = false;
                            }
                        }

                        if (!digitsOnly)
                        {
                            Console.WriteLine("Contact number must contain numbers only.");
                        }
                        else
                        {
                            student.ContactNumber = number;
                            inputtingContactNumber = false;
                        }
                    }
                }

                bool validCourse = false;

                while (!validCourse)
                {
                    Console.WriteLine("Enter Student Course (Example: BSIT):");
                    string course = Console.ReadLine();

                    if (course.Length == 0)
                    {
                        Console.WriteLine("Course cannot be empty.");
                    }
                    else
                    {
                        student.Course = course;
                        validCourse = true;
                    }
                }

                bool validYear = false;

                while (!validYear)
                {
                    Console.WriteLine("Enter Student Year (1-4):");
                    string yearInput = Console.ReadLine();

                    int year;

                    if (int.TryParse(yearInput, out year))
                    {
                        if (year >= 1 && year <= 4)
                        {
                            student.Year = year;
                            validYear = true;
                        }
                        else
                        {
                            Console.WriteLine("Year must be between 1 and 4.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid year.");
                    }
                }

                students.Add(student);
                running = false;
            }

            string path = "Names.txt";

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Student s in students)
                {
                    writer.WriteLine("-----------------STUDENT------------------");
                    writer.WriteLine("Student First Name: " + s.FirstName);
                    writer.WriteLine("Student Middle Initial: " + s.MiddleInitial + ".");
                    writer.WriteLine("Student Last Name: " + s.LastName);
                    writer.WriteLine("Student Birthdate: " + s.BirthDate);
                    writer.WriteLine("Student Age: " + s.Age);
                    writer.WriteLine("Student Address: " + s.Address);
                    writer.WriteLine("Student Contact Number: " + s.ContactNumber);
                    writer.WriteLine("Student Course: " + s.Course + ", " + "Year: " + s.Year);
                    writer.WriteLine("++++++++++++++++++++++++++++++++++++++++++");
                    writer.WriteLine();
                }
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }

    public class EnrollStudent
    {
        public void Execute(List<Student> students)
        {
            Console.Clear();
            string path = "Names.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("No registered students found.");
                Console.ReadKey();
                return;
            }

            // Read registered students from file
            List<Student> studentList = new List<Student>();
            List<string> lines = new List<string>(File.ReadAllLines(path));
            Student temp = null;

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];

                if (line.StartsWith("Student First Name:"))
                {
                    temp = new Student();
                    temp.FirstName = line.Replace("Student First Name:", "").Trim();
                }
                else if (line.StartsWith("Student Middle Initial:"))
                {
                    if (temp != null)
                        temp.MiddleInitial = line.Replace("Student Middle Initial:", "").Replace(".", "").Trim();
                }
                else if (line.StartsWith("Student Last Name:"))
                {
                    if (temp != null)
                    {
                        temp.LastName = line.Replace("Student Last Name:", "").Trim();
                    }
                }
                else if (line.StartsWith("Student Course:"))
                {
                    if (temp != null)
                    {
                        string[] parts = line.Replace("Student Course:", "").Split(',');
                        temp.Course = parts[0].Trim();
                        temp.Year = int.Parse(parts[1].Replace("Year:", "").Trim());
                        studentList.Add(temp);
                    }
                }
            }

            if (studentList.Count == 0)
            {
                Console.WriteLine("No students found.");
                Console.ReadKey();
                return;
            }

            // List students
            Console.WriteLine("Registered Students:\n");
            for (int i = 0; i < studentList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + studentList[i].FirstName + " " + studentList[i].LastName);
            }

            Console.WriteLine("\nSelect student number:");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > studentList.Count)
            {
                Console.WriteLine("Invalid selection. Try again.");
            }

            Student selected = studentList[choice - 1];

            // Map full student info into enrolled
            EnrolledStudent enrolled = new EnrolledStudent
            {
                FirstName = selected.FirstName,
                LastName = selected.LastName,
                Course = selected.Course,
                Year = selected.Year
            };

            Console.Clear();
            Console.WriteLine("Available Subjects:\n");

            for (int i = 0; i < SubjectList.Subjects.Count; i++)
            {
                Console.WriteLine(SubjectList.Subjects[i].SubjectID + " - " + SubjectList.Subjects[i].SubjectName);
            }

            Console.WriteLine("\nEnter 9 Subject SubjectIDs:\n");

            while (enrolled.Subjects.Count < 9)
            {
                Console.Write("Subject " + (enrolled.Subjects.Count + 1) + ": ");
                string subjectID = Console.ReadLine().ToUpper();

                bool validSubject = false;
                for (int i = 0; i < SubjectList.Subjects.Count; i++)
                {
                    if (SubjectList.Subjects[i].SubjectID == subjectID)
                    {
                        validSubject = true;
                        break;
                    }
                }

                if (!validSubject)
                {
                    Console.WriteLine("Invalid subject SubjectID. Please choose from the list.");
                    continue;
                }

                bool duplicate = enrolled.Subjects.Contains(subjectID);
                if (duplicate)
                {
                    Console.WriteLine("Subject already added.");
                }
                else
                {
                    enrolled.Subjects.Add(subjectID);
                }
            }

            // Save to JSON
            string json = JsonSerializer.Serialize(enrolled);
            List<string> jsonLines = new List<string>();
            if (File.Exists("EnrolledStudents.json"))
            {
                jsonLines.AddRange(File.ReadAllLines("EnrolledStudents.json"));
            }
            jsonLines.Add(json);
            File.WriteAllLines("EnrolledStudents.json", jsonLines);

            Console.WriteLine("\nStudent successfully enrolled with 9 subjects.");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }

    public class GradeStudent
    {
        public void Execute(List<Student> students)
        {
            Console.Clear();

            string path = "EnrolledStudents.json";
            string namePath = "Names.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("No enrolled students.");
                Console.ReadKey();
                return;
            }

            List<EnrolledStudent> enrolledList = new List<EnrolledStudent>();
            foreach (string line in File.ReadAllLines(path))
            {
                enrolledList.Add(JsonSerializer.Deserialize<EnrolledStudent>(line));
            }

            // List all enrolled students
            for (int i = 0; i < enrolledList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {enrolledList[i].LastName}, {enrolledList[i].FirstName}");
            }

            Console.WriteLine("\nSelect student number to enter grades:");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > enrolledList.Count)
            {
                Console.WriteLine("Invalid selection. Try again.");
            }

            var selectedStudent = enrolledList[choice - 1];

            // Input grades (50-100 only)
            List<int> grades = new List<int>();
            foreach (string subject in selectedStudent.Subjects)
            {
                int grade;
                do
                {
                    Console.WriteLine($"Enter grade for {subject} (50-100):");
                } while (!int.TryParse(Console.ReadLine(), out grade) || grade < 50 || grade > 100);

                grades.Add(grade);
            }

            // Build output string including Course and Year
            string output = "++++++++++++++++++++\n";
            output += $" {selectedStudent.LastName}, {selectedStudent.FirstName} \n";
            output += "++++++++++++++++++++\n";
            output += $" {selectedStudent.Course} - {selectedStudent.Year} \n";
            output += "++++++++++++++++++++\n";

            for (int i = 0; i < selectedStudent.Subjects.Count; i++)
            {
                output += $" {selectedStudent.Subjects[i]} ----------{grades[i]} \n";
            }
            output += "++++++++++++++++++++\n";

            // Overwrite Names.txt to show grades with student info
            File.WriteAllText(namePath, output);

            Console.WriteLine("Grades Recorded.");
            Console.ReadKey();
        }
    }

    public class ShowGradeStudent
    {
        public void Execute(List<Student> students)
        {
            Console.Clear();

            string path = "Names.txt";

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