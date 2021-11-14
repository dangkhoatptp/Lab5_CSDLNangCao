using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public class Database
    {
        public static string DbFileName { get; set; } // Tên file database
        public static IObjectContainer DB;
        public void CloseDatabase()
        {
            DB.Close();
        } // Đóng database
        public Database()
        {
            DbFileName = "database.yap";
        }
        public void CreateDatabase()
        {
            DB = Db4oEmbedded.OpenFile(DbFileName); // Mở file database
            // Đọc dữ liệu từ file .txt sau đó nạp vào database
            CreateEmployee("data_Employee.txt"); 
            CreateDependents("data_Dependent.txt");
            CreateProject("data_Project.txt");
            CreateDepartment("data_Department.txt");
            CreateWorksOn("data_WorksOn.txt");
        }
        public static void CreateDependents(string fileName)
        {
            // Lấy dữ liệu Dependent cũ và xóa đi
            IObjectSet result = null;
            Dependent dependent = new Dependent(null, null, null, null);
            result = DB.QueryByExample(dependent);
            int count = result.Count;

            for(int i = 0; i < count; ++i)
            {
                DB.Delete(result[i]);
            }

            // Đọc dữ liệu từ file .txt
            if(File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open); // Mở file
                StreamReader fin = new StreamReader(fs); // Tạo biến đọc file
                int n = int.Parse(fin.ReadLine()); // Đọc dòng đầu để lấy số lượng Dependent

                for(int i = 0; i < n; ++i)
                {
                    string line = fin.ReadLine();
                    if(line != null)
                    {
                        string[] fields = line.Split(',');
                        int ssn_Employee = int.Parse(fields[0]);
                        string name = fields[1];
                        string gender = fields[2];
                        string birthdate = fields[3];
                        string relationship = fields[4];

                        Dependent d = new Dependent
                        {
                            Name = name,
                            Gender = gender,
                            BirthDate = birthdate,
                            Relationship = relationship,
                        };

                        // Tìm Employee với Ssn = ssn_Employee
                        // Điều kiện: trong database phải có sẵn dữ liệu Employee thì mới tìm được
                        Employee e = new Employee(ssn_Employee, null, null, null, null, null, 0, null);
                        IObjectSet result_Employee = DB.QueryByExample(e);
                        if(result_Employee.Count != 0)
                        {
                            d.DependentOf = (Employee)result_Employee[0];
                        }

                        DB.Store(d);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }
        public static void CreateEmployee(string fileName)
        {
            // Lấy dữ liệu Employee cũ và xóa đi
            IObjectSet result = null;
            Employee employee = new Employee(0, null, null, null, null, null, 0, null);
            result = DB.QueryByExample(employee);
            int count = result.Count;

            for(int i = 0; i < count; ++i)
            {
                DB.Delete(result[i]);
            }

            // Đọc dữ liệu từ file .txt
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open); // Mở file
                StreamReader fin = new StreamReader(fs); // Tạo biến đọc file
                int n = int.Parse(fin.ReadLine()); // Đọc dòng đầu để lấy số lượng Employee

                for (int i = 0; i < n; ++i)
                {
                    string line = fin.ReadLine();

                    if(line != null)
                    {
                        string[] fields = line.Split(':');

                        string fname = fields[0];
                        string minit = fields[1];
                        string lname = fields[2];
                        int ssn = int.Parse(fields[3]);
                        string bdate = fields[4];
                        string address = fields[5];
                        string gender = fields[6];
                        float salary = float.Parse(fields[7]);

                        Employee e = new Employee
                        {
                            Ssn = ssn,
                            FName = fname,
                            MInit = minit,
                            LName = lname,
                            Address = address,
                            BirthDate = bdate,
                            Salary = salary,
                            Gender = gender

                        };

                        DB.Store(e);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }
        public static void CreateProject(string fileName)
        {
            // Lấy dữ liệu Project cũ và xóa đi
            IObjectSet result = null;
            Project project = new Project(0, null, null);
            result = DB.QueryByExample(project);
            int count = result.Count;

            for (int i = 0; i < count; ++i)
            {
                DB.Delete(result[i]);
            }

            // Đọc dữ liệu từ file .txt
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open); // Mở file
                StreamReader fin = new StreamReader(fs); // Tạo biến đọc file
                int n = int.Parse(fin.ReadLine()); // Đọc dòng đầu để lấy số lượng Project 

                for (int i = 0; i < n; ++i)
                {
                    string line = fin.ReadLine();

                    if (line != null)
                    {
                        string[] fields = line.Split(',');

                        int pnumber = int.Parse(fields[0]);
                        string pname = fields[1];
                        string location = fields[2];

                        Project p = new Project
                        {
                            PNumber = pnumber,
                            PName = pname,
                            Location = location

                        };

                        DB.Store(p);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }
        public static void CreateDepartment(string fileName)
        {
            // Lấy dữ liệu Department cũ và xóa đi
            IObjectSet result = null;
            Department department = new Department(0, null, null);
            result = DB.QueryByExample(department);
            int count = result.Count;

            for (int i = 0; i < count; ++i)
            {
                DB.Delete(result[i]);
            }

            // Đọc dữ liệu từ file .txt
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open); // Mở file
                StreamReader fin = new StreamReader(fs); // Tạo biến đọc file
                int n = int.Parse(fin.ReadLine()); // Đọc dòng đầu để lấy số lượng Department 

                for (int i = 0; i < n; ++i)
                {
                    string line = fin.ReadLine();

                    if (line != null)
                    {
                        string[] fields = line.Split(':');

                        int dnumber = int.Parse(fields[0]);
                        string dname = fields[1];
                        string locations = fields[2];

                        List<string> list_Location = new List<string>();
                        string[] fields_Locations = locations.Split(',');
                        for(int j = 0; j < fields_Locations.Length; ++j)
                        {
                            list_Location.Add(fields_Locations[j]);
                        }

                        Department d = new Department
                        {
                            DNumber = dnumber,
                            DName = dname,
                            Locations = list_Location
                        };

                        DB.Store(d);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }
        public static void CreateWorksOn(string fileName)
        {
            // Lấy dữ liệu WorksOn cũ và xóa đi
            IObjectSet result = null;
            WorksOn worksOn = new WorksOn(0);
            result = DB.QueryByExample(worksOn);
            int count = result.Count;

            for (int i = 0; i < count; ++i)
            {
                DB.Delete(result[i]);
            }

            // Đọc dữ liệu từ file .txt
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open); // Mở file
                StreamReader fin = new StreamReader(fs); // Tạo biến đọc file
                int n = int.Parse(fin.ReadLine()); // Đọc dòng đầu để lấy số lượng WorksOn 

                for (int i = 0; i < n; ++i)
                {
                    string line = fin.ReadLine();

                    if (line != null)
                    {
                        string[] fields = line.Split(',');

                        int ssn_Employee = int.Parse(fields[0]);
                        int number_Project = int.Parse(fields[1]);
                        float hours = float.Parse(fields[2]);

                        WorksOn w = new WorksOn
                        {
                            Hours = hours
                        };

                        // Tìm Employee với Ssn = ssn_Employee
                        // Điều kiện: trong database phải có sẵn dữ liệu Employee thì mới tìm được
                        Employee employee = new Employee(ssn_Employee, null, null, null, null, null, 0, null);
                        IObjectSet result_Employee = DB.QueryByExample(employee);
                        if(result_Employee.Count != 0)
                        {
                            w.Employee = (Employee)result_Employee[0];
                        }

                        // Tìm Project với PNumber = number_Project
                        // Điều kiện: trong database phải có sẵn dữ liệu Project thì mới tìm được
                        Project project = new Project(number_Project, null, null);
                        IObjectSet result_Project = DB.QueryByExample(project);
                        if (result_Project.Count != 0)
                        {
                            w.Project = (Project)result_Project[0];
                        }

                        DB.Store(w);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }
        public IObjectSet result_Dependent()
        {
            Dependent d = new Dependent(null, null, null, null);
            IObjectSet result = DB.QueryByExample(d);
            return result;
        }
        public IObjectSet result_Employee()
        {
            Employee e = new Employee(0, null, null, null, null, null, 0, null);
            IObjectSet result = DB.QueryByExample(e);
            return result;
        }
        public IObjectSet result_Project()
        {
            Project p = new Project(0, null, null);
            IObjectSet result = DB.QueryByExample(p);
            return result;
        }
        public IObjectSet result_Department()
        {
            Department d = new Department(0, null, null);
            IObjectSet result = DB.QueryByExample(d);
            return result;
        }
        public IObjectSet result_WorksOn()
        {
            WorksOn w = new WorksOn(0);
            IObjectSet result = DB.QueryByExample(w);
            return result;
        }
    }
}
