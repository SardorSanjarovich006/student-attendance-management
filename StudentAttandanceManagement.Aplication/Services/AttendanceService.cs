using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAttandanceManagement.Domain;
using StudentAttendanceManagement.Infrastucture;

namespace StudentAttandanceManagement.Aplication.Services
{
    public class AttendanceService
    {
        private readonly AttandanceRepository _attandanceRepository = new AttandanceRepository();

        public void Add(Attandance attandance)
        {
            _attandanceRepository.Add(attandance);
        }

        public List<Attandance> GetAll()
        {
            return _attandanceRepository.GetAll();
        }
    }
}
