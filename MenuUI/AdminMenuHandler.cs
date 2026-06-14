using EmPower.Abstract;
using EmPower.Login;
using EmPower.Services;
using System;

namespace EmPower.MenuUI
{
    public class AdminMenuHandler
    {
        private EmployeeService empService;
        private HireFireBase hirefire;
        private LoginPage loginPage;
        private LeaveRequestBase leaveRequestBase;

        public AdminMenuHandler(EmployeeService empService, LeaveRequestBase leaveRequestBase)
        {
            this.empService = empService;
            this.hirefire = new HireFireBase(empService); // Pass the shared service
            this.leaveRequestBase = leaveRequestBase;
        }

        // 1. Add this method to handle the user input
        public void ViewProfileMenu()
        {
            Console.Write("Enter the ID you want to search: ");
            if (int.TryParse(Console.ReadLine(), out int inputid))
            {
                empService.ViewProfile(inputid);
            }
            else
            {
                Console.WriteLine(" Invalid ID format! Please enter a number.");
            }
        }

        public void Run()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\n===== ADMIN Panel =====");
                Console.WriteLine("1. Hire Employee");
                Console.WriteLine("2. Fire Employee");
                Console.WriteLine("3. List All Employees");
                Console.WriteLine("4. View Employee Profile"); // <-- New Option
                Console.WriteLine("5. View Leave Requests"); // <-- New Option
                Console.WriteLine("6. Request Status Update"); // <-- New Option
                Console.WriteLine("7. Logout");
                Console.Write("Choose: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": hirefire.HireMenu(); break;
                    case "2": hirefire.FireMenu(); break;
                    case "3": empService.ListAll(); break;
                    case "4": ViewProfileMenu(); break; // <-- Call your new method
                    case "5": EnterIdForLeaveDetails(); break; // <-- Call the method to view all leave requests
                    case "6": leaveRequestBase.UpdateLeaveStatus(); break; // <-- Call the method to update leave status
                    case "7": return;
                    default: Console.WriteLine(" Invalid choice!"); break;
                }
            }

            
        }
        public void EnterIdForLeaveDetails()
        {
            Console.Write("Enter the Employee ID to view leave requests: ");
            if (int.TryParse(Console.ReadLine(), out int empId))
            {
                leaveRequestBase.ViewLeaveDetails(empId);
            }
            else
            {
                Console.WriteLine(" Invalid ID format! Please enter a number.");
            }
        }
    }
}
