using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public class WorksOn
    {
        // Thuộc tính
        public float Hours { get; set; }

        // Quan hệ
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
