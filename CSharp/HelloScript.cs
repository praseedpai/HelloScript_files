//
//  HelloScript.cs
//  HelloScript for C#
//
//  Created by Peter on 02/05/2020.
//  Copyright © 2020 Peter. MIT License.
//
// Create console app : dotnet new console
// Compile            : dotnet build
// Execute            : dotnet run
//

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HelloScript
{
    class HelloScript
    {
        static void Main(string[] args)
        {
            /* A Simple Console Output */
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Hello!");
            Console.WriteLine("----------------------------------");


            /*
             * Insert the value of an object, variable, or expression
             * into another string using string formatting.
             */
            Console.WriteLine(String.Format("String formatting {0} with {1}", 101, "C#"));
            Console.WriteLine("----------------------------------");


            /* Format a string using string interpolation */
            Console.WriteLine($"String Interpolation example {101}, with C#{8}");
            Console.WriteLine("----------------------------------");


            /* If,else condition */
            int year = 2020;
            if (year > 2009)
                Console.WriteLine("You are in india and you have already enrolled for engineering. Game Over!");
            else if (year < 2008)
                Console.WriteLine("Stay away from ready made custom advices please!");
            else
                Console.WriteLine("Anything wrong with your time machine? You have not gone anywhere, kiddo.");
            Console.WriteLine("----------------------------------");


            /* Range based for loop */
            foreach (int idx in Enumerable.Range( 1, 3 )) {
                Console.WriteLine(idx);
            }
            Console.WriteLine("----------------------------------");


            /* copying range value to a variable */
            List<int> intList = new List<int>();
            Enumerable.Range( 4, 8 ).ToList().ForEach( n => intList.Add(n));
            intList.ToList().ForEach(n => Console.WriteLine(n));
            Console.WriteLine("----------------------------------");


            /* Array demo */
            /* Numerical Array, While */
            string[] rules = { "Do no harm", "Obey", "Continue Living" };
            int index = 0;
            while (index < rules.Length) {
                Console.WriteLine("Rule " + (index + 1).ToString() + " : " + rules[index]);
                ++index;
                Console.WriteLine("");
            }
            Console.WriteLine("----------------------------------");


            /* Associated array, foreach */
            Dictionary<string, string> dictionary = new Dictionary<string, string>();  
            dictionary.Add("hello", "world"); 
            dictionary.Add("foo", "bar"); 
            dictionary.Add("lorem", "ipsum"); 

            foreach(KeyValuePair<string, string> element in dictionary) 
            { 
                Console.WriteLine($"{element.Key} : {element.Value}"); 
            }
            Console.WriteLine("----------------------------------");


            /*
             * Example of a Nested Loop To calculate pythagorean Triplets
             */
            Console.WriteLine("Nested Loop:");
            int limit = 20;
            for (int i = 1; i <= limit; ++i)
            {
                for (int j = i; j <= limit; ++j)
                {
                    for (int k = 1; k <= limit; k++)
                    {
                        if ((i*i)+(j*j) == k*k && k <= limit)
                        {
                            Console.WriteLine($"a = {i}, b = {j}, c = {k}");
                        }
                    }
                }
            }
            Console.WriteLine("----------------------------------");


            /* Iterating over a List using range and len */
            int[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13, 21 };
            Enumerable.Range(0, fibonacci.Length).ToList().ForEach( n => 
                Console.Write(fibonacci[n] + " ")
            );
            Console.WriteLine("\n----------------------------------");


            /* Split a string using delimiters */
            string sampleStr = "This - is, C#, split. using - delimiters.";
            Console.WriteLine($"Splitting string \"{sampleStr}\" into tokens:");

            string[] spearator = { " ", ",", ".", "-" };

                    // using the method 
            string[] strlist = sampleStr.Split(spearator, 7, StringSplitOptions.RemoveEmptyEntries); 
            foreach(string s in strlist) 
            { 
                Console.WriteLine(s); 
            }
            Console.WriteLine("----------------------------------");


            // A single argument Lambda expression
            Func<string, string> hello = x => "Hello, " + x;
            Console.WriteLine(hello("Peter"));
            Console.WriteLine("----------------------------------");

            /* Create the object and invoke a method */
            var movie = new Movie("New Country for Old Men", new List<double>(){8.6, 7, 8.1});
            movie.printMovieDetails();
            Console.WriteLine("----------------------------------");


            /* Instantiate a Pet object and invoke associated methods */
            var polly = new Pet("Polly", "Parrot");
            Console.WriteLine(polly.getName());
            Console.WriteLine(polly.getSpecies());
            Console.WriteLine(polly.toString());
            Console.WriteLine("----------------------------------");

            /*----------invocations-------------*/
            Dog fido    = new Dog("Fido", true);
            Dog rover   = new Dog("Rover", false);
            Cat mittens = new Cat("Mittens", true);
            Cat fluffy  = new Cat("Fluffy", false);

            Console.WriteLine($"{fido.getName()} chases cats: {fido.chasesCats()}");
            Console.WriteLine($"{rover.getName()} chases cats: {rover.chasesCats()}");
            Console.WriteLine($"{mittens.getName()} hates dogs: {mittens.hatesDogs()}");
            Console.WriteLine($"{fluffy.getName()} hates dogs: {fluffy.hatesDogs()}");
            Console.WriteLine("----------------------------------");

            /* List comprehension examples */
            List<int> listExample = new List<int>();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
                listExample.Add(x)
            );
            foreach(var item in listExample) {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------");

            var celsius = new List<double>() {39.2f, 36.5f, 37.3f, 37.8f};
            // Linq extension method syntax
            var degree  = celsius.Select(x => 9 / 5 * x + 32);
            foreach(var item in degree) {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------");


            /*
             * Map-filter-reduce
             * using linq query syntax
             */
            var foo = new List<int>() {2, 18, 9, 22, 17, 24, 8, 12, 27};
            var filter = from item in foo
                         where item%3 == 0
                         select item;
            
            Console.WriteLine("Filtered items:");
            foreach(var item in filter) {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------");

            var map = from item in foo
                      select item * 2 + 10;

            Console.WriteLine("Transformed items:");
            foreach(var item in map) {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------------");
            // Extension method syntax
            var reduction = foo.Select(x=> x*2).Sum();
            Console.WriteLine($"Sum of items: {reduction}");
            Console.WriteLine("----------------------------------");


            /*
             * Deep Copy vs Shallow Copy
             */
             // Shallow copy
            var cinnamon = new Pet("Cinnamon", "Dog");
            Pet ginger   = cinnamon;
            ginger.name = "Ginger";
            Console.WriteLine("(Shallow copy)");
            Console.WriteLine("Details of Cinnamon:");
            Console.WriteLine(cinnamon.toString());
            Console.WriteLine("Details of Ginger:");
            Console.WriteLine(ginger.toString());
            Console.WriteLine();

            // Deep copy
            var julie = new Pet("Julie", "Cat");
            Pet june  = new Pet(julie.name, julie.species);
            june.name = "June";
            june.species = "Rabbit";
            Console.WriteLine("(Deep copy)");
            Console.WriteLine("Details of Julie:");
            Console.WriteLine(julie.toString());
            Console.WriteLine("Details of June:");
            Console.WriteLine(june.toString());
            Console.WriteLine("----------------------------------");


            /*
             * Create new directories in the workspace.
             * Create and write to a new file or append to an existing one.
             */
            var path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "myDir");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, "annualreview.txt");

            var lines = new List<string>() { "1st line", "2nd line", "", "your happy place", "bla bla bla..." };

            if (!File.Exists(path))
            {
                using FileStream fs = File.Create(path);
                using var sr = new StreamWriter(fs);
                foreach(var line in lines) {
                    sr.WriteLine(line);
                }
            }
            else {
                Console.WriteLine($"File \"{path}\" already exists");
            }

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("----------------------------------");


            /*
             * Regex:
             *
             * ((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})
             *
             * Explanation:
             *
             * (            # Start of group
             * (?=.*\d)     # must contains one digit from 0-9
             * (?=.*[a-z])  # must contains one lowercase characters
             * (?=.*[A-Z])  # must contains one uppercase characters
             * (?=.*[@#$%]) # must contains one special symbols in the list "@#$%"
             * .            # match anything with previous condition checking
             * {6,20}       # length at least 6 characters and maximum of 20
             * )            # End of group
             */
            string input;
            Console.WriteLine("Password:");
            input = Console.ReadLine();

            var hasNumber         = new Regex(@"[0-9]+");
            var hasUpperChar      = new Regex(@"[A-Z]+");
            var hasLowerChar      = new Regex(@"[a-z]+");
            var hasSymbols        = new Regex(@"[@!?$%-+]+");
            // To check the length, regex probably is a wrong tool,
            // simple string length check would be more performant.
            //var hasNumberChars    = new Regex(@"^.{6,20}$");
            var isValidated = hasNumber.IsMatch(input) && 
                              hasUpperChar.IsMatch(input) &&
                              hasSymbols.IsMatch(input) &&
                              //hasNumberChars.IsMatch(input) &&
                              input.Length >= 6 && input.Length <=20;

            Console.WriteLine(isValidated ? "That's a valid Password!" : "Invalid password! Try again . . .");
            Console.WriteLine("----------------------------------");
        }

        /*
         * A simple class One for the OOP fanboys - Class, members,
         * object and stuff.
         */
        class Movie {
            String name = "";
            List<double> userRatings;
            double rating = 0;

            public Movie(string name, List<double> ratings) {
                this.name = name;
                this.userRatings = ratings;
                this.rateMovie();
            }

            public void printMovieDetails() {
                Console.WriteLine($"Movie  : {this.name}");
                Console.WriteLine($"Rating : {this.rating}({this.userRatings.Count})");
            }

            private void rateMovie() {
                this.rating = this.userRatings.Average();
            }
        }

        /*
         * (OOPS) Inheritance, polymorphism etc..
         * in C# explained
         */
        class Pet {
            public string name = "";
            public string species = "";

            public Pet(string name, string species) {
                this.name = name;
                this.species = species;
            }

            public string getName() {
                return this.name;
            }

            public string getSpecies() {
                return this.species;
            }

            public string toString() {
                return name + " " + species;
            }
        }

        /* A Dog class inherited from Pet */
        class Dog : Pet {
            bool chases_cats = false;

            public Dog(string name, bool chases_cats) : 
                base(name, "Dog") {
                this.chases_cats = chases_cats;
            }

            public bool chasesCats() {
                return this.chases_cats;
            }
        }

        /* A Cat class inherited from Pet */
        class Cat : Pet {
            bool hates_dogs = false;

            public Cat(string name, bool hates_dogs) :
                base(name, "Cat") {
                this.hates_dogs = hates_dogs;
            }

            public bool hatesDogs() {
                return this.hates_dogs;
            }
        }

    }
}
