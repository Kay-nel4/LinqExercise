using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"The sum of the List of numbers is {numbers.Sum()}");
            Console.WriteLine("----");
            //TODO: Print the Average of numbers
            Console.WriteLine($"The Average of the List of numbers is {numbers.Average()}");
            //TODO: Order numbers in ascending order and print to the console
            
            Console.WriteLine("----");
            Console.WriteLine("Numbers Ascending");
            var orderOfNumbers = numbers.OrderBy(numbers => numbers);
            foreach (var number in orderOfNumbers)
            {
                Console.WriteLine(number);
            }
            //TODO: Order numbers in descending order and print to the console
            
            Console.WriteLine("----");
            Console.WriteLine("Numbers Descending");
            var numbersOrder = numbers.OrderByDescending(numbers => numbers);
            foreach (var number in numbersOrder)
            {
                Console.WriteLine(number);
            }
            
            //TODO: Print to the console only the numbers greater than 6
            
            Console.WriteLine("----");
            Console.WriteLine("Numbers Greater Than 6");
            var numbersGreaterThanSix= numbers.Where(number => number > 6).ToList();
            numbersGreaterThanSix.ForEach(numbersGreaterThanSix => Console.WriteLine(numbersGreaterThanSix));
            
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            
            Console.WriteLine("----");
            Console.WriteLine("Four Printed Descending Numbers");
            var topNumbers = numbers.OrderByDescending(number => number).Take(4);
            foreach (var num in topNumbers)
            {
                Console.WriteLine(num);
            }
            
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            
            Console.WriteLine("----");
            Console.WriteLine("Numbers Descending with age added");
            numbers[4] = 35;
            var numbersDescending = numbers.OrderByDescending(number => number);
            foreach (var number in numbersDescending)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("----");
            Console.WriteLine("Age at index 4 done another way.");
            numbers.Select((number, index) => index == 4 ? 36 : number).OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine (x));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Next Section.");
            Console.ResetColor();
            
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();
            //employees.ForEach(employees => Console.WriteLine(employees));
            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("----");
            Console.WriteLine("C or S Employees Ascending");
            var filteringEmployees = employees.Where(x => x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S")).OrderBy(x => x.FirstName);
            foreach (var person in filteringEmployees)
            {
                Console.WriteLine(person.FullName);
            }

            /*var employeeProperty = employees.Where(x => x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S"));employees.Select(x => x.FirstName);
            foreach (var employee in employeeProperty)
            {
                Console.WriteLine();
            }*/
            
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("----");
            Console.WriteLine("Employees Over 26");

            var employeesOver26 = employees.Where(n => n.Age > 26).OrderBy(n => n.Age).ThenBy(n => n.FirstName);
            foreach (var person in employeesOver26)
            {
                Console.WriteLine($"Name: {person.FullName} Age: {person.Age}");
            }
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("----");
            Console.WriteLine("Employees YOE and Age");

            var sumOfSpecialFilters = employees.Where(n => n.YearsOfExperience <= 10 & n.Age > 35);
            foreach (var person in sumOfSpecialFilters)
            {
                Console.WriteLine(person.FullName);
            }
            Console.WriteLine("Now the Sum");
            Console.WriteLine($"Years of Experence: {sumOfSpecialFilters.Sum(n => n.YearsOfExperience)}");
            
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            
            Console.WriteLine("Now the Average");
            Console.WriteLine($"Average Years of Experience: {sumOfSpecialFilters.Average(n => n.YearsOfExperience)}");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee ("Kay", "Nell", 35, 1 )).ToList();
            Console.WriteLine("----");
            Console.WriteLine("List of Employees");
            employees.ForEach(n => Console.WriteLine(n.FullName));

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
