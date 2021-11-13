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
            List<Employee> list_Employee = new List<Employee>();
            List<Dependent> list_Dependent = new List<Dependent>();
            List<Project> list_Project = new List<Project>();

            Database database = new Database();
            database.CreateDatabase();

            result = database.result_Employee();

            for(int i = 0; i < result.Count; ++i)
            {
                Employee employee = (Employee)result[i];
                list_Employee.Add(employee);
            }

            result = database.result_Dependent();

            for (int i = 0; i < result.Count; ++i)
            {
                Dependent dependent = (Dependent)result[i];
                list_Dependent.Add(dependent);
            }

            result = database.result_Project();

            for (int i = 0; i < result.Count; ++i)
            {
                Project project = (Project)result[i];
                list_Project.Add(project);
            }

            dataGridView_Employee.DataSource = list_Employee;
            dataGridView_Dependent.DataSource = list_Dependent;
            dataGridView_Project.DataSource = list_Project;
        }
    }
}
