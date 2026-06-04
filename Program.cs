using EmPower.MenuUI;
using EmPower.Repository;
using EmPower.Services;

var repo = new EmployeeRepository();
var empService = new EmployeeService(repo);
var menu = new MenuHandler(empService);

menu.Run();