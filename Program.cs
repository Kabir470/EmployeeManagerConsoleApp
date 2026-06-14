using EmPower.Abstract;
using EmPower.Login;
using EmPower.MenuUI;
using EmPower.Repository;
using EmPower.Services;
using System.Globalization;

// Create our global repository and services ONE TIME
var repo = new EmployeeRepository();
var empService = new EmployeeService(repo);
var empProfileService = new EmployeeProfileServices(repo); // <-- NEW
var leaveRepo = new LeaveRepository();
var leaveService = new LeaveService(leaveRepo, repo);

// Give those single instances to our menus
var adminMenu = new AdminMenuHandler(empService);
var leaveRequestBase = new LeaveRequestBase(leaveService, leaveRepo);
var employeeMenu = new EmployeeMenuHandler(empProfileService, leaveRequestBase); // <-- Pass the shared service

// Give the menus to the login page
var loginPage = new LoginPage(adminMenu, employeeMenu, repo);

var checkpassword = new CheckPassword();
int counter = 0;

Console.Write("Enter password to login:  ");
if (checkpassword.Check(Console.ReadLine()))
{
    loginPage.runLoginPage();
}
else
{
    while (counter < 2)
    {
        Console.WriteLine("Incorrect password. Attempt Remaining: {0}", 2 - counter);
        Console.Write("Try Again:  ");
        if (checkpassword.Check(Console.ReadLine()))
        {
            loginPage.runLoginPage();
            break;
        }
        counter++;
    }
}