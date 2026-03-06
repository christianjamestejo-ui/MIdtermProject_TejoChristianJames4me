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
        public string StudentName { get;set; }
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
                Console.WriteLine("Enter Student's Date of Birth(yyyy-MM-dd):");
                while(!DateTime.TryParse(Console.ReadLine(), out birthDate) || birthDate > DateTime.Now)
                {
                    Console.WriteLine();
                }
                student.BirthDate = birthDate;

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
                        student.ContactNumber = contactNumber;
                        inputting = false;
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
                    writer.WriteLine("Student First Name: " + s.FirstName);
                    writer.WriteLine("Student Middle Initial: " + s.MiddleInitial);
                    writer.WriteLine("Student Last Name: " + s.LastName);
                    writer.WriteLine("Student Birthdate: " + s.BirthDate);
                    writer.WriteLine("Student Age: " + s.Age);
                    writer.WriteLine("Student Address:" + s.Address);
                    writer.WriteLine("Student Contact Number:" + s.ContactNumber);
                }
            }
        }
    }
      

    public class EnrollStudent
    {
        public void Execute(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("DEEZ NUTZ");
        }
    }
    public class GradeStudent
    {
        public void Execute(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("DAZ NUTZ");
        }
    }
    public class ShowGradeStudent
    {
        public void Execute(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("RAAAAAAAAHHHHHHHHH");
        }
    }
}