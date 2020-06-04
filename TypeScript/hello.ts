// compile the file using command: tsc hello.ts
// run command: node hello.js

import * as  _ from 'lodash'; // Javascript utility library. command: npm i --save lodash
import * as fs from 'fs'; // fs module to access file system. command: npm install -g --save-dev @types/node
 
// A Simple Console Output
// Equivalent to Printf

console.log('Hello World');
console.log("=================================")

// Demonstrates formatted output
// str(nn)-converts nn to string

let userName = 'Praseed';
let year: Number = 2020;
console.log( 'Hello, ' + userName + ' - welcome to ' + year.toString() );
console.log("=================================")

// IF Elif Condition
// If,else conditions

if (year > 2008) {
    console.log('Welcome to the future - yes, we have flying cars!');
} else if(year < 2008) {
	console.log("The past - please don't change anything. Don't step on any butterflies. And for the sake of all thats good and holy, stay away from your parents!");
} else {
    console.log('Anything wrong with your time machine? You have not gone anywhere, kiddo.');
}
console.log("=================================")

// Range based for loop
// For loop

for (let i = 0; i < 3; i++) {
    console.log((i).toString() + ') Hi there!');
}
console.log("=================================")

// No support for copying range value to a variable
console.log("=================================")

let rules = ['Do no harm','Obey','Continue Living'];
let i = 0
while(i < rules.length) {
	console.log('Rule ' + (i+1).toString() + ' : ' + rules[i]);
    i = i + 1;
}
console.log("=================================")

// Associating array
// Associated array, foreach

let associated = {
	'hello'	:	'world',
	'foo'	:	'bar',
	'lorem'	:	'ipsum'
}
for (let key in associated) {
	console.log(key + ' : ' + associated[key]);
}
console.log("=================================")

// Example of a Nested Loop
// To calculate Pythagorean Triplets
function isInt(n) {
    return n % 1 === 0;
 }

let n: Number = 11;
for (let a = 1 ; a <= n; a++) {
    for (let b = a; b <= n; b++) {
       let c_square: number = a*a + b*b;
        let c:number = Math.sqrt(c_square);
        if (isInt(c) && (c_square - c*c) === 0 ) {
            console.log( a, b, c);
        }       
    } 
}


console.log("=================================")

// Iterating over a array using foreach

let fibonacci = [0,1,1,2,3,5,8,13,21]
fibonacci.forEach(( element, i) => {
    console.log( i, element);
});
console.log("=================================")
    
// Parsing a line...
let csv_values = ('hello,world,how,are,you').split(',');

console.log( csv_values );
console.log(_.join(csv_values,':'));
console.log("=================================")

// A Single Argument Function
// Function, argument, return, call

function hello(name) {
    return 'Hello ' + name;
}
    
let hello_str = hello('Praseed');
console.log(hello_str);
console.log("=================================")

// A simple class
// One for the OOP fanboys - Class, members, object and stuff.

class Movie {
	name: string = '';
	rating: Number = 0; 

	 constructor (name: string) {
		this.name = name;
        this.rateMovie();
     }

	 rateMovie() {
        this.rating = ((this.name).length % 10) + 1  // IMDBs rating algorithm. True story!
     }
	
	 printMovieDetails() {
        console.log( 'Movie : '+this.name);
        let result = 'Rating : ';
        for (let i =0; i < this.rating; i++) {
            result += '*';
        }
        result += '('+ this.rating +')';
        console.log(result);
     }
}
        
// Create the object
let ncfom = new Movie('New Country for Old Men') // It's a sequel!
ncfom.printMovieDetails();
console.log("=================================")

// -------------------------------------


class Pet {

    constructor ( public name, public species) {
        this.name = name
        this.species = species
    }

    getName() {
        return this.name
    }

    getSpecies() {
        return this.species
    }

    toString () {
        return `${this.name} is a ${this.species}`;
    }
}


let polly = new Pet("Polly", "Parrot");
console.log( polly.getName());
console.log(polly.toString());


class Dog extends Pet {

    constructor(public name, public chases_cats) {
        super(name, "Dog")
        this.chases_cats = chases_cats
    }

    chasesCats() {
        return this.chases_cats
    }
}

class Cat extends Pet {

    constructor(public name, public hates_dogs) {
        super(name, "Cat")
        this.hates_dogs = hates_dogs
    }

    hatesDogs() {
        return this.hates_dogs
    }
}

// -------------------- invocations 
let fido = new Dog("Fido", true)
let rover = new Dog("Rover", false)
let mittens = new Cat("Mittens", true)
let fluffy = new Cat("Fluffy", false)
console.log(fido.toString());
console.log(rover.toString());
console.log(mittens.toString());
console.log(fluffy.toString());
console.log(`${fido.getName()} chases cats: ${fido.chasesCats()}`)

console.log( `${rover.getName()} chases cats: ${rover.chasesCats()}`)

console.log( `${mittens.getName()} hates dogs: ${mittens.hatesDogs()}`)

console.log( `${fluffy.getName()} hates dogs: ${fluffy.hatesDogs()}`)
console.log("=================================")

// No support for List comprehension examples

// Tuples are mutable

let tup1 = [12, 34.56]
let tup2 = ['abc', 'xyz']
console.log(tup1);
// Following action is  valid for tuples
tup1[0] = 100
console.log(tup1);
// So let's create a new tuple as follows

let tup3 = [...tup1, ...tup2];
console.log(tup3);
console.log("=================================")

// -------------------------------------------------
let g = (x: number) => {
    return x*x;
}
function make_incrementor (n) {
    return  (x: number) => x + n;
}

console.log(g(8));
let r = make_incrementor(10);
console.log(r(2))
console.log("=================================")

// install lodash using command: npm i --save lodash

let foo = [2, 18, 9, 22, 17, 24, 8, 12, 27]
// filter array using lodash
let filterResult = _.filter(foo, function(element){
    return (element % 3) === 0;
})
console.log(filterResult);
// map using lodash
let mapResult = _.map(foo, function(element){
    return element * 2 + 10;
})
console.log(mapResult);
// reduce using lodash
let reduceResult = _.reduce(foo, function(sum, element){
    return sum + element;
})
console.log(reduceResult);
console.log("=================================")

// Deep Copy vs Shallow Copy

console.log("Shallow Copy")

let lst1 = [{id:1,value:'a'},{id:2,value:'b'},{id:3,value:'c'}]
let shallowList = _.clone(lst1); // copy using lodash
_.each(shallowList, function(element){
    element.id += 100;
});
console.log(lst1) // changed reflected in original list
console.log(shallowList) // change reflected in the copied list

console.log("")
console.log("Deep Copy")

let lst2 = [{id:1,value:'a'},{id:2,value:'b'},{id:3,value:'c'}]

let deepList = _.cloneDeep(lst2) // deep copy using lodash
_.each(deepList, function(element){
    element.id += 100;
});
console.log(lst2) // changed not reflected in original list
console.log(deepList) // change reflected in the copied list
console.log("=================================")

// Regular Expressions

let hell_check = new RegExp("^Hell")
let str = "Hello World"

if (hell_check[Symbol.match](str))
    console.log("Yup - its evil (Compiled)")


 console.log(str.replace(/l/gi, '')) // removes character 'l'

// File IO
// File reading and writing, easy method...

// install @types/node module
// command: npm install -g --save-dev @types/node

let res = '';
fs.writeFile('file.txt','Hello World Of Typescript!!', function(err) {
    if(err) {
        console.error(err);
    }
});
fs.readFile('file.txt', function(err, data) {
    res = data.toString();
    console.log(res);
});
console.log("=================================")
  
// ----- End of File

