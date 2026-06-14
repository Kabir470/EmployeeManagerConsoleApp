using EmPower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Services
{
    public class LeaveService
    {
        private LeaveRepository leaveRepo;
        private EmployeeRepository repo;

        public LeaveService(LeaveRepository leaveRepo, EmployeeRepository repo)
        {
            this.leaveRepo = leaveRepo;
            this.repo = repo;
        }

        public int GetEmployeeID(int EmID)
        {
            var emp = repo.GetByID(EmID);
            if (emp == null)
            {
                Console.WriteLine(" Employee not found!");
                return -1;
            }
            return emp.EmployeeID;
        }

        public void SubmitLeaveRequest(int employeeID, DateTime startDate, DateTime endDate, string reason)
        {
            var leave = new Models.LeaveRequests
            {
                LeaveID = leaveRepo.GenerateLeaveID(),
                EmployeeID = employeeID,
                StartDate = startDate,
                EndDate = endDate,
                Reason = reason,
                Status = "Pending"
            };
            leaveRepo.AddLeaveRequest(leave);
        }

        
    }
}
