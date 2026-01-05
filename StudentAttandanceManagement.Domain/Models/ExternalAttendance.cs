using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttandanceManagement.Domain.Models
{
    //public class ExternalAttendance
    //{
    //    public int Id { get; set; }
    //    public int StudentId { get; set; }
    //    public DateTime UploadedDate { get; set; }
    //    public string ExternalSystemName { get; set; }
    //}

    public  class  ExternalAttendance
    {
        public string FullNameWithCode { get; set; }
        public string Email { get; set; }
        public string EnterDate { get; set; }
        public string ExitDate { get; set; }
        public int Duration { get; set; }
        public string IsHost { get; set; }
        public string IsWaiting { get; set; }

    }
}
