using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAttandanceManagement.Domain;

namespace StudentAttendanceManagement.Infrastucture
{
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();


        public void Add(Student student)
        {
            students.Add(student);
        }
        public List<Student> GetAll()
        {
            return students;
        }
    }
}
