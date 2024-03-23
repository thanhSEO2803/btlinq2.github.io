using System;
using System.Collections.Generic;
using System.Linq;

class Department
{
    public string Name { get; set; }
    public string Description { get; set; }
}

class Position
{
    public string Title { get; set; }
    public string Description { get; set; }
}

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Department Department { get; set; }
    public Position Position { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo danh sách các đối tượng
        var departments = new List<Department>
        {
            new Department { Name = "IT", Description = "Information Technology" },
            new Department { Name = "AI", Description = "AI Engineer" }
        };

        var positions = new List<Position>
        {
            new Position { Title = "Manager", Description = "Managerial position" },
            new Position { Title = "Developer", Description = "Software developer" }
        };

        var employees = new List<Employee>
        {
            new Employee { Name = "Long", Age = 21, Department = departments[0], Position = positions[1] },
            new Employee { Name = "Thanh", Age = 30, Department = departments[1], Position = positions[0] }
        };

        // Nhập thông tin tìm kiếm từ người dùng
        Console.WriteLine("Nhap tu khoa tim kiem:");
        string keyword = Console.ReadLine();

        Console.WriteLine("Tuoi tu:");
        int minAge = int.Parse(Console.ReadLine());

        Console.WriteLine("Đen tuoi:");
        int maxAge = int.Parse(Console.ReadLine());

        Console.WriteLine("Vi tri:");
        string positionKeyword = Console.ReadLine();

        Console.WriteLine("Phong ban:");
        string departmentKeyword = Console.ReadLine();

        // Tìm kiếm và in kết quả
        var searchResults = employees.Where(emp =>
            (emp.Name.Contains(keyword) || emp.Position.Title.Contains(keyword) || emp.Position.Description.Contains(keyword) ||
             emp.Department.Name.Contains(keyword) || emp.Department.Description.Contains(keyword)) &&
            emp.Age >= minAge &&
            emp.Age <= maxAge &&
            (string.IsNullOrEmpty(positionKeyword) || emp.Position.Title.Contains(positionKeyword) || emp.Position.Description.Contains(positionKeyword)) &&
            (string.IsNullOrEmpty(departmentKeyword) || emp.Department.Name.Contains(departmentKeyword) || emp.Department.Description.Contains(departmentKeyword))
        );

        Console.WriteLine("Kết quả tìm kiếm:");
        foreach (var employee in searchResults)
        {
            Console.WriteLine($"Ten: {employee.Name}, Tuoi: {employee.Age}, Phong ban: {employee.Department.Name}, Vi tri: {employee.Position.Title}");
        }
        Console.ReadLine();
    }
}
