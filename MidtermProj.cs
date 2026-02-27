using System;
using static TESTRAH.Program;

namespace TESTRAH
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
        public string firstname { get; set; }
        public string middleinitial { get; set; }
        public string lastname { get; set; }
        public string birthdate { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string Contactnumber { get; set; }
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
            Console.WriteLine("DIS NUTZ");
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