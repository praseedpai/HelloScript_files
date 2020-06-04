<?php

#---- A Simple text Output
echo("Hello World\n\n");

#---- A Simple array Output
print_r(["hello", "world"]);

#----- Demonstrates formatted output

$name = "Praseed";
$year = 2020;
print "Hello, " . $name . " - welcome to " . $year . "\n";

#----- if - elseif Condition

# If,else conditions
if ($year > 2008) {
    echo("Welcome to the future - yes, we have flying cars!\n");
} elseif ($year < 2008) {
    echo("The past - please don't change anything. Don't step on any butterflies. And for the sake of all thats good and holy, stay away from your parents!\n");
} else {
    echo("Anything wrong with your time machine? You have not gone anywhere, kiddo.\n");
}

#if - elseif condition with only single line code for each condition (No curly brackets needed)
if ($year > 2008)
    echo("Welcome to the future - yes, we have flying cars!\n");
elseif ($year < 2008)
    echo("The past - please don't change anything. Don't step on any butterflies. And for the sake of all thats good and holy, stay away from your parents!\n");
else
    echo("Anything wrong with your time machine? You have not gone anywhere, kiddo.\n");

#----- Loops
# For loop
for ($i = 0; $i <= 3; $i++) {
    echo $i . ") Hi there!";
}


#----- Array demo
#-----

#Numerical Array, While

$rules = ['Do no harm', 'Obey', 'Continue Living'];
$i = 0;
while ($i < count($rules)) {
    echo("Rule " . ($i + 1) . " : " . $rules[$i] . "\n");
    $i = $i + 1;
}
echo("");


#----- Associative array
#----
#----

# Associated array, foreach
$associated = [
    'hello' => 'world',
    'foo' => 'bar',
    'lorem' => 'ipsum'
];
foreach ($associated as $key => $value) {
    echo($key . " : " . $value . "\n");
}
echo("");

#------- Example of a Nested Loop
#------- To calculate Pythagorean Triplets
#
#
#

$n = 10 + 1;
echo("-------------------------------------\n");
for ($a = 0; $a <= $n; $a++) {
    for ($b = $a; $b < $n; $b++) {
        $c_square = $a ** 2 + $b ** 2;
        $c = sqrt($c_square);
        if (($c_square - $c ** 2) == 0) {
            echo($a . ' ' . $b . ' ' . $c . "\n");
        }
    }
}

echo("----------------------------------\n");

#
# Iterating over a List using range and len
#
#
echo("-------------------------------------\n");
$fibonacci = [0, 1, 1, 2, 3, 5, 8, 13, 21];
for ($i = 0; $i < count($fibonacci); $i++) {
    echo($i . ' ' . $fibonacci[$i]);
}
echo("-------------------------------------\n");
#--------- Parsing a line...
#-------

$csv_values = explode(",", "hello,world,how,are,you\n");
print_r($csv_values);
echo("\n");
echo(implode(':', $csv_values));

#------ A Single Argument Function
#------
# Function, argument, return, call
function hello($name)
{
    return "Hello " . $name . "\n";
}

$hello_str = hello("Praseed");

echo($hello_str);

#----- A simple class

# One for the OOP fanboys - Class, members, object and stuff.
class Movie
{
    public $name = "";
    public $rating = 0;

    function __construct($name)
    {
        $this->name = $name;
        $this->rateMovie();
    }

    function rateMovie()
    {
        $this->rating = (strlen($this->name) % 10) + 1; #IMDBs rating algorithm. True story!
    }

    function printMovieDetails()
    {
        echo("Movie : " . $this->name);
        echo("\nRating : " . str_repeat('*', $this->rating) . "(" . $this->rating . ")\n");
    }
}


#Create the object
$ncfom = new Movie("New Country for Old Men"); #It's a sequel!
$ncfom->printMovieDetails();

#--------------------------------------
#---------------------------------------
#---------------------------------------

class Pet
{
    public $name = '';
    public $species = '';

    function __construct($name, $species)
    {
        $this->name = $name;
        $this->species = $species;
    }

    function getName()
    {
        return $this->name;
    }

    function getSpecies()
    {
        return $this->species;
    }

    public function __toString()
    {
        return $this->name . ' is a ' . $this->species;
    }
}


$polly = new Pet("Polly", "Parrot");

echo($polly->getName());

echo($polly);


class Dog extends Pet
{
    public $chase_cats;

    function __construct($name, $chases_cats)
    {
        $this->name = $name;
        $this->species = 'Dog';
        $this->chase_cats = $chases_cats;
    }

    function chasesCats()
    {
        return $this->chase_cats;
    }
}


class Cat extends Pet
{
    public $hates_dogs;

    function __construct($name, $hates_dogs)
    {
        $this->name = $name;
        $this->species = 'Cat';
        $this->hates_dogs = $hates_dogs;
    }

    function hatesDogs()
    {
        return $this->hates_dogs;
    }

}

#-------------------- invocations
$fido = new Dog("Fido", True);
$rover = new Dog("Rover", False);
$mittens = new Cat("Mittens", True);
$fluffy = new Cat("Fluffy", False);
print_r($fido);
print_r($rover);
print_r($mittens);
print_r($fluffy);

if ($fido->chasesCats()) {
    echo($fido->getName() . " does chase cats.\n");
} else {
    echo($fido->getName() . " does't chase cats.\n");
}

if ($rover->chasesCats()) {
    echo($rover->getName() . " does chase cats.\n");
} else {
    echo($rover->getName() . " does't chase cats.\n");
}

if ($mittens->hatesDogs()) {
    echo($mittens->getName() . " does hate dogs.\n");
} else {
    echo($mittens->getName() . " does't hate dogs.\n");
}

if ($fluffy->hatesDogs()) {
    echo($fluffy->getName() . " does hate dogs.\n");
} else {
    echo($fluffy->getName() . " does't hate dogs.\n");
}

#
#
#
#
# List comprehension examples
#
#
#
$myList = array_map(function ($i) {
    return $i * $i;
}, range(1, 10));

print_r($myList);
echo "\n";
$Celsius = [39.2, 36.5, 37.3, 37.8];
$Fahrenheit = array_map(function ($x) {
    return ((9 / 5) * $x + 32);
}, $Celsius);
print_r($Fahrenheit);
echo "\n";


#
#
#
#
#
# File IO
# File reading, easy method...
#

$file_in = fopen("Hello.php", "r") or die("Unable to open file!");
echo("Current file has " . filesize("Hello.php") . " chars\n");
fclose($file_in);

# Writing to a file
$file_out = fopen('hello.txt', 'w');
fwrite($file_out, "Hello World");
fclose($file_out);

print_r(exec('dir')); #Execute the command 'dir' and print its output
echo("\n");

#
#
#
#
# Regular Expressions
#
preg_match('/(foo)(bar)(baz)/', 'foobarbaz', $matches, PREG_OFFSET_CAPTURE);
print_r($matches);






