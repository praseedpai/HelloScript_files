
#---- A Simple Console Output
#---- Equivalent to Printf

print("Hello World\n\n")


#----- str(year)-converts year to string
#----- Demonstrates formatted output

name = "Praseed"
year = 2019
print("Hello, " + name + " - welcome to " + str(year) + "\n")
# or -----   print("Hello %s, - welcome to %s \n" %(name, year))


#----- If,else conditions

if (year > 2018):
	print("Welcome to the future - yes, we have flying cars!\n")
elif(year < 2018):
	print("The past - please don't change anything. Don't step on any butterflies. And for the sake of all thats good and holy, stay away from your parents!\n")
else:
	print("Anything wrong with your time machine? You have not gone anywhere, kiddo.\n")


#----- Range based for loop
#----- For loop

for i in range(0,3):
	print(str(i) + ") Hi there!")
    # or -----   print("%d) Hi there!" %(i))


#----- copying range value to a variable

range_array= range(0,10)
print(range_array)


#----- Array demo
#----- Numerical Array, While

rules = ['Do no harm','Obey','Continue Living']
i = 0
while(i<len(rules)):
	print("Rule " + str(i+1) + " : " + rules[i])
	i = i + 1
print()


#----- Associating array
#----- Associated array, foreach

associated = {
	'hello'	:	'world',
	'foo'	:	'bar',
	'lorem'	:	'ipsum'
}
for key in associated:
	print(key + " : " + associated[key])
print()


#----- Example of a Nested Loop
#----- To calculate Pythagorean Triplets

from math import sqrt
n = int(10)+1
print("-------------------------------------\n")
for a in range(1,n):
    for b in range(a,n):
        c_square = a**2 + b**2
        c = int(sqrt(c_square))
        if ((c_square - c**2) == 0):
            print(a, b, c,"\n")

print("----------------------------------\n")


#----- Iterating over a List using range and len

print("-------------------------------------\n")
fibonacci = [0,1,1,2,3,5,8,13,21]
for i in range(len(fibonacci)):
    print(i,fibonacci[i])
print("-------------------------------------\n")


#----- Parsing a line...

csv_values = str.split("hello,world,how,are,you", ",")
print(csv_values)
print("-------------------------------------\n")
print(":".join(csv_values))

#------ A Single Argument Function
#------
# Function, argument, return, call

def hello(name):
	return "Hello " + name + ". Welcome Back!\n"

hello_str = hello("Praseed")
print(hello_str)

#----- A simple class
# One for the OOP fanboys - Class, members, object and stuff.

class Movie:
    name = ''
    rating = 0
    
    def __init__(self, name):
        self.name = name
        self.rateMovie()

    def rateMovie(self):
        self.rating = (len(self.name) % 10) + 1 #IMDBs rating algorithm. True story!
    
    def printMovieDetails(self):
        print("Movie : ",  self.name)
        print("Rating : ", '*' * self.rating , "(", self.rating ,")\n")
    

#Create the object
ncfom = Movie("New Country for Old Men") #It's a sequel!
ncfom.printMovieDetails()

#--------------------------------------
#---------------------------------------
#---------------------------------------

class Pet(object):

    def __init__(self, name, species):
        self.name = name
        self.species = species

    def getName(self):
        return self.name

    def getSpecies(self):
        return self.species

    def __str__(self):
        return "%s is a %s" % (self.name, self.species)


polly = Pet("Polly", "Parrot")

print(polly.getName())

print(str(polly))


class Dog(Pet):

    def __init__(self, name, chases_cats):
        Pet.__init__(self, name, "Dog")
        self.chases_cats = chases_cats

    def chasesCats(self):
        return self.chases_cats


class Cat(Pet):

    def __init__(self, name, hates_dogs):
        Pet.__init__(self, name, "Cat")
        self.hates_dogs = hates_dogs

    def hatesDogs(self):
        return self.hates_dogs

#-------------------- invocations 
fido = Dog("Fido", True)
rover = Dog("Rover", False)
mittens = Cat("Mittens", True)
fluffy = Cat("Fluffy", False)
print(fido)
print(rover)
print(mittens)
print(fluffy)

print("%s chases cats: %s" % (fido.getName(), fido.chasesCats()))

print("%s chases cats: %s" % (rover.getName(), rover.chasesCats()))

print("%s hates dogs: %s" % (mittens.getName(), mittens.hatesDogs()))

print("%s hates dogs: %s" % (fluffy.getName(), fluffy.hatesDogs()))

#
#
#
#
# List comprehension examples
#
#
myList=[i*i for i in range(10)]

print(myList)

Celsius = [39.2, 36.5, 37.3, 37.8]
Fahrenheit = [ ((float(9)/5)*x + 32) for x in Celsius ]
print(Fahrenheit)

noprimes = [j for i in range(2, 8) for j in range(i*2, 100, i)]
primes = [x for x in range(2, 100) if x not in noprimes]
print(primes)


#
#
# Tuples are immutable

tup1 = (12, 34.56)
tup2 = ('abc', 'xyz')

# Following action is not valid for tuples
# tup1[0] = 100

# So let's create a new tuple as follows
tup3 = tup1 + tup2
print(tup3)

#
#
g = lambda x: x**2
def make_incrementor (n):
    return lambda x: x + n

print(g(8))
r = make_incrementor(10);
print(r(2))

foo = [2, 18, 9, 22, 17, 24, 8, 12, 27]
print(list(filter(lambda x: x % 3 == 0, foo)))
print(list(map(lambda x: x * 2 + 10, foo)))

from functools import reduce
print(reduce(lambda x, y: x + y, foo))


# 
# Deep Copy vs Shallow Copy

print("=================================\n")
print("Shallow Copy\n")

import copy

lst1 = ['a','b',['ab','ba']]

lst2 = copy.copy(lst1) # using copy to shallow copy

lst2[2][1] = "shallow" # changing an element in the copied list

print(lst1) # change reflected in original list
print(lst2) # changed copied list

print("=================================\n")
print("Deep Copy\n")

lst3 = ['c','d',['cd','dc']]

lst4 = copy.deepcopy(lst3) # using deepcopy to deep copy

lst4[2][1] = "deep" # changing an element in the copied list

print(lst3) # change NOT reflected in original list
print(lst4) # changed copied list


#
# File IO
# File reading, easy method...

file_in  = open('Hello.py', 'r')
contents = file_in.read()
print("Current file has " + str(len(contents)) + " chars\n")
file_in.close()


# Writing to a file

file_out = open('hello.txt', 'w')
file_out.write("Hello World")
file_out.close()


#----- Execute the command 'ls' and print its output

import subprocess

print(subprocess.getoutput('dir'))
print("\n")


#
# Regular Expressions
#
import re
hell_check = re.compile("^Hell")
string = "Hello World"

if hell_check.match(string):
    print("Yup - its evil (Compiled)")

if re.match('^Hell', string):
    print("Yup - its evil (Not Compiled)")

print(re.sub(r'l([^l])', r'\1', string))

#----- End of File