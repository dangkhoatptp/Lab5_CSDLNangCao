using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public class Department
    {
        // Thuộc tính
        public int DNumber { get; set; }
        public string DName { get; set; }
        public List<string> Locations { get; set; }

        // Quan hệ
        public List<Employee> Employees { get; set; }
        public Employee Manager { get; set; }
        public List<Project> Projects { get; set; }

        public string MgrStartDate { get; set; }
    }
}
