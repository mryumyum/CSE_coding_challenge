using System;
using System.Collections.Generic;

namespace CSECodeSampleConsole
{
    /// <summary>
    /// INSTRUCTIONS:
    /// Using this file ONLY (you can copy to a .cs file, just send it back as a plain text file), write a C# console application demonstrating the following logic. 
    /// 1. Present a menu to the user with 3 options [View Persons, Add Person, Exit]
    /// 2. If the user selects 'View Persons', the application should show a list of persons in the application.
    /// 3. If the user selects 'Add Person', they should be instructed to enter a name. The program should assign a unique id to the new person. 
    /// 4. If a person selects 'Exit', the application should close. Otherwise, the application should stay running and/or indicate that the choice was invalid. 
    /// 5. Optional: Create a 4th feature where you can search by name and the program indicates whether or not the name is in the system. 
    /// 6. Use an in memory list to store person objects.
    /// 7. Use multiple classes and object oriented design to write your program (don't put all of your logic in the Program class).
    /// 8. Submit this file as a TEXT file in your application. 
    /// 9. Download a free trial of Visual Studio or use the free Community edition.
    /// 10. What we look for: 
    ///    - Does the program meet the requirements/instructions and is it stable?
    ///    - Is the code clean & appropriately commented? 
    ///    - Is there an understandable object oriented design?
    /// </summary>

    public class Program
    {
        private static List<Person> _People = new List<Person>();

        public static void Main(string[] args)
        {
            bool q = true;
            while (q == true) {

                Console.WriteLine("Type 1 to view person");
                Console.WriteLine("Type 2 to add person");
                Console.WriteLine("Type 3 to search person");
                Console.WriteLine("Type 4 to exit");
                Console.WriteLine(" ");

                int input;
                bool parsedSuccess = int.TryParse(Console.ReadLine(), out input);

                if (parsedSuccess == false || input < 1 || input > 4) Console.WriteLine("Please enter a number between 1 and 4\n");
                if (input == 1) ViewPerson(_People);
                if (input == 2) { Person person = new Person(Person.NewName(),Person.NewId()); _People.Add(person); }
                if (input == 3) FindPerson(_People);
                if (input == 4) q = false;
            }
        }

        public static void ViewPerson(List<Person> names)
        {
            Console.WriteLine("you chose view person \n");
            foreach (var item in names)
            {
                Console.Write("Name: ");
                Console.Write(item.Name);
                Console.Write(" Id: ");
                Console.WriteLine(item.Id + "\n");
            }
            Console.WriteLine(" ");
        }

        public static void FindPerson(List<Person> names)
        {
            Console.WriteLine("Insert the name of the person you wish to find: ");
            string result = Console.ReadLine();
            foreach (var item in names)
            {
                if(result == item.Name)
                {
                    Console.Write("Name: ");
                    Console.Write(item.Name);
                    Console.Write(" Id: ");
                    Console.WriteLine(item.Id + "\n");
                }

                if (result != item.Name) Console.WriteLine("Person not found :(, Person either doesnt exist or try all lower case!");
            }

        }
    }



    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Person(string Name, int Id)
        {
            this.Name = Name;
            this.Id = Id;
        }

        public static string NewName()
        {
            // Reads in name from user input and returns Name
            Console.WriteLine("you chose new person \n");
            Console.Write("Person's name?: ");
            string Name = Console.ReadLine();
            Console.WriteLine("\n");
            return Name;
        }

        public static int NewId()
        {
            // Creates an initial ID from DateTime, adds the first and last 3 characters, converts from hex to int, and returns id
            string initialId = DateTime.Now.Ticks.ToString("x");
            string hexId = initialId.Substring(0, 3) + initialId.Substring(initialId.Length - 3);
            int Id = Int32.Parse(hexId, System.Globalization.NumberStyles.HexNumber);
            return Id;
        }
    }
}
