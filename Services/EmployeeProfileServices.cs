using EmPower.Abstract;
using EmPower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NOTE: Ensure your namespace matches the folder (Services, not MenuUI)
namespace EmPower.Services 
{
    public class EmployeeProfileServices
    {
        private EmployeeRepository repo;

        // Force construction with an existing repo
        public EmployeeProfileServices(EmployeeRepository repo)
        {
            this.repo = repo;
        }

        public void ViewProfile(int eID)
        {
            var emp = repo.GetByID(eID);
            if (emp == null) 
            { 
                Console.WriteLine(" Employee not found!...");
                Console.ReadLine(); 
                return; 
            }
            emp.PrintDetails();
            Console.ReadLine(); // Pause so they can read the profile
        }
    }
}
