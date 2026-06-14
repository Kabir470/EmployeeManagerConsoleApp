using EmPower.MenuUI;
using EmPower.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmPower.Repository;

namespace EmPower.Login
{
    public class LoginPage
    {
        private int enterID;
        // Only keep the fields that get initialized in the constructor
        private AdminMenuHandler adminMenu;
        private EmployeeMenuHandler employeeMenu;
        private EmployeeRepository repo;

        public LoginPage(AdminMenuHandler adminMenu, EmployeeMenuHandler employeeMenu, EmployeeRepository repo)
        {
            this.adminMenu = adminMenu;
            this.employeeMenu = employeeMenu;
            this.repo = repo;
        }

        public void runLoginPage()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== LOGIN PAGE =====");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Employee");
                Console.WriteLine("3. Exit");
                Console.Write("Choose: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    // Use the variables injected from the constructor
                    case "1": adminMenu.Run(); break;
                    case "2": checkCase2(); break;
                    case "3": return;
                    default: Console.WriteLine(" Invalid choice!"); break;
                }
            }


        }
        public void checkCase2()
        {
            Console.Clear();
            Console.Write("enter ur employee id: ");
            enterID = int.Parse(Console.ReadLine());
            var emp = repo.GetByID(enterID);
            if (emp == null) { Console.WriteLine(" Employee not found!enter again...");Console.ReadLine(); return; }
            Console.WriteLine($"Employee found: {emp.Name}");
            Console.WriteLine($"Position: {emp.Position}");

            Console.Write("please enter to continue...");
            Console.ReadLine();

            employeeMenu.runEmployeeMenu(enterID);
        }
    }
}
