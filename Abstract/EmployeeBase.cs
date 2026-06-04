using EmPower.Interfaces;

namespace EmPower.Abstract
{
    public abstract class EmployeeBase : IEmployee, ISalaryCalculation
    {

        private int employeeID;
        private string? name;
        private int salary;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public string? Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Name cannot be null or empty.");
                    return;
                }
                name = value;
            }
        }

        public int Salary
        {
            get { return salary; }
            set 
            {
                if (value < 0)
                {
                    Console.WriteLine("Salary cannot be negative.");
                    return;
                }
                salary = value; 
            }
        }

        public string? Department { get; set; }

        public string? Position { get; set; }

        public EmployeeBase(int id, string? name, int salary, string? department, string? position)
        {
            EmployeeID = id;
            Name = name;
            Salary = salary;
            Department = department;
            Position = position;
        }

        public int CalculateBonus(int employeeID)
        {
            // Implement bonus calculation logic here
            return Salary / 10; // Example: Bonus is 10% of salary
        }

        public void ClockIn()
        {
            Console.WriteLine($"{Name} clocked in.");
        }
        public void ClockOut()
        {
            Console.WriteLine($"{Name} clocked out.");
        }

        public void PrintDetails()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Employee ID: {EmployeeID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Role: {GetRole()}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Bonus: {CalculateBonus(EmployeeID)}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine("------------------------------");
        }

        public abstract void CalculateSalary(int employeeID);
        public abstract string GetRole();





    }
}
