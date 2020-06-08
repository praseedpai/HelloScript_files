/**
 * HelloScript.groovy
 */

//  A Simple Console Output

    println "Hello World"

//  Some more
    print ("Hello World")
    System.out.println("K-Mug"); // Java style also works

// Declare variables
    def a = 100 // a number, def is about scope
    b = 100; // another number
    year = "Twenty Twenty" // a string

// String formatting & interpolation
    println "This is ${a}, ${b}, and " + year;

// Reassign a variable
    year = 2008; // dynamic typing

// if-else
    if (year > 2008)
        println "Welcome to the future - yes, we have flying cars!"
    else if (year < 2008)
        printLN "The past - please don't change anything. Don't step on any butterflies. And for the sake of all thats good and holy, stay away from your parents!"
    else
        println "Anything wrong with your time machine? You have not gone anywhere, kiddo."


// Range based for loop
for (i in 0..3) {
    println "$i Hi there!"
}

// Copying range value to a variable
    range_array = (0..10)
    print range_array;

// Array demo
    rules = ['Do no harm','Obey','Continue Living']
    println rules;

    rules << "Be Honest" // add one more item
    println rules

// Array demo, with mixed types
    more_rules = ['Do no harm','Obey','Continue Living', 404, 403, 500, 100f]
    println more_rules;

// Loop through Array
    i = 0
    while (i < rules.size()) {
        print "Rule " + (i + 1) + " : " + rules[i]
        i += 1
    }

    println() // just a newline

// Associating array
    associated = [
        'hello'	:	'world',
        'foo'	:	'bar',
        'lorem'	:	'ipsum'
    ]

    for (ele in associated) {
        print ele.key + " : " + ele.value
    }

    println() // just a newline

// Example of a Nested Loop
// To calculate Pythagorean Triplets
    n = 10
    println "-------------------------------------"
    for (va in (1..n)) {
        for (vb in (va..n)) {
            Integer c_square = va**2 + vb**2
            Integer vc = Math.sqrt(c_square)
            if ((c_square - vc**2) == 0) {
                println va + " " + vb + " " + vc
            }
        }
    }
    println "----------------------------------"

// Iterating over a list using range and size
    println "-------------------------------------"
    fibonacci = [0,1,1,2,3,5,8,13,21]
    for (i in (0..fibonacci.size()-1)) {
        println i + " " + fibonacci[i]
    }
    println "---------------------------------------"

// Parsing a line - split and join
    csv_values = "hello,world,how,are,you".split(",")
    println csv_values;
    println csv_values.join(":")

// A Single Argument Function
    def hello(name) {
        return "Hello ${name}!"
    }
    println hello("Praveen")

// A simple class
    class Movie {
        String name = ""
        Integer rating = 0

        def Movie(movieName) {
            this.name = movieName
            this.rateMovie()
        }

        def rateMovie() {
            this.rating = (this.name.length() % 10) + 1     // IMDBs rating algorithm. True story!
        }
        def printMovieDetails() {
            println "Movie : " +   this.name
            println "Rating : " + '*'.multiply(this.rating)  +  "(" + this.rating +")"
        }
    }

// Create the Object
    ncfom = new Movie("New Country for Old Men");     // It's a sequel!
    ncfom.printMovieDetails()

// Closures in action
    myList = ["Hello","My","World","What's","Up"]
    myList.each {
        print it + "-" // it is special
    }

// Multiplication table
    (1..10).each {
        println "${it} x 2 = ${it*2}"
    }

    println() // just a newline

// Tuples
    myTuple = new Tuple(1, 'two', 3, 'four')
    println myTuple

// File IO - Create a new file
    myFile = new File("myfile.txt");
    myFile.text = "Hello World! - from the file"
    myFile.createNewFile()

// File IO - Read from file
    println myFile.text

// File IO - With closure
    myFile.eachLine {
        l -> println l.toUpperCase()
    }

// Regular Expressions
    import java.util.regex.Pattern
    Pattern pattern = ~/World/
    str = "Hello World, this is Universe, not your World!"
    println "Found " + pattern.matcher(str).size() + " mathes."