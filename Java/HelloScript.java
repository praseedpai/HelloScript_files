/**
 * HelloScript.java
 */

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;
import java.util.stream.DoubleStream;
import java.util.stream.IntStream;
import java.util.stream.LongStream;
import java.util.stream.Stream;

/**
 * @author RBz 
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
public class HelloScript {

	/**
	 * @param args
	 * @throws IOException
	 */
	public static void main(String[] args) throws IOException {

		/* A Simple Console Output */
		System.out.println("Hello");

		/*
		 * Demonstrates formatted output, %d placeholder for decimal,
		 * %s-->string, %f-->float, "/n"-->next line
		 */
		System.out.printf("Formatting %s is easy %d %f\n", "with Java", 10,
				98.6);
		/*
		 * String.format returns a formatted string, '-' makes the result left
		 * justified, 32 is the width of the first string
		 */
		System.out.println(String.format("%-32s= %s", "label", "content"));

		/* If,else condition */
		int year = 2016;
		if (year > 2008)
			System.out
					.println("You are in india and you have already enrolled for engineering. Game Over!\n");
		else if (year < 2008)
			System.out
					.println("Stay away from ready made custom advices please!\n");
		else
			System.out
					.println("Anything wrong with your time machine? You have not gone anywhere, kiddo.\n");

		/* Range based for loop */
		IntStream.range(0, 3).forEachOrdered(n -> {
			System.out.println(n + " : Hi there");
		});

		/* copying range value to a variable */
		List<Integer> newArray = new ArrayList<Integer>();
		IntStream.range(0, 3).forEachOrdered(n -> {
			newArray.add(n);
		});
		System.out.println(newArray);

		/* Array demo */
		/* Numerical Array, While */
		String[] rules = { "Do no harm", "Obey", "Continue Living" };
		int i = 0;
		while (i < rules.length) {
			System.out.println("Rule " + Integer.toString(i + 1) + " : "
					+ rules[i]);
			i = i + 1;
			System.out.println("");
		}
		/* Associating array */

		/* Associated array, foreach */
		Map<String, String> map = new HashMap<String, String>();
		map.put("hello", "world");
		map.put("foo", "bar");
		map.put("lorem", "ipsum");
		for (Map.Entry<String, String> entry : map.entrySet()) {
			System.out.println(entry.getKey() + " : " + entry.getValue());
			System.out.println("");
		}
		/*
		 * Example of a Nested Loop To calculate pythagorean Triplets
		 */
		int n = 11;
		System.out.println("-------------------------------------\n");
		IntStream
				.range(0, n)
				.forEach(
						a -> {
							IntStream
									.range(a, n)
									.forEach(
											b -> {
												int cSquare = (int) Math.pow(a,
														2)
														+ (int) Math.pow(b, 2);
												int c = (int) Math
														.sqrt(cSquare);
												if ((cSquare - (c * c)) == 0) {
													System.out
															.printf("a=%d, b=%d, c=%d\n",
																	a, b, c);
													System.out
															.println("-------------------------------------\n");
												}
											});
						});

		/* Iterating over a List using range and len */

		System.out.println("-------------------------------------\n");
		Integer[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13, 21 };
		IntStream.range(0, fibonacci.length).forEachOrdered(t -> {
			System.out.println(t + " : " + fibonacci[t]);
		});

		System.out.println("-------------------------------------\n");

		/* Parsing a line */

		String[] csv_values = "hello*world*how*are*you\n".trim().split("\\*");
		System.out.println(Arrays.toString(csv_values) + "\n");
		System.out.println(String.join(" : ", csv_values));

		/*
		 * A Single Argument Function call
		 */
		System.out.println(hello("Praseed"));

		/*
		 * A simple class One for the OOP fanboys - Class, members, object and
		 * stuff
		 */
		class Movie {
			String name = "";
			int rating = 0;

			public Movie(String name) {
				this.name = name;
				this.rateMovie();
			}

			public void rateMovie() {
				this.rating = (((this.name).length()) % 10) + 1; /*
																 * IMDBs rating
																 * algorithm.
																 * True story!
																 */
			}

			public void printMovieDetails() {
				System.out.println("Movie : " + this.name);
				System.out.println("Rating : " + '*' * this.rating + "("
						+ this.rating + ")\n");
			}
		}

		/* Create the object */
		Movie ncfom = new Movie("New Country for Old Men"); /* It's a sequel! */
		ncfom.printMovieDetails();

		/*--------------------------------------
		---------------------------------------
		---------------------------------------*/
		class Pet {

			String name = "";
			String species = "";

			public Pet(String name, String species) {
				this.name = name;
				this.species = species;
			}

			public String getName() {
				return this.name;
			}

			public String getSpecies() {
				return this.species;
			}

			public String toString() {
				return String.format("%s %s", this.name, this.species);
			}

		}
		Pet polly = new Pet("Polly", "Parrot");
		System.out.println(polly.getName());
		System.out.println(polly.getSpecies());
		System.out.println(polly.toString());

		class Dog extends Pet {
			boolean chases_cats = false;

			public Dog(String name, boolean chases_cats) {
				super(name, "Dog");
				this.chases_cats = chases_cats;
			}

			public boolean chasesCats() {
				return this.chases_cats;
			}
		}

		class Cat extends Pet {
			boolean hates_dogs = false;

			public Cat(String name, boolean hates_dogs) {
				super(name, "Cat");
				this.hates_dogs = hates_dogs;
			}

			public boolean hatesDogs() {
				return this.hates_dogs;
			}

		}

		/*----------invocations-------------*/
		Dog fido = new Dog("Fido", true);
		Dog rover = new Dog("Rover", false);
		Cat mittens = new Cat("Mittens", true);
		Cat fluffy = new Cat("Fluffy", false);

		System.out.println(fido);
		System.out.println(rover);
		System.out.println(mittens);
		System.out.println(fluffy);

		System.out.printf("%s chases cats: %b %s", fido.getName(),
				fido.chasesCats(), "\n");
		System.out.printf("%s chases cats: %s %s", rover.getName(),
				rover.chasesCats(), "\n");
		System.out.printf("%s hates dogs: %s %s", mittens.getName(),
				mittens.hatesDogs(), "\n");
		System.out.printf("%s hates dogs: %s %s", fluffy.getName(),
				fluffy.hatesDogs(), "\n");

		/* List comprehension examples */
		List<Integer> listExample = new ArrayList<Integer>();
		IntStream.range(0, 10).forEachOrdered(l -> {
			listExample.add((int) Math.pow(l, 2));
		});
		System.out.println(listExample);

		double celsius[] = { 39.2f, 36.5f, 37.3f, 37.8f };
		double[] fahrenheit = DoubleStream.of(celsius)
				.map(x -> (float) 9 / 5 * x + 32).toArray();
		System.out.println(Arrays.toString(fahrenheit));

		List<Integer> list = IntStream.range(0, 100).boxed()
				.collect(Collectors.toList());
		List<Integer> primeList = new ArrayList<Integer>();
		List<Integer> nonPrimeList = new ArrayList<Integer>();
		list.stream()
				.filter((u) -> u > 1
						&& LongStream.range(2, u - 1).parallel()
								.noneMatch(e -> (u) % e == 0))
				.forEach((u) -> primeList.add(u));
		list.stream()
				.filter((u) -> u > 1
						&& LongStream.range(2, u - 1).parallel()
								.anyMatch(e -> (u) % e == 0))
				.forEach((u) -> nonPrimeList.add(u));
		System.out.println(primeList + "\n");
		System.out.println(nonPrimeList + "\n");

		/*
		 * Using Comparator Sorting list of pets first by their name, and then
		 * sort again the list by species and print in reversed order
		 */
		List<Pet> pets = new ArrayList<>();
		pets.add(new Pet("Grey Wind", "Direwolve"));
		pets.add(new Pet("Lady", "Direwolve"));
		pets.add(new Pet("Nymeria", "Direwolve"));
		pets.add(new Pet("Summer", "Direwolve"));
		pets.add(new Pet("Shaggydog", "Direwolve"));
		pets.add(new Pet("Ghost", "Direwolve"));
		pets.add(new Pet("Scooby-Doo", "Dog"));
		pets.add(new Pet("Bouncer", "Frog"));
		pets.add(new Pet("Puss-in-Boots", "Cat"));
		pets.add(new Pet("Hachi", "Dog"));

		Comparator<Pet> groupByComparator = Comparator.comparing(Pet::getName)
				.thenComparing(Pet::getSpecies);
		pets.sort(groupByComparator.reversed());

		System.out.println(pets);

		/* A collection of value of pairs ( tuples ? ) */
		java.util.Map.Entry<Integer, Float> pair1 = new java.util.AbstractMap.SimpleEntry<>(
				12, 34.56f);
		java.util.Map.Entry<String, String> pair2 = new java.util.AbstractMap.SimpleEntry<>(
				"abc", "xyz");
		System.out.println(pair1);
		System.out.println(pair2);

		/*
		 * If you need an expandable list, pass Arrays.asList to the ArrayList
		 * constructor and vice versa
		 */
		List<Double> expandableDoubleList = new ArrayList<>(Arrays.asList(1.38,
				2.56, 4.3, 9.0, 14.3, 15.0));
		expandableDoubleList.add(22d);

		/*
		 * Obtaining a stream from a collection(which is concrete) and following
		 * the pipeline pattern Stream configuring using filter( which preserves
		 * the type and may change the count) or map (which preserves the count
		 * and may change type) or .. Stream processing using collect or reduce
		 * or..
		 */
		List<Double> result = expandableDoubleList.stream()
				.filter(item -> item % 3 == 0).collect(Collectors.toList());
		System.out.println(result);

		List<Double> anotherResult = result.stream().map(m -> m * 3)
				.collect(Collectors.toList());
		System.out.println(anotherResult);
		result.stream().map(m -> m * 3).collect(Collectors.toList())
				.forEach(System.out::println);

		List<Integer> numbers = Arrays.asList(new Integer[] { 1, 2, 3, 4, 5 });
		Optional<Integer> sum = numbers.stream().reduce((a, b) -> a + b);
		System.out.println(sum.get());

		/*
		 * Create new directories in the workspace. And Create and write to a
		 * new file or append to an existing one.
		 */
		createNewOrAppendToFile();

		/*
		 * Read content of the file line by line and check if any line contains
		 * word "password" then print it.
		 */
		readStreamOfLinesUsingFilesWithTryBlock();

		/*
		 * Regex in java. Validating the password using Regex
		 */
		System.out.println(aPasswordValidator());
		

	}

	/*
	 * A Single Argument FunctionFunction, argument, return
	 */

	public static String hello(String name) {
		return String.format("%s %s %s", "Hello", name, "\n");
	}

	private static void createNewOrAppendToFile() throws IOException {
		Path newDirectoryPath = Paths.get("./my/directory");
		Files.createDirectories(newDirectoryPath);
		List<String> lines = Arrays.asList("1st line", "2nd line", "",
				"yourhappyplace", "bla bla bla");
		Files.write(Paths.get(newDirectoryPath + "/yearendreview.txt"), lines,
				StandardCharsets.UTF_8, StandardOpenOption.CREATE,
				StandardOpenOption.APPEND);
	}

	/*
	 * This read the lines as streams and use use try-with-resources which will
	 * eliminate the need of closing the stream and checks if the underlying
	 * file is closed or not
	 */
	private static void readStreamOfLinesUsingFilesWithTryBlock()
			throws IOException {
		Path path = Paths.get("./my/directory/", "yearendreview.txt");
		// When filteredLines is closed, it closes underlying stream as well as
		// underlying file.
		try (Stream<String> filteredLines = Files.lines(path)
				.onClose(() -> System.out.println("File closed"))
				.filter(s -> s.contains("happy"))) {
			Optional<String> hasPassword = filteredLines.findFirst();
			if (hasPassword.isPresent()) {
				System.out.println(hasPassword.get());
			}
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
	public static String aPasswordValidator() throws IOException {
		System.out.printf("Please choose a password (In correct format) :: ");
		BufferedReader bufferRead = new BufferedReader(new InputStreamReader(
				System.in));
		String yourPassword = bufferRead.readLine();

		final String PASSWORD_PATTERN = "((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})";
		Pattern pattern;
		Matcher matcher;
		pattern = Pattern.compile(PASSWORD_PATTERN);
		matcher = pattern.matcher(yourPassword);
		return matcher.matches() ? "Valid!!!" : aPasswordValidator();

	}

}
