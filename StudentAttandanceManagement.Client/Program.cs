using StudentAttandanceManagement.Aplication.Services;
using StudentAttandanceManagement.Domain;
using StudentAttandanceManagement.Domain.Models;

namespace StudentAttandanceManagement.Client
{


    class Program
    {
        static StudentService studentService = new StudentService();
        static AttendanceService attendanceService = new AttendanceService();
        static ExternalAttendanceService service = new ExternalAttendanceService();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=====Menular=====");
                Console.WriteLine("1.Student Attendance Menu");
                Console.WriteLine("2.Zoom Attendance Menu");

                Console.Write("Tanlang (0 chiqish uchun): ");
                string mainChoice = Console.ReadLine();
                switch (mainChoice)
                {
                    case "1":
                        StudentAttendanceMenu();
                        break;
                    case "2":
                        ZoomAttendanceMenu();
                        break;
                    case "0":
                        Console.WriteLine("Dastur yakunlandi.");
                        return;
                    default:
                        Console.WriteLine("Noto'g'ri tanlov! Qayta tanlang.");
                        break;
                }
            }

            static void StudentAttendanceMenu()
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

            static void ZoomAttendanceMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("     ZOOM ATTENDANCE BOSHQARUV MENYUSI");
                    Console.WriteLine("========================================");
                    Console.WriteLine("1. Barcha qatnashuvchilarni ko‘rish");
                    Console.WriteLine("2. Ism bo‘yicha qidirish");
                    Console.WriteLine("3. Email bo‘yicha qidirish");
                    Console.WriteLine("4. Faqat mehmonlarni ko‘rish (Host)");
                    Console.WriteLine("5. Kutish zalida bo‘lganlarni ko‘rish");
                    Console.WriteLine("6. Eng ko‘p qatnashganlarni ko‘rish (Top 5)");
                    Console.WriteLine("7. Qatnashuvchilar sonini ko‘rish");
                    Console.WriteLine("0. Dasturdan chiqish");
                    Console.WriteLine("----------------------------------------");
                    Console.Write("Tanlovingizni kiriting: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ShowList(service.GetAll());
                            break;

                        case "2":
                            Console.Write("Ism kiriting: ");
                            string name = Console.ReadLine();
                            var byName = service.GetByName(name);
                            ShowSingle(byName);
                            break;

                        case "3":
                            Console.Write("Email kiriting: ");
                            string email = Console.ReadLine();
                            var byEmail = service.GetByEmail(email);
                            ShowSingle(byEmail);
                            break;

                        case "4":
                            ShowList(service.GetGuests());
                            break;

                        case "5":
                            ShowList(service.GetWaitingRoom());
                            break;

                        case "6":
                            ShowList(service.GetMostActive());
                            break;

                        case "7":
                            Console.WriteLine($"Jami qatnashuvchilar soni: {service.GetCount()}");
                            Console.ReadKey();
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Noto‘g‘ri tanlov!");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            static void ShowList(List<ExternalAttendance> list)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.FullNameWithCode} | {item.Email} | {item.Duration} min | EnterDate:{item.EnterDate}  | ExitDate:{item.ExitDate} | Host:{item.IsHost} |  Waiting:{item.IsWaiting}");
                }
                Console.WriteLine("\nDavom ettirish uchun tugma bosing...");
                Console.ReadKey();
            }

            static void ShowSingle(ExternalAttendance? item)
            {

                if (item == null)
                {
                    Console.WriteLine("Ma'lumot topilmadi !");
                }
                else
                {
                    Console.WriteLine($"Ism: {item.FullNameWithCode}");
                    Console.WriteLine($"Email: {item.Email}");
                    Console.WriteLine($"Kirish: {item.EnterDate}");
                    Console.WriteLine($"Chiqish: {item.ExitDate}");
                    Console.WriteLine($"Davomiylik: {item.Duration} min");
                    Console.WriteLine($"Host: {item.IsHost}");
                    Console.WriteLine($"Waiting: {item.IsWaiting}");
                }

                Console.WriteLine("\nDavom ettirish uchun tugma bosing...");
                Console.ReadKey();
            }
        }
    }

}
