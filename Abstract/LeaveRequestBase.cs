using EmPower.Repository;
using EmPower.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.Abstract
{
    public class LeaveRequestBase
    {

        private LeaveService leaveService;
        private LeaveRepository leaveRepo;


        public LeaveRequestBase(LeaveService leaveService, LeaveRepository leaveRepo)
        {
            this.leaveService = leaveService;
            this.leaveRepo = leaveRepo;
        }

        public void SubmitRequest(int employeeID)
        {
            
            int empId = employeeID;
            Console.WriteLine($"Employee ID: {empId}");
            Console.Write("Start Date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse("2025-02-03"); //= DateTime.Parse(Console.ReadLine());
            Console.Write("\nEnd Date (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse("2025-02-10"); //= DateTime.Parse(Console.ReadLine());
            Console.Write("\nReason for leave: ");
            string reason = Console.ReadLine();
            leaveService.SubmitLeaveRequest(empId, startDate, endDate, reason);
        }

        public void printLeaveDetails(Models.LeaveRequests leave)
        {
            Console.WriteLine("---------Leave Request Details:-------\n");
            Console.WriteLine($"Leave ID: {leave.LeaveID}");
            Console.WriteLine($"Employee ID: {leave.EmployeeID}");
            Console.WriteLine($"Start Date: {leave.StartDate:yyyy-MM-dd}");
            Console.WriteLine($"End Date: {leave.EndDate:yyyy-MM-dd}");
            Console.WriteLine($"Reason: {leave.Reason}");
            Console.WriteLine($"Status: {leave.Status}");
            Console.WriteLine("\n---------------------------------------");
        }
        public void ViewLeaveDetails(int employeeID)
        {
            // Now it returns a List!
            var leaves = leaveRepo.GetLeaveByEmployeeID(employeeID);
            
            if (leaves == null || leaves.Count == 0)
            {
                Console.WriteLine(" No leave requests found!");
                Console.ReadLine(); // Pause so the user can read the message
                return;
            }

            Console.WriteLine($"\nFound {leaves.Count} leave request(s):");
            
            foreach(var l in leaves)
            {
                printLeaveDetails(l); // Call the method you created just above this one
            }
            
            Console.WriteLine("Press enter to return.");
            Console.ReadLine();
        }
    }
}
