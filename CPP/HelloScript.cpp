//
//  HelloScript.cpp
//  HelloScript for C++
//
//  Created by Peter on 18/04/20.
//  Copyright © 2020 Peter. MIT License.
//
// Compile : g++ -std=c++17 HelloScript.cpp -o hello.o
// Execute : ./hello.o
//

#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <map>
#include <array>
#include <memory>
#include <numeric>
#include <list>
#include <math.h>
#include <tuple>
#include <filesystem>
#include <fstream>
#include <cstdio>
#include <regex>


/*
 * Using std definition namespace, NOT ideal to use
 * in header files can unexpectedly change the meaning
 * of code in any other files that include that header.
 */
using namespace std;
namespace fs = std::filesystem;


int main(int argc, const char * argv[])
{
    cout << "-------------------------------------\n";
    /* A Simple Console Output */
    cout << "Hello, World!\n";
    cout << "-------------------------------------\n";
    
    
    /*
     * Demonstrates formatted output, %d placeholder for decimal,
     * %s-->string, %f-->float, "/n"-->next line
     */
    printf("Formatting %s is easy %d %f\n", "with C++", 10, 98.6);
    cout << "-------------------------------------\n";
    
    
    /* Demonstrates string formatting using ostream operator{<<} */
    stringstream stream;
    stream << "Fommatting " << "with C++xx " << "streams is easier. " << 11 << " " << 98.5 << endl;
    cout << stream.str();
    cout << "-------------------------------------\n";
    
    /* If,else condition */
    int year = 2020;
    if (year > 2009)
        cout << "You are in india and you have already enrolled for engineering. Game Over!\n";
    else if (year < 2009)
        cout << "Stay away from ready made custom advices please!\n";
    else
        cout << "Anything wrong with your time machine? You have not gone anywhere, kiddo.\n";
    cout << "-------------------------------------\n";
    
    /* Range based for loop */
    // Iterating over whole vector
    vector<int> v = {0, 1, 2, 3, 4, 5};
    for (auto i : v)
      cout << i << ' ';
    cout << '\n';
        
    // Iterating over an initializer-list
    for (int n : {0, 1, 2, 3, 4, 5})
      cout << n << ' ';
    cout << '\n';
     
    // Iterating over array
    int arr[] = {0, 1, 2, 3, 4, 5};
    for (int n : arr)
      cout << n << ' ';
    cout << '\n';
                
    // Printing string characters
    string str = "Modern C++";
    for (char c : str)
      cout << c << ' ';
    cout << '\n';

    // Printing keys and values of a map
    map <int, int> integerMap({{1, 1}, {2, 2}, {3, 3}});
    for (auto i : integerMap)
      cout << '{' << i.first << ", " << i.second << "}\n";
    
    
    /* Numerical Array, While */
    array<string, 3> rules = { "Do no harm", "Obey", "Continue Living" };
    int i = 0;
    while (i < rules.size()) {
        cout << "Rule " << i + 1 << " : " << rules[i] << endl;
        ++i;
    }
    cout << "-------------------------------------\n";
    
    
    /* Associating array */
    /* Copying range of values to a new collection */
    int intArr[]={10,20,30,40,50,60,70};
    vector<int> intVec (5);
    copy ( intArr, intArr+5, intVec.begin() );
    for (auto i : intVec)
      cout << i << ' ';
    cout << '\n';
    cout << "-------------------------------------\n";
    
    /*
     * Example of a Nested Loop To calculate pythagorean Triplets
     * triplet: a^2 + b^2 = c^2
     */
    cout << "Nested Loop:\n";
    int limit = 20;
    for (int i = 1; i <= limit; ++i)
    {
        for (int j = i; j <= limit; ++j)
        {
            for (int k = 1; k <= limit; k++)
            {
                if ((i*i)+(j*j) == k*k && k <= limit)
                {
                    printf("a = %d, b = %d, c = %d\n", i, j, k);
                    //cout << i << " + " << j << " = " << k << endl;
                }
            }
        }
    }
    cout << "-------------------------------------\n";
    
    
    /* Iterating over a Collection using STL iterator and collection size */
    cout << "Fibonacci:\n";
    vector<int> fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13, 21 };
    for(auto i = 0; i < fibonacci.size(); ++i)
    {
        cout << *(fibonacci.begin() + i) <<"\t";
    }
    cout << "\n-------------------------------------\n";
    
    
    /* Tokenize a string using delimiters */
    char sampleStr[] ="This - is, C++, tokenizing. using - delimiters.";
    printf ("Splitting string \"%s\" into tokens:\n",sampleStr);
    char * pch = strtok (sampleStr," ,.-");
    while (pch != NULL)
    {
      printf ("%s\n",pch);
      pch = strtok (NULL, " ,.-");
    }
    cout << "-------------------------------------\n";
    
    
    /*
     * A Single Argument Lambda function, and it's usage
     */
    auto hello = [](string name) {
        ostringstream str;
        str << "Hello " << name << endl;
        return str.str();
    };
    
    // A single argument Lambda function call
    cout << hello("Peter") ;
    cout << "-------------------------------------\n";
    
    /*
     * A simple class One for the OOP fanboys - Class, members, object and
     * stuff
     */
    class Movie {
    public:
        Movie(string name, vector<float> ratings): rating(0.0) {
            this->name = name;
            this->userRatings = ratings;
            this->rateMovie();
        }

        void printMovieDetails() {
            cout << "Movie  : " << this->name << endl;
            cout << "Rating : " << this->rating << "("
                      << this->userRatings.size() << ")\n" << endl;
        }
        
    private:
        /*
         * IMDBs rating algorithm.
         * True story!
         */
        void rateMovie() {
            this->rating = accumulate( userRatings.begin(), userRatings.end(), 0.0) / userRatings.size();
        }
        
    private:
        string name;
        vector<float> userRatings;
        float rating;
    };
    
    /* Create the object using a Smart pointer */
    auto rateMovie = make_unique<Movie>("New Country for Old Men",
                                         vector<float>{8.6, 7, 8.1});/* It's a sequel! */
    //auto ncfom = Movie("New Country for Old Men");
    rateMovie->printMovieDetails();
    cout << "-------------------------------------\n";
    
    
    /*----------------------------------------
     * (OOPS) Inheritance, polymoprphism etc..
     * in C++ explained
     *----------------------------------------*/
    class Pet {
    public:
        Pet(string name, string species) {
            this->name = name;
            this->species = species;
        }

        string getName() {
            return this->name;
        }

        string getSpecies() {
            return this->species;
        }

        string toString() {
            ostringstream stream;
            stream << name << " " << species;
            return stream.str();
        }
        
    private:
        string name = "";
        string species = "";
    };
    
    auto polly = Pet("Polly", "Parrot");
    cout << polly.getName() << endl;
    cout << polly.getSpecies() << endl;
    cout << polly.toString() << endl;
    cout << "-------------------------------------\n";

    class Dog : public Pet {
    public:
        Dog(string name, bool chases_cats) : Pet(name, "Dog"){
            this->chases_cats = chases_cats;
        }

        bool chasesCats() {
            return this->chases_cats;
        }
        
    private:
        bool chases_cats = false;
    };

    class Cat : public Pet {
    public:
        Cat(string name, bool hates_dogs): Pet(name, "Cat") {
            this->hates_dogs = hates_dogs;
        }

        bool hatesDogs() {
            return this->hates_dogs;
        }
        
        private:
            bool hates_dogs = false;
    };
    
    /*----------invocations-------------*/
    auto fido    = make_unique<Dog>("Fido", true);
    auto rover   = make_unique<Dog>("Rover", false);
    auto mittens = make_unique<Cat>("Mittens", true);
    auto fluffy  = make_unique<Cat>("Fluffy", false);

    cout << fido->toString()    << endl;
    cout << rover->toString()   << endl;
    cout << mittens->toString() << endl;
    cout << fluffy->toString()  << endl;

    // There isn't any format specifier for bool in C++.
    // Lambda function to return bool string.
    auto boolToString = [](bool flag) {
        return flag ? "true": "false";
    };

    printf("%s chases cats: %s %s", fido->getName().c_str(), boolToString(fido->chasesCats()), "\n");
    printf("%s chases cats: %s %s", rover->getName().c_str(), boolToString(rover->chasesCats()), "\n");
    printf("%s hates dogs: %s %s",  mittens->getName().c_str(), boolToString(mittens->hatesDogs()), "\n");
    printf("%s hates dogs: %s %s",  fluffy->getName().c_str(), boolToString(fluffy->hatesDogs()), "\n");
    cout << "-------------------------------------\n";
    
    
    /* List comprehension examples using parallel STL*/
    auto printList = [](vector<double> list) {
        for(auto item : list) {
            cout << item << endl;
        }
    };
    
    vector<double> transList;
    for(int i=1; i <=10; ++i )
        transList.push_back(i);
    
    transform(transList.begin(), transList.end(), transList.begin(), [](int v){
        return v*v;
    });
    
    printList(transList);
    cout << "-------------------------------------\n";
    
    
    vector<double> celsius = { 39.2f, 36.5f, 37.3f, 37.8f };
    vector<double> fahrenheit(celsius.size());
    
    transform(celsius.begin(), celsius.end(), fahrenheit.begin(), [](double d){
        return (9 / 5 * d + 32);
    });
    
    printList(fahrenheit);
    cout << "-------------------------------------\n";
    
    
    /*
     * Tuple in C++ are mutable
     */
    tuple<string, int, string, int> cppTuple("C++", 11, "Tuples", 101);
    //tuple cppTuple{"C++", 17, "Tuple", 101}; // Another C++17 feature: class template argument deduction
    apply([](auto&&... args) {
        ((cout << args << ' '), ...);
    }, cppTuple);
    cout << "\nTuple size: " << tuple_size<decltype(cppTuple)>::value << "\n\n";
    
    // Unpacking the tuple in seperate variables
    string lang;
    int         libVer;
    string feature;
    int         chapter;
    
    // Change the value in a tuple
    get<1>(cppTuple) = 17;
    
    tie(lang, libVer, feature, chapter) = cppTuple;
    cout << "Language: " << lang << endl;
    cout << "Std Lib: " << libVer << endl;
    cout << "Feature: " << feature << endl;
    cout << "Chapter: " << chapter << endl;
    
    // Concatinating two tuples
    tuple<char, string, int, string> extraTuple{',', "and C++", 20, "fetures are more exciting" };
    auto newTuple = tuple_cat(cppTuple, extraTuple);
    apply([](auto&&... args) {
        ((cout << args << ' '), ...);
    }, newTuple);
    cout << "\n-------------------------------------\n";
    
    
    /*
     * Map-filter-reduce
     */
    vector<double>foo = {2, 18, 9, 22, 17, 24, 8, 12, 27};
    // Filter
    auto itrEnd = remove_if(foo.begin(), foo.end(), [](int d) {
        return !(d % 3 == 0);
    });
    auto dist = distance(foo.begin(), itrEnd);
    foo.resize(dist);
    
    cout << "Reduced container: \n";
    printList(foo);

    // Map
    transform(foo.begin(), foo.end(), foo.begin(), [](double d) {
        return d * 2 + 10;
    });
    
    cout << "\nTransformed container (x * 2 + 10): \n";
    printList(foo);
    
    // Reduce
    auto result = accumulate(foo.begin(), foo.end(), 0, [](int a, int b) {
        return a + b;
    });

    
    cout << "\nReduced result (sum): " << result << endl;
    cout << "-------------------------------------\n";
    
    
    /*
     * Deep Copy vs Shallow Copy
     */
    int *x = new int (5), *y = nullptr;
    
    y = x; // Shallow copy
    *y = 6;
    cout << "Shallow copy:\n";
    cout << "X = " << *x << ", Y = " << *y << endl;
    
    y = new int(7);
    *y = 8;
    cout << "Deep copy:\n";
    cout << "X = " << *x << ", Y = " << *y << endl;
    
    // MVP - Always free the memory allocated in heap.
    // Or use smart solutions follows RAII idiom.
    delete x;
    delete y;
    cout << "-------------------------------------\n";
    
    
    /*
     * Create new directories in the workspace.
     * Create and write to a new file or append to an existing one.
     */
    auto currentPath = fs::current_path() / "myDir";
    fs::create_directory(currentPath);
    
    auto filePath = currentPath / "annualreview.txt";
    vector<std::string> lines = { "1st line", "2nd line", "", "your happy place", "bla bla bla..." };
    
    // Opening a text file using {o}filestream
    ofstream file(filePath);
    for(auto line : lines)
        file << line << endl;
    file.close();
    
    // Read entire text file using classic C-style FILE pointer.
    // Opening the file in read mode.
    FILE* fp = fopen(filePath.c_str(), "r");
    if(!fp) {
       perror("File opening failed");
    }
    else {
        int c;
        while ((c = fgetc(fp)) != EOF)
          putchar(c);
    }
    cout << "-------------------------------------\n";
    
    
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
    string password;
    cout << "Password:";
    getline(cin, password);
    
    bool valid = false;
    
    regex upperCaseExpression   { "[A-Z]+" };
    regex lowerCaseExpression   { "[a-z]+" };
    regex numberExpression      { "[0-9]+" };
    regex specialCharExpression { "[@!?$%-+]+" };
    
    auto upperCase   = std::regex_search(password, upperCaseExpression);
    auto lowerCase   = std::regex_search(password, lowerCaseExpression);
    auto numberCase  = std::regex_search(password, numberExpression);
    auto specialChar = std::regex_search(password, specialCharExpression);
    
    //eg: regex_results = 1 + 0 + 1 + 1 (true/false as an integer)
    int regex_results = upperCase + lowerCase + numberCase + specialChar;
    
    if (regex_results     == 4 &&
        password.length() >= 6 &&
        password.length() <= 20)
    {
        valid = true;
    }
    
    cout << (valid ? "That's a valid Password!" : "Invalid password! Try again . . .") << endl;
    cout << "-------------------------------------\n";
    
    return 0;
}
