import java.io.File
import java.nio.charset.StandardCharsets
import java.nio.file.Files
import java.nio.file.Paths
import java.nio.file.StandardOpenOption

/**
 *
 * Contents:
 *
 * 		   A simple console output, Formatted Output, If-else
 *         condition, Range based for loop, Copying Range values to a variable,
 *         Numerical Array and while, Associated Array and foreach, Nestedloop
 *         to calculate pythagorean triplets, Iterating over a List using range
 *         and length, Parsing a line, A Single Argument Function call, A simple
 *         class, Create the object, Inheritance, List comprehension, Create and
 *         write to a file, Read from a file, Using Regex.
 *
 */
fun main(args: Array<String>) {
    /* A Simple Console Output */
    println("Hello")

    /*
     * Demonstrates formatted output, %d placeholder for decimal,
     * %s-->string, %f-->float, "/n"-->next line
     */
    print(String.format("Formatting %s is easy %d %f\n", "with kotlin", 10, 98.6))

    /*
     * String.format returns a formatted string, '-' makes the result left
     * justified, 32 is the width of the first string
     */
    print(String.format("%-32s= %s", "label", "content"))

    /* String formatting with string templates */
    val str = "HelloWorld"
    val i = 10
    println("Length of the string is ${str.length} and value of i is $i")

    /* If,else condition */
    val year = 2016
    if (year > 2008)
        println("You are in india and you have already enrolled for engineering. Game Over!")
    else if (year < 2008)
        println("Stay away from ready made custom advices please!")
    else
        println("Anything wrong with your time machine? You have not gone anywhere, kiddo.")

    /* Range based for loop */
    (0..3).forEach { println("$it : Hi there") }

    /* copying range value to a variable */
    val newArray = mutableListOf<Int>()
    (0..3).forEach { newArray.add(it) }
    println(newArray)

    /* Array demo */
    /* Numerical Array, While */
    val rules = listOf("Do no harm", "Obey", "Continue living")
    var j = 0
    while (j < rules.size) {
        println("Rule ${j + 1} : ${rules[j]}")
        j++
    }

    /* Associated array, foreach */
    val map = mapOf("hello" to "world", "foo" to "bar", "lorem" to "ipsum")
    map.forEach { key, value -> println("$key : $value") }

    /*
     * Example of a Nested Loop To calculate pythagorean Triplets
     */
    val n = 11
    (0..n).forEach { a ->
        (a..n).forEach { b ->
            val cSquare = Math.pow(a.toDouble(), 2.0).toInt() + Math.pow(b.toDouble(), 2.0).toInt()
            val c = Math.sqrt(cSquare.toDouble()).toInt()
            if ((cSquare - (c * c)) == 0) {
                println("a = $a, b = $b, c = $c")
                println("----------------------------------")
            }
        }
    }

    /* Iterating over a List using range and len */
    val fibonacci = listOf(0, 1, 1, 2, 3, 5, 8, 13, 21)
    (0..fibonacci.size - 1).forEach { println("$it : ${fibonacci[it]}") }

    /* Parsing a line */
    val csv_values = "hello*world*how*are*you".trim().split("*")
    println(csv_values)
    println(csv_values.joinToString(":"))

    /*
     * A Single Argument Function call
     */
    println(hello("Vyshakh"))

    /*
     * A simple class One for the OOP fanboys - Class, members, object and
     * stuff
     */
    class Movie {
        var name: String = ""
        var rating: Int = 0

        constructor(name: String) {
            this.name = name
            this.rateMovie()
        }

        fun rateMovie() {
            this.rating = ((this.name.length) % 10) + 1
        }

        fun printMovieDetails() {
            println("Movie : ${this.name}")
            println("Rating : * ${this.rating} (${this.rating})")
        }
    }

    /* Create the object */
    val ncfom = Movie("New Country for Old Men")
    ncfom.printMovieDetails()

    open class Pet(var name: String, var species: String) {
        override fun toString(): String = "${this.name} ${this.species}"
    }

    val polly = Pet("Polly", "Parrot")
    println(polly.name)
    println(polly.species)
    println(polly.toString())

    class Dog : Pet {
        var chases_cats = false

        constructor(name: String, chases_cats: Boolean) : super(name, "Dog") {
            this.chases_cats = chases_cats
        }
    }

    class Cat : Pet {
        var hates_dog = false

        constructor(name: String, hates_dog: Boolean) : super(name, "Cat") {
            this.hates_dog = hates_dog
        }
    }

    /*----------invocations-------------*/
    val fido = Dog("Fido", true)
    val rover = Dog("Rover", true)
    val mittens = Cat("Mittens", true)
    val fluffy = Cat("Fluffy", false)

    println(fido)
    println(rover)
    println(mittens)
    println(fluffy)

    println("${fido.name} chases cats : ${fido.chases_cats}")
    println("${rover.name} chases cats : ${rover.chases_cats}")
    println("${mittens.name} hates dogs : ${mittens.hates_dog}")
    println("${fluffy.name} hates dogs : ${fluffy.hates_dog}")

    /* List comprehension examples */
    val listExample = mutableListOf<Int>()
    (0..10).forEach { listExample.add(Math.pow(it.toDouble(), 2.0).toInt()) }
    println(listExample)

    val celsius = listOf(39.2f, 36.5f, 37.3f, 37.8f)
    val fahrenheit = celsius.map { 9 / 5 * it + 32 }
    println(fahrenheit)

    val list = (0..100).toList()
    val primeList = list.filter { u -> u > 1 && (2..u - 1).none { e -> u % e == 0 } }
    val nonPrimeList = list.filter { u -> u > 1 && (2..u - 1).any { e -> u % e == 0 } }
    println(primeList)
    println(nonPrimeList)

    /*
     * Using Comparator Sorting list of pets first by their name, and then
     * sort again the list by species and print in reversed order
     */
    val pets = mutableListOf(
        Pet("Grey Wind", "Direwolve"), Pet("Lady", "Direwolve"),
        Pet("Nymeria", "Direwolve"), Pet("Summer", "Direwolve"),
        Pet("Shaggydog", "Direwolve"), Pet("Ghost", "Direwolve"),
        Pet("Scooby-Doo", "Dog"), Pet("Bouncer", "Frog"),
        Pet("Puss-in-Boots", "Cat"), Pet("Hachi", "Dog")
    )

    val groupByComparator = compareBy<Pet> { it.name }.thenBy { it.species }
    pets.sortWith(groupByComparator.reversed())
    println(pets)

    /* A collection of value of pairs ( tuples ? ) */
    val pair1 = 12 to 34.56f
    val pair2 = "abc" to "xyz"
    println(pair1)
    println(pair2)

    /* Expandable list */
    var expandableDoubleList = mutableListOf(1.38, 2.56, 4.3, 15.0)
    expandableDoubleList.add(22.0)

    /*
     * Obtaining a stream from a collection(which is concrete) and following
     * the pipeline pattern Stream configuring using filter( which preserves
     * the type and may change the count) or map (which preserves the count
     * and may change type) or .. Stream processing using collect or reduce
     * or..
     */
    var result = expandableDoubleList.filter { (it % 3).equals(0) }
    println(result)

    var anotherResult = expandableDoubleList.map { it * 3 }
    println(anotherResult)

    result.map { it * 3 }.forEach { println(it) }

    val numbers = listOf(1, 2, 3, 4, 5)
    val sum = numbers.reduce { a, b -> a + b }
    println(sum)

    /*
     * Create new directories in the workspace. And Create and write to a
     * new file or append to an existing one.
     */
    createNewOrAppendToFile()

    /*
     * Read content of the file line by line and check if any line contains
     * word "happy" then print it.
     */
    readStreamOfLinesUsingUseFunction()

    /*
     * Regex in kotlin. Validating the password using Regex
     */
    println(aPasswordValidator())

}

