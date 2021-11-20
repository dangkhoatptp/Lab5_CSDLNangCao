using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.IO;
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
            textBox_SsnEmployee.ReadOnly = false;
            textBox_SsnEmployee.Clear();
            textBox_FNameEmployee.Clear();
            textBox_LNameEmployee.Clear();
            textBox_GenderEmployee.Clear();
            textBox_MInitEmployee.Clear();
            textBox_BirthDateEmployee.Clear();
            textBox_AddressEmployee.Clear();
            textBox_SalaryEmployee.Clear();

            // tab_Dependent
            textBox_NameDependent.Clear();
            textBox_GenderDependent.Clear();
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
            textBox_SsnDependentOfOld.Clear();
            textBox_NameDependentOf.Clear();
            textBox_NameDependentOld.Clear();
            textBox_GenderDependentOld.Clear();
            textBox_BirthDateDependentOld.Clear();
            textBox_RelationshipDependentOld.Clear();

            // tab_Project
            textBox_NumberProject.ReadOnly = false;
            textBox_NumberProject.Clear();
            textBox_NameProject.Clear();
            comboBox_LocationProject.Items.Clear();
            comboBox_LocationProject.Text = "";
            textBox_NumberControlledBy.Clear();
            textBox_NameControlledBy.Clear();
            textBox_NumberControlledByOld.Clear();

            // tab_Department
            textBox_NumberDepartment.ReadOnly = false;
            textBox_NumberDepartment.Clear();
            textBox_NameDepartment.Clear();
            textBox_LocationsDepartment.Clear();
            textBox_SsnManager.Clear();
            textBox_NameManager.Clear();
            textBox_SsnManagerOld.Clear();
            textBox_MgrStartDate.Clear();

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
            dataGridView_DependentOf.DataSource = list_Employee;
            dataGridView_ControlledBy.DataSource = list_Department;
            dataGridView_Manager.DataSource = list_Employee;

            // Truy vấn 1: Tìm tất cả những người làm thuê có giới tính là nam
            IList<Employee> listEmployee = database.DB.Query(delegate (Employee e)
            {
                if (e.Gender == "M") return true;
                return false;
            });
            List<Employee> listCTV1 = new List<Employee>();
            for(int i = 0; i < listEmployee.Count; ++i)
            {
                listCTV1.Add((Employee)listEmployee[i]);
            }
            dataGridView_CauTruyVan1.DataSource = listCTV1;

            // Truy vấn 2: Tìm tất cả những người làm thuê đã làm việc cho ban ngành có tên có chữ T ở đầu
            IList<Department> listDepartment = database.DB.Query(delegate(Department d) 
            {
                if (d.DName[0] == 'T') return true;
                return false;
            });
            List<Employee> listCTV2 = new List<Employee>();
            for(int i = 0; i < listDepartment.Count; ++i)
            {
                for(int j = 0; j < listDepartment[i].Employees.Count; ++j)
                {
                    if (listCTV2.Count == 0) listCTV2.Add((Employee)listDepartment[i].Employees[j]);
                    else
                    {
                        bool check = false;
                        for(int k = 0; k < listCTV2.Count; ++k)
                        {
                            if (listCTV2[k] == (Employee)listDepartment[i].Employees[j]) check = true;
                        }
                        if (check == true) continue;
                        else
                        {
                            listCTV2.Add((Employee)listDepartment[i].Employees[j]);
                        }
                    }
                }
            }
            dataGridView_CauTruyVan2.DataSource = listCTV2;
        }

        private void dataGridView_Employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                IObjectSet result = database.result_Employee();
                Employee employee = (Employee)result[e.RowIndex];

                textBox_SsnEmployee.ReadOnly = true;
                textBox_SsnEmployee.Text = employee.Ssn.ToString();
                textBox_FNameEmployee.Text = employee.FName;
                textBox_LNameEmployee.Text = employee.LName;
                textBox_MInitEmployee.Text = employee.MInit;
                textBox_GenderEmployee.Text = employee.Gender;
                textBox_AddressEmployee.Text = employee.Address;
                textBox_BirthDateEmployee.Text = employee.BirthDate;
                textBox_SalaryEmployee.Text = employee.Salary.ToString();
            }
        }
        private void dataGridView_DependentOf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                IObjectSet result = database.result_Employee();
                Employee dependentOf = (Employee)result[e.RowIndex];

                textBox_SsnDependentOf.Text = dependentOf.Ssn.ToString();
                textBox_NameDependentOf.Text = dependentOf.FName + " " + dependentOf.LName;
            }
        }
        private void dataGridView_Dependent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                IObjectSet result = database.result_Dependent();
                Dependent dependent = (Dependent)result[e.RowIndex];

                textBox_NameDependent.Text = dependent.Name;
                textBox_GenderDependent.Text = dependent.Gender;
                textBox_BirthDateDependent.Text = dependent.BirthDate;
                comboBox_RelationshipDependent.Text = dependent.Relationship;
                textBox_SsnDependentOf.Text = dependent.DependentOf.Ssn.ToString();
                textBox_SsnDependentOfOld.Text = dependent.DependentOf.Ssn.ToString();
                textBox_NameDependentOf.Text = dependent.DependentOf.FName + " " + dependent.DependentOf.LName;
                textBox_NameDependentOld.Text = dependent.Name;
                textBox_GenderDependentOld.Text = dependent.Gender;
                textBox_BirthDateDependentOld.Text = dependent.BirthDate;
                textBox_RelationshipDependentOld.Text = dependent.Relationship;
            }
        }
        private void dataGridView_ControlledBy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IObjectSet result = database.result_Department();
            Department department = (Department)result[e.RowIndex];

            textBox_NumberControlledBy.Text = department.DNumber.ToString();
            textBox_NameControlledBy.Text = department.DName;
            comboBox_LocationProject.Text = "";
            comboBox_LocationProject.Items.Clear();
            for(int i = 0; i < department.Locations.Count; ++i)
            {
                comboBox_LocationProject.Items.Add(department.Locations[i]);
            }
        }
        private void dataGridView_Project_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_NumberProject.ReadOnly = true;
            IObjectSet result = database.result_Project();
            if(e.RowIndex != -1)
            {
                Project project = (Project)result[e.RowIndex];
                textBox_NumberProject.Text = project.PNumber.ToString();
                textBox_NameProject.Text = project.PName;
                comboBox_LocationProject.Items.Clear();
                for(int i = 0; i < project.ControlledBy.Locations.Count; ++i)
                {
                    comboBox_LocationProject.Items.Add(project.ControlledBy.Locations[i]);
                }
                comboBox_LocationProject.Text = project.Location;
                textBox_NumberControlledBy.Text = project.ControlledBy.DNumber.ToString();
                textBox_NameControlledBy.Text = project.ControlledBy.DName;
                textBox_NumberControlledByOld.Text = project.ControlledBy.DNumber.ToString();
            }
        }
        private void dataGridView_Manager_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                IObjectSet result = database.result_Employee();
                Employee manager = (Employee)result[e.RowIndex];

                textBox_MgrStartDate.Clear();
                textBox_SsnManager.Text = manager.Ssn.ToString();
                textBox_NameManager.Text = manager.FName + " " + manager.LName;
            }
        }
        private void dataGridView_Department_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                textBox_NumberDepartment.ReadOnly = true;

                IObjectSet result = database.result_Department();
                Department department = (Department)result[e.RowIndex];

                textBox_NumberDepartment.Text = department.DNumber.ToString();
                textBox_NameDepartment.Text = department.DName;
                string locations = null;
                for(int i = 0; i < department.Locations.Count; ++i)
                {
                    if (i == 0) locations = department.Locations[i];
                    else locations += "," + department.Locations[i];
                }
                textBox_LocationsDepartment.Text = locations;
                if(department.Manager != null)
                {
                    textBox_SsnManager.Text = department.Manager.Ssn.ToString();
                    textBox_SsnManagerOld.Text = department.Manager.Ssn.ToString();
                    textBox_NameManager.Text = department.Manager.FName + " " + department.Manager.LName;
                    textBox_MgrStartDate.Text = department.MgrStartDate;
                }
                else
                {
                    textBox_SsnManager.Clear();
                    textBox_SsnManagerOld.Clear();
                    textBox_NameManager.Clear();
                    textBox_MgrStartDate.Clear();
                }
            }
        }


        private void button_AddEmployee_Click(object sender, EventArgs e)
        {
            int ssn = -1;
            if (textBox_SsnEmployee.Text != "") ssn = int.Parse(textBox_SsnEmployee.Text);
            string fname = textBox_FNameEmployee.Text;
            string lname = textBox_LNameEmployee.Text;
            string gender = textBox_GenderEmployee.Text;
            string minit = textBox_MInitEmployee.Text;
            string address = textBox_AddressEmployee.Text;
            string birthdate = textBox_BirthDateEmployee.Text;
            double salary = -1;
            if(textBox_SalaryEmployee.Text != "") salary = double.Parse(textBox_SalaryEmployee.Text);

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
                Employee employee = new Employee(ssn, null, null, null, null, null, 0, null);
                IObjectSet result = database.DB.QueryByExample(employee);
                if(result.Count != 0) MessageBox.Show("Ssn bị trùng, vui lòng nhập lại");
                else
                {
                    employee = new Employee(ssn, fname, minit, lname, address, birthdate, salary, gender);
                    database.DB.Store(employee);

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

                    MessageBox.Show("Bạn đã thêm thành công");

                    LoadData();
                }
            }
        }
        private void button_DeleteEmployee_Click(object sender, EventArgs e) // Xem lại phần này
        {
            int ssn = -1;
            if (textBox_SsnEmployee.Text != "") ssn = int.Parse(textBox_SsnEmployee.Text);

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
            if(textBox_SsnEmployee.Text != "") ssn = int.Parse(textBox_SsnEmployee.Text);
            string fname = textBox_FNameEmployee.Text;
            string lname = textBox_LNameEmployee.Text;
            string gender = textBox_GenderEmployee.Text;
            string minit = textBox_MInitEmployee.Text;
            string birthdate = textBox_BirthDateEmployee.Text;
            string address = textBox_AddressEmployee.Text;
            double salary = -1; 
            if(textBox_SalaryEmployee.Text != "") salary = double.Parse(textBox_SalaryEmployee.Text);

            string thongbao = null;

            if (ssn == -1) MessageBox.Show("Bạn chưa chọn employee để sửa");
            else
            {
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
                    if (result.Count != 0)
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
                        for (int i = 0; i < countNew; ++i)
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
        }

        private void textBox_Ssn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

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

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBox_PNumberProject_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBox_NumberDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

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
            string gender = textBox_GenderDependent.Text;
            string birthdate = textBox_BirthDateDependent.Text;
            string relationship = comboBox_RelationshipDependent.Text;
            int ssnEmployee = -1;
            if(textBox_SsnDependentOf.Text != "") ssnEmployee = int.Parse(textBox_SsnDependentOf.Text);
            string nameEmployee = textBox_NameDependentOf.Text;

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
            if (ssnEmployee == -1)
            {
                string thongbaossn = "- Ssn Employee\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaossn;
                else thongbao += thongbaossn;
            }
            if (nameEmployee == "")
            {
                string thongbaoname = "- Name Employee\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaoname;
                else thongbao += thongbaoname;
            }

            if (thongbao != null) MessageBox.Show(thongbao);
            else
            {
                Dependent dependent = new Dependent(name, gender, birthdate, relationship);

                Employee employee = new Employee(ssnEmployee, null, null, null, null, null, 0, null);
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
            string name = textBox_NameDependentOld.Text;
            string gender = textBox_GenderDependentOld.Text;
            string birthdate = textBox_BirthDateDependentOld.Text;
            string relationship = textBox_RelationshipDependentOld.Text;

            if (name == "" && gender == "" && birthdate == "" && relationship == "") MessageBox.Show("Bạn chưa chọn dependent để xóa");
            else
            {
                Dependent dependent = new Dependent(name, gender, birthdate, relationship);
                IObjectSet result = database.DB.QueryByExample(dependent);
                if (result.Count != 0)
                {
                    dependent = (Dependent)result[0];
                    database.DB.Delete(dependent);

                    result = database.result_Dependent();
                    int countNew = result.Count;
                    string[] data_DependentNew = new string[countNew + 1];

                    data_DependentNew[0] = countNew.ToString();
                    for (int i = 0; i < countNew; ++i)
                    {
                        Dependent temp = (Dependent)result[i];
                        data_DependentNew[i + 1] = temp._ToString();
                    }

                    File.WriteAllLines("data_Dependent.txt", data_DependentNew);

                    MessageBox.Show("Xóa thành công");

                    LoadData();
                }
            }
        }
        private void button_ModifyDependent_Click(object sender, EventArgs e)
        {
            string nameDependentNew = textBox_NameDependent.Text;
            string genderDependentNew = textBox_GenderDependent.Text;
            string birthdateDependentNew = textBox_BirthDateDependent.Text;
            string relationshipDependentNew = comboBox_RelationshipDependent.Text;

            string nameDependentOld = textBox_NameDependentOld.Text;
            string genderDependentOld = textBox_GenderDependentOld.Text;
            string birthDateDependentOld = textBox_BirthDateDependentOld.Text;
            string relationshipDependentOld = textBox_RelationshipDependentOld.Text;

            int ssnDependentOf = -1;
            if(textBox_SsnDependentOf.Text != "") ssnDependentOf = int.Parse(textBox_SsnDependentOf.Text);
            int ssnDependentOfOld = -1;
            if(textBox_SsnDependentOfOld.Text != "") ssnDependentOfOld = int.Parse(textBox_SsnDependentOfOld.Text);

            if (ssnDependentOf == -1) MessageBox.Show("Bạn chưa chọn dependent để sửa");
            else
            {
                string thongbao = null;

                if (nameDependentNew == "")
                {
                    string thongbaoname = "- Name dependent\n";
                    if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaoname;
                    else thongbao += thongbaoname;
                }
                if (genderDependentNew == "")
                {
                    string thongbaogender = "- Gender dependent\n";
                    if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaogender;
                    else thongbao += thongbaogender;
                }
                if (birthdateDependentNew == "")
                {
                    string thongbaobirthdate = "- BirthDate dependent\n";
                    if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaobirthdate;
                    else thongbao += thongbaobirthdate;
                }
                if (relationshipDependentNew == "")
                {
                    string thongbaorelationship = "- Relationship dependent\n";
                    if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaorelationship;
                    else thongbao += thongbaorelationship;
                }

                if (thongbao != null) MessageBox.Show(thongbao);
                else
                {
                    Dependent dependent = new Dependent(nameDependentOld, genderDependentOld, birthDateDependentOld, relationshipDependentOld);
                    IObjectSet result = database.DB.QueryByExample(dependent);
                    if (result.Count != 0)
                    {
                        dependent = (Dependent)result[0];
                        dependent.Name = nameDependentNew;
                        dependent.Gender = genderDependentNew;
                        dependent.BirthDate = birthdateDependentNew;
                        dependent.Relationship = relationshipDependentNew;

                        if (ssnDependentOf != ssnDependentOfOld)
                        {
                            Employee dependentOfNew = new Employee(ssnDependentOf, null, null, null, null, null, 0, null);
                            result = database.DB.QueryByExample(dependentOfNew);
                            dependentOfNew = (Employee)result[0];

                            dependent.DependentOf = dependentOfNew;
                        }

                        database.DB.Store(dependent);

                        result = database.result_Dependent();
                        int countNew = result.Count;
                        string[] data_DependentNew = new string[countNew + 1];

                        data_DependentNew[0] = countNew.ToString();
                        for (int i = 0; i < countNew; ++i)
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

        private void button_AddProject_Click(object sender, EventArgs e)
        {
            int numberProject = -1;
            if (textBox_NumberProject.Text != "") numberProject = int.Parse(textBox_NumberProject.Text);
            string nameProject = textBox_NameProject.Text;
            string locationProject = comboBox_LocationProject.Text;
            int numberDepartment = -1;
            if (textBox_NumberControlledBy.Text != "") numberDepartment = int.Parse(textBox_NumberControlledBy.Text);
            string nameDepartment = textBox_NameControlledBy.Text;

            string thongbao = null;

            if(numberProject == -1)
            {
                string thongbaonumberProject = "- Number project\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaonumberProject;
                else thongbao += thongbaonumberProject;
            }
            if (nameProject == "")
            {
                string thongbaonameProject = "- Name project\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaonameProject;
                else thongbao += thongbaonameProject;
            }
            if (locationProject == "")
            {
                string thongbaolocationProject = "- Location project\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaolocationProject;
                else thongbao += thongbaolocationProject;
            }
            if (numberDepartment == -1)
            {
                string thongbaonumberDepartment = "- Number department\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaonumberDepartment;
                else thongbao += thongbaonumberDepartment;
            }
            if (nameDepartment == "")
            {
                string thongbaonameDepartment = "- Name department\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaonameDepartment;
                else thongbao += thongbaonameDepartment;
            }

            if (thongbao != null) MessageBox.Show(thongbao);
            else
            {
                Project project = new Project(numberProject, null, null);
                IObjectSet result = database.DB.QueryByExample(project);
                if (result.Count != 0) MessageBox.Show("Number project bị trùng, vui lòng nhập lại");
                else
                {
                    project = new Project(numberProject, nameProject, locationProject);

                    Department department = new Department(numberDepartment, nameDepartment, null);
                    result = database.DB.QueryByExample(department);
                    if (result.Count != 0)
                    {
                        department = (Department)result[0];
                        if (department.Projects == null) department.Projects = new List<Project>();
                        department.Projects.Add(project);
                        project.ControlledBy = department;

                        database.DB.Store(department);
                        database.DB.Store(project);

                        result = database.result_Project();
                        int countNew = result.Count;
                        string[] data_ProjectNew = new string[countNew + 1];

                        data_ProjectNew[0] = countNew.ToString();
                        for (int i = 0; i < countNew; ++i)
                        {
                            Project temp = (Project)result[i];
                            data_ProjectNew[i + 1] = temp._ToString();
                        }

                        File.WriteAllLines("data_Project.txt", data_ProjectNew);

                        result = database.result_Department();
                        int count = 0;
                        string[] data_Temp = new string[result.Count];

                        for (int i = 0; i < result.Count; ++i)
                        {
                            Department temp = (Department)result[i];
                            if (temp.Projects != null)
                            {
                                data_Temp[i] = temp.DNumber.ToString() + ": ";
                                for (int j = 0; j < temp.Projects.Count; ++j)
                                {
                                    if (j == 0)
                                    {
                                        data_Temp[i] += temp.Projects[j].PNumber.ToString();
                                    }
                                    else
                                    {
                                        data_Temp[i] += ", " + temp.Projects[j].PNumber.ToString();
                                    }
                                }
                                ++count;
                            }
                        }

                        string[] data_ControlledByNew = new string[count + 1];
                        data_ControlledByNew[0] = count.ToString();
                        for (int i = 0; i < data_ControlledByNew.Length - 1; ++i)
                        {
                            if(data_Temp[i] != null) data_ControlledByNew[i + 1] = data_Temp[i];
                        }

                        File.WriteAllLines("SetControlledBy.txt", data_ControlledByNew);

                        MessageBox.Show("Thêm thành công");

                        LoadData();
                    }
                }
            }
        }
        private void button_DeleteProject_Click(object sender, EventArgs e)
        {
            int numberProject = -1;
            if(textBox_NumberProject.Text != "") numberProject = int.Parse(textBox_NumberProject.Text);
            int numberDepartment = -1;
            if(textBox_NumberControlledByOld.Text != "") numberDepartment = int.Parse(textBox_NumberControlledByOld.Text);

            if (numberDepartment == -1) MessageBox.Show("Bạn chưa chọn project để xóa");
            else
            {
                Project project = new Project(numberProject, null, null);
                IObjectSet result = database.DB.QueryByExample(project);
                project = (Project)result[0];

                Department department = new Department(numberDepartment, null, null);
                result = database.DB.QueryByExample(department);
                department = (Department)result[0];
                department.Projects.Remove(project);

                database.DB.Store(department);
                database.DB.Delete(project);

                result = database.result_Project();
                int countNew = result.Count;
                string[] data_ProjectNew = new string[countNew + 1];

                data_ProjectNew[0] = countNew.ToString();
                for (int i = 0; i < countNew; ++i)
                {
                    Project temp = (Project)result[i];
                    data_ProjectNew[i + 1] = temp._ToString();
                }

                File.WriteAllLines("data_Project.txt", data_ProjectNew);

                result = database.result_Department();
                int count = 0;
                string[] data_Temp = new string[result.Count];

                for (int i = 0; i < result.Count; ++i)
                {
                    Department temp = (Department)result[i];
                    if (temp.Projects != null && temp.Projects.Count != 0)
                    {
                        data_Temp[i] = temp.DNumber.ToString() + ": ";
                        for (int j = 0; j < temp.Projects.Count; ++j)
                        {
                            if (j == 0)
                            {
                                data_Temp[i] += temp.Projects[j].PNumber.ToString();
                            }
                            else
                            {
                                data_Temp[i] += ", " + temp.Projects[j].PNumber.ToString();
                            }
                        }
                        ++count;
                    }
                }

                string[] data_ControlledByNew = new string[count + 1];
                data_ControlledByNew[0] = count.ToString();
                for (int i = 0; i < data_ControlledByNew.Length - 1; ++i)
                {
                    if (data_Temp[i] != null) data_ControlledByNew[i + 1] = data_Temp[i];
                }

                File.WriteAllLines("SetControlledBy.txt", data_ControlledByNew);

                MessageBox.Show("Xóa thành công");

                LoadData();
            }
        }
        private void button_ModifyProject_Click(object sender, EventArgs e)
        {
            int numberProject = -1;
            if(textBox_NumberProject.Text != "") numberProject = int.Parse(textBox_NumberProject.Text);
            string nameProjectNew = textBox_NameProject.Text;
            string locationProjectNew = comboBox_LocationProject.Text;

            int numberDepartmentNew = -1;
            if(textBox_NumberControlledBy.Text != "") numberDepartmentNew = int.Parse(textBox_NumberControlledBy.Text);
            int numberDepartmentOld = -1; 
            if(textBox_NumberControlledByOld.Text != "") numberDepartmentOld = int.Parse(textBox_NumberControlledByOld.Text);

            if (numberDepartmentOld == -1) MessageBox.Show("Bạn chưa chọn project để sửa");
            else
            {
                string thongbao = null;

                if (nameProjectNew == "")
                {
                    string thongbaoname = "- Name project\n";
                    if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaoname;
                    else thongbao += thongbaoname;
                }
                if (locationProjectNew == "")
                {
                    string thongbaolocation = "- Location project\n";
                    if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaolocation;
                    else thongbao += thongbaolocation;
                }

                if (thongbao != null) MessageBox.Show(thongbao);
                else
                {
                    Project project = new Project(numberProject, null, null);
                    IObjectSet result = database.DB.QueryByExample(project);
                    project = (Project)result[0];

                    project.PName = nameProjectNew;
                    project.Location = locationProjectNew;

                    if (numberDepartmentOld == numberDepartmentNew)
                    {
                        database.DB.Store(project);

                        result = database.result_Project();
                        int countNew = result.Count;
                        string[] data_ProjectNew = new string[countNew + 1];

                        data_ProjectNew[0] = countNew.ToString();
                        for (int i = 0; i < countNew; ++i)
                        {
                            Project temp = (Project)result[i];
                            data_ProjectNew[i + 1] = temp._ToString();
                        }

                        File.WriteAllLines("data_Project.txt", data_ProjectNew);
                    }
                    else if (numberDepartmentOld != numberDepartmentNew)
                    {
                        Department departmentOld = new Department(numberDepartmentOld, null, null);
                        result = database.DB.QueryByExample(departmentOld);
                        departmentOld = (Department)result[0];

                        Department departmentNew = new Department(numberDepartmentNew, null, null);
                        result = database.DB.QueryByExample(departmentNew);
                        departmentNew = (Department)result[0];

                        departmentOld.Projects.Remove(project);
                        if (departmentNew.Projects == null) departmentNew.Projects = new List<Project>();
                        departmentNew.Projects.Add(project);
                        project.ControlledBy = departmentNew;

                        database.DB.Store(project);
                        database.DB.Store(departmentOld);
                        database.DB.Store(departmentNew);

                        result = database.result_Project();
                        int countNew = result.Count;
                        string[] data_ProjectNew = new string[countNew + 1];

                        data_ProjectNew[0] = countNew.ToString();
                        for (int i = 0; i < countNew; ++i)
                        {
                            Project temp = (Project)result[i];
                            data_ProjectNew[i + 1] = temp._ToString();
                        }

                        File.WriteAllLines("data_Project.txt", data_ProjectNew);

                        result = database.result_Department();
                        int count = 0;
                        string[] data_Temp = new string[result.Count];

                        for (int i = 0; i < result.Count; ++i)
                        {
                            Department department = (Department)result[i];
                            if (department.Projects != null && department.Projects.Count != 0)
                            {
                                data_Temp[i] = department.DNumber.ToString() + ": ";
                                for (int j = 0; j < department.Projects.Count; ++j)
                                {
                                    if (j == 0) data_Temp[i] += department.Projects[j].PNumber.ToString();
                                    else data_Temp[i] += ", " + department.Projects[j].PNumber.ToString();
                                }
                                ++count;
                            }
                        }

                        string[] data_ControlledByNew = new string[count + 1];
                        data_ControlledByNew[0] = count.ToString();
                        for (int i = 0; i < count; ++i)
                        {
                            data_ControlledByNew[i + 1] = data_Temp[i];
                        }

                        File.WriteAllLines("SetControlledBy.txt", data_ControlledByNew);
                    }

                    MessageBox.Show("Sửa thành công");

                    LoadData();
                }
            }
        }

        private void button_AddDepartment_Click(object sender, EventArgs e)
        {
            int numberDepartment = -1;
            if (textBox_NumberDepartment.Text != "") numberDepartment = int.Parse(textBox_NumberDepartment.Text);
            string nameDepartment = textBox_NameDepartment.Text;
            string locationsDepartment = textBox_LocationsDepartment.Text;

            int ssnManager = -1;
            if (textBox_SsnManager.Text != "") ssnManager = int.Parse(textBox_SsnManager.Text);
            string mgrStartDate = textBox_MgrStartDate.Text;

            string thongbao = null;

            if(numberDepartment == -1)
            {
                string thongbaonumber = "- Number department\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaonumber;
                else thongbao += thongbaonumber;
            }
            if (nameDepartment == "")
            {
                string thongbaoname = "- Name department\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaoname;
                else thongbao += thongbaoname;
            }
            if (locationsDepartment == "")
            {
                string thongbaolocations = "- Locations department\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaolocations;
                else thongbao += thongbaolocations;
            }
            if (ssnManager == -1)
            {
                string thongbaossn = "- Ssn manager\n- Name manager\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaossn;
                else thongbao += thongbaossn;
            }
            if(mgrStartDate == "")
            {
                string thongbaodate = "- Manager start date\n";
                if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaodate;
                else thongbao += thongbaodate;
            }

            if (thongbao != null) MessageBox.Show(thongbao);
            else
            {
                Department department = new Department(numberDepartment, null, null);
                IObjectSet result = database.DB.QueryByExample(department);
                if (result.Count != 0) MessageBox.Show("Number department bị trùng, vui lòng nhập lại");
                else
                {
                    Employee employee = new Employee(ssnManager, null, null, null, null, null, 0, null);
                    result = database.DB.QueryByExample(employee);
                    employee = (Employee)result[0];
                    if (employee.Manager != null) MessageBox.Show("Một department được quản lí bởi employee này, vui lòng nhập lại");
                    else
                    {
                        List<string> Locations = new List<string>();
                        string[] listLocations = locationsDepartment.Split(',');
                        for (int i = 0; i < listLocations.Length; ++i)
                        {
                            while (listLocations[i][0] == ' ') listLocations[i] = listLocations[i].Remove(0, 1);
                            while (listLocations[i][listLocations[i].Length - 1] == ' ') listLocations[i] = listLocations[i].Remove(listLocations[i].Length - 1, 1);

                            Locations.Add(listLocations[i]);
                        }

                        department = new Department(numberDepartment, nameDepartment, Locations);

                        Employee manager = new Employee(ssnManager, null, null, null, null, null, 0, null);
                        result = database.DB.QueryByExample(manager);

                        department.Manager = manager;
                        department.MgrStartDate = mgrStartDate;
                        manager.Manager = department;

                        database.DB.Store(department);
                        database.DB.Store(manager);

                        result = database.result_Employee();
                        int count = 0;
                        string[] data_Temp = new string[result.Count];

                        for (int i = 0; i < result.Count; ++i)
                        {
                            employee = (Employee)result[i];
                            if (employee.Manager != null)
                            {
                                string lineManager = employee.Manager.DNumber.ToString() + "," + employee.Ssn.ToString() + "," + employee.Manager.MgrStartDate;
                                data_Temp[count] = lineManager;
                                ++count;
                            }
                        }

                        string[] data_ManagerNew = new string[count + 1];
                        data_ManagerNew[0] = count.ToString();
                        for (int i = 0; i < count; ++i)
                        {
                            data_ManagerNew[i + 1] = data_Temp[i];
                        }

                        File.WriteAllLines("SetManager.txt", data_ManagerNew);

                        result = database.result_Department();
                        int countNew = result.Count;
                        string[] data_DepartmentNew = new string[countNew + 1];

                        data_DepartmentNew[0] = countNew.ToString();
                        for (int i = 0; i < countNew; ++i)
                        {
                            Department temp = (Department)result[i];
                            string lineDepartment = temp.DNumber.ToString() + ":" + temp.DName + ":";
                            for (int j = 0; j < temp.Locations.Count; ++j)
                            {
                                if (j == 0) lineDepartment += temp.Locations[j];
                                else lineDepartment += "," + temp.Locations[j];
                            }
                            data_DepartmentNew[i + 1] = lineDepartment;
                        }

                        File.WriteAllLines("data_Department.txt", data_DepartmentNew);

                        MessageBox.Show("Thêm thành công");

                        LoadData();
                    }
                }
            }
        }
        private void button_ModifyDepartment_Click(object sender, EventArgs e)
        {
            int numberDepartment = -1;
            if (textBox_NumberDepartment.Text != "") numberDepartment = int.Parse(textBox_NumberDepartment.Text);
            string nameDepartment = textBox_NameDepartment.Text;
            string locationsDepartment = textBox_LocationsDepartment.Text;

            int ssnManagerOld = -1;
            if (textBox_SsnManagerOld.Text != "") ssnManagerOld = int.Parse(textBox_SsnManagerOld.Text);
            int ssnManagerNew = -1;
            if (textBox_SsnManager.Text != "") ssnManagerNew = int.Parse(textBox_SsnManager.Text);
            string mgrStartDate = textBox_MgrStartDate.Text;

            if (numberDepartment == -1) MessageBox.Show("Bạn chưa chọn department để sửa");
            else
            {
                string thongbao = null;

                if(nameDepartment == "")
                {
                    string thongbaoname = "- Name department\n";
                    if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaoname;
                    else thongbao += thongbaoname;
                }
                if(locationsDepartment == "")
                {
                    string thongbaolocations = "- Locations department\n";
                    if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaolocations;
                    else thongbao += thongbaolocations;
                }
                if(ssnManagerNew == -1)
                {
                    string thongbaossn = "- Ssn manager\n";
                    if (thongbao == null) thongbao = "Bạn chưa nhập:\n" + thongbaossn;
                    else thongbao += thongbaossn;
                }

                if (thongbao != null) MessageBox.Show(thongbao);
                else
                {
                    Department department = new Department(numberDepartment, null, null);
                    IObjectSet result = database.DB.QueryByExample(department);
                    department = (Department)result[0];

                    List<string> Locations = new List<string>();
                    string[] listLocations = locationsDepartment.Split(',');
                    for (int i = 0; i < listLocations.Length; ++i)
                    {
                        while (listLocations[i][0] == ' ') listLocations[i] = listLocations[i].Remove(0, 1);
                        while (listLocations[i][listLocations[i].Length - 1] == ' ') listLocations[i] = listLocations[i].Remove(listLocations[i].Length - 1, 1);

                        Locations.Add(listLocations[i]);
                    }

                    department.DName = nameDepartment;
                    department.Locations = Locations;
                    department.MgrStartDate = mgrStartDate;

                    if (ssnManagerOld == ssnManagerNew)
                    {
                        database.DB.Store(department);
                    }
                    else if(ssnManagerOld != ssnManagerNew)
                    {
                        if(ssnManagerOld == -1)
                        {
                            Employee managerNew = new Employee(ssnManagerNew, null, null, null, null, null, 0, null);
                            result = database.DB.QueryByExample(managerNew);
                            managerNew = (Employee)result[0];

                            managerNew.Manager = department;
                            department.Manager = managerNew;

                            database.DB.Store(managerNew);
                            database.DB.Store(department);
                        }
                        else if(ssnManagerOld != -1)
                        {
                            Employee managerNew = new Employee(ssnManagerNew, null, null, null, null, null, 0, null);
                            result = database.DB.QueryByExample(managerNew);
                            managerNew = (Employee)result[0];

                            Employee managerOld = new Employee(ssnManagerOld, null, null, null, null, null, 0, null);
                            result = database.DB.QueryByExample(managerOld);
                            managerOld = (Employee)result[0];

                            managerOld.Manager = null;
                            managerNew.Manager = department;
                            department.Manager = managerNew;

                            database.DB.Store(managerOld);
                            database.DB.Store(managerNew);
                            database.DB.Store(department);
                        }
                    }

                    result = database.result_Employee();
                    int count = 0;
                    string[] data_Temp = new string[result.Count];

                    for (int i = 0; i < result.Count; ++i)
                    {
                        Employee employee = (Employee)result[i];
                        if (employee.Manager != null)
                        {
                            string lineManager = employee.Manager.DNumber.ToString() + "," + employee.Ssn.ToString() + "," + employee.Manager.MgrStartDate;
                            data_Temp[count] = lineManager;
                            ++count;
                        }
                    }

                    string[] data_ManagerNew = new string[count + 1];
                    data_ManagerNew[0] = count.ToString();
                    for (int i = 0; i < count; ++i)
                    {
                        data_ManagerNew[i + 1] = data_Temp[i];
                    }

                    File.WriteAllLines("SetManager.txt", data_ManagerNew);

                    result = database.result_Department();
                    int countNew = result.Count;
                    string[] data_DepartmentNew = new string[countNew + 1];

                    data_DepartmentNew[0] = countNew.ToString();
                    for (int i = 0; i < countNew; ++i)
                    {
                        Department temp = (Department)result[i];
                        string lineDepartment = temp.DNumber.ToString() + ":" + temp.DName + ":";
                        for (int j = 0; j < temp.Locations.Count; ++j)
                        {
                            if (j == 0) lineDepartment += temp.Locations[j];
                            else lineDepartment += "," + temp.Locations[j];
                        }
                        data_DepartmentNew[i + 1] = lineDepartment;
                    }

                    File.WriteAllLines("data_Department.txt", data_DepartmentNew);

                    MessageBox.Show("Thêm thành công");

                    LoadData();
                }
            }
        }
        private void button_DeleteDepartment_Click(object sender, EventArgs e)
        {
            int numberDepartment = -1;
            if (textBox_NumberDepartment.Text != "") numberDepartment = int.Parse(textBox_NumberDepartment.Text);
            int ssnManager = -1;
            if (textBox_SsnManagerOld.Text != "") ssnManager = int.Parse(textBox_SsnManagerOld.Text);

            if (numberDepartment == -1 && ssnManager == -1) MessageBox.Show("Bạn chưa chọn department để xóa");
            else
            {
                Department department = new Department(numberDepartment, null, null);
                IObjectSet result = database.DB.QueryByExample(department);
                department = (Department)result[0];

                Employee manager = new Employee(ssnManager, null, null, null, null, null, 0, null);
                result = database.DB.QueryByExample(manager);
                manager = (Employee)result[0];

                manager.Manager = null;

                database.DB.Store(manager);
                database.DB.Delete(department);

                result = database.result_Employee();
                int count = 0;
                string[] data_Temp = new string[result.Count];

                for (int i = 0; i < result.Count; ++i)
                {
                    Employee employee = (Employee)result[i];
                    if (employee.Manager != null)
                    {
                        string lineManager = employee.Manager.DNumber.ToString() + "," + employee.Ssn.ToString() + "," + employee.Manager.MgrStartDate;
                        data_Temp[count] = lineManager;
                        ++count;
                    }
                }

                string[] data_ManagerNew = new string[count + 1];
                data_ManagerNew[0] = count.ToString();
                for (int i = 0; i < count; ++i)
                {
                    data_ManagerNew[i + 1] = data_Temp[i];
                }

                File.WriteAllLines("SetManager.txt", data_ManagerNew);

                result = database.result_Department();
                int countNew = result.Count;
                string[] data_DepartmentNew = new string[countNew + 1];

                data_DepartmentNew[0] = countNew.ToString();
                for (int i = 0; i < countNew; ++i)
                {
                    Department temp = (Department)result[i];
                    string lineDepartment = temp.DNumber.ToString() + ":" + temp.DName + ":";
                    for (int j = 0; j < temp.Locations.Count; ++j)
                    {
                        if (j == 0) lineDepartment += temp.Locations[j];
                        else lineDepartment += "," + temp.Locations[j];
                    }
                    data_DepartmentNew[i + 1] = lineDepartment;
                }

                File.WriteAllLines("data_Department.txt", data_DepartmentNew);

                MessageBox.Show("Xóa thành công");

                LoadData();
            }
        }
    }
}