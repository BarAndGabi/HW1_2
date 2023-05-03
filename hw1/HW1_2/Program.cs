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

            List<Group> groups = mat.Select((row, i) => new Group
            {
                number = i + 1,
                name = $"Group g{i + 1}",
                students = row.ToList()
            }).ToList();


            print(groups);
            getSelection(mat, groups);
        }
        public static void sort(Student[][] mat)
        {
            foreach (Student[] row in mat)
            {
                Array.Sort(row, (s1, s2) => s1.Grades.Count.CompareTo(s2.Grades.Count));
            }
        }

        public static void print(Student[][] mat)
        {
            foreach (var studentArray in mat)
            {
                Console.WriteLine(string.Join("\n", studentArray.Select(student => student.ToString())));
                Console.WriteLine("---------------");
            }
        }

        //generic print method for list using  IEnumerator
        public static void print<T>(List<T> list)
        {
            IEnumerator<T> enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        //function to print menu
        public static void printMenu()
        {
            Console.WriteLine("1 - Matrix after sorting:");
            Console.WriteLine("2 - All groups in list of groups:");
            Console.WriteLine("3 - The group with the higher number of students who has no grades at all:");
            Console.WriteLine("4 - All Student order by id without duplications :");
            Console.WriteLine("5 - The Student with the higher number of grades above 100 :");
            Console.WriteLine("6 - How many insensetive different student's by names:");
            Console.WriteLine("7 - How many grades for each Student by name insensitive:");
            Console.WriteLine("8. To Exit");
        }

        //function that get selection item from user and switch to the right function
        public static void getSelection(Student[][] mat, List<Group> groups)
        {
            int selection = 0;
            while (selection != 9)
            {
                printMenu();
                selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        sort(mat);
                        print(mat);
                        break;
                    case 2:
                        print(groups);
                        break;
                    case 3:
                        printGroupWithMostStudentsWithoutGrades(groups);
                        break;
                    case 4:
                        printAllStudentsNoDup(mat);
                        break;
                    case 5:
                        printStudentWithMostGradesAbove100(mat);
                        break;
                    case 6:
                        printNumberOfDifferentStudents(mat);
                        break;
                    case 7:
                        printNumberOfGradesForEachStudent(mat);
                        break;
                    case 8:
                        Console.WriteLine("Bye Bye");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong selection");
                        break;
                }
            }
        }
        //print Group With Most Students Without Grades within a group list

        public static void printGroupWithMostStudentsWithoutGrades(List<Group> groups)
        {
            int max = 0;
            int maxIndex = 0;
            for (int i = 0; i < groups.Count; i++)
            {
                int count = 0;
                foreach (var student in groups[i].students)
                {
                    if (student.Grades.Count == 0)
                    {
                        count++;
                    }
                }
                if (count > max)
                {
                    max = count;
                    maxIndex = i;
                }
            }
            Console.WriteLine($"Group number: {groups[maxIndex].number}, Group name: {groups[maxIndex].name}");
            Console.WriteLine("Students:");
            foreach (var student in groups[maxIndex].students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Grades: {string.Join(",", student.Grades)}");
            }
            Console.WriteLine();
        }
        //print All Students no duplicate ,the print should be order by id
        //duplicate is when the name is same no case sensitive and grades are same
        public static void printAllStudentsNoDup(Student[][] mat)
        {
            List<Student> students = new List<Student>();
            foreach (var studentArray in mat)
            {
                foreach (var student in studentArray)
                {
                    if (!students.Any(s => s.Name.ToLower() == student.Name.ToLower() && mySequenceEqual(s.Grades, student.Grades)))
                    {
                        students.Add(student);
                    }
                }
            }
            students.Sort((s1, s2) => s1.Id.CompareTo(s2.Id));
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Grades: {string.Join(",", student.Grades)}");
            }
        }
        public static bool mySequenceEqual<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first == null || second == null)
            {
                return first == null && second == null;
            }

            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (firstEnumerator.MoveNext())
            {
                if (!secondEnumerator.MoveNext() || !Equals(firstEnumerator.Current, secondEnumerator.Current))
                {
                    return false;
                }
            }

            return !secondEnumerator.MoveNext();
        }


        //print Student With Most Grades Above 100
        public static void printStudentWithMostGradesAbove100(Student[][] mat)
        {
            List<Student> students = new List<Student>();
            foreach (var studentArray in mat)
            {
                students.AddRange(studentArray);
            }
            students.Sort((s1, s2) => s1.Grades.Count.CompareTo(s2.Grades.Count));
            int max = 0;
            int maxIndex = 0;
            for (int i = 0; i < students.Count; i++)
            {
                int count = 0;
                foreach (var grade in students[i].Grades)
                {
                    if (grade > 100)
                    {
                        count++;
                    }
                }
                if (count > max)
                {
                    max = count;
                    maxIndex = i;
                }
            }
            Console.WriteLine($"Id: {students[maxIndex].Id}, Name: {students[maxIndex].Name}, Grades: {string.Join(",", students[maxIndex].Grades)}");
        }
        //print Number Of Different keys in hashset of students name no case sensitive
        public static void printNumberOfDifferentStudents(Student[][] mat)
        {
            HashSet<string> students = new HashSet<string>();
            foreach (var studentArray in mat)
            {
                foreach (var student in studentArray)
                {
                    students.Add(student.Name.ToLower());
                }
            }
            Console.WriteLine(students.Count);
        }
        //create Dictionary of students name no case sensitive and as value the count the number of student with the same name
        //TO DO
        public static void printNumberOfGradesForEachStudent(Student[][] mat)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();
            foreach (var studentArray in mat)
            {
                foreach (var student in studentArray)
                {
                    if (students.ContainsKey(student.Name.ToLower()))
                    {
                        students[student.Name.ToLower()] += student.Grades.Count;
                    }
                    else
                    {
                        students.Add(student.Name.ToLower(), student.Grades.Count);
                    }
                }
            }
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} : {student.Value}");
            }

        }







    }
}