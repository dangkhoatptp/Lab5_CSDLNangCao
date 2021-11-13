using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public class Dependent
    {
        // Thuộc tính
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Relationship { get; set; }

        public Dependent (string name = "", string gender = "", string birthdate = "", string relationship = "")
        {
            Name = name;
            Gender = gender;
            BirthDate = birthdate;
            Relationship = relationship;
        }

        // Quan hệ
        public Employee DependentOf { get; set; }
    }
}
