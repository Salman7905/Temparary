using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqAssignemnt
{
    class Employee
    {
        public int EmployeeID{get;set;}
        public string EmployeeName{get;set;}
        public double EmployeeSalary{get;set;}
    }
    class EmployeeList
    {
        List<Employee> list = new List<Employee>();
        public void AddEmployee()
        {
            list.Add(new Employee{
                EmployeeID = 101,
                EmployeeName = "Mike",
                EmployeeSalary = 35000.234
            });
             list.Add(new Employee{
                EmployeeID = 102,
                EmployeeName = "ABDeVilliers",
                EmployeeSalary = 55000.847
            });
             list.Add(new Employee{
                EmployeeID = 103,
                EmployeeName = "Robert",
                EmployeeSalary = 45000.564
            });
        }
        public IEnumerable<Employee> fetchEmployees()
        {
            return list;
        }
           public IQueryable<Employee> filterRecords()
        {
            IQueryable<Employee> lists = list.AsQueryable().Where( e =>e.EmployeeSalary>=45000); // // it works like SELECT * FROM Employee WHERE EmployeeSalary>=45000
            return lists;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeList employeeList = new EmployeeList();
            employeeList.AddEmployee();
            var lists = employeeList.fetchEmployees();
            // fetching values using IEnumerable
            Console.WriteLine("-------------IEnumerable-------------");
            foreach(var items in lists)
            {
                Console.WriteLine(items.EmployeeID+" "+items.EmployeeName+" "+items.EmployeeSalary);
            }
            Console.WriteLine("-------------IQueryable--------------");
            // fetching values using IQueryable
            var list = employeeList.filterRecords();
            foreach(var item in list)
            {
                Console.WriteLine(item.EmployeeID+" "+item.EmployeeName+" "+item.EmployeeSalary);
            }
        }
    }
}