/* Single-expression functions */
fun hello(name: String): String = "Hello $name"

fun createNewOrAppendToFile() {
    var currentDirectory = System.getProperty("user.dir")
    var newDirectoryPath = currentDirectory + "\\dir"
    File(newDirectoryPath).mkdirs()
    val lines = listOf(
        "1st line", "2nd line", "",
        "yourhappyplace", "bla bla bla"
    )
    Files.write(
        Paths.get(newDirectoryPath + "\\yearendreview.txt"),
        lines,
        StandardCharsets.UTF_8,
        StandardOpenOption.CREATE,
        StandardOpenOption.APPEND
    )
}

/*
 * This read the lines as streams and use "use()" function which is equivalent of
 * try-with-resources which will eliminate the need of closing the stream and
 * checks if the underlying file is closed or not
 */
fun readStreamOfLinesUsingUseFunction() {
    val path = Paths.get(System.getProperty("user.dir") + "\\dir\\yearendreview.txt")
    val filteredLines = Files.lines(path).onClose { println("File closed") }.filter { it.contains("happy") }
    filteredLines.use {
        it.findFirst().ifPresent { println(it) }
    }
}

/*
 * Regex:
 *
 * ((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})
 *
 * Explanation:
 *
 * ( 			# Start of group
 * (?=.*\d) 	# must contains one digit from 0-9
 * (?=.*[a-z]) 	# must contains one lowercase characters
 * (?=.*[A-Z]) 	# must contains one uppercase characters
 * (?=.*[@#$%]) # must contains one special symbols in the list "@#$%"
 * . 			# match anything with previous condition checking
 * {6,20} 		# length at least 6 characters and maximum of 20
 * ) 			# End of group
 */
fun aPasswordValidator(): String {
    print("Please choose a password (In correct format) ::")
    var yourPassword = readLine()
    val PASSWORD_PATTERN = Regex("""(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#\$%]).{6,20}""")
    return if (PASSWORD_PATTERN.containsMatchIn(yourPassword!!)) "Valid!!!" else aPasswordValidator()
}