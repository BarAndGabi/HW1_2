using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_2
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Grades { get; set; }

        public Student(int id, string name, List<int> grades)
        {
            Id = id;
            Name = name;
            Grades = grades;
        }
        public override string ToString()
        {
            string gradesString = string.Join(", ", Grades);
            return $"Id: {Id}, Name: {Name}, Grades: {gradesString}";
        }


    }
}
