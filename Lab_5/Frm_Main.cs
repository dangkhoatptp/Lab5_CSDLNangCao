using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        Database database = new Database(); // Khởi tạo database
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            database.CreateDatabase(); // Mở database

            // tab_Employee
            textBox_Ssn.ReadOnly = false;
            textBox_Ssn.Clear();
            textBox_Ssn_Delete.Clear();
            textBox_FName.Clear();
            textBox_LName.Clear();
            textBox_GenderEmployee.Clear();
            textBox_MInit.Clear();
            textBox_BirthDate.Clear();
            textBox_Address.Clear();
            textBox_Salary.Clear();

            // tab_Dependent
            textBox_NameDependent.Clear();
            textBox_GenderDepenednt.Clear();
            textBox_BirthDateDependent.Clear();
            comboBox_RelationshipDependent.Items.Clear();
            string[] relationships =
            {
                "Father",
                "Mother",
                "Son",
                "Daughter",
                "Husband",
                "Wife",
                "Brother",
                "Sister",
                "Uncle",
                "Aunt"
            };
            comboBox_RelationshipDependent.Items.AddRange(relationships);
            comboBox_RelationshipDependent.Text = "";
            textBox_SsnDependentOf.Clear();
            textBox_NameDependentOf.Clear();
            textBox_FNameEmployee.Clear();
            textBox_LNameEmployee.Clear();

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

            IObjectSet result = null;

            // Lấy dữ liệu Employee từ database
            result = database.result_Employee();
            // Đưa từng dữ liệu Employee vào trong list_Employee
            for (int i = 0; i < result.Count; ++i)
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
            dataGridView_DependentOf_Dependent.DataSource = list_Employee;
        }

        private void dataGridView_Employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView_Employee.Rows[e.RowIndex];

                textBox_Ssn.ReadOnly = true;
                textBox_Ssn.Text = row.Cells[0].Value.ToString();
                textBox_Ssn_Delete.Text = row.Cells[0].Value.ToString();
                textBox_FName.Text = row.Cells[1].Value.ToString();
                textBox_LName.Text = row.Cells[3].Value.ToString();
                textBox_GenderEmployee.Text = row.Cells[7].Value.ToString();
                textBox_MInit.Text = row.Cells[2].Value.ToString();
                textBox_Address.Text = row.Cells[4].Value.ToString();
                textBox_BirthDate.Text = row.Cells[5].Value.ToString();
                textBox_Salary.Text = row.Cells[6].Value.ToString();
            }
        }
        private void dataGridView_DependentOf_Dependent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView_DependentOf_Dependent.Rows[e.RowIndex];
                textBox_SsnDependentOf.Text = row.Cells[0].Value.ToString();
                textBox_NameDependentOf.Text = row.Cells[1].Value.ToString() + " " + row.Cells[3].Value.ToString();
                textBox_FNameEmployee.Text = row.Cells[1].Value.ToString();
                textBox_LNameEmployee.Text = row.Cells[3].Value.ToString();
            }
        }
        private void dataGridView_Dependent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                IObjectSet result = database.result_Dependent();
                Dependent dependent = (Dependent)result[e.RowIndex];

                textBox_NameDependent.Text = dependent.Name;
                textBox_GenderDepenednt.Text = dependent.Gender;
                textBox_BirthDateDependent.Text = dependent.BirthDate;
                comboBox_RelationshipDependent.Text = dependent.Relationship;
                textBox_SsnDependentOf.Text = dependent.DependentOf.Ssn.ToString();
                textBox_NameDependentOf.Text = dependent.DependentOf.FName + " " + dependent.DependentOf.LName;
                textBox_FNameEmployee.Text = dependent.DependentOf.FName;
                textBox_LNameEmployee.Text = dependent.DependentOf.LName;
                textBox_NameDependentOld.Text = dependent.Name;
                textBox_GenderDependentOld.Text = dependent.Gender;
                textBox_BirthDateDependentOld.Text = dependent.BirthDate;
                textBox_RelationshipDependentOld.Text = dependent.Relationship;
            }
        }

        private void button_AddEmployee_Click(object sender, EventArgs e)
        {
            int ssn = -1;
            if (textBox_Ssn.Text != "") ssn = int.Parse(textBox_Ssn.Text);
            string fname = textBox_FName.Text;
            string lname = textBox_LName.Text;
            string gender = textBox_GenderEmployee.Text;
            string minit = textBox_MInit.Text;
            string address = textBox_Address.Text;
            string birthdate = textBox_BirthDate.Text;
            double salary = -1;
            if(textBox_Salary.Text != "") salary = double.Parse(textBox_Salary.Text);

            string thongbao = null;

            if(ssn == -1)
            {
                string thongbaossn = "- Ssn\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaossn;
                else thongbao += thongbaossn;
            }
            if (fname == "")
            {
                string thongbaofname = "- First name\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaofname;
                else thongbao += thongbaofname;
            }
            if (lname == "")
            {
                string thongbaolname = "- Last name\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaolname;
                else thongbao += thongbaolname;
            }
            if (gender == "")
            {
                string thongbaogender = "- Gender\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaogender;
                else thongbao += thongbaogender;
            }
            if (minit == "")
            {
                string thongbaominit = "- MInit\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaominit;
                else thongbao += thongbaominit;
            }
            if (address == "")
            {
                string thongbaoaddress = "- Address\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaoaddress;
                else thongbao += thongbaoaddress;
            }
            if (birthdate == "")
            {
                string thongbaobirthdate = "- Birthdate\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaobirthdate;
                else thongbao += thongbaobirthdate;
            }
            if (salary == -1)
            {
                string thongbaosalary = "- Salary\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaosalary;
                else thongbao += thongbaosalary;
            }

            if(thongbao != null) MessageBox.Show(thongbao);
            else
            {
                Employee temp = new Employee(ssn, null, null, null, null, null, 0, null);
                IObjectSet searchEmployee = database.DB.QueryByExample(temp);
                if(searchEmployee.Count != 0) MessageBox.Show("Ssn bị trùng, vui lòng nhập lại");
                else
                {
                    Employee employeeAdd = new Employee(ssn, fname, minit, lname, address, birthdate, salary, gender);
                    database.DB.Store(employeeAdd);
                    IObjectSet result = database.result_Employee();
                    int countNew = result.Count;
                    string[] data_EmployeeNew = new string[countNew + 1];
                    data_EmployeeNew[0] = countNew.ToString();
                    for (int i = 0; i < countNew; ++i)
                    {
                        temp = (Employee)result[i];
                        data_EmployeeNew[i + 1] = temp._ToString();
                    }
                    File.WriteAllLines("data_Employee.txt", data_EmployeeNew);

                    MessageBox.Show("Bạn đã thêm thành công");

                    LoadData();
                }
            }
        }
        private void button_DeleteEmployee_Click(object sender, EventArgs e)
        {
            int ssn = -1;
            if (textBox_Ssn_Delete.Text != "") ssn = int.Parse(textBox_Ssn_Delete.Text);

            if (ssn == -1) MessageBox.Show("Bạn chưa chọn Employee để xóa");
            else
            {
                Employee employee = new Employee(ssn, null, null, null, null, null, 0, null);
                IObjectSet result = database.DB.QueryByExample(employee);
                if(result.Count != 0)
                {
                    employee = (Employee)result[0];

                    bool check = true;

                    if (employee.WorksFor != null || employee.Manager != null || employee.Supervisor != null || employee.WorksOn != null || employee.Dependents != null || employee.Supervisees != null) check = false;

                    if (check == true)
                    {
                        database.DB.Delete(employee);

                        result = database.result_Employee();
                        int countNew = result.Count;
                        string[] data_EmployeeNew = new string[countNew + 1];

                        data_EmployeeNew[0] = countNew.ToString();
                        for (int i = 0; i < countNew; ++i)
                        {
                            Employee temp = (Employee)result[i];
                            data_EmployeeNew[i + 1] = temp._ToString();
                        }

                        File.WriteAllLines("data_Employee.txt", data_EmployeeNew);

                        MessageBox.Show("Xóa thành công");

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa vì sẽ ảnh hưởng đến các bảng khác");

                        LoadData();
                    }
                }
            }
        }
        private void button_ModifyEmployee_Click(object sender, EventArgs e)
        {
            int ssn = -1;
            if(textBox_Ssn.Text != "") ssn = int.Parse(textBox_Ssn.Text);
            string fname = textBox_FName.Text;
            string lname = textBox_LName.Text;
            string gender = textBox_GenderEmployee.Text;
            string minit = textBox_MInit.Text;
            string birthdate = textBox_BirthDate.Text;
            string address = textBox_Address.Text;
            double salary = -1; 
            if(textBox_Salary.Text != "") salary = double.Parse(textBox_Salary.Text);

            string thongbao = null;

            if (ssn == -1)
            {
                string thongbaossn = "- Ssn\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaossn;
                else thongbao += thongbaossn;
            }
            if (fname == "")
            {
                string thongbaofname = "- First name\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaofname;
                else thongbao += thongbaofname;
            }
            if (lname == "")
            {
                string thongbaolname = "- Last name\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaolname;
                else thongbao += thongbaolname;
            }
            if (gender == "")
            {
                string thongbaogender = "- Gender\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaogender;
                else thongbao += thongbaogender;
            }
            if (minit == "")
            {
                string thongbaominit = "- MInit\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaominit;
                else thongbao += thongbaominit;
            }
            if (address == "")
            {
                string thongbaoaddress = "- Address\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaoaddress;
                else thongbao += thongbaoaddress;
            }
            if (birthdate == "")
            {
                string thongbaobirthdate = "- Birthdate\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaobirthdate;
                else thongbao += thongbaobirthdate;
            }
            if (salary == -1)
            {
                string thongbaosalary = "- Salary\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaosalary;
                else thongbao += thongbaosalary;
            }

            if (thongbao != null) MessageBox.Show(thongbao);
            else
            {
                Employee employee = new Employee(ssn, null, null, null, null, null, 0, null);
                IObjectSet result = database.DB.QueryByExample(employee);
                if(result.Count != 0)
                {
                    employee = (Employee)result[0];
                    employee.FName = fname;
                    employee.LName = lname;
                    employee.Gender = gender;
                    employee.MInit = minit;
                    employee.BirthDate = birthdate;
                    employee.Address = address;
                    employee.Salary = salary;

                    database.DB.Store(employee);
                    result = database.result_Employee();
                    int countNew = result.Count;
                    string[] data_EmployeeNew = new string[countNew + 1];
                    data_EmployeeNew[0] = countNew.ToString();
                    for(int i = 0; i < countNew; ++i)
                    {
                        Employee temp = (Employee)result[i];
                        data_EmployeeNew[i + 1] = temp._ToString();
                    }
                    File.WriteAllLines("data_Employee.txt", data_EmployeeNew);

                    MessageBox.Show("Sửa thành công");

                    LoadData();
                }
            }
        }

        private void textBox_Ssn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBox_Salary_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button_Reset_Employee_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void button_Reset_Dependent_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void button_Reset_Project_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void button_Reset_Department_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button_AddDependent_Click(object sender, EventArgs e)
        {
            string name = textBox_NameDependent.Text;
            string gender = textBox_GenderDepenednt.Text;
            string birthdate = textBox_BirthDateDependent.Text;
            string relationship = comboBox_RelationshipDependent.Text;
            string ssn_Employee = textBox_SsnDependentOf.Text;
            string name_Employee = textBox_NameDependentOf.Text;
            string fname_Employee = textBox_FNameEmployee.Text;
            string lname_Employee = textBox_LNameEmployee.Text;

            string thongbao = null;

            if(name == "")
            {
                string thongbaoname = "- Name dependent\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaoname;
                else thongbao += thongbaoname;
            }
            if(gender == "")
            {
                string thongbaogender = "- Gender\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaogender;
                else thongbao += thongbaogender;
            }
            if (birthdate == "")
            {
                string thongbaobirthdate = "- BirthDate\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaobirthdate;
                else thongbao += thongbaobirthdate;
            }
            if (relationship == "")
            {
                string thongbaorelationship = "- Relationship\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaorelationship;
                else thongbao += thongbaorelationship;
            }
            if (ssn_Employee == "")
            {
                string thongbaossn = "- Ssn Employee\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaossn;
                else thongbao += thongbaossn;
            }
            if (name_Employee == "")
            {
                string thongbaoname = "- Name Employee\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaoname;
                else thongbao += thongbaoname;
            }

            if (thongbao != null) MessageBox.Show(thongbao);
            else
            {
                Dependent dependent = new Dependent(name, gender, birthdate, relationship);

                Employee employee = new Employee(int.Parse(ssn_Employee), fname_Employee, null, lname_Employee, null, null, 0, null);
                IObjectSet result = database.DB.QueryByExample(employee);
                employee = (Employee)result[0];
                if (employee.Dependents == null) employee.Dependents = new List<Dependent>();
                employee.Dependents.Add(dependent);
                dependent.DependentOf = employee;

                database.DB.Store(dependent);
                database.DB.Store(employee);

                result = database.result_Dependent();
                int countNew = result.Count;
                string[] data_DependentNew = new string[countNew + 1];

                data_DependentNew[0] = countNew.ToString();
                for(int i = 0; i < countNew; ++i)
                {
                    Dependent temp = (Dependent)result[i];
                    data_DependentNew[i + 1] = temp._ToString();
                }

                File.WriteAllLines("data_Dependent.txt", data_DependentNew);

                MessageBox.Show("Thêm thành công");

                LoadData();
            }
        }
        private void button_DeleteDependent_Click(object sender, EventArgs e)
        {
            string name = textBox_NameDependent.Text;
            string gender = textBox_GenderDepenednt.Text;
            string birthdate = textBox_BirthDateDependent.Text;
            string relationship = comboBox_RelationshipDependent.Text;

            Dependent dependent = new Dependent(name, gender, birthdate, relationship);
            IObjectSet result = database.DB.QueryByExample(dependent);
            if(result.Count != 0)
            {
                dependent = (Dependent)result[0];
                database.DB.Delete(dependent);

                result = database.result_Dependent();
                int countNew = result.Count;
                string[] data_DependentNew = new string[countNew + 1];

                data_DependentNew[0] = countNew.ToString();
                for(int i = 0; i < countNew; ++i)
                {
                    Dependent temp = (Dependent)result[i];
                    data_DependentNew[i + 1] = temp._ToString();
                }

                File.WriteAllLines("data_Dependent.txt", data_DependentNew);

                MessageBox.Show("Xóa thành công");

                LoadData();
            }
        }
        private void button_ModifyDependent_Click(object sender, EventArgs e)
        {
            string name = textBox_NameDependent.Text;
            string gender = textBox_GenderDepenednt.Text;
            string birthdate = textBox_BirthDateDependent.Text;
            string relationship = comboBox_RelationshipDependent.Text;

            string thongbao = null;

            if(name == "")
            {
                string thongbaoname = "- Name dependent";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaoname;
                else thongbao += thongbaoname;
            }
            if (gender == "")
            {
                string thongbaogender = "- Gender dependent";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaogender;
                else thongbao += thongbaogender;
            }
            if (birthdate == "")
            {
                string thongbaobirthdate = "- BirthDate dependent";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaobirthdate;
                else thongbao += thongbaobirthdate;
            }
            if (relationship == "")
            {
                string thongbaorelationship = "- Relationship dependent";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaorelationship;
                else thongbao += thongbaorelationship;
            }

            if (thongbao != null) MessageBox.Show(thongbao);
            else
            {
                string nameOld = textBox_NameDependentOld.Text;
                string genderOld = textBox_GenderDependentOld.Text;
                string birthDateOld = textBox_BirthDateDependentOld.Text;
                string relationshipOld = textBox_RelationshipDependentOld.Text;
                Dependent dependent = new Dependent(nameOld, genderOld, birthDateOld, relationshipOld);
                IObjectSet result = database.DB.QueryByExample(dependent);
                if(result.Count != 0)
                {
                    dependent = (Dependent)result[0];
                    dependent.Name = name;
                    dependent.Gender = gender;
                    dependent.BirthDate = birthdate;
                    dependent.Relationship = relationship;
                    database.DB.Store(dependent);

                    result = database.result_Dependent();
                    int countNew = result.Count;
                    string[] data_DependentNew = new string[countNew + 1];

                    data_DependentNew[0] = countNew.ToString();
                    for(int i = 0; i < countNew; ++i)
                    {
                        Dependent temp = (Dependent)result[i];
                        data_DependentNew[i + 1] = temp._ToString();
                    }

                    File.WriteAllLines("data_Dependent.txt", data_DependentNew);

                    MessageBox.Show("Sửa thành công");

                    LoadData();
                }
            }
        }
    }
}