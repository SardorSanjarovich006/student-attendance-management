using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAttandanceManagement.Domain.Models;

namespace StudentAttendanceManagement.Infrastucture
{
    public class ExcelContext
    {
        List<ExternalAttendance> externalAttendances = new List<ExternalAttendance>();
        private readonly string directoryPath;

        private readonly string filePath;
        public ExcelContext()
        {
            string directoryPath = @"C:\Users\Asus\Desktop\Attendance";
            string filePath = Path.Combine(directoryPath, "attendance1.csv");
            string[] excelLines = File.ReadAllLines(filePath);

            foreach (var line in excelLines.Skip(1))
            {
                string[] studentInfo = line.Split(',');
                ExternalAttendance externalAttendance = new ExternalAttendance
                {
                    FullNameWithCode = studentInfo[0],
                    Email = studentInfo[1],
                    EnterDate = studentInfo[2],
                    ExitDate = studentInfo[3],
                    Duration = int.Parse(studentInfo[4]),
                    IsHost = studentInfo[5],
                    IsWaiting = studentInfo[6],
                };

                externalAttendances.Add(externalAttendance);

            }

        }
        public List<ExternalAttendance> GetExternalAttendances()
        {
            return externalAttendances;
        }

    }
}
