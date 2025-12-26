using StudentAttandanceManagement.Aplication.Services;
using StudentAttandanceManagement.Domain;

namespace StudentAttandanceManagement.Client
{
    

    class Program
    {
        static StudentService studentService = new StudentService();
        static AttendanceService attendanceService = new AttendanceService();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Student Attendance Menu ===");
                Console.WriteLine("1. Student qo'shish");
                Console.WriteLine("2. Studentlarni ko'rish");
                Console.WriteLine("3. Attendance qo'shish");
                Console.WriteLine("4. Attendance ro'yxatini ko'rish");
                Console.WriteLine("0. Chiqish");

                Console.Write("\nTanlang: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        GetAllStudents();
                        break;

                    case "3":
                        AddAttendance();
                        break;

                    case "4":
                        GetAllAttendance();
                        break;

                    case "0":
                        Console.WriteLine("Dastur yakunlandi.");
                        return;

                    default:
                        Console.WriteLine("Noto'g'ri tanlov! Qayta tanlang.");
                        break;
                }
            }
        }

        

        static void AddStudent()
        {
            Console.Write("\nStudent Id kiriting: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("To‘liq ism kiriting: ");
            string fullName = Console.ReadLine();

            Student student = new Student
            {
                Id = id,
                FullName = fullName
            };

            studentService.Add(student);
            Console.WriteLine("Student muvaffaqiyatli qo‘shildi!");
        }

        static void GetAllStudents()
        {
            var students = studentService.GetAll();

            Console.WriteLine("\n=== Studentlar ro'yxati ===");

            if (students.Count == 0)
            {
                Console.WriteLine("Hali studentlar yo‘q!");
                return;
            }

            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.Id} | FullName: {s.FullName}");
            }
        }

        static void AddAttendance()
        {
            Console.Write("\nAttendance Id kiriting: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Student Id kiriting: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("IsPresent (true/false): ");
            bool present = bool.Parse(Console.ReadLine());

            Console.Write("Sana (YYYY-MM-DD): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Attandance attendance = new Attandance
            {
                Id = id,
                StudentId = studentId,
                IsPresent = present,
                Date = date
            };

            attendanceService.Add(attendance);
            Console.WriteLine("Attendance muvaffaqiyatli qo‘shildi!");
        }

        static void GetAllAttendance()
        {
            var list = attendanceService.GetAll();

            Console.WriteLine("\n=== Attendance List ===");

            if (list.Count == 0)
            {
                Console.WriteLine("Hali attendance kiritilmagan!");
                return;
            }

            foreach (var a in list)
            {
                Console.WriteLine(
                    $"ID:{a.Id} | StudentId:{a.StudentId} | Present:{a.IsPresent} | Date:{a.Date.ToShortDateString()}");
            }
        }
    }

}

