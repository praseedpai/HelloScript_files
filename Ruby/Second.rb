
require "java"
# Define method factorial 
   def factorial(n)
  if n == 0
   1
   else
  n * factorial(n-1)
   end
  end
# Printing factorial of 5 
puts factorial(5).to_i