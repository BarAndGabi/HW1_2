namespace HW1_2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Student[][] mat = new Student[][]
 {
  new Student[]{
      new Student(1, "Avi", new List<int>{1, 2, 3}),
      new Student(2, "Tami", new List<int>{101, 102, 103}),
      new Student(3, "aVI", new List<int>{}),
      new Student(4, "AVI", new List<int>{101, 200, 300, 400})},
  new Student[]{
      new Student(5, "tAMI", new List<int>{91, 92, 93}),
      new Student(6, "TAMI", new List<int>{100, 2, 13}),
      new Student(7, "aVI", new List<int>{200}),
      new Student(8, "Dani", new List<int>{10, 20, 300, 40, 60}),
      new Student(9, "danI", new List<int>{11, 12, 13})},
  new Student[]{
      new Student(10, "Tal", new List<int>{}),
      new Student(11, "Dani", new List<int>{}),
      new Student(12, "Tal Cohen", new List<int>{11, 12, 13}),
      new Student(13, "Avi Rabinovitz", new List<int>{200, 103}),
      new Student(14, "avi rabinovitz", new List<int>{200, 103}),
      new Student(15, "AVI Rabinovitz", new List<int>{200, 103}),
      new Student(16, "Dani", new List<int>{10, 20, 300, 40, 60}),
      new Student(17, "tal Cohen", new List<int>{11, 12, 13})}

        };
            Console.WriteLine("before\n");
            Print(mat);
            Sort(mat);
            Console.WriteLine("sorted\n");
            Print(mat);
            List<Group> groups = new List<Group>();
            int i = 0;
            foreach (Student[] row in mat)
            {
                Group group = new Group
                {
                    number = row[0].Id,
                    name = $"Group g{i + 1}",
                    students = row.ToList()
                };
                groups.Add(group);
                i++;
            }
            PrintGroups(groups);
        }
        public static void Sort(Student[][] mat)
        {
            foreach (Student[] row in mat)
            {
                Array.Sort(row, (s1, s2) => s1.Grades.Count.CompareTo(s2.Grades.Count));
            }
        }
        public static void Print<T>(IEnumerable<T> groups) where T : Group
        {
            foreach (var group in groups)
            {
                Console.WriteLine($"Group number: {group.Number}, Name: {group.Name}");
                Console.WriteLine("Students:");
                var enumerator = group.Students.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Console.WriteLine($"\t{enumerator.Current.Id}\t{enumerator.Current.Name}");
                }
            }
        }


        public static void PrintGroups(List<Group> groups)
        {
            foreach (var group in groups)
            {
                Console.WriteLine($"Group number: {group.number}, Group name: {group.name}");
                Console.WriteLine("Students:");
                foreach (var student in group.students)
                {
                    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Grades: {string.Join(",", student.Grades)}");
                }
                Console.WriteLine();
            }
        }



    }
}