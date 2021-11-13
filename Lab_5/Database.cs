using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    // Thêm ghi chú ở đây
    public class Database
    {
        public static string DbFileName { get; set; }
        public static IObjectContainer DB;
        public void CloseDatabase()
        {
            DB.Close();
        }
        public Database()
        {
            DbFileName = "database.yap";
        }
        public void CreateDatabase()
        {
            DB = Db4oEmbedded.OpenFile(DbFileName);
            CreateDependents("data_Dependent.txt");
            CreateEmployee("data_Employee.txt");
            CreateProject("data_Project.txt");
        }
        public static void CreateDependents(string fileName)
        {
            IObjectSet result = null;
            Dependent dependent = new Dependent(null, null, null, null);
            result = DB.QueryByExample(dependent);
            int count = result.Count;

            for(int i = 0; i < count; ++i)
            {
                DB.Delete(result[i]);
            }

            if(File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int n = int.Parse(fin.ReadLine());

                for(int i = 0; i < n; ++i)
                {
                    string line = fin.ReadLine();
                    if(line != null)
                    {
                        string[] fields = line.Split(',');
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

                        DB.Store(d);
                    }
                }
                fin.Close();
                fs.Close();
            }
        }
        public static void CreateEmployee(string fileName)
        {
            IObjectSet result = null;
            Employee employee = new Employee(0, null, null, null, null, null, 0, null);
            result = DB.QueryByExample(employee);
            int count = result.Count;

            for(int i = 0; i < count; ++i)
            {
                DB.Delete(result[i]);
            }

            if(File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int n = int.Parse(fin.ReadLine());

                for(int i = 0; i < n; ++i)
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
            IObjectSet result = null;
            Project project = new Project(0, null, null);
            result = DB.QueryByExample(project);
            int count = result.Count;

            for (int i = 0; i < count; ++i)
            {
                DB.Delete(result[i]);
            }

            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int n = int.Parse(fin.ReadLine());

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
    }
}
