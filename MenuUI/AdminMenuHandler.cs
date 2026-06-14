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

        public AdminMenuHandler(EmployeeService empService)
        {
            this.empService = empService;
            this.hirefire = new HireFireBase(empService); // Pass the shared service
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
                Console.WriteLine("5. Logout");
                Console.Write("Choose: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": hirefire.HireMenu(); break;
                    case "2": hirefire.FireMenu(); break;
                    case "3": empService.ListAll(); break;
                    case "4": ViewProfileMenu(); break; // <-- Call your new method
                    case "5": return;
                    default: Console.WriteLine(" Invalid choice!"); break;
                }
            }
        }
    }
}
