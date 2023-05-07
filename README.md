## HW1

# C# Console Application for Managing Student Groups and Grades

This C# console application provides various functionalities for managing student groups and their grades. 
It uses the **Student** and **Group** classes to store and manipulate the data.

## Project Classes

### Program Class
The **Program** class is the entry point for the console application.
 It contains a **Main** method which is responsible for executing the application and displaying the menu to the user.

### Student Class
The Student class represents a single student with their ID, name, and a list of grades. 
It contains a constructor to initialize the properties and an overridden ToString method to display the details of a student.

### Group Class
The Group class represents a group of students with a group number, group name, and a list of students.
 It also contains an overridden ToString method to display the details of a group.

## Main Method
The **Main** method initializes a list of groups with sample data and displays a menu to the user with the following options:

**Matrix after sorting**: Prints the matrix of all students and their grades sorted in ascending order of their names.<br>
**All groups in list of groups**: Prints the details of all the groups and their students.<br>
**The group with the higher number of students who has no grades at all**: Prints the group details with the highest number of students who have no grades.<br>
**All Student order by id without duplications**: Prints the details of all the students ordered by their ID without any duplicates.<br>
**The Student with the higher number of grades above 100**: Prints the details of the student with the highest number of grades above 100.<br>
**How many insensitive different student's by names**: Prints the number of students with unique names (case-insensitive).<br>
**How many grades for each Student by name insensitive**: Prints the number of grades for each student (case-insensitive).<br>
**To Exit**: Exits the application.<br>
The user can select any option by entering the corresponding number. Once an option is selected, the program performs the corresponding functionality and displays the result to the user.


## How to Run the Application

To run the application, open the solution in Visual Studio and run the program. The console application will display the menu options, and the user can select any option to perform the corresponding functionality.
