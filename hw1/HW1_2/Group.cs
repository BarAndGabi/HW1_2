using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_2
{
    public class Group
    {
        public int? number { get; set; }
        public string? name { get; set; }
        public List<Student> students { get; set; }

        //tostring function 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Group Number: {number}");
            sb.AppendLine($"Group Name: {name}");
            sb.AppendLine("Students:");
            foreach (Student student in students)
            {
                sb.AppendLine(student.ToString());
            }
            return sb.ToString();
        }


    }
}
