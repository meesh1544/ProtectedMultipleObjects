using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Transactions;

namespace Inheritance
{
    //Base Class
    class Players
    {
        protected int _Id;
        protected string _FirstName;
        protected string _LastName;
        protected int _Age;

        // default constructor
        public Players()
        {
            _Id = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Age = 0;
        }
        //parameterized constructor
        public Players(int id, string firstName, string lastName, int age)
        {
            _Id = id;
            _FirstName = firstName;
            _LastName = lastName;
            _Age = age;
        }
        // Get and Set Methods
        public int getID() { return _Id; }
        public string getFirstName() { return _FirstName; }
        public string getLastName() { return _LastName; }
        public int getAge() { return _Age; }
        public void setID(int id) { _Id = id; }
        public void setFirstName(string firstName) { _FirstName = firstName; }
        public void setLastName(string lastName) { _LastName = lastName; }
        public void setAge(int age) { _Age = age; }

        public virtual void addChange()
        {
            Console.Write("ID=");
            setID(int.Parse(Console.ReadLine()));
            Console.Write("First Name=");
            setFirstName(Console.ReadLine());
            Console.Write("Last Name=");
            setLastName(Console.ReadLine());
            Console.Write("Age=");
            setAge(int.Parse(Console.ReadLine()));
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"      ID: {getID()}");
            Console.WriteLine($"    Name: {getFirstName()} {getLastName()}");
            Console.WriteLine($"     Age: {getAge()}");
        }
    }
    class Coach : Players
    {
        protected double _Score;
        protected string _Coach;

        public Coach()
            : base()
        {
            _Coach = string.Empty;
            _Score = 0;
        }
        public Coach(int id, string firstname, string lastname, int age, double score, string coach)
            : base(id, firstname, lastname, age)
        {
            _Score = score;
            _Coach = coach;
        }
        public void setScore(double score) { _Score = score; }
        public void setCoach(string coach) { _Coach = coach; }
        public double getScore() { return _Score; }
        public string getCoach() { return _Coach; }
        public override void addChange()
        {
            base.addChange();
            Console.Write("Score=");
            setScore(double.Parse(Console.ReadLine()));
            Console.Write("Coach=");
            setCoach(Console.ReadLine());
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($"  Score: {getScore()}");
            Console.WriteLine($"Coach: {getCoach()}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many player do you want to enter?");
            int maxPla;
            while (!int.TryParse(Console.ReadLine(), out maxPla))
                Console.WriteLine("Please enter a whole number");
            // array of Employee objects
            Players[] pla = new Players[maxPla];
            Console.WriteLine("How many Coaches do you want to enter?");
            int maxCo;
            while (!int.TryParse(Console.ReadLine(), out maxCo))
                Console.WriteLine("Please enter a whole number");
            // array of Manager objects
            Coach[] co = new Coach[maxCo];

            int choice, rec, type;
            int PlaCounter = 0, coCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Coach or 2 for Players");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Coach or 2 for Players");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1)
                            {
                                if (coCounter <= maxCo)
                                {
                                    co[coCounter] = new Coach();  // places an object in the array instead of null
                                    co[coCounter].addChange();
                                    coCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of coaches has been added");

                            }
                            else
                            {
                                if (PlaCounter <= maxPla)
                                {
                                    pla[PlaCounter] = new Players(); // places an object in the array instead of null
                                    pla[PlaCounter].addChange();
                                    PlaCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of players have been added");
                            }

                            break;
                        case 2:
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;
                            if (type == 1)
                            {
                                while (rec > coCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                co[coCounter].addChange();
                            }
                            else
                            {
                                while (rec > PlaCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                pla[PlaCounter].addChange();
                            }
                            break;
                        case 3: // Print All
                            if (type == 1)
                            {
                                for (int i = 0; i < coCounter; i++)
                                    co[PlaCounter].print();
                            }
                            else // players
                            {
                                for (int i = 0; i < PlaCounter; i++)
                                    pla[PlaCounter].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }


        protected static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}

