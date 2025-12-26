using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAttandanceManagement.Domain;
using StudentAttendanceManagement.Infrastucture;

namespace StudentAttandanceManagement.Aplication.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepsitory = new StudentRepository();

        public void Add(Student student)
        {
            _studentRepsitory.Add(student);
        }

        public List<Student> GetAll()
        {
            return _studentRepsitory.GetAll();
        }
    }
}
