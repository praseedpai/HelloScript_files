# Ruby Comment


#---- A Simple Console Output
#---- Equivalent to Printf
print  "Hello World" 

#---- A Simple Console Output
#---- Equivalent to Printline, prints each argument in different line
puts  "Hello World" 


#----- Demonstrates formatted output
#----- String(nn)-converts nn to string
name = "Praseed"
year = 2008

puts "Hello, " + name + " - welcome to " + String(year)

#----- IF Elsif Condition

# If,else conditions
if (year > 2008)
	print "Welcome to the future - yes, we have flying cars!\n"
elsif(year < 2008)
	print "The past - please don't change anything. Don't step on any butterflies. And for the sake of all thats good and holy, stay away from your parents!\n"
else
	print "Anything wrong with your time machine? You have not gone anywhere, kiddo.\n"
end	
	#----- Range based for loop
# For loop
for i in 0..3
	puts String(i) + ") Hi there!"
end


#----- copying range value to a variable
#------
range_array= Array(0..10)

puts range_array;

#Numerical Array, While
rules = ['Do no harm','Obey','Continue Living']
i = 0
while(i<rules.size) do
	puts "Rule " + String(i+1) + " : " + rules[i]
	i = i + 1
print ""
end

# Associated array, foreach
associated = Hash.new
associated ={"hello" => "world", "foo" => "bar","lorem"=>"ipsum"}

# Print keys
for value in associated.keys
	puts value 
print ""
end
# Print Key value pair
for value in associated
	print value 
print ""
end

#------- Example of a Nested Loop
#------- To calculate Pythagorean Triplets
#
#
#


n = Integer(10)+1
print "-------------------------------------\n";
for a in 1..n
    for b in a..n
        c_square = a**2 + b**2
        c = Integer(Math.sqrt(c_square))
        if ((c_square - c**2) == 0)
            print a, b, c,"\n"
end
end
end
print "----------------------------------\n";

#
# Iterating over a List using range and array size. here since range starts with zero, array size-1 is used
#
#
print "-------------------------------------\n";
fibonacci = [0,1,1,2,3,5,8,13,21]
for i in 0..fibonacci.size-1
    puts String(i)+","+String(fibonacci[i])
end
print "-------------------------------------\n";
#--------- Parsing a line...
#-------

values="hello,world,how,are,you\n"
csv_values = values.split(",")
print csv_values;
print "\n"
print csv_values.join(":")

#------ A Single Argument Function
#------
# Function, argument, return, call
def hello(name)
	return "Hello " + name + "\n"
end
hello_str = hello("Arun")

print hello_str

#----- A simple class

# One for the OOP fanboys - Class, members, object and stuff.
class Movie
	name = ''
	rating = 0
	
	def initialize(name)
	@name = name
	rateMovie()
end
	def rateMovie()
		@rating = (@name.size % 10) + 1 #IMDBs rating algorithm. True story!
	end
	def printMovieDetails()
		print "Movie : ",  @name
		print " Rating : ", '*' *@rating , "(", @rating ,")\n"
	end
end
#Create the object
ncfom = Movie.new("New Country for Old Men") #It's a sequel!
ncfom.printMovieDetails()



#--------------------------------------
#---------------------------------------
#---------------------------------------

class Pet

    def initialize(name, species)
       @name = name
        @species = species
    end
    
    def getName()
       @name
    end
    def getSpecies()
       @species
end
    def to_s()
         "#@name is a #@species\n"
end
end
polly = Pet.new("Polly", "Parrot")

puts polly.getName();

print String(polly);


class Dog < Pet

    def initialize(name, chases_cats)
        super(name, "Dog")
        @chases_cats = chases_cats
end
    def chasesCats()
        @chases_cats
end
end
class Cat < Pet

    def initialize( name, hates_dogs)
        super( name, "Cat")
        @hates_dogs = hates_dogs
end
    def hatesDogs()
        @hates_dogs
end
end
#-------------------- invocations 
fido = Dog.new("Fido", true)
rover = Dog.new("Rover", false)
mittens = Cat.new("Mittens", true)
fluffy = Cat.new("Fluffy", false)
print fido
print rover
print mittens
print fluffy

print fido.getName()+" chases cats: "+String(fido.chasesCats())+"\n"

print rover.getName()+" chases cats: "+String(rover.chasesCats())+"\n"

print mittens.getName()+" hates dogs: "+String(mittens.hatesDogs())+"\n"
print fluffy.getName()+" hates dogs: "+String(fluffy.hatesDogs())+"\n"


#
#
#
#
# List comprehension examples
#
#
#

print (1..10).map {|x| x > 0 ? x * x : nil}.compact

