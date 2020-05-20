# A Simple Console Output
Write-Output("Hello World - from HelloScript")

# Variable declaration
$name = "helloscript"
Write-Output $name

# String concatenation
$foo = "Foo"
$bar = "Bar"
Write-Output "This is $foo $bar"
Write-Output "This is also $($foo) $($bar)"
Write-Output "This first line`n`tThis is new line with tab"

# If else
$year = 2019
$currentYear = (Get-Date).Year
$reminder = $currentYear % 4
if($reminder -eq 0){
    Write-Output "$currentyear is a Leap Year"
} else {
    Write-Output "$currentyear is not a Leap Year"
}

if($year -gt 2018){
    Write-Output "Welcome to the future - yes, we have flying cars!"
} elseif ($year -lt 2018){
    Write-Output "The past - please don't change anything. Don't step on any butterflies. And for the sake of all thats good and holy, stay away from your parents!"
} else {
    Write-Output "Anything wrong with your time machine? You have not gone anywhere, kiddo."
}

# Range based for loop
# For loop
$range = 1..9
for ($i = 0; $i -lt $range.Count; $i++) {
    Write-Output $i    
}

#Short version
$range | Write-Output

# Converts year to string.
# Write-Output(Get-Date)
# Write-Output((Get-Date).Year)
# Write-Output(Get-Date -Format "dddd MM/dd/yyyy HH:mm K")


# Foreach loop
$names = @('Hello','KMUG')

# Perform iteration 
foreach ($i in $names) {
    Write-Output $i
}

# Loop over 
$process = Get-Process

foreach ($p in $process) {
    Write-Output "Process Name is $($p.Name)."
}

# Get file details
$Path = Get-Location 
Get-ChildItem |
     Select-Object Name, Length, LastWriteTime, Fullname 

# Invoke a web request
(Invoke-WebRequest -Uri "https://k-mug.net/").Links.Href
$req = Invoke-WebRequest "https://k-mug.net/"

$req.StatusCode
$req.Headers

#using inbuilt c# static method
[System.Math]::Sqrt(36)

#using instance 
$obj = New-Object -TypeName System.String("Hello")
$obj.Length 

# Invoke a c# function from ps

$code = @"
    public static class HelloScript
    {
        public static string Hello()
        {
            return "Hello KMUG";
        }
    }
"@

Add-Type $code
[HelloScript]::Hello()

