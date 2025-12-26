using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAttandanceManagement.Domain;

namespace StudentAttendanceManagement.Infrastucture
{
    public class AttandanceRepository
    {
        private List<Attandance> attandances = new List<Attandance>();
        public void Add(Attandance attandance)
        {
            attandances.Add(attandance);
        }
        public List<Attandance> GetAll()
        {
            return attandances;
        }
    }
}
