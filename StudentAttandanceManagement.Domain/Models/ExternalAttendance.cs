using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttandanceManagement.Domain.Models
{
    public class ExternalAttendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime UploadedDate { get; set; }
        public string ExternalSystemName { get; set; }
    }
}
