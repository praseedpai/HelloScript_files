Imports System
Imports System.IO
Imports System.Linq
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module HelloScript

    Sub Main()

        'A Simple Console Output
        Console.WriteLine("----------------------------------")
        Console.WriteLine("Hello!")
        Console.WriteLine("----------------------------------")


        'Insert the value Of an Object, variable, Or expression
        'into another string using string formatting.
        Console.WriteLine(String.Format("String formatting {0} with {1}", 101, "C#"))
        Console.WriteLine("----------------------------------")


        'Format a string using string interpolation
        Console.WriteLine($"String Interpolation example {101}, with C#{8}")
        Console.WriteLine("----------------------------------")


        'If,else condition
        Dim year As Integer = 2020
        If year > 2009 Then
            Console.WriteLine("You are in india and you have already enrolled for engineering. Game Over!")
        ElseIf (year < 2008) Then
            Console.WriteLine("Stay away from ready made custom advices please!")
        Else
            Console.WriteLine("Anything wrong with your time machine? You have not gone anywhere, kiddo.")
        End If
        Console.WriteLine("----------------------------------")


        'Range based for loop
        Dim idx
        For Each idx In Enumerable.Range(1, 3)
            Console.WriteLine(idx)
        Next
        Console.WriteLine("----------------------------------")


        'Copying range value to a variable
        Dim intList As New List(Of Integer)
        Enumerable.Range(4, 8).ToList().ForEach(Sub(n) intList.Add(n))
        intList.ToList().ForEach(Sub(n) Console.Write(n.ToString() + " "))
        Console.WriteLine()
        Console.WriteLine("----------------------------------")


        'Array demo
        'Numerical Array, While
        Dim rules As String() = {"Do no harm", "Obey", "Continue Living"}
        Dim Index As Integer = 0
        While (Index < rules.Length)
            Console.WriteLine("Rule " & (Index + 1).ToString() & " : " + rules(Index))
            Index += 1
            Console.WriteLine("")
        End While
        Console.WriteLine("----------------------------------")


        'Associated array, foreach
        Dim dictionary As New Dictionary(Of String, String)
        dictionary.Add("hello", "world")
        With dictionary
            .Add("foo", "bar")
            .Add("lorem", "ipsum")
        End With

        For Each element As KeyValuePair(Of String, String) In dictionary
            Console.WriteLine($"{element.Key} : {element.Value}")
        Next
        Console.WriteLine("----------------------------------")


        'Example of a Nested Loop To calculate pythagorean Triplets
        Console.WriteLine("Nested Loop:")
        Dim limit As Integer = 20
        For i As Integer = 1 To limit
            For j As Integer = i To limit Step 1
                For k As Integer = 1 To limit
                    If (i * i) + (j * j) = (k * k) And k <= limit Then
                        Console.WriteLine($"a = {i}, b = {j}, c = {k}")
                    End If
                Next
            Next j
        Next
        Console.WriteLine("----------------------------------")


        'Iterating over a List using range And len
        Dim fibonacci As Integer() = {0, 1, 1, 2, 3, 5, 8, 13, 21}
        Enumerable.Range(0, fibonacci.Length).ToList().ForEach(Sub(n) Console.Write(fibonacci(n).ToString() + " "))
        Console.WriteLine()
        Console.WriteLine("----------------------------------")


        'Split a string using delimiters
        Dim sampleStr As String = "This - is, C#, split. using - delimiters."
        Console.WriteLine($"Splitting string ""{sampleStr}"" into tokens:")

        Dim spearator As String() = {" ", ",", ".", "-"}

        'using the method 
        Dim strlist As String() = sampleStr.Split(spearator, 7, StringSplitOptions.RemoveEmptyEntries)
        For Each s As String In strlist
            Console.WriteLine(s)
        Next
        Console.WriteLine("----------------------------------")


        'A single argument Lambda expression
        Dim hello As Func(Of String, String) = Function(x) "Hello, " + x
        Console.WriteLine(hello("Peter"))
        Console.WriteLine("----------------------------------")


        'Create the object And invoke a method
        Dim Movie = New Movie("New Country for Old Men", New List(Of Double)({8.6, 7, 8.1}))
        Movie.printMovieDetails()
        Console.WriteLine("----------------------------------")


        'Instantiate a Pet object And invoke associated methods
        Dim polly = New Pet("Polly", "Parrot")
        Console.WriteLine(polly.getName())
        Console.WriteLine(polly.getSpecies())
        Console.WriteLine(polly.toString())
        Console.WriteLine("----------------------------------")


        '----------invocations-------------
        Dim fido As Dog = New Dog("Fido", True)
        Dim rover As Dog = New Dog("Rover", False)
        Dim mittens As Cat = New Cat("Mittens", True)
        Dim fluffy As Cat = New Cat("Fluffy", False)

        Console.WriteLine($"{fido.getName()} chases cats: {fido.chasesCats()}")
        Console.WriteLine($"{rover.getName()} chases cats: {rover.chasesCats()}")
        Console.WriteLine($"{mittens.getName()} hates dogs: {mittens.hatesDogs()}")
        Console.WriteLine($"{fluffy.getName()} hates dogs: {fluffy.hatesDogs()}")
        Console.WriteLine("----------------------------------")


        'List comprehension examples
        Dim listExample As List(Of Integer) = New List(Of Integer)
        Enumerable.Range(1, 10).ToList().ForEach(
            Sub(x)
                listExample.Add(x)
            End Sub
        )
        For Each item In listExample
            Console.Write(item.ToString() + " ")
        Next
        Console.WriteLine()
        Console.WriteLine("----------------------------------")

        Dim celsius = New List(Of Double)({39.2F, 36.5F, 37.3F, 37.8F})
        'Linq extension method syntax
        Dim degree = celsius.Select(Function(x) 9 / 5 * x + 32)
        For Each item In degree
            Console.WriteLine(item)
        Next
        Console.WriteLine("----------------------------------")


        ' Tuples are immutable

        Dim tup1 As Tuple(Of Integer, Double) = New Tuple(Of Integer, Double)(12, 34.56)
        Dim tup2 As Tuple(Of String, String) = New Tuple(Of String, String)("abc", "xyz")

        ' Following action Is Not valid For tuples
        ' tup1.Item1 = 100

        ' So Let's create a new tuple as follows
        Dim tup3 = New Tuple(Of String, String)(tup1.Item1.ToString() + tup2.Item1, tup1.Item2.ToString() + tup2.Item2)
        Console.WriteLine(tup3.Item1 + " " + tup3.Item2)
        Console.WriteLine("----------------------------------")


        'Map-filter-reduce
        'using linq query syntax
        Dim foo = New List(Of Integer)({2, 18, 9, 22, 17, 24, 8, 12, 27})
        Dim Filter = From item In foo
                     Where item Mod 3 = 0
                     Select item

        Console.WriteLine("Filtered items:")
        For Each item In Filter
            Console.Write(item.ToString() + " ")
        Next
        Console.WriteLine()
        Console.WriteLine("----------------------------------")

        Dim map = From item In foo
                  Select item * 2 + 10

        Console.WriteLine("Transformed items:")
        For Each item In map
            Console.Write(item.ToString() + " ")
        Next
        Console.WriteLine()
        Console.WriteLine("----------------------------------")
        'Extension method syntax
        Dim reduction = foo.Select(Function(x) x * 2).Sum()
        Console.WriteLine($"Sum of items: {reduction}")
        Console.WriteLine("----------------------------------")


        'Deep Copy vs Shallow Copy
        'Shallow copy
        Dim cinnamon = New Pet("Cinnamon", "Dog")
        Dim ginger As Pet = cinnamon
        ginger.name = "Ginger"
        Console.WriteLine("(Shallow copy)")
        Console.WriteLine("Details of Cinnamon:")
        Console.WriteLine(cinnamon.toString())
        Console.WriteLine("Details of Ginger:")
        Console.WriteLine(ginger.toString())
        Console.WriteLine()

        'Deep copy
        Dim julie = New Pet("Julie", "Cat")
        Dim june As Pet = New Pet(julie.name, julie.species)
        june.name = "June"
        june.species = "Rabbit"
        Console.WriteLine("(Deep copy)")
        Console.WriteLine("Details of Julie:")
        Console.WriteLine(julie.toString())
        Console.WriteLine("Details of June:")
        Console.WriteLine(june.toString())
        Console.WriteLine("----------------------------------")


        'Create New directories in the workspace.
        'Create And write to a New file Or append to an existing one.
        Try
            Dim filePath = Directory.GetCurrentDirectory()
            filePath = Path.Combine(filePath, "myDir")
            Directory.CreateDirectory(filePath)
            filePath = Path.Combine(filePath, "annualreview.txt")

            Dim lines As List(Of String) = New List(Of String)({"1st line", "2nd line", "", "your happy place", "bla bla bla..."})

            If Not File.Exists(filePath) Then
                Using fs As FileStream = File.Create(filePath)
                    Using SW As StreamWriter = New StreamWriter(fs)
                        For Each line In lines
                            SW.WriteLine(line)
                        Next
                        SW.Close()
                    End Using
                    fs.Close()
                End Using
            Else
                Console.WriteLine($"File ""{filePath}"" already exists")
            End If

            Using SR As StreamReader = New StreamReader(filePath)
                Dim line As String = SR.ReadLine()
                While (line IsNot Nothing)
                    Console.WriteLine(line)
                    line = SR.ReadLine()
                End While
            End Using
            Console.WriteLine("----------------------------------")
        Catch e As Exception
            Console.WriteLine("Error...in File IO" + e.ToString())
        End Try

        ' Execute the command 'dir' and print its output

        Dim startInfo = New ProcessStartInfo() With {
            .FileName = "cmd.exe",
            .Arguments = "/C dir",
            .WindowStyle = ProcessWindowStyle.Hidden,
            .CreateNoWindow = True,
            .RedirectStandardOutput = True,
            .UseShellExecute = False
        }

        Dim cmd = Process.Start(startInfo)
        Dim output = cmd.StandardOutput.ReadToEnd()
        cmd.WaitForExit()
        Console.WriteLine(output)
        Console.WriteLine()
        Console.WriteLine("----------------------------------")


        'Regex:

        '((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})

        'Explanation:

        ' (            # Start of group
        ' (?=.*\d)     # must contains one digit from 0-9
        ' (?=.*[a-z])  # must contains one lowercase characters
        ' (?=.*[A-Z])  # must contains one uppercase characters
        ' (?=.*[@#$%]) # must contains one special symbols in the list "@#$%"
        ' .            # match anything with previous condition checking
        ' {6,20}       # length at least 6 characters And maximum of 20
        ' )            # End of group

        Dim Input As String
        Console.WriteLine("Password:")
        Input = Console.ReadLine()

        Dim hasNumber = New Regex("[0-9]+")
        Dim hasUpperChar = New Regex("[A-Z]+")
        Dim hasLowerChar = New Regex("[a-z]+")
        Dim hasSymbols = New Regex("[@!?$%-+]+")
        Dim hasNumberChars = New Regex("^.{6,20}$")

        ' To check the length, regex probably Is a wrong tool,
        ' simple string length check would be more performant.
        Dim isValidated = hasNumber.IsMatch(Input) AndAlso
                            hasUpperChar.IsMatch(Input) AndAlso
                            hasSymbols.IsMatch(Input) AndAlso
                            Input.Length >= 6 AndAlso Input.Length <= 20

        If isValidated Then
            Console.WriteLine("That's a valid Password!")
        Else
            Console.WriteLine("Invalid password! Try again . . .")
        End If
        Console.WriteLine("----------------------------------")


        Console.WriteLine("Press any key to exit")
        Console.ReadLine()

    End Sub

