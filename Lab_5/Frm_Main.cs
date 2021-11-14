using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        IObjectSet result = null;
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            // Khởi tạo biến list để lưu dữ liệu Employee
            List<Employee> list_Employee = new List<Employee>();
            // Khởi tạo biến list để lưu dữ liệu Dependent
            List<Dependent> list_Dependent = new List<Dependent>();
            // Khởi tạo biến list để lưu dữ liệu Project
            List<Project> list_Project = new List<Project>();
            // Khởi tạo biến list để lưu dữ liệu Department
            List<Department> list_Department = new List<Department>();
            // Khởi tạo biến list để lưu dữ liệu WorksOn
            List<WorksOn> list_WorksOn = new List<WorksOn>();

            Database database = new Database(); // Khởi tạo database
            database.CreateDatabase(); // Mở database

            // Lấy dữ liệu Employee từ database
            result = database.result_Employee();
            // Đưa từng dữ liệu Employee vào trong list_Employee
            for(int i = 0; i < result.Count; ++i)
            {
                Employee employee = (Employee)result[i];
                list_Employee.Add(employee);
            }

            // Lấy dữ liệu Dependent từ database
            result = database.result_Dependent();
            // Đưa từng dữ liệu Dependent vào trong list_Dependent
            for (int i = 0; i < result.Count; ++i)
            {
                Dependent dependent = (Dependent)result[i];
                list_Dependent.Add(dependent);
            }

            // Lấy dữ liệu Project từ database
            result = database.result_Project();
            // Đưa từng dữ liệu Project vào trong list_Project
            for (int i = 0; i < result.Count; ++i)
            {
                Project project = (Project)result[i];
                list_Project.Add(project);
            }

            // Lấy dữ liệu Department từ database
            result = database.result_Department();
            // Đưa từng dữ liệu Department vào trong list_Department
            for (int i = 0; i < result.Count; ++i)
            {
                Department department = (Department)result[i];
                list_Department.Add(department);
            }

            // Lấy dữ liệu WorksOn từ database
            result = database.result_WorksOn();
            // Đưa từng dữ liệu WorksOn vào trong list_WorksOn
            for (int i = 0; i < result.Count; ++i)
            {
                WorksOn worksOn = (WorksOn)result[i];
                list_WorksOn.Add(worksOn);
            }

            // Đưa dữ liệu vào dataGridView
            dataGridView_Employee.DataSource = list_Employee;
            dataGridView_Dependent.DataSource = list_Dependent;
            dataGridView_Project.DataSource = list_Project;
            dataGridView_Department.DataSource = list_Department;
            dataGridView_WorksOn.DataSource = list_WorksOn;
        }
    }
}
