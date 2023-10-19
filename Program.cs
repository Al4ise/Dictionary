// Dictionary Challenges:
    //a. Create a dictionary to store student grades. Implement functions to add a new student, remove a student, and calculate the average grade.

    //b. Given two dictionaries representing courses and their respective credit hours, create a new dictionary that calculates the total credit hours for each student.

    //c. Write a program to find and display the duplicate elements in a dictionary.


using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;



var dict = new Dictionary<string, double>();
// print dict
foreach (var item in dict)
{
    Console.WriteLine(item);
}

    //b. Given two dictionaries representing courses and their respective credit hours, create a new dictionary that calculates the total credit hours for each student.

var courses = new Dictionary<string, int>();
courses.Add("Math", 3);
courses.Add("English", 4);
courses.Add("Science", 3);
courses.Add("History", 3);
courses.Add("Art", 2);

var courseMembers = new Dictionary<string, string[]>();
courseMembers.Add("Math", new string[] {"John"});
courseMembers.Add("English", new string[] {"John", "Mary", "Peter"});
courseMembers.Add("Science", new string[] {"Peter"});
courseMembers.Add("History", new string[] {"Mary"});
courseMembers.Add("Art", new string[] {"Mary", "Peter"});


// menu to add, remove and calculate average grade
int choice;
string name;
double grade;

bool status = true;
while (status)
{
    printMenu();
    choice = Convert.ToInt32(Console.ReadLine());
    var totalCreditHours = new Dictionary<string, int>();
    switch (choice){
        case 1:
            Console.Write("Enter student name: ");
            name = Console.ReadLine();
            Console.Write("Enter student grade: ");
            grade = Convert.ToDouble(Console.ReadLine());
            addStudent(name, grade);
            break;

        case 2:
            Console.Write("Enter student name: ");
            name = Console.ReadLine();
            removeStudent(name);
            break;
        case 3:
            Console.WriteLine("Average grade is " + averageGrade());
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            break;
        case 4:
            printStudents();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            break;
        case 5:
            //total credit hours for each student
            foreach (KeyValuePair<string, string[]> pair in courseMembers)
            {
                foreach (var student in pair.Value)
                {
                    if (totalCreditHours.ContainsKey(student))
                    {
                        totalCreditHours[student] += courses[pair.Key];
                    }
                    else
                    {
                        totalCreditHours.Add(student, courses[pair.Key]);
                    }
                }
            }
            foreach (KeyValuePair<string, int> pair in totalCreditHours)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            break;

        case 6:
                //c. Write a program to find and display the duplicate elements in a dictionary.
                var duplicates = new Dictionary<double, List<string>>();

                foreach (KeyValuePair<string, double> pair in dict)
                {
                    if (duplicates.ContainsKey(pair.Value))
                    {
                        duplicates[pair.Value].Add(pair.Key);
                    }
                    else
                    {
                        duplicates.Add(pair.Value, new List<string> { pair.Key });
                    }
                }

                foreach (KeyValuePair<double, List<string>> pair in duplicates)
                {
                    if (pair.Value.Count > 1)
                    {
                        Console.WriteLine("People with grade {0}: ", pair.Key);
                        for (int i = 0; i < pair.Value.Count-1; i++)
                        {
                            Console.Write(pair.Value[i] + ", ");
                        }
                        Console.Write(pair.Value[pair.Value.Count-1]+ "\n");
                    }
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                break;

        case 7:
            Console.WriteLine("Exiting");
            status=false;
            break;
    }
    //clear console
    Console.Clear();
}



void addStudent(string name, double grade)
{
    dict.Add(name, grade);
}

void removeStudent(string name)
{
    dict.Remove(name);
}

double averageGrade(){
    double sum = 0;
    foreach (KeyValuePair<string, double> pair in dict)
    {
        sum += pair.Value;
    }
    double average = sum / dict.Count;
    return average;
}

void printMenu(){
    Console.WriteLine("Menu");
    Console.WriteLine("[1] Add Student");
    Console.WriteLine("[2] Remove Student");
    Console.WriteLine("[3] Print Average Grade");
    Console.WriteLine("[4] Print Students");
    Console.WriteLine("[5] Total Credit Hours");
    Console.WriteLine("[6] Print Duplicate Grades");
    Console.WriteLine("[7] Exit");
    Console.Write("Enter your choice: ");
}

void printStudents(){
    foreach (KeyValuePair<string, double> pair in dict)
    {
        Console.WriteLine(pair.Key + " " + pair.Value);
    }
}