End Module


'A simple class One for the OOP fanboys - Class, members,
'object and stuff.
Class Movie
    Dim name As String = ""
    Dim userRatings As List(Of Double)
    Dim rating As Double = 0

    Public Sub New(name As String, ratings As List(Of Double))
        Me.name = name
        Me.userRatings = ratings
        Me.rateMovie()
    End Sub

    Public Sub printMovieDetails()
        Console.WriteLine($"Movie  : {name}")
        Console.WriteLine($"Rating : {rating}({userRatings.Count})")
    End Sub

    Private Sub rateMovie()
        rating = userRatings.Average()
    End Sub
End Class

'(OOPS) Inheritance, polymorphism etc..
'in C# explained
Class Pet
    Public name As String = ""
    Public species As String = ""

    Public Sub New(name As String, species As String)
        Me.name = name
        Me.species = species
    End Sub

    Public Function getName() As String
        Return name
    End Function

    Public Function getSpecies() As String
        getSpecies = species
    End Function

    Public Overrides Function toString() As String
        Return name + " " + species
    End Function
End Class

'A Dog class inherited from Pet
Class Dog : Inherits Pet
    Public chases_cats As Boolean = False

    Public Sub New(name As String, chases_cats As Boolean)
        MyBase.New(name, "Dog")
        Me.chases_cats = chases_cats
    End Sub

    Public Function chasesCats() As Boolean
        Return chases_cats
    End Function
End Class

'A Cat class inherited from Pet
Class Cat
    Inherits Pet
    Dim hates_dogs As Boolean = False

    Public Sub New(name As String, hates_dogs As Boolean)
        MyBase.New(name, "Cat")
        Me.hates_dogs = hates_dogs
    End Sub

    Public Function hatesDogs() As Boolean
        Return hates_dogs
    End Function
End Class
