using EmPower.Abstract;
using EmPower.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmPower.MenuUI
{
    public class EmployeeMenuHandler
    {
        private EmployeeProfileServices employeeProfileServices;
        //private LeaveService leaveService;
        private LeaveRequestBase leaveRequestBase;

        // Force initialization with the shared services
        public EmployeeMenuHandler(EmployeeProfileServices profileServices, LeaveRequestBase leaveRequestBase)
        {
            this.employeeProfileServices = profileServices;
            this.leaveRequestBase = leaveRequestBase;
        }

        public void runEmployeeMenu(int eID)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n===== EMPLOYEE panel =====");
                Console.WriteLine("1. View Profile");
                Console.WriteLine("2. Edit Profile");
                Console.WriteLine("3. List All Employees");
                Console.WriteLine("4. Apply For Leave");
                Console.WriteLine("5. View my Leaves");
                Console.WriteLine("6. Logout"); // <-- Changed Exit to Logout
                Console.Write("Choose: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": employeeProfileServices.ViewProfile(eID); break;
                    case "4": leaveRequestBase.SubmitRequest(eID); break;
                    case "5": leaveRequestBase.ViewLeaveDetails(eID); break;
                    case "6": return; // Logout to go back to LoginPage
                    default: Console.WriteLine(" Invalid choice!"); break;
                }
            }
        }
    }
}