Celsius = [39.2, 36.5, 37.3, 37.8]
Fahrenheit =Celsius.map {|x| x > 0 ? ((Float(9)/5)*x + 32) : nil}.compact
print Fahrenheit
primes=[];
noprimes=[]

(2..100).each{|n| primes.any?{|l|n%l==0}?nil:primes.push(n)};

noprimes= (2..100).to_a-primes
print primes
print "\n" 
print noprimes
#
#
# all the variables are immutable in ruby
#
#
tup1 = [12, 34.56];
tup2 = ['abc', 'xyz'];

# Following action is not valid for tuples in python but valid in ruby
 tup1[0] = 100;

# So let's create a new tuple as follows
tup3 = tup1 + tup2;
print tup3

#
#
#
#Functional Programming in Ruby
#
#
#
#

natural_numbers = Enumerator.new do |yielder|
  (1..1.0/0).each do |number|
    yielder.yield number
  end
end
print natural_numbers.take(10)

print natural_numbers.map { |x| 2*x }.take(10)

print (1..100).select { |i| i % 5 == 0 }.map { |i| i * 5 }.take(3) 
#=> [25, 50, 75]
[["functional", "programming", "rules"].mash { |s| [s, s.length] }]
# {"rules"=>5, "programming"=>11, "functional"=>10}

# 
# Deep Copy vs Shallow Copy 
#
#

print "=================================\n";
print "Deep Copy vs Shallow Copy\n";

complex_array = ['a','b',['ab','ba']]
print complex_array
print "\n"
copied_array=complex_array #shallow copy
print copied_array
print "\n"
copied_array = Marshal.load(Marshal.dump(complex_array))  #deep copy
print copied_array


#
#
# File IO
# File reading, easy method...
#

aFile = File.new("input.txt", "r")
if aFile
   content = aFile.sysread(20)
   puts content
else
   puts "Unable to open file!"
end
# Writing to a file

aFile = File.new("input.txt", "r+")
if aFile
   aFile.syswrite("Hello World")
else
   puts "Unable to open file!"
end

#
# 
#
#
# Regular Expressions
#
#The sub and gsub return a new string, leaving the original unmodified 
#where as sub! and gsub! modify the string on which they are called.

phone = "2004-959-559 #This is Phone Number"

# Delete Ruby-style comments
phone = phone.sub!(/#.*$/, "")   
puts "Phone Num : #{phone}"

# Remove anything other than digits
phone = phone.gsub!(/\D/, "")    
puts "Phone Num : #{phone}"


#
# 
#
#
#DOM-like Parsing:
#include REXML to import into the top-level namespace for convenience.

require 'rexml/document'
include REXML

xmlfile = File.new("movies.xml")
xmldoc = Document.new(xmlfile)

# Now get the root element
root = xmldoc.root
puts "Root element : " + root.attributes["shelf"]

# This will output all the movie titles.
xmldoc.elements.each("collection/movie"){ 
   |e| puts "Movie Title : " + e.attributes["title"] 
}

# This will output all the movie types.
xmldoc.elements.each("collection/movie/type") {
   |e| puts "Movie Type : " + e.text 
}

# This will output all the movie description.
xmldoc.elements.each("collection/movie/description") {
   |e| puts "Movie Description : " + e.text 
}

#
#
#
#
#
#modules in Ruby
#
#

#Consider following module written in support.rb file.

module Week
   FIRST_DAY = "Sunday"
   def Week.weeks_in_month
      puts "You have four weeks in a month"
   end
   def Week.weeks_in_year
      puts "You have 52 weeks in a year"
   end
end
#Load Module into class
$LOAD_PATH << '.'
require "support"

class Decade
include Week
   no_of_yrs=10
   def no_of_months
      puts Week::FIRST_DAY
      number=10*12
      puts number
   end
end
d1=Decade.new
puts Week::FIRST_DAY
Week.weeks_in_month
Week.weeks_in_year
d1.no_of_months

#
#
# Date and Time
#
time1 = Time.new
puts "Current Time : " + time1.inspect
# Time.now is a synonym:
time2 = Time.now
puts "Current Time : " + time2.inspect
# Components of a Time
puts "Current Time : " + time.inspect
puts time.year    # => Year of the date 
puts time.month   # => Month of the date (1 to 12)
puts time.day     # => Day of the date (1 to 31 )
puts time.wday    # => 0: Day of week: 0 is Sunday
puts time.yday    # => 365: Day of year
puts time.hour    # => 23: 24-hour clock
puts time.min     # => 59
puts time.sec     # => 59
puts time.usec    # => 999999: microseconds
puts time.zone    # => "UTC": timezone name