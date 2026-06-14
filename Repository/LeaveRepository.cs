using System;
using EmPower.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace EmPower.Repository
{
    public class LeaveRepository
    {
        private List<LeaveRequests> leaveRequests = new List<LeaveRequests>();
        private int nextLeaveId = 1;
        private readonly string filePath = "leaves.txt";

        public LeaveRepository()
        {
            LoadData();
        }

        public void AddLeaveRequest(LeaveRequests leave)
        {
            leaveRequests.Add(leave);
            SaveData();
            Console.WriteLine($"Leave request added successfully with ID: {leave.LeaveID}");

        }

        public LeaveRequests GetLeaveByID(int leaveId) => leaveRequests.FirstOrDefault(l => l.LeaveID == leaveId);
        public List<LeaveRequests> GetLeaveByEmployeeID(int employeeId) 
            => leaveRequests.Where(l => l.EmployeeID == employeeId).ToList();
        public List<LeaveRequests> GetAllLeaveApplication() => leaveRequests;

        public int GenerateLeaveID() => nextLeaveId++;
        private void SaveData()
        {
            List <string> lines = new List<string>();
            foreach(var leave in leaveRequests)
            {
                lines.Add($"{leave.LeaveID}|{leave.EmployeeID}|{leave.StartDate:yyyy-MM-dd}|{leave.EndDate:yyyy-MM-dd}|{leave.Reason}|{leave.Status}");
            }
            File.WriteAllLines(filePath, lines);
        }
        private void LoadData()
        {
            if(!File.Exists(filePath)) return; // If the file doesn't exist, we start with an empty list

            var lines = File.ReadAllLines(filePath);
            foreach(var line in lines)
            {
                var parts = line.Split('|');
                if(parts.Length == 6)
                {
                    leaveRequests.Add(new LeaveRequests
                    {
                        LeaveID = int.Parse(parts[0]),
                        EmployeeID = int.Parse(parts[1]),
                        StartDate = DateTime.Parse(parts[2]),
                        EndDate = DateTime.Parse(parts[3]),
                        Reason = parts[4],
                        Status = parts[5]
                    });
                    nextLeaveId = Math.Max(nextLeaveId, int.Parse(parts[0]) + 1); // Ensure next ID is always higher
                }
            }
        }
       
    }
}
