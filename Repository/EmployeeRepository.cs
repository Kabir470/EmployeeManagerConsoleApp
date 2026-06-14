using EmPower.Abstract;
using EmPower.Models; // We need this to reconstruct the exact model types (AdminMember, etc.)
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmPower.Repository
{
    public class EmployeeRepository
    {
        public List<EmployeeBase> employees = new List<EmployeeBase>();
        private int nextId = 1;
        private readonly string filePath = "users.txt";

        // Constructor runs ONE time when Program.cs begins
        public EmployeeRepository()
        {
            LoadData(); // Load historical data the moment the kitchen opens!
        }

        public void AddEmployee(EmployeeBase emp)
        {
            employees.Add(emp);
            SaveData(); // Instantly backup to the file!
            Console.WriteLine($"Employee added: {emp.Name} ");
        }

        public void RemoveEmployee(int employeeID)
        {
            var emp = GetByID(employeeID);
            if (emp == null) { Console.WriteLine(" Employee not found!"); return; }
            
            employees.Remove(emp);
            SaveData(); // Instantly update the file!
            Console.WriteLine($" {emp.Name} removed.");
        }

        public EmployeeBase GetByID(int id) => employees.FirstOrDefault(e => e.EmployeeID == id);

        public List<EmployeeBase> GetAllEmployees() => employees;

        public int GenerateID () => nextId++;

        // ===== NEW DATABASE LOGIC =====

        private void SaveData()
        {
            List<string> lines = new List<string>();
            foreach (var emp in employees)
            {
                // We use GetType().Name to save their exact role (e.g. "AdminMember" or "HrMember")
                lines.Add($"{emp.GetType().Name}|{emp.EmployeeID}|{emp.Name}|{emp.Salary}|{emp.Department}|{emp.Position}");
            }
            
            // This replaces everything in the file with our fresh list
            File.WriteAllLines(filePath, lines); 
        }

        private void LoadData()
        {
            // If it's your very first time running the app, the file won't exist yet!
            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|'); // Split the string back into 6 pieces
                
                if (parts.Length == 6)
                {
                    string? roleType = parts[0];
                    int id = int.Parse(parts[1]);
                    string? name = parts[2];
                    int salary = int.Parse(parts[3]);
                    string? dept = parts[4];
                    string? pos = parts[5];

                    // Rebuild the specific role based on the string we saved
                    EmployeeBase emp = roleType switch
                    {
                        "AdminMember" => new AdminMember(id, name, salary, dept, pos),
                        "HrMember" => new HrMember(id, name, salary, dept, pos),
                        "Employee" => new Employee(id, name, salary, dept, pos),
                        "InternEmployee" => new InternEmployee(id, name, salary, dept, pos),
                        _ => null
                    };

                    if (emp != null)
                    {
                        employees.Add(emp);
                        
                        // Ensure that our GenerateID mechanism stays ahead of loaded ID's
                        if (id >= nextId) 
                        {
                            nextId = id + 1; 
                        }
                    }
                }
            }
        }
    }
}
